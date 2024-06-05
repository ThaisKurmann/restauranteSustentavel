import { useEffect, useState } from "react";
import { Sobremesa } from "../models/Sobremesa";
import axios from "axios";
import { PedidoSobremesa } from "../models/PedidoSobremesa";


interface AddSobremesaToPedidoProps {
    pedidoId: number;
}

const AddSobremesaToPedido: React.FC<AddSobremesaToPedidoProps> = ({ pedidoId }) => {

    const [sobremesas, setSobremesas] = useState<Sobremesa[]>([]);
    const [sobremesaSelecionadaId, setSobremesaSelecionadaId] = useState<number | null>(null);
    const [quantidade, setQuantidade] = useState<number>(1);

    

        const buscaSobremesas = async () => {
            try {
                const response = await axios.get('https://localhost:7163/Sobremesa/api/GetAll');
                setSobremesas(response.data);
                
            } catch (error) {
                console.error('Erro ao carregar sobremesas no BD:', error);
            }
        };


    useEffect(() => {
        buscaSobremesas();
    }, []);

    const handleAddSobremesa = async () => { 
        if (sobremesaSelecionadaId === null) {
            alert('Selecione uma sobremesa.');
            return;
        }
 
        const pedidoSobremesa: PedidoSobremesa = {
            idSobremesa: sobremesaSelecionadaId,
            idPedido: pedidoId,
            quantidade
        };
       
        try {
            await axios.post('https://localhost:7163/Pedido/api/Insert/PedidoSobremesa', pedidoSobremesa);
            alert('Sobremesa adicionada ao pedido com sucesso!'); //dar um refresh na pag
            
        } catch (error) {
            console.error('Erro ao adicionar sobremesa ao pedido:', error);
        }
    };

    return (
        
        <div>
            <h2>Adicionar Sobremesa ao Pedido</h2>
            <select onChange={(e) => setSobremesaSelecionadaId(Number(e.target.value))} value={sobremesaSelecionadaId ?? ''}>
                <option value="" disabled>Selecione uma sobremesa</option>
                    {sobremesas.map((sobremesa) => (
                    <option key={sobremesa.id} value={sobremesa.id}> 
                    {sobremesa.nome}
                    </option>
                ))}
            </select>
            <input
                type="number"
                value={quantidade}
                onChange={(e) => setQuantidade(Number(e.target.value))}
                min="1"
            />
            <button onClick={() => handleAddSobremesa()}>Adicionar ao Pedido</button>
        </div>
    );
};

export default AddSobremesaToPedido;