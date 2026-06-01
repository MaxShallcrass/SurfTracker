import {
  signOut as amplifySignOut,
  fetchAuthSession,
} from 'aws-amplify/auth';

export interface AuthTokens {
  idToken: string;
}

export async function signOut(): Promise<void> {
  await amplifySignOut();
}

// Used by AuthContext on app load to restore auth state from Amplify's stored session.
// Returns null if no valid session exists.
export async function getIdToken(): Promise<string | null> {
  try {
    const session = await fetchAuthSession();
    return session.tokens?.idToken?.toString() ?? null;
  } catch {
    return null;
  }
}

export async function createBackendUser(idToken: string): Promise<void> {
  const response = await fetch(`${import.meta.env.VITE_API_BASE_URL}/api/users`, {
    method: 'POST',
    headers: { Authorization: `Bearer ${idToken}` },
  });
  // 409 means user already exists in DB — not an error during registration
  if (!response.ok && response.status !== 409) {
    throw new Error('Failed to register user profile.');
  }
}
