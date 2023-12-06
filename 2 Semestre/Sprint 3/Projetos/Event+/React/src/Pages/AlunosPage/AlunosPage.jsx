import React, { useContext, useEffect, useState } from "react";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Title/Title";
import Table from "./TableEva/TableEvA.jsx";
import Container from "../../Components/Container/Container";
import { Select } from "../../Components/FormComponents/FormComponents.jsx";
import Spinner from "../../Components/Spinner/Spinner";
import Modal from "../../Components/Modal/Modal";
import api from "../../Services/Services";

import "./AlunosPage.css";
import { UserContext } from "../../context/AuthContext";

const EventosAlunoPage = () => {
  // state do menu mobile
  const { userData, setUserData } = useContext(UserContext);
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [eventos, setEventos] = useState([]);
  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: "1", text: "Todos os eventos" },
    { value: "2", text: "Meus eventos" },
  ]);

  const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);

  // recupera os dados globais do usuário

  async function loadEventsType() {
    try {
      if (tipoEvento === "2") {
        let arrEventos = [];
        const promise = await api.get(
          `/PresencasEvento/ListarMinhas/${userData.userId}`
        );
        promise.data.forEach((Element) => {
          arrEventos.push(Element.evento);
        });
        setEventos(arrEventos);
      } else {
        const promise = await api.get("/Evento");
        setEventos(promise.data);
        console.log(promise.data)
        const promiseEventos = await api.get(
          `/PresencasEvento/ListarMinhas/${userData.userId}`
        );
        console.log(promiseEventos.data)
  
        const dadosMarcados = verificaPresenca(promise.data, promiseEventos.data);
        console.log("Dados marcados:"+ dadosMarcados);
      }
    } catch (error) {
      console.log(error)
    }
  }

  useEffect(() => {
    loadEventsType();
  }, [tipoEvento, userData.userId]);

  const verificaPresenca = (arrAllEvents, eventsUser) => {
    for (let x = 0; x < arrAllEvents.length; x++) {
      for (let i = 0; i < eventsUser.length; i++) {
        if (arrAllEvents[x].idEvento === eventsUser[i].idEvento) {
          arrAllEvents[x].situacao = true;
          break;
        }
      }
    }
  };

  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    loadEventsType(userData.userId);
    setTipoEvento(tpEvent);
  }

  async function loadMyComentary(idComentary) {
    return "????";
  }

  const showHideModal = () => {
    setShowModal(showModal ? false : true);
  };

  const commentaryRemove = () => {
    alert("Remover o comentário");
  };

  function handleConnect() {
    alert("Desenvolver a função conectar evento");
  }

  return (
    <>
      <MainContent>
        <Container>
          <Title titleText={"Eventos"} aditionalClass="custom-title" />

          <Select
            id="id-tipo-evento"
            name="tipo-evento"
            required={true}
            dados={quaisEventos}
            manipulationFunction={(e) => myEvents(e.target.value)} // aqui só a variável state
            defaultText="Selecione"
            defaultValue="1"
            aditionalClass="select-tp-evento"
            titleKey="text"
            idKey="value"
          />
          <Table
            dados={eventos}
            fnConnect={handleConnect}
            fnShowModal={() => {
              showHideModal();
            }}
          />
        </Container>
      </MainContent>

      {/* SPINNER -Feito com position */}
      {showSpinner ? <Spinner /> : null}

      {showModal ? (
        <Modal
          userId={userData.userId}
          showHideModal={showHideModal}
          fnDelete={commentaryRemove}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
