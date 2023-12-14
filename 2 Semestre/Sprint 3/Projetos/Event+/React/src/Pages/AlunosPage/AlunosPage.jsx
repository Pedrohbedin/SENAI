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
import Notification from "../../Components/Notification/Notification.js";

const EventosAlunoPage = () => {
  // state do menu mobile
  const [notifyUser, setNotifyUser] = useState({});
  const { userData, setUserData } = useContext(UserContext);
  const [exibeNavbar, setExibeNavbar] = useState(false);
  const [eventos, setEventos] = useState([]);

  // select mocado
  const [quaisEventos, setQuaisEventos] = useState([
    { value: "1", text: "Todos os eventos" },
    { value: "2", text: "Meus eventos" },
  ]);

  //Comentarios
  const [descricao, setDescricao] = useState();
  const [exibe, setExibe] = useState();
  const [idUsuario, setIdUsuario] = useState();
  const [idEvento, setIdEvento] = useState();

  const [tipoEvento, setTipoEvento] = useState("1"); //código do tipo do Evento escolhido
  const [showSpinner, setShowSpinner] = useState(false);
  const [showModal, setShowModal] = useState(false);

  // recupera os dados globais do usuário

  useEffect(() => {
    loadEventsType();
    console.log(tipoEvento);
  }, [tipoEvento, userData.userId]);

  async function loadEventsType() {
    setShowSpinner(true);
    try {
      if (tipoEvento === "1") {
        const retornoEventos = await api.get("/Evento");
        const retorno = await api.get(
          `/PresencasEvento/ListarMinhas/${userData.userId}`
        );

        const dadosMarcados = verificaPresenca(
          retornoEventos.data,
          retorno.data
        );
        console.log(dadosMarcados);
        setEventos(dadosMarcados);
      } else if (tipoEvento === "2") {
        const arrEventos = [];

        const retorno = await api.get(
          `/PresencasEvento/ListarMinhas/${userData.userId}`
        );

        retorno.data.forEach((element) => {
          arrEventos.push({
            ...element.evento,
            situacao: element.situacao,
            idPresencaEvento: element.idPresencaEvento,
          });
        });
        setEventos(arrEventos);
      }
    } catch (error) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: `Erro ao desconectar!`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    }
    setShowSpinner(false);
  }

  const verificaPresenca = (arrAllEvents, eventsUser) => {
    for (let x = 0; x < arrAllEvents.length; x++) {
      for (let i = 0; i < eventsUser.length; i++) {
        if (arrAllEvents[x].idEvento === eventsUser[i].idEvento) {
          arrAllEvents[x].situacao = true;
          arrAllEvents[x].idPresencaEvento = eventsUser[i].idPresencaEvento;
          break;
        }
      }
    }

    return arrAllEvents;
  };

  // toggle meus eventos ou todos os eventos
  function myEvents(tpEvent) {
    setTipoEvento(tpEvent);
  }

  const showHideModal = () => {
    setShowModal(showModal ? false : true);
  };

  async function loadMyComentary() {
    try {
      const promise = await api.get(`/ComentariosEvento/BuscarPorIdUsuario/${userData.userId}/${idEvento}`)
      console.log("Showing result")
      console.log(promise.data)
    
    } catch (error) {}
  }

  async function postMyCOmentary() {
    try {
      await api.post("/ComentariosEvento", {
        descricao: descricao,
      });
    } catch (error) {}
  }

  const commentaryRemove = async () => {
    alert("Remover o comentário");
  };

  async function handleConnect(
    idEvent,
    connect = false,
    idPresencaEvento = null
  ) {
    if (!connect) {
      try {
        const promise = await api.post("/PresencasEvento", {
          situacao: true,
          idUsuario: userData.userId,
          idEvento: idEvent,
        });
        if ((promise.status = 201)) {
          loadEventsType();
          setNotifyUser({
            titleNote: "Sucesso",
            textNote: `Presença confirmada!`,
            imgIcon: "success",
            imgAlt:
              "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
            showMessage: true,
          });
        }
      } catch (error) {
        setNotifyUser({
          titleNote: "Erro",
          textNote: `Erro ao desconectar!`,
          imgIcon: "danger",
          imgAlt:
            "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
          showMessage: true,
        });
      }
      return;
    }

    try {
      const promiseDelete = await api.delete(
        `/PresencasEvento/${idPresencaEvento}`
      );
      if (promiseDelete.status === 204) {
        loadEventsType();
        setNotifyUser({
          titleNote: "Sucesso",
          textNote: `Presença removida!`,
          imgIcon: "success",
          imgAlt:
            "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
          showMessage: true,
        });
      }
    } catch (error) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: `Erro ao desconectar!`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    }
  }
  
  return (
    <>
      <MainContent>
        <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
        {showSpinner ? <Spinner /> : null}
        <Container>
          <Title titleText={"Eventos"} aditionalClass="custom-title" />

          <Select
            id="id-tipo-evento"
            name="tipo-evento"
            aditionalClass="select-tp-evento"
            required={true}
            dados={quaisEventos}
            manipulationFunction={(e) => myEvents(e.target.value)}
            defaultText="Selecione"
            defaultValue="1"
            titleKey="text"
            idKey="value"
          />
          <Table
            dados={eventos}
            fnConnect={handleConnect}
            fnShowModal={(e) => {
              showHideModal(e.target);
              console.log(e.target.id);
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
          fnGet={loadMyComentary}
          fnPost={postMyCOmentary}
          fnDelete={commentaryRemove}
          value={descricao}
        />
      ) : null}
    </>
  );
};

export default EventosAlunoPage;
