import React from 'react';
import { useParams } from 'react-router-dom';
import styles from './FinalizarPedidoPage.module.css'


const FinalizarPedidoPage: React.FC = () => {

    const {id} = useParams();
    const pedidoAtualId = Number(id);

        

    return (
        <div className={styles.Content}>
            <h1 className={styles.H1}>PEDIDO REALIZADO COM SUCESSO!</h1>
            <div>
                <h2 className={styles.H2}>CODIGO DO SEU PEDIDO:</h2>
                <h3 className={styles.H3}>{pedidoAtualId}</h3>
            </div>
        </div>
    );
};

export default FinalizarPedidoPage;
