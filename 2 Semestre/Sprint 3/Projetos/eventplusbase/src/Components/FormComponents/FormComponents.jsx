import React from "react";
import "./FormComponents.css";

export const Input = ({
  type,
  id,
  required,
  aditionalClass,
  name,
  placeholder,
  manipulationFunction,
  value
}) => {
  return (
    <input
      type={type}
      id={id}
      required={required}
      className={`input-component ${aditionalClass}`}
      placeholder={placeholder}
      onChange={manipulationFunction}
      autoComplete="off"
      value={value}
    />
  );
};

export const Button = ({
  texButton,
  id,
  name,
  type,
  aditionalClass,
  manipulationFunction
}) => {
  return (
    <button
      type={type}
      id={id}
      name={name}
      className={`button-component ${aditionalClass}`}
      onClick={manipulationFunction}
    >{texButton}</button>
  );
};
