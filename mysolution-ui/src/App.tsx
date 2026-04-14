import "./App.css";
import { QueryClient, QueryClientProvider } from "@tanstack/react-query";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import OrderPage from "./pages/orders/OrderPage";
import ClientPage from "./pages/clients/ClientsPage";
import Navbar from "./components/Navbar";
import LoginPage from "./pages/login/loginPage";
const queryClient = new QueryClient();

function App() {
  return (
    <QueryClientProvider client={queryClient}>
      <BrowserRouter>
        <Navbar></Navbar>
        <div className="layout">
          <Routes>
            <Route path="/orders" element={<OrderPage></OrderPage>}></Route>
            <Route path="/clients" element={<ClientPage></ClientPage>}></Route>
            <Route path="/login" element={<LoginPage></LoginPage>}></Route>
          </Routes>
        </div>
      </BrowserRouter>
    </QueryClientProvider>
  );
}

export default App;
