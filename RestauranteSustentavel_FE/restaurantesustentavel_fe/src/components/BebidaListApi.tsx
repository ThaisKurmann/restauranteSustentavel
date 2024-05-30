import { useEffect, useState } from "react";
import { Bebida } from "../models/Bebida";
import api from "../api";


const BebidaListApi: React.FC<{}> = () => {
    const [bebidas, setBebidas] = useState<Bebida[]>([]);

    const getBebidas = async () => {
        await api.get("/Bebida/GetAll").then((response) => setBebidas(response.data));
    };

  
    useEffect(() => {
        getBebidas();
       // console.log(bebidas);
    }, []);

    return (
        //retrna html, mas tbm da pra colocar javascript/tyscript quando coloco {} pra manipular os dados
        <div>
          <h2>Lista de Bebidas [API]</h2>
          <ul>
            {bebidas.map(bebida => (
              <li key={bebida.id}>
                {bebida.nome} - R$ {bebida.preco.toFixed(2)} - {bebida.alcoolica ? "Alcoólica" : "Não alcoólica"} - Id: {bebida.id}
              </li>
            ))}
          </ul>
        </div>
    );
} 

export default BebidaListApi;