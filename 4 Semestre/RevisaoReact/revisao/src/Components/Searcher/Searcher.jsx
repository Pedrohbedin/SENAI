import React from "react";
import "./Searcher.css"
import searchImg from "../../icons/Vector.png"

const Searcher = ({ value, onChange, placeholder }) => {
    return (
        <div className="searcherContainer">
            <div className="searcherIcon">
                <img src={searchImg} alt="" />
            </div>
                <input className="searcherInput" value={value} onChange={onChange} placeholder={placeholder}/>
        </div>
    )
}

export default Searcher;