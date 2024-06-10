import React, { useState, useEffect, useCallback } from 'react';
import { Bebida } from '../../models/Bebida';
import { PedidoBebida } from '../../models/PedidoBebida';
import api from '../../api';
import MostraBebidaEmPedido from './MostraBebidaEmPedido';
import DeleteBebidasEmPedido from './DeleteBebidasEmPedido';

export interface PedidoProps{
    pedidoId: number
}

const UpdateBebidasEmPedido: React.FC<PedidoProps> = ({pedidoId}) => {

    const [bebidaSelecionadaId, setBebidaSelecionadaId] = useState<number | null>(null);
    const [quantidade, setQuantidade] = useState<number>(1);
    const [bebidasIdOnPedido, setBebidasIdOnPedido] = useState<PedidoBebida[]>([]);
    
     //busca bebidas do pedido atual
     const  updateBebidasEmPedido = useCallback(async ()=>{
        try{
            const response = await api.get("/Pedido/api/Busca/PedidoEmPedidoBebida?idPedido=" + pedidoId);
            setBebidasIdOnPedido(response.data);
            console.log('bebidas no pedido:', response.data);

       
        }catch(error){
            console.error('Naso foi possivel buscar bebidas no pedido atual', error );
        }

     },[ pedidoId]);

     
    useEffect(() => {
        console.log("useEffect on UpdateBebidaToPedido.tsx");
        updateBebidasEmPedido();
    }, [pedidoId, updateBebidasEmPedido]);

    
     const handleUpdateBebida = async () =>{

        if(bebidaSelecionadaId === null){
            alert('Selecione para excluir');
            return;
        }

        const bebidaSelecionada: PedidoBebida={
            idBebida: bebidaSelecionadaId,
            idPedido: pedidoId,
            quantidade
        };

        try{
            //excluir as bebidas selecioandas
            const response =  await api.put("/Pedido/api/Update/QuantidadeBebidaEmPedidoBebida?quantidadeRemover="+ bebidaSelecionada.quantidade);
            //atualizar a quantidade de bebidas no pedido atual
            console.log('quantidade a remover no BD: ', response.data);
            updateBebidasEmPedido();

        }catch(error){
            console.error('Erro ao tentar excluir bebida no BD', error);
        }
     };


    return(
    <>
        
        <div>
            <h1>Altere seu pedido: {pedidoId}</h1>
            <select onChange={(e) => setBebidaSelecionadaId(Number(e.target.value))} value={bebidaSelecionadaId ?? ''}>
                <option value="" disabled>Selecione uma bebida</option>
                {bebidasIdOnPedido.map((bebida, index) => (<option key={index} value={bebida.idBebida}> </option>))}
            </select>
            <input
                type="number"
                value={quantidade}
                onChange={(e) => setQuantidade(Number(e.target.value))}
                min="1"
            />
            <button onClick={() => handleUpdateBebida()}>Alterar</button>
        </div>
        
    </>
    );
};

export default UpdateBebidasEmPedido;
