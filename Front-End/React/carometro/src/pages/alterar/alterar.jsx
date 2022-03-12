import React, { useEffect } from "react";
import { useState } from "react";
// import foto_perfil from '../../assets/img/foto_perfil.png'
import '../../assets/css/adm.css'
import Header from '../../components/header/header'
import Footer from '../../components/footer/footer'
import api from "../../services/api"

import '../../assets/css/webcam.css'
import { Sidebar } from "../../components/sidebar/SideBar";
// import { WebcamCapture } from "../../components/webcam/Webcam";
import Webcam from 'react-webcam'

const videoConstraints = {
    width: 320,
    height: 300,
    facingMode: "user"
};


export default function Cadastrar() {
    const [isLoading, setIsLoading] = useState(false);
    const [imgPerfil, setImgPerfil] = useState('')
    const [idSala, setIdSala] = useState(0)
    const [idRa, setIdRa] = useState(0)
    const listaTurma = [1, 2]
    const [idAlunos, setIdAlunos] = useState(0)
    const [listaAlunos, setListaAlunos] = useState([])
    const [imagem, setImagem] = useState('')
    const [image, setImage] = useState('');


    function BuscarAlunos() {
        api('/Alunos', {
            headers: {
                'Authorization': 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })

            .then(resposta => {
                if (resposta.status === 200) {
                    console.log('Lista')
                    setListaAlunos(resposta.data)
                }
            })
            .catch(erro => console.log(erro))
    }

    const webcamRef = React.useRef(null);

    const capture = React.useCallback(
        () => {
            const imageSrc = webcamRef.current.getScreenshot();
            setImagem(imageSrc)
        }
    );

    const MostrarImg = (idAluno) => {
        api.get('/Alunos/aluno/' + idAluno)
            .then(resp => {
                if (resp.status === 200) {
                    setImgPerfil(resp.data.imagem)
                    // setIdAlunos(resp.data)
                }
            }).catch(erro => {
                console.log(erro)
            })
    }

    useEffect(BuscarAlunos, []);




    function AlterarAluno(event) {
        setIsLoading(true)
        event.preventDefault();
        console.log('Imagem')
        console.log(image)
        let alunos = {
            idSala: idSala,
            imagem: imagem
        }

        api.put('/Alunos/' + idAlunos, {
            idSala: idSala,
            imagem: imagem
        }, {
            headers: {
                Authorization: 'Bearer ' + localStorage.getItem('usuario-login')
            }
        })
            .then((resposta) => {
                if (resposta.status === 204) {
                    console.log('Aluno Atualizado')
                    setIsLoading(false);
                }
            })
            .catch(erro => console.log(erro), setInterval(() => {
                setIsLoading(false);
            }, 5000));
    }




    return (
        <div >
            <Header />
            <Sidebar />
            <section className="container_adm" >
                <div >

                    <form className="display" onSubmit={AlterarAluno} >

                        <div className="posicao_foto">
                            <img
                                className="foto_perfil"
                                src={imgPerfil}
                                alt="Adicione a sua foto"
                            />
                            
                            <div className='webcam-container'>
                                <div  >
                                    {imagem === '' ? <Webcam
                                        audio={false}
                                        height={300}
                                        ref={webcamRef}
                                        screenshotFormat="image/jpeg"
                                        width={320}
                                        frameBorder={50}
                                        videoConstraints={videoConstraints}
                                    // value={arquivo}

                                    /> : <img src={imagem} alt="Imagem Capturada" />}
                                </div>
                                <div>
                                    {imagem !== '' ?
                                        <button onClick={(e) => {
                                            e.preventDefault();
                                            setImagem('')
                                        }}
                                            className="input_file btn ">
                                            Tirar Outra Foto</button> :
                                        <button onClick={(e) => {
                                            e.preventDefault();
                                            capture();
                                        }}
                                            className="input_file btn ">Tirar Foto</button>
                                    }
                                </div>
                            </div>
                        </div>
                        <div className="input_container">



                            <select
                                className="input"
                                name="alunos"
                                id="alunos"
                                value={idAlunos}
                                onChange={(campo) => setIdAlunos(campo.target.value)}
                                onChangeCapture={(img) => MostrarImg(img.target.value)}
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


                            <select
                                className="input"
                                name="Turma"
                                value={idSala}
                                onChange={(campo) => setIdSala(campo.target.value)}
                            >
                                <option value="0">Turmas</option>
                                <option value={listaTurma[0]}> 1A </option>
                                <option value={listaTurma[1]}> 1B </option>
                            </select>

                            {/* <input
                                className="input"
                                type="date"
                                name="dataDeNascimento"
                                value={dataNascimento}
                                onChange={(campo) => setDataNascimento(campo.target.value)}
                            /> */}
                            {
                                isLoading === false &&
                                <button type="submit" className="btn btn_cadastro"  >Alterar</button>
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