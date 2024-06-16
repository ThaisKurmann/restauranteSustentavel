import CreatePedidoButton from "../components/Pedidos/CreatePedidoButton";
import styles from "./PedidoPage.module.css";

const PedidoPage: React.FC = () => {


   return(
        <div>
            <div>
                <h1 className={styles.H1}>RESTAURANTE SUSTENTAVEL: </h1>
                <p className={styles.Content}>Bem-vindo!</p>

                <div className={styles.Content}>
                    <CreatePedidoButton />
                </div>
                
                
            </div>
        
            
        </div>
    );
};


export default PedidoPage;