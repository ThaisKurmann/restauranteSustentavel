
import GetBebidaEmPedidoAtual from "./GetBebidaEmPedidoAtual";
import GetSobremesaEmPedidoAtual from "./GetSobremesaEmPedidoAtual";


interface PedidoProps{
    pedidoID: number
}

const GetPedidoAtual: React.FC<PedidoProps> = ({pedidoID}) =>{

    
    return(

        <div>
            <h1>PEDIDO ATUAL: </h1>

            <GetBebidaEmPedidoAtual pedidoID={pedidoID}/>

            <GetSobremesaEmPedidoAtual pedidoID={pedidoID}/>
             
        </div>
    );

}
export default GetPedidoAtual;
