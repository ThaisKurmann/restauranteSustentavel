import { IngredientePratoListView } from "../../models/IngredientePratoListView";

interface PratoProps{
    ingredientePratosList: IngredientePratoListView[],
}

const ShowPratosOnPedido: React.FC<PratoProps> = ({ingredientePratosList})=>{

    return(
        <>
            <div>
                
                <ul>
                    {ingredientePratosList.map((item, index) => (
                    <li key={index}>
                    Prato {item.idPrato} : {item.nomeIngredientes}
                    </li>))}

                </ul>

            </div>
        </>
    )

}

export default ShowPratosOnPedido;