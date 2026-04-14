import axios from "axios";
import type { Client } from "../Models/Client";

const API_URL = "http://localhost:5138/api/clients";

export const getAllClients = async (): Promise<Client[]> => {
  const clients = await axios.get<Client[]>(API_URL);
  return clients.data;
};
