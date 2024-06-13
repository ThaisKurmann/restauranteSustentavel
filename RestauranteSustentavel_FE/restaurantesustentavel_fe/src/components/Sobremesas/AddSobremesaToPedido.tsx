import { useCallback, useEffect, useState } from "react";
import { Sobremesa } from "../../models/Sobremesa";
import axios from "axios";
import { PedidoSobremesa } from "../../models/PedidoSobremesa";
import api from "../../api";
import UpdateSobremesasOnPedido from "./UpdateSobremesasOnPedido";


interface AddSobremesaToPedidoProps {
    pedidoId: number;
}

const AddSobremesaToPedido: React.FC<AddSobremesaToPedidoProps> = ({ pedidoId }) => {

    const [sobremesas, setSobremesas] = useState<Sobremesa[]>([]);
    const [sobremesaSelecionadaId, setSobremesaSelecionadaId] = useState<number | null>(null);
    const [quantidade, setQuantidade] = useState<number>(1);
    const [sobremesasOnPedido, setSobremesasOnPedido] = useState<PedidoSobremesa[]>([]);
    

    const buscaSobremesas = async () => {
        try {
            const response = await axios.get('https://localhost:7163/Sobremesa/api/GetAll');
            setSobremesas(response.data);
            //console.log('componente AddSobremesaToPedidoSobremesaCorreto.tsxt: response.data =>', response.data);
        } catch (error) {
            console.error('Erro ao carregar sobremesas no BD:', error);
        }
    };

    const updatePediddoSobremesa = useCallback(async ()=> {
        await api.get("/Pedido/api/Busca/PedidoPorIdEmPedidoSobremesa?idPedido=" + pedidoId).then((response)=> setSobremesasOnPedido(response.data));
    },[pedidoId])

    useEffect(() => {
        buscaSobremesas();
        updatePediddoSobremesa();
    }, [pedidoId, updatePediddoSobremesa]);

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
            updatePediddoSobremesa();
            
        } catch (error) {
            console.error('Erro ao adicionar sobremesa ao pedido:', error);
        }
    };

    //updateBebidas
    const handleButtonSobremesasChangeQuantity= async(pedidoSobremesa: PedidoSobremesa, increment: Boolean)=>{

        if(increment){
            pedidoSobremesa.quantidade++;
        }else{
            pedidoSobremesa.quantidade--;
        }

        await api.put("/Pedido/api/Update/QuantidadeDeSobremesaEmPedidoSobremesa", pedidoSobremesa);

        const response = await api.get("/Pedido/api/Busca/PedidoPorIdEmPedidoSobremesa?idPedido=" + pedidoSobremesa.idPedido);

        setSobremesasOnPedido(response.data);
        
    }


    return (
        <>
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
        <UpdateSobremesasOnPedido pedidoSobremesa={sobremesasOnPedido} updateSobremesaOnPedido={handleButtonSobremesasChangeQuantity}/>
        </>
    );
};

export default AddSobremesaToPedido;