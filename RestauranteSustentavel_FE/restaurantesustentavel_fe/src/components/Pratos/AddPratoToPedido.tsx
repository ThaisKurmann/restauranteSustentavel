import { useCallback, useEffect, useState } from "react";
import { Prato } from "../../models/Prato";
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


    const buscaIngredientePratoListView=useCallback(async(pedidoId: number)=>{
        
        let response = await axios.get('https://localhost:7163/Prato/api/BuscaPratoIngredienteListView?pedidoId='+ pedidoId);
        setIngredientePratosOnPedido(response.data);
        console.log(response.data);
              
    }, []);


    const handleAddPratoToPedido= async()=>{
        createPratoToPedido();
        buscaIngredientePratoListView(pedidoId);

    };

    useEffect(()=>{
       buscaIngredientePratoListView(pedidoId)
    },[pedidoId, buscaIngredientePratoListView, createPratoToPedido])

    return(
        <>
        <div>
            <h1>Adicionar Pratos ao Pedido: {pedidoId}</h1>
            <button onClick={() => handleAddPratoToPedido()}>Novo</button>
            <ShowPratosOnPedido ingredientePratosList={ingredientePratosOnPedido}/>
       
        </div>
        </>
    )
}

export default AddPratoToPedido;