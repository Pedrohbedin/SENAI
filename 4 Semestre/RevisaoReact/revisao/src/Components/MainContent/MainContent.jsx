import React from "react";
import "./MainContent.css"

const MainContent = ({ children }) => {
    return (
        <div className="mainContent">
            {children}
        </div>
    )
}

export default MainContent;