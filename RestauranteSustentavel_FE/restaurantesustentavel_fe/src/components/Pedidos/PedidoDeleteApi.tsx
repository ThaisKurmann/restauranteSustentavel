import { useEffect, useState } from "react";
import { Pedido } from "../../models/Pedido";
import axios from "axios";


const PedidoDeleteApi: React.FC = () =>{

        const[pedidos, setPedidos] = useState<Pedido[]>([]);

        const loadPedidos = async () => {
            try{
                const response = await axios.get('https://localhost:7163/api/Pedido/GetAll');
                setPedidos(response.data);
            }catch(error){
                console.error('Erro ao carregar pedidos na API: ', error);
            }
        };

        //carrega os pedidos quando o compoenente for montado
        useEffect(() =>{
            loadPedidos();
        }, []);

        //exclui pedidos
        const handleDeletePedido = async (id: number) => {
                try{
                    await axios.delete(`https://localhost:7163/Pedido/api/Delete?i=${id}`);
                    // Atualizar a lista de pedidos após a exclusão
                    console.log('entrou aqui' + id);
                    setPedidos(pedidos.filter(pedido => pedido.id !== id));

                    
                }
                catch(error){
                    console.error('Erro ao excluir pedido da API: ', error);
                }
     
        };
         
     

    return (
        <div>
            <ul>
                {pedidos.map(pedido => (
                    <li key={pedido.id}>
                        ID: {pedido.id} - Data: {pedido.data} - Hora: {pedido.hora}
                        <button onClick={() => handleDeletePedido(pedido.id)}>Excluir</button>
                    </li>
                ))}
            </ul>
        </div>
    )
};

export default PedidoDeleteApi;