import { useCallback, useEffect, useState } from "react";
import ShowPratosOnPedido from "./ShowPratoOnPedido";
import axios from "axios";
import { IngredientePratoListView } from "../../models/IngredientePratoListView";


interface PedidoProps{
    pedidoId: number
}

const AddPratoToPedido: React.FC<PedidoProps> = ({pedidoId})=>{

    const[ingredientePratosOnPedido, setIngredientePratosOnPedido] = useState<IngredientePratoListView[]>([]);
   
    const createPratoToPedido= useCallback(async()=>{
        
        try{
            const response = await axios.post("https://localhost:7163/Prato/api/InsertPrato?pedidoId=" + pedidoId);
            console.log('prato criado', response.data);
            alert('Prato adicionado com sucesso!');

        }catch(error){
            console.error('Erro ao adicionar prato ao pedido no BD', error);
        }
    }, [pedidoId]);

    const updateIngredientePratoListView=useCallback(async(pedidoId: number)=>{
        
        let response = await axios.get('https://localhost:7163/Prato/api/BuscaPratoIngredienteListView?pedidoId='+ pedidoId);
        setIngredientePratosOnPedido(response.data);
        console.log(response.data);
              
    }, []);

    const handleAddPratoToPedido= async()=>{
        createPratoToPedido();
        updateIngredientePratoListView(pedidoId);

    };

    const handleDeletePratoToPedido=async(idPrato: number)=>{

        try{
            await axios.delete(`https://localhost:7163/Prato/api/DeletePrato?idPrato=${idPrato}`);

        }catch(error){
            console.error("Nao foi possivel excluir prato do pedido!", error);
        }
        updateIngredientePratoListView(pedidoId);
    }

    useEffect(()=>{
       updateIngredientePratoListView(pedidoId)
    },[pedidoId, updateIngredientePratoListView, createPratoToPedido])

   

    return(
        <>
        <div>
            <h1>Adicionar Pratos ao Pedido: {pedidoId}</h1>
            <button onClick={() => handleAddPratoToPedido()}>Novo</button>
            <ShowPratosOnPedido ingredientePratosList={ingredientePratosOnPedido} deletePrato={handleDeletePratoToPedido}/>
       
        </div>
        </>
    )
}

export default AddPratoToPedido;