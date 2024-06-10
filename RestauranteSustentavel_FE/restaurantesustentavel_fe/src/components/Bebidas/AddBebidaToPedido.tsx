import React, { useState, useEffect, useCallback } from 'react';
import axios from 'axios';
import { Bebida } from '../../models/Bebida';
import { PedidoBebida } from '../../models/PedidoBebida';
import api from '../../api';
import UpdateBebidasOnPedido from './UpdateBebidasOnPedido';

interface AddBebidaToPedidoProps {
    pedidoId: number;
}



//codigo correto
const AddBebidaToPedido: React.FC<AddBebidaToPedidoProps> = ({ pedidoId }) => {

    const [bebidas, setBebidas] = useState<Bebida[]>([]);
    const [bebidaSelecionadaId, setBebidaSelecionadaId] = useState<number | null>(null);
    const [quantidade, setQuantidade] = useState<number>(1);
    const [bebidasOnPedido, setBebidasOnPedido] = useState<PedidoBebida[]>([]);

        const buscaBebidas = async () => {
            try {
                const response = await axios.get('https://localhost:7163/Bebida/api/GetAll');
                setBebidas(response.data);
                console.log(response.data)
            } catch (error) {
                console.error('Erro ao carregar bebidas no BD:', error);
            }
        };

        const updatePedidoBebidas = useCallback(async () => {
            await api.get("/Pedido/api/Busca/PedidoEmPedidoBebida?idPedido=" + pedidoId).then((response) => setBebidasOnPedido(response.data));
        }, [pedidoId])


    useEffect(() => {
        console.log("useEffect on AddBebidaToPedido.tsx");
        buscaBebidas();
        updatePedidoBebidas();
    }, [pedidoId, updatePedidoBebidas]);

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
            await axios.post('https://localhost:7163/Pedido/api/Insert/PedidoBebida', pedidoBebida);
           alert('Bebida adicionada ao pedido com sucesso!'); //dar um refresh na pag
            updatePedidoBebidas();
        } catch (error) {
            console.error('Erro ao adicionar bebida ao pedido:', error);
        }
    };

    const handleButtonBebidasChangeQuantity= async(pedidoBebida: PedidoBebida, increment: Boolean)=>{

        if(increment){
            pedidoBebida.quantidade++;
        }else{
            pedidoBebida.quantidade--;
        }

        await api.put("/Pedido/api/Update/QuantidadeBebidaEmPedidoBebida", pedidoBebida);

        const response = await api.get("/Pedido/api/Busca/PedidoEmPedidoBebida?idPedido=" + pedidoBebida.idPedido);

        setBebidasOnPedido(response.data);
        
    }




    return (
        <>
        <div>
            <h2>Adicionar Bebida ao Pedido</h2>
            <select onChange={(e) => setBebidaSelecionadaId(Number(e.target.value))} value={bebidaSelecionadaId ?? ''}>
                <option value="" disabled>Selecione uma bebida</option>
                {bebidas.map((bebida) => (<option key={bebida.id} value={bebida.id}> {bebida.nome} </option>))}
            </select>
            <input
                type="number"
                value={quantidade}
                onChange={(e) => setQuantidade(Number(e.target.value))}
                min="1"
            />
            <button onClick={() => handleAddBebida()}>Adicionar ao Pedido</button>
        </div>
        <UpdateBebidasOnPedido pedidoBebida= {bebidasOnPedido} updateBebidaOnPedido={handleButtonBebidasChangeQuantity} />
        </>
    );
};

export default AddBebidaToPedido;

