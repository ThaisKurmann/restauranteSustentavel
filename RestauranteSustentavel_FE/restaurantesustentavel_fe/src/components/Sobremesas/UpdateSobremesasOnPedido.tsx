import { PedidoSobremesa } from "../../models/PedidoSobremesa";



interface PedidoProps{
    pedidoSobremesa: PedidoSobremesa[]
    updateSobremesaOnPedido: (pedidoSobremesa: PedidoSobremesa, increment: Boolean)=>{}

}

const UpdateBebidasOnPedido: React.FC<PedidoProps> = ({pedidoSobremesa, updateSobremesaOnPedido}) => {

   return(
        <div>
            <div>
            <h2>Sobremesas:</h2>
                <ul>
                    {pedidoSobremesa.map((item, index)=> (
                        <li key={index}> Pedido: {item.idPedido} Quantidade: {item.quantidade} - ID Bebida: {item.idSobremesa }
                        <input type="button" onClick={()=>{updateSobremesaOnPedido(item, false)}} value="-"/>
                        <input type="button" onClick={()=>{updateSobremesaOnPedido(item, true)}} value="+"/>
                        </li>
                    
                    ))}
                </ul>  

            </div>
        </div>
    );
}

export default UpdateBebidasOnPedido;


