import React from "react";
import { useState, useEffect } from "react";
import Header from "../../components/header/header";
import Footer from "../../components/footer/footer";
import { Sidebar } from "../../components/sidebar/SideBar"
import { Link } from "react-router-dom";

import "../../assets/css/home.css";

import api from "../../services/api";
// import { useHistory } from "react-router-dom";

export default function Adm() {
  const [listaSalas, setListaSalas] = useState([]);


  function listarSalas() {
    api('/Salas')
      .then(resposta => {
        if (resposta.status === 200) {
          console.log('Lista')
          console.log(resposta)
          setListaSalas(resposta.data)
        }
      })
      .catch(erro => console.log(erro))
  }

  useEffect(listarSalas, []);

  // let history = useHistory();
  // function redirecionarSalas(idSala) {

  //   history.push('/adm/Sala/' + { idSala })
  // }

  return (
    <>
      <Header />
      <Sidebar />
      <section className="container_home">
        <h2 className="titulo_periodo" style={{ marginTop: 50 }}>
          Salas
        </h2>
        <div className="container_sala">

          <div className="box_sala">
            {listaSalas.map((sala) => {
              return (
                <Link to={"/Salas/" + sala.idSala} > <div key={sala.idSala}>
                  <h3>{sala.nomeSala}</h3>
                </div> </Link>
              )
            })}
          </div>
        </div>
      </section>
      <Footer />
    </>
  );
}
