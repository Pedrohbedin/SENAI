import React, { useEffect, useState } from "react";
import "./DetalhesDoEventoPage.css";
import Title from "../../Components/Title/Title";
import { useParams } from "react-router-dom";
import api from "../../Services/Services";
import Table from "./TableDe/TableDe";
import MainContent from "../../Components/MainContent/MainContent";
import { Container } from "react-bootstrap";

const DetalhesDoEventoPage = () => {
  let { id } = useParams();
  const [evento, setEvento] = useState({});
  const [titulo, setTitulo] = useState("");
  const [nF, setNF] = useState("");

  useEffect(() => {
    async function getEvento() {
      // setShowSpinner(true);
      try {
        const promise = await api.get(`/Evento`);
        const found = promise.data.find((Element) => Element.idEvento === id);
        setTitulo(found.tiposEvento.titulo);
        setNF(found.instituicao.nomeFantasia);
        setEvento(found);
      } catch (error) {
        console.log("error");
      }
      // setShowSpinner(false);
    }
    getEvento();
  }, [id]);
  return (
    <MainContent>
      <Container>
        <Title titleText={"Detalhes do evento"} />
        <Table dado={evento} titulo={titulo} nF={nF} />
      </Container>

      <div className="comentarios">
        <Container>
          <h1>Oi</h1>
        </Container>
      </div>
    </MainContent>
  );
};

export default DetalhesDoEventoPage;
