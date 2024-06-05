import { useEffect } from "react";
import axios from "axios";



  const BebidaPostApi: React.FC<{}> = () => {
    
 
    const postBebidas = async () => {
        //await api.get("/Bebida/GetAll").then((response) => setBebidas(response.data));
        //await api.post("/Bebida/Insert", bebidas).then((response) => console.log(response)).catch((error)=> console.log(error));
        axios({
            method: 'post',
            url: 'https://localhost:7163/Bebida/api/Insert', 
            headers: {},
            data: {
                nome: 'TESTE 5',
                alcoolica: false,
                id: 1,
                preco: 50
            }

        });
    };


    useEffect(() => {
    }, []);

    return(
        <div>
            <br></br>
            <h1>Bebida Post in API</h1>
            <button onClick={() => postBebidas()}>POST</button>
        </div>
    );
}


export default BebidaPostApi;