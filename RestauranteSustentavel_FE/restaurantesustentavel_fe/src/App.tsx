//Arquivo para definir as rotas da aplicacao

import React from "react";
import { Link, Route, Routes, BrowserRouter } from "react-router-dom";
import HomePage from "./pages/HomePage";
import NewPage from "./pages/NewPage";
import PedidoPage from "./pages/PedidoPage";
import SinglePedidoPage from "./pages/SinglePedidoPage";

const App: React.FC = () => {


  return (
    <BrowserRouter>
          <div>
                <nav>
                    <ul>
                        <li >
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
                    <Route path="/pedido" element={<PedidoPage/>} />
                    <Route path="/pedido/:id" element={<SinglePedidoPage/>}/>
                </Routes>
          </div>   
    </BrowserRouter>

    
   
  );
};

export default App;
