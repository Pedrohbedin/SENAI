import './App.css';
import Titulo from './components/Titulo/Titulo';
import Card from './components/CardEvento/Card-evento'

function App() {
  return (
    <div className="App">
      <h1>Hello React</h1>
      <Titulo texto = "Pedro"/>
      <Card tituloDoEvento = "Event+" texto = "Evento sobre javascript que será na próxima semana" textoLink = "Conectar" desabilitar={false}/>
      <Card tituloDoEvento = "Event-" texto = "Evento sobre C# que será na próxima semana" textoLink = "Conectar" desabilitar={true}/>
    </div>
  );
}

export default App;