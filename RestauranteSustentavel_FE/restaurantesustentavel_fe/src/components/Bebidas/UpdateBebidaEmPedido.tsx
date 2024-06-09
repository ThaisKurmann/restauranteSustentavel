import React, { useState, useEffect, useCallback } from 'react';
import { Bebida } from '../../models/Bebida';
import { PedidoBebida } from '../../models/PedidoBebida';
import api from '../../api';
import MostraBebidaEmPedido from './MostraBebidaEmPedido';

export interface PedidoProps{
    pedidoId: number
}

const UpdateBebidasEmPedido: React.FC<PedidoProps> = ({pedidoId}) => {


    const [Nomebebidas, setNomeBebidas] = useState<Bebida[]>([]);
    const [bebidaSelecionadaId, setBebidaSelecionadaId] = useState<number | null>(null);
    const [quantidade, setQuantidade] = useState<number>(1);
    const [bebidasOnPedido, setBebidasOnPedido] = useState<PedidoBebida[]>([]);

    
     //busca bebidas do pedido atual
     const  updateBebidasEmPedido = useCallback(async ()=>{
        try{
            const response = await api.get("/Pedido/api/Busca/PedidoEmPedidoBebida?idPedido=" + pedidoId);
            setBebidasOnPedido(response.data);
            console.log('bebidas no pedido:', setBebidasOnPedido);
        }catch(error){
            console.error('Naso foi possivel buscar bebidas no pedido atual', error );
        }
     },[pedidoId]);

    
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
            await api.put("/Pedido/api/Update/QuantidadeBebidaEmPedidoBebida?quantidadeRemover="+ pedidoId);
            //atualizar a quantidade de bebidas no pedido atual
            updateBebidasEmPedido();

        }catch(error){
            console.error('Erro ao tentar excluir bebida no BD', error);
        }
     };

     const buscaNomeBebbidasOnPedido= async()=>{
        //chamar funcao do backend que soh busca bebida por seu id
     }

    return(
    <>
        
        <div>
            <h1>Altere seu pedido:</h1>
            <select onChange={(e) => setBebidaSelecionadaId(Number(e.target.value))} value={bebidaSelecionadaId ?? ''}>
                <option value="" disabled>Selecione uma bebida</option>
                {bebidasOnPedido.map((bebida, index) => (<option key={index} value={bebida.idBebida}> </option>))}
            </select>
            <input
                type="number"
                value={quantidade}
                onChange={(e) => setQuantidade(Number(e.target.value))}
                min="1"
            />
            <button onClick={() => handleUpdateBebida()}>Alterar</button>
        </div>
        <MostraBebidaEmPedido pedidos={bebidasOnPedido}/>
    </>
    );
};

export default UpdateBebidasEmPedido;
