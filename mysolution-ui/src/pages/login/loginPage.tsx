import { useState } from "react";
import { login } from "../../services/authService";

export default function LoginPage() {
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");

  const handleLogin = async () => {
    const token = await login(email, password);
    console.log("token", token);
  };

  return (
    <div>
      <input placeholder="email" onChange={(e) => setEmail(e.target.value)} />
      <br></br>
      <input
        placeholder="password"
        onChange={(e) => {
          setPassword(e.target.value);
        }}
      />
      <br></br>
      <button onClick={handleLogin}>Login</button>
    </div>
  );
}
