import React, { useState } from "react";
import type { Order } from "../Models/Order";
import { createOrder } from "../services/orderService";
import { useMutation, useQueryClient } from "@tanstack/react-query";

export default function CreateOrder() {
  const queryClient = useQueryClient();

  const mutation = useMutation({
    mutationFn: createOrder,

    onSuccess: async () => {
      setTotal(0);
      setDescription("");
      queryClient.invalidateQueries({
        queryKey: ["orders"],
      });
    },
  });

  const [total, setTotal] = useState<number>(0);
  const [description, setDescription] = useState<string>("");
  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    const neworder: Order = {
      id: "3fa85f64-5717-4562-b3fc-2c963f66afa6",
      total: total,
      description: description,
      orderDate: new Date(),
    };
    console.log(neworder);
    mutation.mutate(neworder);
  };

  return (
    <form onSubmit={handleSubmit}>
      <h2>Create Order</h2>

      <input
        type="number"
        value={total}
        onChange={(e) => setTotal(Number(e.target.value))}
        placeholder="Total"
      />
      <br></br>
      <input
        type="string"
        value={description}
        onChange={(e) => setDescription(String(e.target.value))}
        placeholder="Description"
      />
      <br></br>
      <button type="submit">Create</button>
    </form>
  );
}
