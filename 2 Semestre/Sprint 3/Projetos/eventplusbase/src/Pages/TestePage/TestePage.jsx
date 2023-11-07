import React, { useState } from "react";
import Input from "../../Components/Input/Input";
import Button from "../../Components/Button/Button";


const TestePage = () => {
  const [total, setTotal] = useState();
  const [n1, setN1] = useState();
  const [n2, setN2] = useState();

  function handleCalcular(e) {
    e.preventDefault();
    setTotal(parseFloat(n1) + parseFloat(n2));
  }
  return (
    <form onSubmit={handleCalcular}>
      <Input
        tipo="number"
        id="numero1"
        nome="numero1"
        ph="Insira o primeiro número"
        valor={n1}
        fnAltera={setN1}
      />
      <Input
        tipo="number"
        id="numero2"
        nome="numero2"
        ph="Insira o segundo número"
        valor={n2}
        fnAltera={setN2}
      />
      <br />
      <Button tipo="submit" textoBotao="Somar" />
      <br />
      <span>Resultado:{total}</span>
    </form>
  );
};

export default TestePage;
