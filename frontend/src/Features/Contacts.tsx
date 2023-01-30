import React, { useState, useEffect } from "react";
import { Contact } from "../Interfaces/Contact";
import { getContacts } from "../Services/Api";

// Create Contacts component that renders a list of contacts from the API using the getContacts from the Api.ts file
export const Contacts = () => {
  const [contacts, setContacts] = useState<Contact[]>([]);

  // call  getContacts function from the Api.ts file with async await inside a useEffect
  useEffect(() => {
    const fetchContacts = async () => {
      const contacts = await getContacts();
      setContacts(contacts);
    };
    fetchContacts();
  }, []);

  return (
    <div>
      <h1>Contact List</h1>
      <ul>
        {contacts.map((contact) => (
          <div key={contact.id}>
            <li>{contact.firstName}</li>
            <li>{contact.lastName}</li>
            <li>{contact.email}</li>
            <li>{contact.billingAddress}</li>
            <li>{contact.deliveryAddress}</li>
          </div>
        ))}
      </ul>
    </div>
  );
};
