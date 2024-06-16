

interface PrecoTotalPedidoProps{
    preco: number
}


const PrecoTotalPedido: React.FC<PrecoTotalPedidoProps> =({preco})=>{

        return(<>
            <div>
                preco: {preco}
            </div>        

        
        </>)
}
export default PrecoTotalPedido;