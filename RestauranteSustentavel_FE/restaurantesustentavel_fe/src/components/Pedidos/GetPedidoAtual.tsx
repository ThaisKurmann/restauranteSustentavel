import { PedidoSobremesa } from "../../models/PedidoSobremesa";
import MostraSobremesaEmPedido from "../Sobremesas/MostraSobremesasEmPedido";


interface PedidoProps{
    pedidos: PedidoSobremesa[];
}

const GetPedidoAtual: React.FC<PedidoProps> = ({pedidos}) =>{

    
    return(

        <div>
            <h1>PEDIDO ATUAL: </h1>


            <MostraSobremesaEmPedido pedidos={pedidos}/>

             
        </div>
    );

}
export default GetPedidoAtual;
