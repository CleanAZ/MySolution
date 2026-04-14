import { Link, useNavigate } from "react-router-dom";
import { logout } from "../services/authService";

export default function Navbar() {
  const navigate = useNavigate();
  const handleLogOut = () => {
    logout();
    navigate("/login");
  };
  return (
    <div className="navbar">
      <div className="navbar_links">
        <Link to="/">Home</Link>
        <Link to="/login">Login</Link>
        <Link onClick={handleLogOut} to="/">
          LogOut
        </Link>
        <Link to="/orders">Orders</Link>
        <Link to="/clients">Clients</Link>
      </div>
    </div>
  );
}
