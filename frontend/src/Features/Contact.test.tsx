import React from 'react'
import { render, screen } from '@testing-library/react';
import { Contacts } from './Contacts';


test("Renders Contact component", () => {
  render(<Contacts />);
  const contactElement = screen.getByText(/Contact/i);
  expect(contactElement).toBeInTheDocument();
});
// Write a test to check if the Contact component renders
// Write a test to check if the Contact component renders the name of the contact
