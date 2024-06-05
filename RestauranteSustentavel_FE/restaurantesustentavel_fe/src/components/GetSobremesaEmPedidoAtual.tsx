import { useEffect, useState } from "react";
import api from "../api";
import { PedidoSobremesa } from "../models/PedidoSobremesa";


interface PedidoProps{
    pedidoID: number
}


const GetSobremesasEmPedidoAtual: React.FC<PedidoProps> = ({pedidoID}) => {

    const [buscaPedidoPorIdEmPedidoSobremesa, setBuscaPedidoPorIdEmPedidoSobremesa] = useState<PedidoSobremesa[]>([]);
    
    useEffect(()=>{
         //buscar sobremesas que estao no pedido atual
      async function buscaSobremesaEmPedido(){
        try{
            const response = await api.get("/Pedido/api/Busca/PedidoPorIdEmPedidoSobremesa?idPedido=" + pedidoID)
            setBuscaPedidoPorIdEmPedidoSobremesa(response.data); 

            console.log('entrou aqui sobremesa');

        }catch(error){
            console.error('Erro ao buscar sobremesa no BD: ', error);
        }       
    };

        buscaSobremesaEmPedido();

    },[pedidoID]);

  


    
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