import { useEffect, useState } from "react";
import api from "../api";
import { PedidoSobremesa } from "../models/PedidoSobremesa";


interface PedidoProps{
    pedidoID: number
}


const GetSobremesasEmPedidoAtual: React.FC<PedidoProps> = ({pedidoID}) => {

    const [buscaPedidoPorIdEmPedidoSobremesa, setBuscaPedidoPorIdEmPedidoSobremesa] = useState<PedidoSobremesa[]>([]);
    
     //buscar sobremesas que estao no pedido atual
     const buscaSobremesaEmPedido = async () => {
        try{
            await api.get("/api/Pedido/BuscaPedidoPorIdEmPedidoSobremesa?idPedido=" + pedidoID).then((response) => setBuscaPedidoPorIdEmPedidoSobremesa(response.data)); 

        }catch(error){
            console.error('Erro ao buscar sobremesa no BD: ', error);
        }       
    };

    useEffect(()=>{
        buscaSobremesaEmPedido();
    },);


    
    return(
        <div>
            <div>
                <h2>Sobremesas:</h2>
                <ul>
                    {buscaPedidoPorIdEmPedidoSobremesa.map((item, index)=> (
                        <li key={index}> Pedido: {item.idPedido} Quantidade: {item.quantidade} - ID Bebida: {item.idSobremesa }</li>
                    
                    ))}
                </ul>
            </div>
        </div>
    );
}

export default GetSobremesasEmPedidoAtual;