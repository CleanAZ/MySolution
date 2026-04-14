import axios from "axios";
import type { Order } from "../Models/Order";

const API_URL = "http://localhost:5138/api/orders";

export const getOrders = async (): Promise<Order[]> => {
  const token = localStorage.getItem("token");
  console.log(token);
  if (!token) {
    throw new Error("No token found");
  }
  const response = await axios.get<Order[]>(API_URL, {
    headers: { Authorization: `Bearer ${token}` },
  });
  console.log(response.data);
  return response.data;
};

export const createOrder = async (or: Order): Promise<Order> => {
  const response = await axios.post(API_URL, or);
  return response.data;
};

export const getOrderById = async (id: string) => {
  const response = await axios.get<Order>(`${API_URL}/${id}`);
  console.log(response.data);
  return response.data;
};
