import CreatePedidoButton from "../components/Pedidos/CreatePedidoButton";
import { Pedido } from "../models/Pedido";

interface PedidoProps{
    pedido: Pedido;
}


const PedidoPage: React.FC<PedidoProps> = ({pedido}) => {

   return(
        <div>
            <div>
                <h1>PEDIDO (API): </h1>
                <p>Bem-vindo a agina 'pedidos'!</p>

                <h2>Criar Pedido: </h2>
                <CreatePedidoButton />
            </div>
        </div>
    );
};


export default PedidoPage;