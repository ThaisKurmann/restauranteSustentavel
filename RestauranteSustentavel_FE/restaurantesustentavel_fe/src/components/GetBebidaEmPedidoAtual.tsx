import { useEffect, useState } from "react";
import { PedidoBebida } from "../models/PedidoBebida";
import api from "../api";


interface PedidoProps{
    pedidoID: number
}


const GetBebidaEmPedidoAtual: React.FC<PedidoProps> = ({pedidoID}) => {

    const [buscaPedidoPorIdEmPedidoBebida, setBuscaPedidoPorIdEmPedidoBebida] = useState<PedidoBebida[]>([]);
    
     //buscar bebidas que estao no pedido atual
     const buscaBebidasEmPedido = async () => {
        await api.get("/api/Pedido/BuscaPedidoEmPedidoBebida?idPedido=" + pedidoID).then((response) => setBuscaPedidoPorIdEmPedidoBebida(response.data)); 
       
    };

    useEffect(()=>{
        buscaBebidasEmPedido();
    },);


    
    return(
        <div>
            <div>
                <h2>Bebidas:</h2>
                <ul>
                    {buscaPedidoPorIdEmPedidoBebida.map((item, index)=> (
                        <li key={index}> Pedido: {item.idPedido} Quantidade: {item.quantidade} - ID Bebida: {item.idBebida }</li>
                    
                    ))}
                </ul>
            </div>
        </div>
    );
}

export default GetBebidaEmPedidoAtual;