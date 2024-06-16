import { IngredientePratoListView } from "../../models/IngredientePratoListView";

interface ShowPratosOnPedidoProps{
    ingredientePratosList: IngredientePratoListView[],
    deletePrato: (idPrato: number)=>{},
    editaPrato: (idPrato: number)=>{},

}

const ShowPratosOnPedido: React.FC<ShowPratosOnPedidoProps> = ({ingredientePratosList, deletePrato, editaPrato})=>{

    return(
        <>
            <div>
                <ul>
                    {ingredientePratosList.map((item, index) => (
                    <li key={index}>
                    Prato {item.idPrato} : {item.nomeIngredientes}
                    
                    <button onClick={() => editaPrato(item.idPrato)}>Editar</button>
                    <button onClick={() => deletePrato(item.idPrato)}>Excluir</button>
                    </li>))}

                </ul>

            </div>
        </>
    )

}

export default ShowPratosOnPedido;