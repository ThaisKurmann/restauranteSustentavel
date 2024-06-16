import { IngredientePrato } from "../../models/IngredientePrato";


interface UpdateIngredientesOnPratoProps{
    ingredientePrato: IngredientePrato[],
    updateIngredienteOnPrato: (ingrdientePrato: IngredientePrato, increment: Boolean)=>{}
}

const UpdateIngredientesOnPrato: React.FC<UpdateIngredientesOnPratoProps> = ({ingredientePrato, updateIngredienteOnPrato}) => {

    console.log("componente UpdateIngredienteOnPrato:", ingredientePrato)
    
    return(
        <div>
            <div>
            <h3>Ingredientes:</h3>
                <ul>
                    {ingredientePrato.map((ingrediente, index)=> (
                        <li key={index}> Prato: {ingrediente.idPrato} Quantidade: {ingrediente.quantidade} - ID Ingrediente: {ingrediente.idIngrediente }
                        <input type="button" onClick={()=>{updateIngredienteOnPrato(ingrediente, false)}} value="-"/>
                        <input type="button" onClick={()=>{updateIngredienteOnPrato(ingrediente, true)}} value="+"/>
                       
                        </li>
                    
                    ))}
                </ul>  

            </div>
        </div>
    );
}

export default UpdateIngredientesOnPrato;