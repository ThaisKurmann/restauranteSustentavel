import { IngredientePratoListView } from "../../models/IngredientePratoListView";

interface PratoProps{
    ingredientePratosList: IngredientePratoListView[],
    //receber metodo deletePrato como parametro de entrada
    deletePrato: (idPrato: number)=>{}
}

const ShowPratosOnPedido: React.FC<PratoProps> = ({ingredientePratosList, deletePrato})=>{

    return(
        <>
            <div>
                
                <ul>
                    {ingredientePratosList.map((item, index) => (
                    <li key={index}>
                    Prato {item.idPrato} : {item.nomeIngredientes}
                    <button onClick={() => deletePrato(item.idPrato)}>Excluir</button>
                    </li>))}

                </ul>

            </div>
        </>
    )

}

export default ShowPratosOnPedido;