import React from "react";
import "./NextEvent.css";
import { Tooltip } from "react-tooltip";
import { Link } from "react-router-dom";

const NextEvent = ({ title, description, eventDate, idEvento }) => {
  function conectar(idEvento) {
    console.log(`Conectando ao evento: ${idEvento}`);
  }
  return (
    <article className="event-card">
      <h2 className="event-card__title">{title}</h2>
      <p
        data-tooltip-id={idEvento}
        data-tooltip-content={description}
        data-tooltip-place="top"
        className="event-card__description"
      >
        <Tooltip className="tooltip" id={idEvento} />
        {description}
      </p>
      <p className="event-card__data">{eventDate}</p>
      {/* <a
        onClick={() => {
          conectar(idEvento);
        }}
        href={`/detalhes-evento/${idEvento}`}
        className="event-card__connect-link"
      >
        Conectar
      </a> */}
      <Link
        to={`/detalhes-evento/${idEvento}`}
        className="event-card__connect-link"
      >
        Conectar
      </Link>
    </article>
  );
};

export default NextEvent;
