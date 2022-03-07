import React from "react";

import Logo from "../../assets/img/FaceCheck.svg";

import { useHistory } from "react-router-dom";

import "../../assets/css/header.css";

export default function Header() {
  let history = useHistory();

  function logOut() {
    localStorage.removeItem("usuario-login");

    history.push("/login");
  }

  return (
    <header className="container_header">
      <div className="grid_header">
        <div>
          <img className="header_logo" src={Logo} alt="Logo" />
        </div>
        <button onClick={logOut} className="btn button">Sair</button>
      </div>
    </header>
  );
}
