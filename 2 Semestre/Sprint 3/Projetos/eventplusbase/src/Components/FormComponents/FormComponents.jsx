import React from "react";
import "./FormComponents.css";

export const Input = ({ type, id, required, aditionalClass, name, placeholder, manipulationFunction }) => {
  return (
    <input type={type} id={id} required={required} className={`input-component ${aditionalClass}`} placeholder={placeholder} onChange={manipulationFunction} autoComplete='off' />
  );
};
