import React, { createContext, useContext, useEffect, useState, ReactNode } from 'react';
import { Hub } from 'aws-amplify/utils';
import { signOut, getIdToken, createBackendUser } from '../services/authService';

interface AuthState {
  idToken: string | null;
  isAuthenticated: boolean;
  isLoading: boolean;
}

interface AuthContextValue extends AuthState {
  logout: () => Promise<void>;
}

const AuthContext = createContext<AuthContextValue | null>(null);

export function AuthProvider({ children }: { children: ReactNode }) {
  const [state, setState] = useState<AuthState>({
    idToken: null,
    isAuthenticated: false,
    isLoading: true,
  });

  useEffect(() => {
    // Restore auth state from Amplify's stored session on app load.
    // Amplify handles token refresh automatically via fetchAuthSession.
    getIdToken()
      .then((token) =>
        setState((s) => ({
          ...s,
          idToken: token,
          isAuthenticated: !!token,
          isLoading: false,
        }))
      )
      .catch(() => setState((s) => ({ ...s, isLoading: false })));

    // Listen for sign-in / sign-out events fired by the Amplify Authenticator.
    const unsubscribe = Hub.listen('auth', async ({ payload }) => {
      if (payload.event === 'signedIn') {
        const token = await getIdToken();
        if (token) {
          // Best-effort backend user creation — 409 (already exists) is handled in the service.
          createBackendUser(token).catch(() => {});
          setState((s) => ({ ...s, idToken: token, isAuthenticated: true, isLoading: false }));
        }
      } else if (payload.event === 'signedOut') {
        setState((s) => ({ ...s, idToken: null, isAuthenticated: false, isLoading: false }));
      }
    });

    return () => unsubscribe();
  }, []);

  async function logout(): Promise<void> {
    await signOut();
    // Hub 'signedOut' will also update state, but set immediately for responsiveness.
    setState((s) => ({ ...s, idToken: null, isAuthenticated: false }));
  }

  return (
    <AuthContext.Provider value={{ ...state, logout }}>
      {children}
    </AuthContext.Provider>
  );
}

export function useAuth(): AuthContextValue {
  const ctx = useContext(AuthContext);
  if (!ctx) throw new Error('useAuth must be used inside AuthProvider');
  return ctx;
}
