import { useState, useEffect } from "react";
import Title from "../../Components/Title/Title";
import MainContent from "../../Components/MainContent/MainContent";
import Notification from "../../Components/Notification/Notification";
import Spinner from "../../Components/Spinner/Spinner";
import Container from "../../Components/Container/Container";
import ImageIllustrator from "../../Components/ImageIllustrator/ImageIllustrator";
import EventImage from "../../assets/images/evento.svg";
import { Button, Input } from "../../Components/FormComponents/FormComponents";
import TableEv from "../../Components/TableEv/TableEv";
import api from "../../Services/Services";
import { dateFormatDbToForm } from "../../Utils/stringFunctions";

const EventosPage = () => {
  const [notifyUser, setNotifyUser] = useState({});
  const [showSpinner, setShowSpinner] = useState(false);
  const [nomeEvento, setNomeEvento] = useState("");
  const [tipoEvento, setTipoEvento] = useState("");
  const [eventos, setEventos] = useState([]);
  const [idEvento, setIdEvento] = useState("");
  const [eventDate, setEventDate] = useState("");
  const [description, setDescription] = useState("");
  const [frmEdit, setFrmEdit] = useState(false);

  async function handleSubmit(e) {
    e.preventDefault();

    if (nomeEvento.trim().length < 3) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: `O título deve conter no mínimo 3 caractéres!`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      return;
    }

    try {
      await api.post("/Evento", { titulo: nomeEvento });
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Cadastrado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      const promise = await api.get("/evento");
      setEventos(promise.data);
      setNomeEvento("");
    } catch (error) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: `Evento não cadastrado!`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    }
  }

  async function handleUpdate(e) {
    e.preventDefault();
    if (nomeEvento.trim().length < 3) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: `O título deve conter no mínimo 3 caractéres!`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      return;
    }
    try {
      await api.put(`/Evento/` + idEvento, {
        nomeEvento: nomeEvento,
        dataEvento: eventDate,
        tiposEvento: tipoEvento,
        descricao: description
      });

      const retornoGet = await api.get("/Evento");
      setEventos(retornoGet.data);
      const promise = await api.get("/Evento");
      setEventos(promise.data);
      editActionAbort();
    } catch (error) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: `Erro ao atualizar evento`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    }
  }

  async function showUpdateForm(idElemento) {
    setFrmEdit(true);
    try {
      const retorno = await api.get("/Evento/" + idElemento);
      console.log(retorno.data)
      setNomeEvento(retorno.data.nomeEvento);
      setDescription(retorno.data.descricao);
      
      setEventDate(dateFormatDbToForm(retorno.data.dataEvento));
      setIdEvento(idElemento);
      const promise = await api.get("/Evento");
      setEventos(promise.data);
    } catch (error) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: `Erro ao listar os evento`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    }
  }

  function editActionAbort() {
    setFrmEdit(false);
    setNomeEvento("");
    setDescription("");
    setEventDate("");
    setIdEvento(null);
  }

  async function handleDelete(id) {
    try {
      await api.delete(`/Evento/${id}`);
      eventos.filter((eventos) => eventos.idEvento !== id);
      setNotifyUser({
        titleNote: "Sucesso",
        textNote: `Deletado com sucesso!`,
        imgIcon: "success",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
      const promise = await api.get("/Evento");
      setEventos(promise.data);
    } catch (error) {
      setNotifyUser({
        titleNote: "Erro",
        textNote: `Erro ao deletar!`,
        imgIcon: "danger",
        imgAlt:
          "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
        showMessage: true,
      });
    }
  }

  useEffect(() => {
    async function getEventos() {
      setShowSpinner(true);
      try {
        const promise = await api.get("/Evento");
        setEventos(promise.data);
      } catch (error) {
        setNotifyUser({
          titleNote: "Erro",
          textNote: `Erro ao receber dados da api`,
          imgIcon: "danger",
          imgAlt:
            "Imagem de ilustração de sucesso. Moça segurando um balão com símbolo de confirmação ok.",
          showMessage: true,
        });
      }
      setShowSpinner(false);
    }
    getEventos();
  }, []);

  return (
    <MainContent>
      <Notification {...notifyUser} setNotifyUser={setNotifyUser} />
      {showSpinner ? <Spinner /> : null}
      <section className="cadastro-evento-section">
        <Container>
          <div className="cadastro-evento__box">
            <Title
              titleText={"Cadastro De Eventos"}
              additionalClass={"cor-titulo"}
              color={""}
            />
            <ImageIllustrator alterText="" imageRender={EventImage} />
            <form
              className="ftipo-evento"
              onSubmit={frmEdit ? handleUpdate : handleSubmit}
            >
              {!frmEdit ? (
                <>
                  <Input
                    type={"text"}
                    id={"text"}
                    name={"nomeEvento"}
                    placeholder={"Nome"}
                    required={"required"}
                    value={nomeEvento}
                    manipulationFunction={(e) => {
                      setNomeEvento(e.target.value);
                    }}
                  />
                  <select
                    id={"select"}
                    name={"tipoEvento"}
                    placeholder={"Tipo Evento"}
                    required={"required"}
                    value={eventos}
                    manipulationFunction={(e) => {
                      setNomeEvento(e.target.value);
                    }}
                  >
                    <option value=""></option>
                  </select>

                  <Input
                    type={"text"}
                    id={"description"}
                    name={"description"}
                    placeholder={"Descrição"}
                    required={"required"}
                    value={description}
                    manipulationFunction={(e) => {
                      setDescription(e.target.value);
                    }}
                  />
                  <Input
                    type={"date"}
                    id={"eventDate"}
                    name={"eventDate"}
                    placeholder={"Data"}
                    required={"required"}
                    value={eventDate}
                    manipulationFunction={(e) => {
                      setEventDate(e.target.value);
                    }}
                  />
                  <Button
                    type={"submit"}
                    id={"cadastrar"}
                    name={"cadastrar"}
                    texButton={"Cadastrar"}
                    className="btn-cadastrar"
                  />
                </>
              ) : (
                <>
                  <Input
                    type={"text"}
                    id={"text"}
                    name={"titulo"}
                    placeholder={"Nome"}
                    required={"required"}
                    value={nomeEvento}
                    manipulationFunction={(e) => {
                      setNomeEvento(e.target.value);
                    }}
                  />
                  <select
                    id={"select"}
                    name={"tipoEvento"}
                    placeholder={"Tipo Evento"}
                    required={"required"}
                    value={eventos}
                    manipulationFunction={(e) => {
                      setNomeEvento(e.target.value);
                    }}
                  />
                  <Input
                    type={"text"}
                    id={"description"}
                    name={"description"}
                    placeholder={"Descrição"}
                    required={"required"}
                    value={description}
                    manipulationFunction={(e) => {
                      setNomeEvento(e.target.value);
                    }}
                  />
                  <Input
                    type={"date"}
                    id={"eventDate"}
                    name={"eventDate"}
                    placeholder={"Data"}
                    required={"required"}
                    value={eventDate}
                    manipulationFunction={(e) => {
                      setNomeEvento(e.target.value);
                    }}
                  />
                  <div className="buttons-editbox">
                    <Button
                      type={"submit"}
                      id={"atualizar"}
                      name={"atualizar"}
                      texButton={"Atualizar"}
                      aditionalClass="button-component--midle"
                    />
                    <Button
                      type={"button"}
                      id={"cancelar"}
                      name={"cancelar"}
                      texButton={"Cancelar"}
                      manipulationFunction={editActionAbort}
                      aditionalClass="button-component--midle"
                    />
                  </div>
                </>
              )}
            </form>
          </div>
        </Container>
      </section>
      <section className="lista-eventos-section">
        <Container>
          <Title titleText={"Lista de Eventos"} color="white" />
          <TableEv
            dados={eventos}
            fnUpdate={showUpdateForm}
            fnDelete={handleDelete}
          />
        </Container>
      </section>
    </MainContent>
  );
};

export default EventosPage;
