import { useEffect, useState } from "react";
import { PedidoBebida } from "../../models/PedidoBebida";
import api from "../../api";
import { PedidoSobremesa } from "../../models/PedidoSobremesa";



interface PedidoProps{
    pedidoBebida: PedidoBebida[]

}

const UpdateBebidasOnPedido: React.FC<PedidoProps> = ({pedidoBebida}) => {

    const [pedidosIntern, setPedidoBebidaIntern] = useState<PedidoBebida[]>(pedidoBebida);

    //updateBebidas
    const handleButtonBebidasChangeQuantity= async(pedidoBebida: PedidoBebida, increment: Boolean)=>{

        if(increment){
            pedidoBebida.quantidade++;
        }else{
            pedidoBebida.quantidade--;
        }

        await api.put("/Pedido/api/Update/QuantidadeBebidaEmPedidoBebida", pedidoBebida);

        const response = await api.get("/Pedido/api/Busca/PedidoEmPedidoBebida?idPedido=" + pedidoBebida.idPedido);

        setPedidoBebidaIntern(response.data);
        
    }

    useEffect(()=>{
        setPedidoBebidaIntern(pedidoBebida)
    }, [pedidoBebida])

    return(
        <div>
            <div>
            <h1>Carrinho de compra:</h1>
            <h2>Bebidas:</h2>
                <ul>
                    {pedidosIntern.map((item, index)=> (
                        <li key={index}> Pedido: {item.idPedido} Quantidade: {item.quantidade} - ID Bebida: {item.idBebida }
                        <input type="button" onClick={()=>{handleButtonBebidasChangeQuantity(item, false)}} value="-"/>
                        <input type="button" onClick={()=>{handleButtonBebidasChangeQuantity(item, true)}} value="+"/>
                        </li>
                    
                    ))}
                </ul>  

            </div>
        </div>
    );
}

export default UpdateBebidasOnPedido;


