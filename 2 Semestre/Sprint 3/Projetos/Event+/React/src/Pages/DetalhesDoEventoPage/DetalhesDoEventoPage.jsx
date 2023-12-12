import React from "react";
import "./DetalhesDoEventoPage.css";
import Title from "../../Components/Title/Title";

const DetalhesDoEventoPage = ({ idEvento }) => {
  return (
    <div>
      <Title titleText={"Lista de Eventos"} />
      <h1>O id do evento é {idEvento}</h1>
    </div>
  );
};

export default DetalhesDoEventoPage;
