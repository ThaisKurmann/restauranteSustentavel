


import { useEffect, useState } from "react";
import api from "../../api";
import { PedidoSobremesa } from "../../models/PedidoSobremesa";



interface PedidoProps{
    pedidos: PedidoSobremesa[]

}

const UpdateBebidasOnPedido: React.FC<PedidoProps> = ({pedidos}) => {

    const [pedidosSobremesaIntern, setPedidoSobremesaIntern] = useState<PedidoSobremesa[]>(pedidos);

    //updateBebidas
    const handleButtonSobremesasChangeQuantity= async(pedidoSobremesa: PedidoSobremesa, increment: Boolean)=>{

        if(increment){
            pedidoSobremesa.quantidade++;
        }else{
            pedidoSobremesa.quantidade--;
        }

        await api.put("/Pedido/api/Update/QuantidadeDeSobremesaEmPedidoSobremesa", pedidoSobremesa);

        const response = await api.get("/Pedido/api/Busca/PedidoPorIdEmPedidoSobremesa?idPedido=" + pedidoSobremesa.idPedido);

        setPedidoSobremesaIntern(response.data);
        
    }

    useEffect(()=>{
        setPedidoSobremesaIntern(pedidos)
    }, [pedidos])

    return(
        <div>
            <div>
            <h1>Carrinho de compra:</h1>
            <h2>Sobremesas:</h2>
                <ul>
                    {pedidosSobremesaIntern.map((item, index)=> (
                        <li key={index}> Pedido: {item.idPedido} Quantidade: {item.quantidade} - ID Bebida: {item.idSobremesa }
                        <input type="button" onClick={()=>{handleButtonSobremesasChangeQuantity(item, false)}} value="-"/>
                        <input type="button" onClick={()=>{handleButtonSobremesasChangeQuantity(item, true)}} value="+"/>
                        </li>
                    
                    ))}
                </ul>  

            </div>
        </div>
    );
}

export default UpdateBebidasOnPedido;


