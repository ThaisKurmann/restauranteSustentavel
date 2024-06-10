import { useEffect, useState } from "react";
import { PedidoBebida } from "../../models/PedidoBebida";
import api from "../../api";



interface PedidoProps{
    pedidos: PedidoBebida[]

}

const MostraBebidaEmPedido: React.FC<PedidoProps> = ({pedidos}) => {

    const [pedidosIntern, setPedidosIntern] = useState<PedidoBebida[]>(pedidos);

    
    const handleButtonBebidaChangeQuantity= async(pedidoBebida: PedidoBebida, increment: Boolean)=>{

        if(increment){
            pedidoBebida.quantidade++;
        }else{
            pedidoBebida.quantidade--;
        }

        await api.put("/Pedido/api/Update/QuantidadeBebidaEmPedidoBebida", pedidoBebida);

        const response = await api.get("/Pedido/api/Busca/PedidoEmPedidoBebida?idPedido=" + pedidoBebida.idPedido);

        setPedidosIntern(response.data);
        
    }

    useEffect(()=>{
        setPedidosIntern(pedidos)
    }, [pedidos])

    return(
        <div>
            <div>
            <h1>Carrinho de compra:</h1>
            <h2>Bebidas:</h2>
                <ul>
                    {pedidosIntern.map((item, index)=> (
                        <li key={index}> Pedido: {item.idPedido} Quantidade: {item.quantidade} - ID Bebida: {item.idBebida }
                        <input type="button" onClick={()=>{handleButtonBebidaChangeQuantity(item, false)}} value="-"/>
                        <input type="button" onClick={()=>{handleButtonBebidaChangeQuantity(item, true)}} value="+"/>
                        </li>
                    
                    ))}
                </ul>  
                
            </div>
        </div>
    );
}

export default MostraBebidaEmPedido;


