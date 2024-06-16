import { PedidoSobremesa } from "../../models/PedidoSobremesa";



interface PedidoProps{
    pedidoSobremesa: PedidoSobremesa[]
    updateSobremesaOnPedido: (pedidoSobremesa: PedidoSobremesa, increment: Boolean)=>{}

}

const UpdateBebidasOnPedido: React.FC<PedidoProps> = ({pedidoSobremesa, updateSobremesaOnPedido}) => {

   return(
        <div>
            <div>
                <h3>Sobremesas:</h3>
                <ul>
                    {pedidoSobremesa.map((item, index)=> (
                        <li key={index}> Pedido: {item.idPedido} - ID Sobremesa: {item.idSobremesa + ' '} -  Quantidade:{item.quantidade + ' '}
                        
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


