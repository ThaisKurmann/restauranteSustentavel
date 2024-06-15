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
            <h2>Adicionar Ingredientes ao prato</h2>
                <ul>
                    {ingredientePratosList.map((item, index) => (
                    <li key={index}>
                    Prato {item.idPrato} : {item.nomeIngredientes}
                    <button onClick={() => deletePrato(item.idPrato)}>Excluir</button>
                    <button onClick={() => editaPrato(item.idPrato)}>Editar</button>
                    </li>))}

                </ul>

            </div>
        </>
    )

}

export default ShowPratosOnPedido;