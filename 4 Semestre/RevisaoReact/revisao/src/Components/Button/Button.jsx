import React from "react";
import "./Button.css";

const Button = ({ text, onClick, color = "light" }) => {
    return (
        <button onClick={onClick} className={`button ${color}`}  >
            <p className={`buttonText ${color}`}>{text}</p>
        </button >
    )
}

export default Button;