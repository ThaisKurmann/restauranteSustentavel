import { PedidoSobremesa } from "../../models/PedidoSobremesa";



interface PedidoProps{
    pedidos: PedidoSobremesa[];
}

const MostraSobremesaEmPedido: React.FC<PedidoProps> = ({pedidos}) => {
    
    return(
        <div>
            <div>
            <h2>Sobremesas:</h2>
                <ul>
                    {pedidos.map((item, index)=> (
                        <li key={index}> Pedido: {item.idPedido} Quantidade: {item.quantidade} - ID Bebida: {item.idSobremesa }</li>
                    
                    ))}
                </ul>  
            </div>
        </div>
    );
}

export default MostraSobremesaEmPedido;


