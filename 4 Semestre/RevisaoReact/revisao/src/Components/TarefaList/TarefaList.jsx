import React, { useEffect } from "react";
import "./TarefaList.css";
import Tarefa from "../Tarefa/Tarefa";

const TarefaList = ({ tarefas, Deletar, Edit }) => {
    return (
        <div className="tarefaList">
            {
                tarefas.map((tarefa, index) =>
                (
                    <Tarefa key={index} desc={tarefa} Delete={() => Deletar(index)} Edit={() => Edit(index)} />
                )
                )

            }
        </div>
    )


}


export default TarefaList;