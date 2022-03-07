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
    const [image, setImage] = useState('');

    const webcamRef = React.useRef(null);

    const capture = React.useCallback(
        () => {
            const imageSrc = webcamRef.current.getScreenshot();
            setImage(imageSrc)
        }
    );

    return(
        <div className='webcam-container'>
            <div  >
                {image === '' ? <Webcam
                    audio={false}
                    height={300}
                    ref={webcamRef}
                    screenshotFormat="image/jpeg"
                    width={320}
                    frameBorder={50}
                    videoConstraints={videoConstraints}

                /> : <img src={image} alt="Imagem Capturada"/>}
            </div>
            <div>
            {image !== '' ?
                    <button onClick={(e) => {
                        e.preventDefault();
                        setImage('')
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