import {  useCallback, useEffect, useState } from "react";
import { Ingrediente } from "../../models/Ingrediente";
import { Prato } from "../../models/Prato";
import { IngredientePrato } from "../../models/IngredientePrato";
import api from "../../api";
import axios from "axios";
import { IngredientePratoListView } from "../../models/IngredientePratoListView";

interface PratoProps{
    pratos: Prato[]
    pedidoId: number
}

const ShowPratosOnPedido: React.FC<PratoProps> = ({pratos, pedidoId})=>{

    const[ingredientePratosOnPedido, setIngredientePratosOnPedido] = useState<IngredientePratoListView[]>([]);
  
  
    //Mostar todos os PRATOs do pedido
    /** let test = [];

    for(let i=0; i>test.length; i++){
       //test.push(variavel);
    }

    console.log(JSON.stringify(pratos));*/
    
    console.log('tamanho do vetor pratos: ', pratos.length);
  
    const buscaPratoIngredienteListView=useCallback(async()=>{
        
        let response = await axios.get('https://localhost:7163/Prato/api/BuscaPratoIngredienteListView?pedidoId='+ pedidoId);
        setIngredientePratosOnPedido(response.data);
        console.log(response.data);
              
    }, [pedidoId]);




   useEffect(()=>{
    buscaPratoIngredienteListView()
    }, [buscaPratoIngredienteListView, pedidoId]);

    
   

    return(
        <>
            <div>
                
                <ul>
                    {ingredientePratosOnPedido.map((item, index) => (
                    <li key={index}>
                    Prato {item.idPrato} : {item.nomeIngredientes}
                    </li>))}

                </ul>

                
                <button onClick={() => buscaPratoIngredienteListView()}>mostra ingrediente</button>
            </div>
        </>
    )

}

export default ShowPratosOnPedido;