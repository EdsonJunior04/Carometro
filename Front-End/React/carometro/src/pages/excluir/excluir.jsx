import React, { useEffect } from "react";
import { useState } from "react";
import foto_perfil from '../../assets/img/foto_perfil.png'
import '../../assets/css/adm.css'
import Header from '../../components/header/header'
import Footer from '../../components/footer/footer'
import api from "../../services/api"
import { Sidebar } from "../../components/sidebar/SideBar";



export default function Cadastrar() {
    const [isLoading,] = useState(false);
    const [idAlunos, setIdAlunos] = useState(0)
    const [listaAlunos, setListaAlunos] = useState([])
    const [fotoAtiva, setFotoAtiva] = useState('')


    function BuscarAlunos() {
        api('/Alunos', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

            .then(resposta => {
                if (resposta.status === 200) {
                    console.log('Lista')
                    console.log(resposta)
                    setListaAlunos(resposta.data)
                }
            })
            .catch(erro => console.log(erro))
    }

    useEffect(BuscarAlunos, []);

    function buscarImagem(event) {
        api('/Alunos/aluno/' + event.idAlunos, )

            .then(resposta => {
                if (resposta.status === 200) {
                    console.log('Imagem')
                    console.log(resposta)
                    setIdAlunos(resposta.data.imagem)
                    // setFotoAtiva(resposta.data.imagem)
                }
            })
            .catch(erro => console.log(erro))
    }

    useEffect(buscarImagem, []);



    function Excluir(aluno) {
        // aluno.preventDefault();
        api.delete('/Alunos/' + idAlunos)

            .then(resposta => {
                if (resposta.status === 204) {
                    console.log('Aluno Excluido')
                }
            })
            .catch(erro => console.log(erro))
    }

    function buscarImagem(){
        
    }

    return (
        <div >
            <Header />
            <Sidebar />
            <section className="container_adm" >
                <div >

                    <form className="display" onSubmit={Excluir} >

                        <div className="posicao_foto">
                            <img
                                className="foto_perfil"
                                src={foto_perfil}
                                alt="Adicione a sua foto"
                            />
                        </div>
                        <div className="input_container">



                            <select
                                className="input"
                                name="alunos"
                                id="alunos"
                                value={idAlunos}
                                onChange={(campo) => setIdAlunos(campo.target.value)}
                            >
                                <option value="0">Selecione o Aluno</option>

                                {
                                    listaAlunos.map((aluno) => {
                                        return (
                                            <option key={aluno.idAlunos} value={aluno.idAlunos}>
                                                Nome: {aluno.nomeAluno} / RA:{aluno.ra}
                                            </option>
                                        )
                                    })}
                            </select>

                            {
                                isLoading === false &&
                                <button type="submit" className="btn  btn_excluir"  >Excluir</button>
                            }
                            {
                                isLoading === true &&
                                <button type="submit" disabled className="btn btn_cadastro">Loading...</button>
                            }
                        </div>
                    </form>
                </div>
            </section>
            <Footer />
        </div>
    )
}