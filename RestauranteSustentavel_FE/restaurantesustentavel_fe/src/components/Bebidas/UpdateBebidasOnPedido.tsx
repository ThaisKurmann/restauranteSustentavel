import { PedidoBebida } from "../../models/PedidoBebida";




interface PedidoProps{
    pedidoBebida: PedidoBebida[],
    updateBebidaOnPedido: (pedidoBebida: PedidoBebida, increment: Boolean)=>{}
}





const UpdateBebidasOnPedido: React.FC<PedidoProps> = ({pedidoBebida, updateBebidaOnPedido}) => {

    
    return(
        <div>
            <div>
            <h3>Bebidas:</h3>
                <ul>
                    {pedidoBebida.map((item, index)=> (
                        <li key={index}> Pedido: {item.idPedido}  - ID Bebida: {item.idBebida + ' ' } - Quantidade: {item.quantidade + ' '} 
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


