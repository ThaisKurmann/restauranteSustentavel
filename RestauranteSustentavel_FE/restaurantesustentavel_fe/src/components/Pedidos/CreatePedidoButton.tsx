import React from 'react';
import { useNavigate } from 'react-router-dom';
import axios from 'axios';

const CreatePedidoButton: React.FC = () => {
    const navigate = useNavigate();

    const handleCreatePedido = async () => {
        try {
            const response = await axios.post('https://localhost:7163/Pedido/api/Insert', {
                data: new Date().toISOString().split('T')[0], // Exemplo de data
                hora: new Date().toLocaleTimeString('pt-BR', { hour: '2-digit', minute: '2-digit' }), // Exemplo de hora
            });
            const pedidoId = response.data.id;
            console.log(response.data.id);
            navigate(`/pedido/${pedidoId}`);
        } catch (error) {
            console.error('Erro ao criar pedido:', error);
        }
    };

    return (
        <button onClick={handleCreatePedido}>Fazer Pedido</button>
    );
};

export default CreatePedidoButton;
