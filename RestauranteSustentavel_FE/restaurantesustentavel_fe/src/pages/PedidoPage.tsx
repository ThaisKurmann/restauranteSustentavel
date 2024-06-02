import { useEffect, useState } from "react";
import { Pedido } from "../models/Pedido";
import CreatePedidoButton from "../components/CreatePedidoButton";
import { Bebida } from "../models/Bebida";
import api from "../api";
import AddBebidaToPedido from "../components/AddBebidaToPedido";
import PedidoDeleteApi from "../components/PedidoDeleteApi";
import { BebidasSelecionada } from "../models/PedidoBebida";
import axios from "axios";

interface PedidoProps{
    pedido: Pedido;
}


const PedidoPage: React.FC<PedidoProps> = ({pedido}) => {

   return(
        <div>
            <div>
                <h1>PEDIDO (API): </h1>
                <p>Bem-vindo a agina 'pedidos'!</p>
                {/**<AddBebidaToPedido pedidoId={pedido.id} />*/}
            </div>

            <div>

            </div>
            <div>
                <h2>Criar Pedido: </h2>
                <CreatePedidoButton />
              {/**<h2>Deletar Pedido: </h2>
               <PedidoDeleteApi /> */} 
            </div>
        </div>
    );
};


export default PedidoPage;