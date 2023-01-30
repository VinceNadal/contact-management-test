import axios from "axios";
import { Contact } from "../Interfaces/Contact";

// Axios API Call
export const api = axios.create({
  baseURL: "https://localhost:7239/api",
});

// Get all contacts asynchronously from the API
export const getContacts = async (): Promise<Contact[]> => {
  const response = await api.get("/contacts");
  return response.data;
};

// Get contact by id asynchronously from the API
export const getContact = async (id: number) => {
  const response = await api.get(`/contacts/${id}`);
  return response.data;
};

// Create contact asynchronously
export const createContact = async (contact: Contact) => {
  const response = await api.post("/contacts", contact);
  return response.data;
};

// Update contact asynchronously
export const updateContact = async (contact: Contact) => {
  const response = await api.put(`/contacts/${contact.id}`, contact);
  return response.data;
};

// Delete contact asynchronously
export const deleteContact = async (id: number) => {
  const response = await api.delete(`/contacts/${id}`);
  return response.data;
};
