import React from "react";
import { BrowserRouter, Routes, Route } from "react-router-dom";
import EventosPage from "../Pages/EventosPage/EventosPage";
import HomePage from "../Pages/HomePage/HomePage";
import LoginPage from "../Pages/LoginPage/LoginPage";
import TipoEventosPage from "../Pages/TipoEventosPages/TipoEventosPage";
import Header from "../Components/Header/Header";
import Footer from "../Components/Footer/Footer";

const Rotas = () => {
  return (
    <BrowserRouter>
      <Header />
      <Routes>
        <Route element={<HomePage />} path="/" exact />
        <Route element={<TipoEventosPage />} path="/tipo-eventos" />
        <Route element={<EventosPage />} path="/eventos" />
        <Route element={<LoginPage />} path="/login" />
      </Routes>
      <Footer />
    </BrowserRouter>
  );
};

export default Rotas;
