import "./App.css";
import Container from "./Components/Container/Container";
import MainContent from "./Components/MainContent/MainContent";
import TitleContainer from "./Components/TitleContainer/TitleContainer";
import Searcher from "./Components/Searcher/Searcher";
import { useState, useEffect } from "react";
import Button from "./Components/Button/Button";
import Modal from "./Components/Modal/Modal";
import TarefaList from "./Components/TarefaList/TarefaList";

function App() {
  const [value, setValue] = useState(""); 
  const [modalValue, setModalValue] = useState(""); 
  const [editingIndex, setEditingIndex] = useState(null); 
  const [tasks, setTasks] = useState([]); 
  const [filteredTasks, setFilteredTasks] = useState([]); 
  const [isModalVisible, setIsModalVisible] = useState(false);

  useEffect(() => {
    setFilteredTasks(
      tasks.filter((task) => task.toLowerCase().includes(value.toLowerCase()))
    );
  }, [tasks, value]);

  const handleDelete = (index) => {
    setTasks((tasks) => tasks.filter((_, i) => i !== index));
  };

  const handleAdd = () => {
    if (modalValue.trim()) {
      setTasks((tasks) => [...tasks, modalValue]);
      setModalValue("");
      setIsModalVisible(false);
    }
  };

  const handleUpdate = (index) => {
    setEditingIndex(index);
    setModalValue(tasks[index]);
    setIsModalVisible(true);
  };

  const handleUpdateConfirm = () => {
    if (editingIndex !== null && modalValue.trim()) {
      setTasks((tasks) => {
        const updatedTasks = [...tasks];
        updatedTasks[editingIndex] = modalValue;
        return updatedTasks;
      });
      setModalValue("");
      setEditingIndex(null);
      setIsModalVisible(false);
    }
  };

  return (
    <MainContent>
      <Container>
        <TitleContainer>
          <h1>Terça-Feira, <span>24</span> de Julho</h1>
        </TitleContainer>
        <Searcher 
          value={value} 
          onChange={(e) => setValue(e.target.value)} 
          placeholder={"Procurar tarefa"} 
        />
        <TarefaList 
          tarefas={filteredTasks} 
          Deletar={handleDelete} 
          Edit={handleUpdate} 
        />
      </Container>
      <div className="buttonContainer">
        <Button text={"Nova tarefa"} onClick={() => setIsModalVisible(true)} />
      </div>
      <Modal
        visible={isModalVisible}
        onClick={() => {
          if (modalValue.trim()) {
            if (editingIndex !== null) {
              handleUpdateConfirm();
            } else {
              handleAdd();
            }
          } else {
            setIsModalVisible(false);
          }
        }}
        value={modalValue}
        onChange={(e) => setModalValue(e.target.value)}
        confirmText={editingIndex !== null ? "Atualizar" : "Adicionar"}
      />
    </MainContent>
  );
}

export default App;
