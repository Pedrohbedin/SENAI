import React from "react";
import { Link } from "react-router-dom";
import "./Nav.css";
import LogoMobile from "../../assets/images/logo-white.svg";
import LogoDesktop from "../../assets/images/logo-pink.svg";

const Nav = ({ setExibeNavbar, exibeNavbar }) => {
  return (
    <nav className={`navbar ${exibeNavbar ? "exibeNavbar" : ""} `}>
      <span
        className="navbar__close"
        onClick={() => {
          setExibeNavbar(false);
        }}
      >
        x
      </span>

      <Link to="">
        <img
          className="eventlogo__logo-image"
          src={window.innerWidth >= 992 ? LogoDesktop : LogoMobile}
          alt="Event plus logo"
        />
      </Link>

      <div className="navbar__items-box">
        <Link to={"/"} className="navbar__items">
          Home
        </Link>
        <Link to={"/tipo-eventos"}>Tipo Eventos</Link>
        <Link to={"/eventos"}>Eventos</Link>
        <Link to={"/login"}>Login</Link>
      </div>
    </nav>
  );
};

export default Nav;
