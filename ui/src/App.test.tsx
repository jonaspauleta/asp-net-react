import { render, screen } from "@testing-library/react";
import App from "./App";

test("renders learn react link", () => {
  render(<App />);
  const linkElement = screen.getByText(/To Do/i);
  expect(linkElement).toBeInTheDocument();
});


//I have never used unit tests in the frontend before, I've searched for it but didn't understood it clearly, I will for sure take a look at Jest later on.