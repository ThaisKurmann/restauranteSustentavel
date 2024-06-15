import { IngredientePrato } from "../../models/IngredientePrato";


interface UpdateIngredientesOnPratoProps{
    ingredientePrato: IngredientePrato[],
    updateIngredienteOnPrato: (ingrdientePrato: IngredientePrato, increment: Boolean)=>{}
}

const UpdateIngredientesOnPrato: React.FC<UpdateIngredientesOnPratoProps> = ({ingredientePrato, updateIngredienteOnPrato}) => {

    
    return(
        <div>
            <div>
            <h1>Carrinho de compra:</h1>
            <h2>Bebidas:</h2>
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