import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import AddBebidaToPedido from "../components/AddBebidaToPedido";
import AddSobremesaToPedido from "../components/AddSobremesaToPedido";
import GetPedido from "../components/GetPedidoAtual";





const SinglePedidoPage: React.FC=  () => {

    const {id} = useParams();
    const pedidoAtualId = Number(id);//converte valor retornado de useParams em number

 
  
    useEffect(() => {
       
    }, []);


    return(
        <div>
          <div>
            <AddBebidaToPedido pedidoId={pedidoAtualId}/>
          </div>

           <AddSobremesaToPedido pedidoId={pedidoAtualId}/>

          
          <div>
            <GetPedido pedidoID={pedidoAtualId}/>
          </div>
        </div>
    );

}
export default SinglePedidoPage;