import React from "react";

import Logo from "../../assets/img/FaceCheck.svg";

import '../../assets/css/footer.css'

export default function Footer() {
  return (
   <footer className="container_footer">
       <img className="logo" src={Logo} alt='Logo'/>
   </footer>
  )
}
