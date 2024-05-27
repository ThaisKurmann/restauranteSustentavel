import { useEffect, useState } from "react";
import { Link } from "react-router-dom";
import api from "../../api"


export default function Bebidas(){
    const [bebidas, setBebidas] = useState<any[]>([]);
    
    const getBebidas = async () => {
        await api.get("/Bebida/GetAll").then((response) => setBebidas(response.data));
    };


    useEffect(() => {
        getBebidas();
    }, []);


    return(
        <div className="App">
            <h2>Bebidas:</h2>
            <ul>
                {bebidas && 
                    bebidas.map((bebidas) => (
                    <li key={bebidas.id}>
                        <br/>
                        {bebidas.nome} 
                        <br/>
                        <br/>
                    </li>
                ))}
            </ul>
        </div>
    );
}