import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import api from "../api";
import { Bebida } from "../models/Bebida";
import { PedidoBebida } from "../models/PedidoBebida";
import AddBebidaToPedido from "../components/AddBebidaToPedido";
import BebidaListApi from "../components/BebidaListApi";
import AddSobremesaToPedido from "../components/AddSobremesaToPedido";
import GetPedido from "../components/GetPedido";





const SinglePedidoPage: React.FC=  () => {

    const {id} = useParams();
    const pedidoAtualId = Number(id);//converte valor retornado de useParams em number

 
  
    useEffect(() => {
       
    }, []);


    return(
        <div>
          <div>
            <AddBebidaToPedido pedidoId={pedidoAtualId}/>
          </div>

          <AddSobremesaToPedido pedidoId={pedidoAtualId}/>

          <GetPedido pedidoID={pedidoAtualId}/>
        </div>
    );

}
export default SinglePedidoPage;