import React from 'react';
import {
  IonPage,
  IonHeader,
  IonToolbar,
  IonTitle,
  IonContent,
  IonButtons,
  IonMenuButton,
} from '@ionic/react';

const Home: React.FC = () => (
  <IonPage>
    <IonHeader>
      <IonToolbar>
        <IonButtons slot="start">
          <IonMenuButton autoHide={false} />
        </IonButtons>
        <IonTitle>Home</IonTitle>
      </IonToolbar>
    </IonHeader>
    <IonContent>
      <p style={{ padding: '24px', color: 'var(--text-muted)', textAlign: 'center' }}>
        Home page — coming soon.
      </p>
    </IonContent>
  </IonPage>
);

export default Home;
