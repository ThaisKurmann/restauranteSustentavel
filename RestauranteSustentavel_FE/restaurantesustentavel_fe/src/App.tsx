//Arquivo para definir as rotas da aplicacao

import React, { useState } from "react";
import BebidaList from "./components/BebidaList";
import BebidaForm from "./components/BebidaForm";
import { Bebida } from "./models/Bebida";
import BebidaListApi from "./components/BebidaListApi";
import BebidaPostApi from "./components/BebidaPostApi";
import BebidaFormApi from "./components/BebidaFormApi";
import BebidaDeleteApi from "./components/BebidaDeleteApi";
import { Router, Link, Route, Routes, BrowserRouter } from "react-router-dom";
import HomePage from "./pages/HomePage";
import NewPage from "./pages/NewPage";
import FazerPedidoPage from "./pages/NewPage";
import PedidoPage from "./pages/PedidoPage";
import { Pedido } from "./models/Pedido";

const App: React.FC = () => {
  const [editBebida, setEditBebida] = useState<Bebida | undefined>(undefined);
  const [refresh, setRefresh] = useState(false);

  const handleSave = () => {
    setEditBebida(undefined);
    setRefresh(!refresh);
  };

  const pedidoEstatico: Pedido = {
      id:8,
      data: '05/03/2024',
      hora: '12:00',
  }

  return (
    <BrowserRouter>
            <div>
                <nav>
                    <ul>
                        <li>
                            <Link to="/">Home</Link>
                        </li>
                        <li>
                            <Link to="/new">NewPage</Link>
                        </li>
                        <li>
                          <Link to="/pedido">Pedido</Link>
                        </li>
                    </ul>
                </nav>
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/new" element={<NewPage />} />
                    <Route path="pedido" element={<PedidoPage pedido={pedidoEstatico}/>} />
                </Routes>
            </div>
        </BrowserRouter>
   
  );
};

export default App;

/**
 * backup do que estava implementado antes de criar a NewPage.tsx
 * 
 * 
 * 
const App: React.FC = () => {
  const [editBebida, setEditBebida] = useState<Bebida | undefined>(undefined);
  const [refresh, setRefresh] = useState(false);

  const handleSave = () => {
    setEditBebida(undefined);
    setRefresh(!refresh);
  };

   return (
    <div>
      <h1>CRUD de Bebidas</h1>

      <BebidaForm bebida={editBebida} onSave={handleSave} />
      
      <br></br>

      <BebidaList refresh={refresh} />

      <BebidaListApi />

      <BebidaPostApi />

      <BebidaFormApi/>

      <BebidaDeleteApi />

    </div>

  );
 * 
 */
