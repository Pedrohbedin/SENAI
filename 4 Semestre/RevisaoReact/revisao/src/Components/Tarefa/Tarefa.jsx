import React, { useState } from "react";
import "./Tarefa.css";
import check from "../../icons/Vector (1).png"
import whiteDel from "../../icons/Vector (2).png"
import whitePen from "../../icons/Vector (3).png"
import darkDel from "../../icons/Vector (4).png"
import darkPen from "../../icons/Vector (5).png"

const Tarefa = ({ Delete, Edit, desc }) => {

    const [state, setState] = useState(false);

    return (
        <div className={`tarefaContainer ${state && "Dark"}`}>
            <div className="descriptionContainer">
                <button className={state ? "checkDark" : "checkLight"} onClick={() => setState(!state)} > {state && <img src={check} alt="" />} </button>
                <p className={`Text ${state && "DarkText"}`}>{desc}</p>
            </div>
            <div className="interactiveContainer">
                <button className={`tarefaButton ${state && "tarefaButtonDark"}`} onClick={Delete}>{state ? <img src={whiteDel} alt="" /> : <img src={darkDel} alt="" />}</button>
                <button className={`tarefaButton ${state && "tarefaButtonDark"}`} onClick={Edit} >{state ? <img src={whitePen} alt="" /> : <img src={darkPen} alt="" />}</button>
            </div>
        </div>
    )
}

export default Tarefa;