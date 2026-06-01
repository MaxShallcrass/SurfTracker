import React from 'react';
import { IonApp, IonRouterOutlet, IonSpinner, setupIonicReact } from '@ionic/react';
import { IonReactRouter } from '@ionic/react-router';
import { Redirect, Route } from 'react-router-dom';

import Home from './pages/Home';
import Login from './pages/Login';
import AppMenu from './components/AppMenu';
import { AuthProvider, useAuth } from './context/AuthContext';

import '@ionic/react/css/core.css';
import '@ionic/react/css/normalize.css';
import '@ionic/react/css/structure.css';
import '@ionic/react/css/typography.css';
import './theme/variables.css';

setupIonicReact();

// Shows a loading spinner while the session is being restored from storage,
// then either the Authenticator (unauthenticated) or the app router (authenticated).
function AppContent() {
  const { isAuthenticated, isLoading } = useAuth();

  if (isLoading) {
    return (
      <div style={{ display: 'flex', justifyContent: 'center', alignItems: 'center', height: '100vh' }}>
        <IonSpinner name="crescent" />
      </div>
    );
  }

  if (!isAuthenticated) {
    return <Login />;
  }

  return (
    <IonReactRouter>
      <AppMenu />
      <IonRouterOutlet id="main-content">
        <Route path="/home" component={Home} exact />
        <Redirect exact from="/" to="/home" />
      </IonRouterOutlet>
    </IonReactRouter>
  );
}

const App: React.FC = () => (
  <IonApp>
    <AuthProvider>
      <AppContent />
    </AuthProvider>
  </IonApp>
);

export default App;
