import React, { useState } from "react";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import MainContent from "../../Components/MainContent/MainContent";
import Title from "../../Components/Title/Title";
import "./TipoEventosPage.css";
import eventTypeImage from "../../assets/images/tipo-evento.svg";
import Container from "../../Components/Container/Container";
import { Input, Button } from "../../Components/FormComponents/FormComponents";
import api from "../../Services/Services";

const TipoEventosPage = () => {
  const [frmEdit, setFrmEdit] = useState(false);
  const [titulo, setTitulo] = useState("");

  async function handleSubmit(e) {
    e.preventDefault();

    if (titulo.trim().length < 3) {
      alert("O Título deve ter no míninmo 3 caracteres");
      return;
    }

    try {
      const retorno = await api.post("/TiposEvento", {titulo: titulo})
      console.log(retorno.data);
      setTitulo("")
    }catch(error) {
      console.log(error)
    }
  }

  function handleUpdate() {
    alert("Bora atualizar");
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
    </MainContent>
  );
};

export default TipoEventosPage;
