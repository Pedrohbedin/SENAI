import React, { useEffect, useState } from "react";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Title/Title";
import "./TipoEventosPage.css";
import eventTypeImage from "../../assets/images/tipo-evento.svg";
import Container from "../../Components/Container/Container";
import { Input, Button } from "../../Components/FormComponents/FormComponents";
import api from "../../Services/Services";
import TableTb from "../../Components/TableTb/TableTb";

const TipoEventosPage = () => {

  const [frmEdit /*, setFrmEdit*/] = useState(false);
  const [titulo, setTitulo] = useState("");

  async function handleSubmit(e) {
    e.preventDefault();

    if (titulo.trim().length < 3) {
      alert("O Título deve ter no míninmo 3 caracteres");
      return;
    }

    try {
      const retorno = await api.post("/TiposEvento", { titulo: titulo });
      console.log(retorno.data);
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

  function handleDelete() {
    alert("Bora lá apagar na api");
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
  }, []);
  const [tipoEventos, setTipoEventos] = useState([]);

  function editActionAbort() {
    alert("Cancelar a tela de edição de dados");
  }

  return (
    <MainContent>
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
