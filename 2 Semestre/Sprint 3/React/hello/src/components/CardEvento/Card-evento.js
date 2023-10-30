import React from "react";
import './Card-evento.css'

const Card = ({tituloDoEvento, texto, desabilitar, textoLink}) => {
    return (
        <div class="card">
            <h1 className="card__titulo">{tituloDoEvento}</h1>
            <p className="card__descricao">{texto}</p>
            <a href="#" className={desabilitar ? "card__conectar card__conectar--ativado" : "card__conectar card__conectar--desativado"}>{textoLink}</a>
        </div>
    )
}

export default Card;