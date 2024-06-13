import {  useState } from "react";
import { Ingrediente } from "../../models/Ingrediente";
import { Prato } from "../../models/Prato";
import { IngredientePrato } from "../../models/IngredientePrato";
import api from "../../api";
import axios from "axios";

interface PratoProps{
    pratos: Prato[]
    pedidoId: number
}

const ShowPratosOnPedido: React.FC<PratoProps> = ({pratos, pedidoId})=>{

    const[ingredientePratosOnPedido, setIngredientePratosOnPedido] = useState<IngredientePrato[]>([]);
    const [ingredientesOnPrato, setIngrendientesOnPrato] = useState<Ingrediente[]>([]);
  
    //Mostar todos os PRATOs do pedido
    /** let test = [];

    for(let i=0; i>test.length; i++){
       //test.push(variavel);
    }

    console.log(JSON.stringify(pratos));*/
    
    console.log('tamanho do vetor pratos: ', pratos.length);
  
    const buscaIngredienteOnPratos=async()=>{
        let response;
        for(const index of pratos){
           response = await axios.get('https://localhost:7163/Pedido/api/Busca/PratoEmIngredientePrato?idPrato='+ index.idPrato);
           setIngredientePratosOnPedido(response.data);
            //console.log('entou aqui:', response.data);
        }
        
    };


   /*useEffect(()=>{
        buscaIngredienteOnPratos()
    }, [buscaIngredienteOnPratos, pratos]);
*/
    
   

    return(
        <>
            <div>
                <ul>
                    {pratos.map((item, index) => (
                    <li key={index}>
                    Prato: {item.idPrato} 
                    </li>))}

                </ul>
                <button onClick={() => buscaIngredienteOnPratos()}>mostra ingrediente</button>
            </div>
        </>
    )

}

export default ShowPratosOnPedido;