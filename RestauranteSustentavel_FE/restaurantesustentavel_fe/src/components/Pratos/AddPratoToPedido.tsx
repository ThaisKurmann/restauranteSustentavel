import { useCallback, useEffect, useState } from "react";
import { Prato } from "../../models/Prato";
import api from "../../api";
import ShowPratosOnPedido from "./ShowPratoOnPedido";
import axios from "axios";
import SinglePedidoPage from "../../pages/SinglePedidoPage";


interface PedidoProps{
    pedidoId: number
}

const AddPratoToPedido: React.FC<PedidoProps> = ({pedidoId})=>{

    const [createPrato, setCreatePrato] = useState<Prato>(); 
    const [pedidoPratos, setPedidoPratos] = useState<Prato[]>([]);
   
    const createPratoToPedido= useCallback(async()=>{
        
        try{
            const response = await axios.post("https://localhost:7163/Prato/api/InsertPrato?pedidoId=" + pedidoId);
            setCreatePrato(response.data);
            console.log('prato craido', response.data);
            alert('Prato adicionado com sucesso!');

        }catch(error){
            console.error('Erro ao adicionar prato ao pedido no BD', error);
        }
    }, [pedidoId]);

    //mostrar na tela lista de pratos desse pedido
    const buscaPratosOnPedido= useCallback(async()=>{
        try{
            const response = await api.get('/Prato/api/BuscaPratosEmPedido?idPedido=' + pedidoId);
            console.log(response.data);
            setPedidoPratos(response.data);

        }catch(error){
            console.error('Erro ao buscar pratos no BD do pedido atual', error);
        }
    },[pedidoId]);

    



    const handleAddPratoToPedido= async()=>{
        createPratoToPedido();
        buscaPratosOnPedido();

    };

    useEffect(()=>{
        buscaPratosOnPedido()
    },[pedidoId, buscaPratosOnPedido, createPratoToPedido])

    return(
        <>
        <div>
            <h1>Adicionar Pratos ao Pedido: {pedidoId}</h1>
            <button onClick={() => handleAddPratoToPedido()}>Novo</button>
            <ShowPratosOnPedido pedidoId={pedidoId} pratos={pedidoPratos}/>
       
        </div>
        </>
    )
}

export default AddPratoToPedido;