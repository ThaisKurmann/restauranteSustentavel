//Arquivo para definir as rotas da aplicacao

import React, { useState } from "react";
import { Bebida } from "./models/Bebida";
import { Link, Route, Routes, BrowserRouter } from "react-router-dom";
import HomePage from "./pages/HomePage";
import NewPage from "./pages/NewPage";
import PedidoPage from "./pages/PedidoPage";
import { Pedido } from "./models/Pedido";
import SinglePedidoPage from "./pages/SinglePedidoPage";



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
                <p>---------------------------------------------------------------------------</p>
                <Routes>
                    <Route path="/" element={<HomePage />} />
                    <Route path="/new" element={<NewPage />} />
                    <Route path="/pedido" element={<PedidoPage pedido={pedidoEstatico}/>} />
                    <Route path="/pedido/:id" element={<SinglePedidoPage />}/>

                </Routes>
                
            </div>   
          {/** <div>
            
              <h1>BEBIDA (API): </h1>
              
              <h2>CREATE:(BebidaFormApi)</h2>
              <BebidaFormApi />
              
              <h2>GET: (BebidaListApi)</h2>
              <BebidaListApi />
              
              <h2>DELETE: (BebidaDeleteApi)</h2>
              <BebidaDeleteApi />
            
            </div>
          */}  
           
           
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
