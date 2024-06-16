import { useCallback, useEffect, useState } from "react";
import ShowPratosOnPedido from "./ShowPratoOnPedido";
import axios from "axios";
import { IngredientePratoListView } from "../../models/IngredientePratoListView";
import { Ingrediente } from "../../models/Ingrediente";
import api from "../../api";
import { IngredientePrato } from "../../models/IngredientePrato";
import AddIngredienteToPrato from "./AddIngredienteToPrato";
import { Prato } from "../../models/Prato";


interface AddPratoToPedidoProps{
    pedidoId: number,
    updatePrecoTotal:()=>{}
}

const AddPratoToPedido: React.FC<AddPratoToPedidoProps> = ({pedidoId, updatePrecoTotal})=>{

    const [ingredientePratosListView, setIngredientePratosListView] = useState<IngredientePratoListView[]>([]);
    const [ingredientes, setIngredientes] = useState<Ingrediente[]>([])
    const [ingredientesOnPrato, setIngredientesOnPrato] = useState<IngredientePrato[]>([]);
    const [ingredienteSelecionadoId, setIngredienteSelecionadoId] = useState<number | null>(null);
    const [quantidade, setQuantidade] = useState<number>(1);
    const [currentPratoId, setCurrentPratoID] = useState<number | null >(null);

    const createPratoToPedido= useCallback(async()=>{
        
        try{
            const response = await axios.post("https://localhost:7163/Prato/api/InsertPrato?pedidoId=" + pedidoId);
            console.log('prato criado', response.data);
            setCurrentPratoID((response.data as Prato).idPrato);

           // alert('Prato adicionado com sucesso!');

        }catch(error){
            console.error('Erro ao adicionar prato ao pedido no BD', error);
        }
    }, [pedidoId]);

    const updateIngredientePratoListView=useCallback(async(pedidoId: number)=>{
        
        let response = await axios.get('https://localhost:7163/Prato/api/BuscaPratoIngredienteListView?pedidoId='+ pedidoId);
        setIngredientePratosListView(response.data);
        console.log(response.data);
              
    }, []);

    const handleAddPratoToPedido= async()=>{
        createPratoToPedido();
        updateIngredientePratoListView(pedidoId);

    };

    const handleDeletePratoOnPedido=async(idPrato: number)=>{

        try{
            await axios.delete(`https://localhost:7163/Prato/api/DeletePrato?idPrato=${idPrato}`);

        }catch(error){
            console.error("Nao foi possivel excluir prato do pedido!", error);
        }
        updateIngredientePratoListView(pedidoId);
    }

    const handleEditaPratoOnPedido = async(idPrato: number)=>{

            try{
                setCurrentPratoID(idPrato);

            }catch(error){
                console.error("Nao foi possivel editar o prato", error);
            }
    }
    const buscaIngredientes=async()=>{

        try{
            const response = await axios.get("https://localhost:7163/Ingrediente/api/GetAll");
            console.log('AddIngredienteToPRato', response.data);
            setIngredientes(response.data);
            
        }catch(error){
            console.error("Nao foi possivel buscar ingredientes no BD", error);
        }
    }

   

    useEffect(()=>{
        buscaIngredientes()
       updateIngredientePratoListView(pedidoId)
    },[pedidoId, updateIngredientePratoListView, createPratoToPedido])

  
    return(
        <>
        <div>
            <h2>Adicione Pratos: <button onClick={() => handleAddPratoToPedido()}>clique aqui</button></h2>            
            <ShowPratosOnPedido ingredientePratosList={ingredientePratosListView} deletePrato={handleDeletePratoOnPedido} editaPrato={handleEditaPratoOnPedido}/>
            <AddIngredienteToPrato pratoId={currentPratoId} updateIngredientePratoListView={updateIngredientePratoListView} pedidoId={pedidoId} updatePrecoTotal={updatePrecoTotal}/>
        </div>
        </>
    )
}

export default AddPratoToPedido;
