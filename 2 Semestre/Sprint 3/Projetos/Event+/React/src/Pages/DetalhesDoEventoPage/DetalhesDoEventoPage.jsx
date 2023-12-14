import React, { useContext, useEffect, useState } from "react";
import "./DetalhesDoEventoPage.css";
import Title from "../../Components/Title/Title";
import { useParams } from "react-router-dom";
import api from "../../Services/Services";
import Table from "./TableDe/TableDe";
import MainContent from "../../Components/MainContent/MainContent";
import { Container } from "react-bootstrap";
import TableCe from "./TableCe/TableCe";
import { UserContext } from "../../context/AuthContext";

const DetalhesDoEventoPage = () => {
  let { id } = useParams();
  const [evento, setEvento] = useState({});
  const [comentarios, setComentarios] = useState([]);
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
        // console.log("error");
      }
      // setShowSpinner(false);
    }

    async function getComentarios() {
      try {
        const promise = await api.get("/ComentariosEvento");
        const found = promise.data.filter((Element) => Element.exibe === true);
        setComentarios(found);
      } catch (error) {
        // console.log("error");
      }
    }

    getEvento();
    getComentarios();
  }, [id, comentarios]);
  return (
    <MainContent>
      <Container>
        <Title titleText={"Detalhes do evento"} />
        <Table dado={evento} titulo={titulo} nF={nF} />
      </Container>

      <section className="lista-comentarios-section">
        <Container>
          <Title titleText={"Comentários"} color="white" />
          <div className="lista-comentarios-container">
            <TableCe comentarios={comentarios} />
          </div>
        </Container>
      </section>
    </MainContent>
  );
};

export default DetalhesDoEventoPage;
