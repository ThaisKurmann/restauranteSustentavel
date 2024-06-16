//Arquivo para definir as rotas da aplicacao

import React from "react";
import { Link, Route, Routes, BrowserRouter } from "react-router-dom";
import NewPage from "./pages/FinalizarPedidoPage";
import PedidoPage from "./pages/PedidoPage";
import SinglePedidoPage from "./pages/SinglePedidoPage";
import FinalizarPedidoPage from "./pages/FinalizarPedidoPage";

const App: React.FC = () => {


  return (
    <BrowserRouter>
          <div>
                <nav>
                    <ul>
                        <li >
                          <Link to="/new">New Page</Link>
                        </li>
                        
                        <li>
                          <Link to="/pedido">Pedido</Link>
                        </li>
                    </ul>
                </nav>
                <Routes>
                    <Route path="/pedido" element={<PedidoPage/>} />
                    <Route path="/pedido/:id" element={<SinglePedidoPage/>}/>
                    <Route path="/pedido/:id/salvar" element={<FinalizarPedidoPage/>}/>
                    <Route path="/new" element={<NewPage />} />
                </Routes>
          </div>   
    </BrowserRouter>

    
   
  );
};

export default App;
