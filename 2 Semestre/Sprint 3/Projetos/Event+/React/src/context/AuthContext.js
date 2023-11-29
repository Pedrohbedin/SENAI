import { jwtDecode } from "jwt-decode";
import { createContext } from "react";

export const UserContext = createContext(null);

export const userDecodeToken = (theToken) => {
  const decoded = jwtDecode(theToken);
  return {
    role: decoded,
    nome: decoded.name,
    userId: decoded.jti,
    token: theToken,
  };
};
