import { useParams } from "react-router-dom";
import AddBebidaToPedido from "../components/Bebidas/AddBebidaToPedido";
import AddSobremesaToPedido from "../components/Sobremesas/AddSobremesaToPedido";
import UpdateBebidasEmPedido from "../components/Bebidas/UpdateBebidaEmPedido";



const SinglePedidoPage: React.FC=  () => {

    const {id} = useParams();
    const pedidoAtualId = Number(id);//converte valor retornado de useParams em number

 
    return(
        <div>
        
          <AddBebidaToPedido pedidoId={pedidoAtualId}/>
          <AddSobremesaToPedido pedidoId={pedidoAtualId}/>
          <UpdateBebidasEmPedido pedidoId={pedidoAtualId}/>
        </div>
    );

}
export default SinglePedidoPage;