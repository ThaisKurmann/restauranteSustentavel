import { useCallback, useEffect, useState } from "react";
import api from "../../api";
import { Ingrediente } from "../../models/Ingrediente";
import axios from "axios";
import { IngredientePrato } from "../../models/IngredientePrato";
import UpdateIngredientesOnPrato from "./UpdateIngredientesOnPrato";

interface AddIngredienteToPratoProps{
    pratoId: number | null,
    pedidoId: number,
    updateIngredientePratoListView: (pedidoId: number)=>{}
    updatePrecoTotal: ()=>{}
}


const AddIngredienteToPrato: React.FC<AddIngredienteToPratoProps> = ({pratoId, pedidoId, updateIngredientePratoListView, updatePrecoTotal})=>{

    const [ingredientes, setIngredientes] = useState<Ingrediente[]>([])
    const [ingredienteSelecionadoId, setIngredienteSelecionadoId] = useState<number | null>(null);
    const [quantidade, setQuantidade] = useState<number>(1);
    const [ingredientesOnPrato, setIngredientesOnPrato] = useState<IngredientePrato[]>([]);

    const buscaIngredientes=async()=>{

        try{
            const response = await axios.get("https://localhost:7163/Ingrediente/api/GetAll");
            console.log('AddIngredienteToPRato', response.data);
            setIngredientes(response.data);
            
        }catch(error){
            console.error("Nao foi possivel buscar ingredientes no BD", error);
        }
    }


    const updateIngredientesOnPrato = useCallback(async()=>{
        
        if(pratoId !== null){//busca somente se jah tiver ingredientes no prato
            const response = await axios.get("https://localhost:7163/Pedido/api/Busca/PratoEmIngredientePrato?idPrato=" + pratoId);
            setIngredientesOnPrato(response.data);
            

        }

    }, [pratoId])



    const handleAddIngrediente = async (pratoId: number)=>{
        if (ingredienteSelecionadoId === null) {
            alert('Selecione um ingrediente.');
            return;
        }

        const ingredientePrato: IngredientePrato = {
           idIngrediente: ingredienteSelecionadoId,
           idPrato: pratoId!,//garante que nao eh um valor nulo
           quantidade
        };
        try {
            await axios.post('https://localhost:7163/Pedido/api/Insert/IngredientePrato', ingredientePrato);
           updateIngredientePratoListView(pedidoId);
           updateIngredientesOnPrato();
           updatePrecoTotal();

        } catch (error) {
            console.error('Erro ao adicionar ingrediente ao prato:', error);
        }

    }
    const handleButtonIngredientesChangeQuantity= async(ingredientePrato: IngredientePrato, increment: Boolean)=>{

        if(increment){
            ingredientePrato.quantidade++;
        }else{
            ingredientePrato.quantidade--;
        }
        console.log("asdasdasd", ingredientePrato)
        await api.put("/Prato/api/Update/QuantidadeIngredienteEmIngredientePrato", ingredientePrato);

        updateIngredientePratoListView(pedidoId);
        updateIngredientesOnPrato();
        updatePrecoTotal();
        
    }
    
    useEffect(()=>{
        buscaIngredientes()
        updateIngredientesOnPrato()
    },[pratoId, updateIngredientesOnPrato])


    //FAZER: se pedido tem pratos, mude a mensagem para: selecione um prato ou prato nao selecionado
    //se pedido tem zero pratos: msg-> nao ha pratos 
    
    if(pratoId === null){
        return(<>
                <h4>**</h4>
        
        </>)
    }

return(
    <>
        <div>
            <h2>Adicionar Ingredientes ao prato: {pratoId}</h2>
            <select onChange={(e) => setIngredienteSelecionadoId(Number(e.target.value))} value={ingredienteSelecionadoId ?? ''}>
                <option value="" disabled>Selecione um ingrediente</option>
                {ingredientes.map((ingrediente) => (<option key={ingrediente.id} value={ingrediente.id}> {ingrediente.nome} [R$ {ingrediente.preco}]</option>))}
            </select>
            <input
                type="number"
                value={quantidade}
                onChange={(e) => setQuantidade(Number(e.target.value))}
                min="1"
            />
            <button onClick={() => handleAddIngrediente(pratoId)}>Adicionar ao Prato</button>
        </div>
        <UpdateIngredientesOnPrato ingredientePrato={ingredientesOnPrato} updateIngredienteOnPrato={handleButtonIngredientesChangeQuantity}/>
    </>

)
}


export default AddIngredienteToPrato;

