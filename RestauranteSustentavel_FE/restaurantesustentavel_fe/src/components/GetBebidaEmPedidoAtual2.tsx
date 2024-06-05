import { useEffect, useState } from "react";
import { PedidoBebida } from "../models/PedidoBebida";
import api from "../api";


interface PedidoProps{
    pedidos: PedidoBebida[]
}


const GetBebidaEmPedidoAtual2: React.FC<PedidoProps> = ({pedidos}) => {
    
    return(
        <div>
            <div>
            <h2>Bebidas:</h2>
                <ul>
                    {pedidos.map((item, index)=> (
                        <li key={index}> Pedido: {item.idPedido} Quantidade: {item.quantidade} - ID Bebida: {item.idBebida }</li>
                    
                    ))}
                </ul>  
            </div>
        </div>
    );
}

export default GetBebidaEmPedidoAtual2;


