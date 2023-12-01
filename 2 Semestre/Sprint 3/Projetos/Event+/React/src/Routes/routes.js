import React from "react";

import EventosPage from "../Pages/EventosPage/EventosPage";
import HomePage from "../Pages/HomePage/HomePage";
import LoginPage from "../Pages/LoginPage/LoginPage";
import TipoEventosPage from "../Pages/TipoEventosPages/TipoEventosPage";

import Header from "../Components/Header/Header";
import { PrivateRoute } from "./PrivateRoutes";
import Footer from "../Components/Footer/Footer";
import { BrowserRouter, Routes, Route } from "react-router-dom";

const Rotas = () => {
  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route element={<HomePage />} path="/" exact />
        <Route
          element={
            <PrivateRoute redirectTo="/">
              <TipoEventosPage />
            </PrivateRoute>
          }
          path="/tipo-eventos"
        />
        <Route element={<EventosPage />} path="/eventos-alunos" />
        <Route
          element={
            <PrivateRoute redirectTo="/">
              <EventosPage />
            </PrivateRoute>
          }
          path="/eventos"
        />
        <Route element={<LoginPage />} path="/login" />
      </Routes>
      <Footer />
    </BrowserRouter>
  );
};

export default Rotas;
