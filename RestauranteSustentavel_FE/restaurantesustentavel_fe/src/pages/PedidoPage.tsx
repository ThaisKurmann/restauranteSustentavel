import AddBebidaToPedido from "../components/AddBebidaToPedido";
import { Pedido } from "../models/Pedido";


interface PedidoPageProps{
    pedido: Pedido;
}

const PedidoPage: React.FC<PedidoPageProps> = ({pedido}) => {
    return(
        <div>
            <h1>Pedidos</h1>
            <p>Bem-vindo a agina 'pedidos'!</p>
            <p>ID: {pedido.id}</p>
            <p>Data: {pedido.data}</p>
            <p>Hora: {pedido.hora}</p>
            <AddBebidaToPedido pedidoId={pedido.id} />
        </div>
    );
}


export default PedidoPage;