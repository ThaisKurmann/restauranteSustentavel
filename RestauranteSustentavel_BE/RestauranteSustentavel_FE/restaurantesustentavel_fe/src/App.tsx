//Arquivo para definir as rotas da aplicacao

import React, { useState } from "react";
import BebidaList from "./components/BebidaList";
import BebidaForm from "./components/BebidaForm";
import { Bebida } from "./models/Bebida";
import BebidaListApi from "./components/BebidaListApi";

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
    
     
    </div>

  );
};

export default App;


/*
import { BrowserRouter, Link, Outlet, Route, Routes } from "react-router-dom";
import Bebidas from "./components/Bebidas/Bebidas";
import { getBebidas } from "./services/BebidaService";



const BebidasContainer = () => {
  return (
    <>
    <h1>Restaurante Sustentavel</h1>
    <Outlet />
    </>
  );
};


export default function App(){
  return (
    <div className="App">
    
     <BrowserRouter>
        <Routes>
          <Route path="/" element={<BebidasContainer />}>
          <Route index element={<Bebidas />}/> 
          </Route>
        </Routes>        
      </BrowserRouter>
    </div>


  )
}
*/

