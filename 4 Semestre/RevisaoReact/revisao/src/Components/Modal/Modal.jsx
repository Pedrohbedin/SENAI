import React from "react";
import "./Modal.css"
import TitleContainer from "../TitleContainer/TitleContainer";
import Button from "../Button/Button";

const Modal = ({ visible = false, value, onClick, onChange }) => {
    return visible ? (
        <div className="modalMainContent">
            <div className="modalCotainer">
                <TitleContainer>
                    <h1>Descreva sua tarefa</h1>
                </TitleContainer>
                <textarea value={value} onChange={onChange} rows={6} placeholder="Exemplo de descrição" className="descriptionInput" />
                <Button text={"Confirmar tarefa"} onClick={onClick} />
            </div>
        </div>
    ) : (
        <>

        </>
    )
}

export default Modal;