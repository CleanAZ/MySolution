export const login = async (email: string, password: string) => {
  const res = await fetch("http://localhost:5138/api/Auth/login", {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify({ email, password }),
  });
  const data = await res.json();
  localStorage.setItem("token", data.token);

  return data;
};

export const logout = () => {
  localStorage.removeItem("token");
};
