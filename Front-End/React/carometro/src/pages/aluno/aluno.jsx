import React, { useState, useEffect } from "react";

import Header from "../../components/header/header";
import Footer from "../../components/footer/footer";
import api from "../../services/api";

import '../../assets/css/aluno.css'
import { Sidebar } from "../../components/sidebar/SideBar";
import { parseJwt } from "../../services/auth";
import { SideBarHome } from "../../components/sidebar/SideBarHome";

export default function Aluno() {
  const [listaAluno, setListaAlunos] = useState([]);

  function listarAlunos() {
    api('/Alunos/sala/1')
      .then(resposta => {
        if (resposta.status === 200) {
          console.log('Lista')
          console.log(resposta)
          setListaAlunos(resposta.data)
        }
      })
      .catch(erro => console.log(erro))
  }

  useEffect(listarAlunos, []);

  return (
    <>
      <Header />
      <div>
        {
          parseJwt().role === "1" && <Sidebar />
        }
        {
          parseJwt().role === "2" && <SideBarHome />
        }
      </div>
      <section className="container_aluno">
        <h2 className="titulo_aluno" style={{ marginTop: 50 }}>
          Alunos
        </h2>
        <div className="box_aluno">
          {listaAluno.map((aluno) => {
            return (
              <div key={aluno.idAluno}>

                <div className="box_imagem">
                  {<img className="img" src={aluno.imagem} />}
                </div>

                <div className="box_dados">
                  <p> Nome: 
                    {aluno.nomeAluno} </p>
                  <p> Data de Nascimento:       {Intl.DateTimeFormat("pt-BR", {
                    year: 'numeric', month: 'numeric', day: 'numeric'
                  }).format(new Date(aluno.dataNascimento))}</p>
                  <p> RA:
                    {aluno.ra} </p>
                </div>

              </div>
            )
          })}
        </div>
      </section>
      <Footer />
    </>
  );
}
