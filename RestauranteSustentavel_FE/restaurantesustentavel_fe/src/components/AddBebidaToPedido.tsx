import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Bebida } from '../models/Bebida';
import { PedidoBebida } from '../models/PedidoBebida';

interface AddBebidaToPedidoProps {
    pedidoId: number;
}

const AddBebidaToPedido: React.FC<AddBebidaToPedidoProps> = ({ pedidoId }) => {
    const [bebidas, setBebidas] = useState<Bebida[]>([]);
    const [bebidaSelecionadaId, setBebidaSelecionadaId] = useState<number | null>(null);
    const [quantidade, setQuantidade] = useState<number>(1);

    useEffect(() => {
        const buscaBebidas = async () => {
            try {
                const response = await axios.get('https://localhost:7163/Bebida/GetAll');
                setBebidas(response.data);
            } catch (error) {
                console.error('Erro ao carregar bebidas no BD:', error);
            }
        };

        buscaBebidas();

    }, []);

    const handleAddBebida = async () => {
        if (bebidaSelecionadaId === null) {
            alert('Selecione uma bebida.');
            return;
        }

        const pedidoBebida: PedidoBebida = {
            idBebida: bebidaSelecionadaId,
            idPedido: pedidoId,
            quantidade,
        };

        try {
            await axios.post('https://localhost:7163/api/Pedido/InsertPedidoBebida', pedidoBebida);
            alert('Bebida adicionada ao pedido com sucesso!');
        } catch (error) {
            console.error('Erro ao adicionar bebida ao pedido:', error);
        }
    };

    return (
        <div>
            <h2>Adicionar Bebida ao Pedido</h2>
            <select onChange={(e) => setBebidaSelecionadaId(Number(e.target.value))} value={bebidaSelecionadaId ?? ''}>
                <option value="" disabled>Selecione uma bebida</option>
                {bebidas.map((bebida) => (
                    <option key={bebida.id} value={bebida.id}>
                        {bebida.nome}
                    </option>
                ))}
            </select>
            <input
                type="number"
                value={quantidade}
                onChange={(e) => setQuantidade(Number(e.target.value))}
                min="1"
            />
            <button onClick={handleAddBebida}>Adicionar ao Pedido</button>
        </div>
    );
};

export default AddBebidaToPedido;
