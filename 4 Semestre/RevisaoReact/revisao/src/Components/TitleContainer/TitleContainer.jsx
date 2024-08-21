import React from "react";
import "./TitleContainer.css";

const TitleContainer = ({ children }) => {
    return (
        <div className="titleContainer">
            {children}
        </div>
    )
}

export default TitleContainer;