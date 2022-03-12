import React, { useState } from 'react';

import Webcam from 'react-webcam'
import '../../assets/css/webcam.css'

// const WebcamComponent = () => <Webcam/>

const videoConstraints = {
    width: 320,
    height: 300,
    facingMode: "user"
};

export const WebcamCapture = () => {
    const [imagem, setImagem] = useState('');

    const webcamRef = React.useRef(null);

    const capture = React.useCallback(
        () => {
            const imageSrc = webcamRef.current.getScreenshot();
            setImagem(imageSrc)
        }
    );
    

    return(
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
                    // value={image}

                /> : <img src={imagem} alt="Imagem Capturada"/>}
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
    )
}