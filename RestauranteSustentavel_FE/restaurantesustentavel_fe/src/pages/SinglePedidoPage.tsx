import { useParams } from "react-router-dom";
import AddBebidaToPedido from "../components/AddBebidaToPedido";
import AddSobremesaToPedido from "../components/AddSobremesaToPedido";
import GetPedido from "../components/GetPedidoAtual";




const SinglePedidoPage: React.FC=  () => {

    const {id} = useParams();
    const pedidoAtualId = Number(id);//converte valor retornado de useParams em number

 
    return(
        <div>
        
          <AddBebidaToPedido pedidoId={pedidoAtualId}/>
          <AddSobremesaToPedido pedidoId={pedidoAtualId}/> 
          <GetPedido pedidoID={pedidoAtualId}/>
          
        </div>
    );

}
export default SinglePedidoPage;