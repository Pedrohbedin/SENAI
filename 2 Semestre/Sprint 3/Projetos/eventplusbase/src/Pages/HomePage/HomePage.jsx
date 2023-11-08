import React from "react";
import MainContent from "../../Components/MainContent/MainContent";
import Banner from "../../Components/Banner/Banner";
import VisionSection from "../../Components/VisionSection/VisionSection";
import ContatctSection from "../../Components/ContactSection/ContactSection";
import NextEvent from "../../Components/NextEvent/NextEvent";
import Container from "../../Components/Container/Container";
import Title from "../../Components/Title/Title";

import "./HomePage.css";

const HomePage = () => {
  return (
    <MainContent>
      <Banner />
      {/* Proximos eventos */}
      <section className="proximos-eventos">
        <Container>
          <Title titleText={"Próximos Eventos"} />
          <div className="events-box">
            {/* {NextEvent.map((e) => (
              <NextEvent
                key={e.idEvento}
                idEvent={e.idEvento}
                title={e.nomeEvento}
                description={e.descricao}
                eventDate={e.dataEvento}
              />
            ))} */}
            <NextEvent
              title={"Happy Hour Event"}
              description={"qweqweqweqwe"}
              eventDate={"29/09/23"}
            />
          </div>
        </Container>
      </section>
      <VisionSection />
      <ContatctSection />
    </MainContent>
  );
};

export default HomePage;
