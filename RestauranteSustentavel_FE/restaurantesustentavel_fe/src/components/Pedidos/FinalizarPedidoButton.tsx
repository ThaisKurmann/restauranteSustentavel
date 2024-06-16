import {useNavigate } from 'react-router-dom';
import styles from './FinalizarPedidoButton.module.css';


interface FinalizarPedidoButtonProps{
    pedidoId: number
}

const FinalizarPedidoButton: React.FC<FinalizarPedidoButtonProps> = ({pedidoId}) => {
    const navigate = useNavigate();

    const handleFinalizarPedidoButton =()=>{
       navigate(`/pedido/${pedidoId}/salvar`);
    }

    return(<>
        <div>
            <button onClick={handleFinalizarPedidoButton} className={styles.Button}>Finalizar Pedido</button>
       
        </div>
    </>)
}

export default FinalizarPedidoButton;