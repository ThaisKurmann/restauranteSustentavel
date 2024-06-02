import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import api from "../api";
import { Bebida } from "../models/Bebida";
import { PedidoBebida } from "../models/PedidoBebida";





const SinglePedidoPage: React.FC=  () => {

    const {id} = useParams();

    const [buscaPedidoPorIdEmPedidoBebida, setbuscaPedidoPorIdEmPedidoBebida] = useState<PedidoBebida[]>([]);
    
    //buscar bebidas que estao no pedido atual
    const buscaPedidoPorId = async () => {
        await api.get("/api/Pedido/BuscaPedidoEmPedidoBebida?idPedido=" + id).then((response) => setbuscaPedidoPorIdEmPedidoBebida(response.data)); 
    };

    //buscar sobremesas que estao no pedido atual
  
    //buscar pratos que estao no pedido atual

    //mostrar codigo da compra (id do pedido)
  
    useEffect(() => {
        buscaPedidoPorId();
    }, []);


    return(
        <div>
            ola
            <ul>
            {buscaPedidoPorIdEmPedidoBebida.map(item => (
              <li key={item.idPedido}>
                { "ID Pedido: " + item.idPedido +  " Quantidade: " + item.quantidade} - {" BebidaId: " + item.idBebida }
              </li>
            ))}
          </ul>
        </div>
    );

}
export default SinglePedidoPage;