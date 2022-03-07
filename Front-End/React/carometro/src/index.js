import React from 'react';
import ReactDOM from 'react-dom';

import {
  Route,
  BrowserRouter as Router,
  Redirect,
  Switch,
} from 'react-router-dom'

import './index.css';

import { parseJwt, usuarioAutenticado } from './services/auth';

import Login from './pages/login/login'
import Home from './pages/home/home'
import Adm from './pages/adm/adm'
import Aluno from './pages/aluno/aluno'


import reportWebVitals from './reportWebVitals';
import Cadastrar from './pages/cadastrar/cadastrar';
import Excluir from './pages/excluir/excluir';
import Alterar from './pages/alterar/alterar';
import Sala from './pages/aluno/sala';

const PermissaoAdm = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '1' ? (
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);

const PermissaoColab = ({ component: Component }) => (
  <Route
    render={(props) =>
      usuarioAutenticado() && parseJwt().role === '2' ? (
        <Component {...props} />
      ) : (
        <Redirect to="login" />
      )
    }
  />
);


const routing = (
  <Router>
    <div>
    <Switch>
        <Route exact path="/" component = {Login}/>
        <Route path ="/login" component ={Login}/>
        <PermissaoAdm exact path = "/adm" component = {Adm}/>
        <PermissaoAdm path = "/cadastrar" component = {Cadastrar}/>
        <PermissaoAdm  path = "/adm/home" component={Home}/>
        <PermissaoAdm path = "/alterar" component={Alterar}/>
        <PermissaoAdm path = "/excluir" component={Excluir}/>
        <PermissaoColab path = "/home" component={Home}/>
        <Route path = "/Salas/1" component={Aluno}/>
        <Route path = "/Salas/2" component={Sala}/>
        <PermissaoColab path = "/aluno" component={Aluno}/>
        <Route path="/adm/login" component={Login}/>
        <Redirect to={Login}/>
      </Switch>
    </div>
  </Router>
)

ReactDOM.render(routing, document.getElementById('root'));

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
