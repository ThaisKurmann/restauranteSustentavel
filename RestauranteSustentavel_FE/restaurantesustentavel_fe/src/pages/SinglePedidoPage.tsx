import { useParams } from "react-router-dom";
import AddBebidaToPedido from "../components/Bebidas/AddBebidaToPedido";
import AddSobremesaToPedido from "../components/Sobremesas/AddSobremesaToPedido";
import AddPratoToPedido from "../components/Pratos/AddPratoToPedido";
import PrecoTotalPedido from "../components/Pedidos/PrecoTotalPedido";
import { useCallback, useEffect, useState } from "react";
import axios from "axios";

const SinglePedidoPage: React.FC=  () => {
    const[precoTotal, setPrecoTotal] = useState<number>(0);
    const {id} = useParams();
    const pedidoAtualId = Number(id);//converte valor retornado de useParams em number

    const buscaPrecoTotal=useCallback(async()=>{
      const response = await axios.get("https://localhost:7163/Pedido/api/Get/PrecoTotalDoPedido?idPedido=" + pedidoAtualId);
      console.log('preco total:', response.data);
      setPrecoTotal(response.data);
    }, [pedidoAtualId])

    useEffect(() => {
      buscaPrecoTotal();
    }, [buscaPrecoTotal, pedidoAtualId]);


    return(
        <div>
          <h1>Pedido: {pedidoAtualId}</h1>
          <AddPratoToPedido pedidoId={pedidoAtualId} updatePrecoTotal={buscaPrecoTotal} />
          <AddBebidaToPedido pedidoId={pedidoAtualId} updatePrecoTotal={buscaPrecoTotal}/>
          <AddSobremesaToPedido pedidoId={pedidoAtualId} updatePrecoTotal={buscaPrecoTotal}/>
          <PrecoTotalPedido preco={precoTotal}/>
      
        </div>
    );

}
export default SinglePedidoPage;