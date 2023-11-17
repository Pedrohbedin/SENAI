import React, { useEffect, useState } from "react";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Title/Title";
import "./TipoEventosPage.css";
import eventTypeImage from "../../assets/images/tipo-evento.svg";
import Container from "../../Components/Container/Container";
import { Input, Button } from "../../Components/FormComponents/FormComponents";
import api from "../../Services/Services";
import Notification from "../../Components/Notification/Notification";
import TableTb from "../../Components/TableTb/TableTb";

const TipoEventosPage = () => {
  const [Notification, setNotifyUser] = useState({});

  const [frmEdit, setFrmEdit] = useState(false);

  const [titulo, setTitulo] = useState("");

  const [tipoEventos, setTipoEventos] = useState([]);

  async function handleSubmit(e) {
    e.preventDefault();

    if (titulo.trim().length < 3) {
      alert("O Título deve ter no míninmo 3 caracteres");
      return;
    }

    try {
      const retorno = await api.post("/TiposEvento", { titulo: titulo });
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      setTitulo("");
    } catch (error) {
      console.log(error);
    }
  }

  function handleUpdate() {
    alert("Bora atualizar");
  }

  function showUpdateForm() {
    alert("Mostrando a tela de update");
  }

  async function handleDelete(id) {
    try {
      const retorno = await api.delete(`/TiposEvento/${id}`);
      tipoEventos.filter((tipoEvento) => tipoEvento.idTipoEvento !== id);
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    } catch (error) {
      console.log(error);
    }
  }

  useEffect(() => {
    async function getTipoEventos() {
      try {
        const promise = await api.get("/TiposEvento");
        console.log(promise.data);
        setTipoEventos(promise.data);
      } catch (error) {
        console.log("Deu ruim na api");
      }
    }
    getTipoEventos();
  }, tipoEventos);

  // function editActionAbort() {
  //   alert("Cancelar a tela de edição de dados");
  // }

  return (
    <MainContent>
      <Notification {...setNotifyUser} setNotifyUser={setNotifyUser} />
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title
              titleText={"Página tipo de eventos"}
              additionalClass={"cor-titulo"}
              color={""}
            />
            <ImageIllustrator alterText="" imageRender={eventTypeImage} />
            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
            >
              <p>
                {!frmEdit ? (
                  <>
                    <Input
                      type={"text"}
                      id={"text"}
                      name={"titulo"}
                      placeholder={"Título"}
                      required={"required"}
                      value={titulo}
                      manipulationFunction={(e) => {
                        setTitulo(e.target.value);
                      }}
                    />
                  </>
                ) : (
                  <p>Tela de edição</p>
                )}
              </p>
              <Button
                type={"submit"}
                id={"cadastrar"}
                name={"cadastrar"}
                texButton={"Cadastrar"}
              />
            </form>
          </div>
        </Container>
      </section>

      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista Tipo de Eventos"} color="white" />
          <TableTb
            dados={tipoEventos}
            fnUpdate={showUpdateForm}
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default TipoEventosPage;
