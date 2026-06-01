import React from 'react';
import {
  IonMenu,
  IonHeader,
  IonToolbar,
  IonTitle,
  IonContent,
  IonFooter,
  IonList,
  IonItem,
  IonLabel,
  IonButton,
  IonIcon,
} from '@ionic/react';
import { logOutOutline } from 'ionicons/icons';
import { useAuth } from '../context/AuthContext';

const AppMenu: React.FC = () => {
  const { logout } = useAuth();

  return (
    <IonMenu contentId="main-content" side="start">
      <IonHeader>
        <IonToolbar>
          <IonTitle>Surf Tracker</IonTitle>
        </IonToolbar>
      </IonHeader>
      <IonContent>
        <IonList lines="none">
          <IonItem routerLink="/home" routerDirection="none" button detail={false}>
            <IonLabel>Home</IonLabel>
          </IonItem>
        </IonList>
      </IonContent>
      <IonFooter>
        <IonToolbar>
          <IonButton expand="block" fill="clear" color="danger" onClick={logout}>
            <IonIcon slot="start" icon={logOutOutline} />
            Sign Out
          </IonButton>
        </IonToolbar>
      </IonFooter>
    </IonMenu>
  );
};

export default AppMenu;
