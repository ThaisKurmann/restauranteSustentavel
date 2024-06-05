import { useEffect, useState } from "react";
import api from "../api";
import { PedidoBebida } from "../models/PedidoBebida";


interface PedidoProps{
    pedidoID: number
}

const GetPedido: React.FC<PedidoProps> = ({pedidoID}) =>{

    const [buscaPedidoPorIdEmPedidoBebida, setbuscaPedidoPorIdEmPedidoBebida] = useState<PedidoBebida[]>([]);
    
    //buscar bebidas que estao no pedido atual
    const buscaPedidoPorId = async () => {
        await api.get("/api/Pedido/BuscaPedidoEmPedidoBebida?idPedido=" + pedidoID).then((response) => setbuscaPedidoPorIdEmPedidoBebida(response.data)); 
       
    };

    useEffect(() => {
        buscaPedidoPorId();
    }, []);

    return(

        <div>
            <h1>PEDIDO ATUAL: </h1>
            <div>
                <h2>Bebidas:</h2>
                <ul>
                    {buscaPedidoPorIdEmPedidoBebida.map(item => (
                        <li key={item.idPedido}> ID Pedido: {item.idPedido} Quantidade: {item.quantidade} - ID Bebida: {" BebidaId: " + item.idBebida }</li>
                    ))}
                </ul>
            </div>

        </div>
    );

}
export default GetPedido;
