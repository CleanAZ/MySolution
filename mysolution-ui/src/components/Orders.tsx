import { useQuery } from "@tanstack/react-query";
import { getOrders } from "../services/orderService";

export default function Orders() {
  const { data: orders, isLoading } = useQuery({
    queryKey: ["orders"],
    queryFn: getOrders,
  });

  if (isLoading) return <p>Loading...</p>;

  return (
    <div className="max-w-lg mx-auto mt-10">
      <h2 className="text-2xl font-bold mb-4">Orders</h2>
      {orders?.map((o) => (
        <div
          key={o.id}
          className="border rounded-lg p-1 mb-2 shadow-sm hover:shadow-md transition"
        >
          <p className="text-gray-500 text-[12px]">
            {new Date(o.orderDate).toLocaleDateString()} - {o.id}
            {o.description} - Total: {o.total}
          </p>
        </div>
      ))}
    </div>
  );
}
