import { useQuery } from "@tanstack/react-query";
import { getAllClients } from "../services/clientService";

export default function Clients() {
  const { data: clients, isLoading } = useQuery({
    queryKey: ["clients"],
    queryFn: getAllClients,
  });
  if (isLoading) return <p>Loading...</p>;
  return (
    <div>
      {clients?.map((o) => (
        <div>
          ({o.clientId}){o.name}--{new Date(o.dateSub).toLocaleDateString()}
        </div>
      ))}
    </div>
  );
}
