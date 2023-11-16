import React, { useEffect, useState } from "react";
import MainContent from "../../Components/MainContent/MainContent";
import Banner from "../../Components/Banner/Banner";
import VisionSection from "../../Components/VisionSection/VisionSection";
import ContatctSection from "../../Components/ContactSection/ContactSection";
import NextEvent from "../../Components/NextEvent/NextEvent";
import Container from "../../Components/Container/Container";
import Title from "../../Components/Title/Title";
import {dateFormatDbToView} from "../../Utils/stringFunctions"
import api from "../../Services/Services";

import "./HomePage.css";

const HomePage = () => {
  useEffect(() => {
    async function getProximosEventos() {
      try {
        const promise = await api.get(
          "/Evento/ListarProximos"
        );

        console.log(promise.data);
        setNextEvents(promise.data);
      } catch (error) {
        alert("Deu ruim na api");
      }
    }
    getProximosEventos();
    console.log("A home foi montada");
  }, []);

  const [nextEvent, setNextEvents] = useState([]);

  return (
    <MainContent>
      <Banner />
      {/* Proximos eventos */}
      <section className="proximos-eventos">
        <Container>
          <Title titleText={"Próximos Eventos"} />
          <div className="events-box">
            {nextEvent.map((e) => {
              return (
                <NextEvent
                  key = {e.idEvento}
                  idEvent={e.idEvento}
                  title={e.nomeEvento}
                  description={e.descricao}
                  eventDate={dateFormatDbToView(e.dataEvento)}
                />
              );
            })}
          </div>
        </Container>
      </section>
      <VisionSection />
      <ContatctSection />
    </MainContent>
  );
};

export default HomePage;
