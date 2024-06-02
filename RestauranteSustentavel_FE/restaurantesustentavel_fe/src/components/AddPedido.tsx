import React, { useState } from 'react';
import axios from 'axios';
import { Pedido } from '../models/Pedido';
import { createTypeReferenceDirectiveResolutionCache } from 'typescript';

const AddPedido: React.FC = () => {
    const [data, setData] = useState<string>('');
    const [hora, setHora] = useState<string>('');
    const [mensagem, setMensagem] = useState<string>('');

    const handleAddPedido = async () => {
        const novoPedido: Omit<Pedido, 'id'> = {
            data,
            hora
        };

        try {
            const response = await axios.post('https://localhost:7163/api/Pedido/Insert', novoPedido);
            setMensagem('Pedido adicionado: ID: ' + response.data.id + ' Data :' + response.data.data + ' Hora : ' + response.data.hora);
            setData('');
            setHora('');
        } catch (error) {
            console.error('Erro ao adicionar pedido:', error);
            setMensagem('Nao foi possivel add pedido');
        }
    };
    
    console.log('addPedido');

    return (
        <div>
            
            <form onSubmit={(e) => {e.preventDefault(); handleAddPedido();}}>
                <div>
                    <label htmlFor="data">Data:</label>
                    <input
                        id="data"
                        type="date"
                        value={data}
                        onChange={(e) => setData(e.target.value)}
                    />
                </div>
                <div>
                    <label htmlFor="hora">Hora:</label>
                    <input
                        id="hora"
                        type="time"
                        value={hora}
                        onChange={(e) => setHora(e.target.value)}
                    />
                </div>
                <button type="submit">Adicionar Pedido</button>
            </form>
        </div>
    );
};

export default AddPedido;
