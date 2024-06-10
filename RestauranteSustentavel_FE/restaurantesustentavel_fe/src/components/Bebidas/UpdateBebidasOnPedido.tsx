import { useEffect, useState } from "react";
import { PedidoBebida } from "../../models/PedidoBebida";
import api from "../../api";



interface PedidoProps{
    pedidoBebida: PedidoBebida[],
    updateBebidaOnPedido: (pedidoBebida: PedidoBebida, increment: Boolean)=>{}
}

const UpdateBebidasOnPedido: React.FC<PedidoProps> = ({pedidoBebida, updateBebidaOnPedido}) => {

    
    return(
        <div>
            <div>
            <h1>Carrinho de compra:</h1>
            <h2>Bebidas:</h2>
                <ul>
                    {pedidoBebida.map((item, index)=> (
                        <li key={index}> Pedido: {item.idPedido} Quantidade: {item.quantidade} - ID Bebida: {item.idBebida }
                        <input type="button" onClick={()=>{updateBebidaOnPedido(item, false)}} value="-"/>
                        <input type="button" onClick={()=>{updateBebidaOnPedido(item, true)}} value="+"/>
                       
                        
                        </li>
                    
                    ))}
                </ul>  

            </div>
        </div>
    );
}

export default UpdateBebidasOnPedido;


