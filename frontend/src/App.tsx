import React from 'react';
import './App.css';
import { Contacts } from './Features/Contacts';

function App() {
  // await getContacts() inside useEffect() to fetch contacts from the backend
  return (
    <div>
      <h1>Contacts</h1>
      <Contacts />
    </div>
  );
}

export default App;
