import React, { useState, useEffect } from 'react';
import axios from 'axios';
import { Bebida } from '../models/Bebida';



const BebidaDeleteApi: React.FC = () => {

    const [bebidas, setBebidas] = useState<Bebida[]>([]);

    // atribui bebidas do servidor no vetor de 'bebidas'
    const loadBebidas = async () => {
        try {
            const response = await axios.get('https://localhost:7163/Bebida/GetAll');
            setBebidas(response.data);
        } catch (error) {
            console.error('Erro ao carregar bebidas:', error);
        }
    };

    // Carregar as bebidas quando o componente for montado
    useEffect(() => {
        loadBebidas();
    }, []);

    // Função para excluir uma bebida
    const handleDelete = async (id: number) => {
        try {
            await axios.delete(`https://localhost:7163/Bebida/Delete?i=${id}`);
            // Atualizar a lista de bebidas após a exclusão
            setBebidas(bebidas.filter(bebida => bebida.id !== id));
        } catch (error) {
            console.error('Erro ao excluir bebida no:', error);
        }
    };

    return (
        <div>
            <ul>
                {bebidas.map(bebida => (
                    <li key={bebida.id}>
                        {bebida.nome} - R$ {bebida.preco.toFixed(2)} - {bebida.alcoolica ? 'Alcoólica' : 'Não Alcoólica'} - ID: {bebida.id}
                        <button onClick={() => handleDelete(bebida.id)}>Excluir</button>
                    </li>
                ))}
            </ul>
        </div>
    );
};

export default BebidaDeleteApi;
