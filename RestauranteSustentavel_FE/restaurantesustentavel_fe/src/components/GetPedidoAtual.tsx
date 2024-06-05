
import GetBebidaEmPedidoAtual from "./GetBebidaEmPedidoAtual";


interface PedidoProps{
    pedidoID: number
}

const GetPedidoAtual: React.FC<PedidoProps> = ({pedidoID}) =>{

    
    return(

        <div>
            <h1>PEDIDO ATUAL: </h1>

            <GetBebidaEmPedidoAtual pedidoID={pedidoID}/>

             
        </div>
    );

}
export default GetPedidoAtual;
