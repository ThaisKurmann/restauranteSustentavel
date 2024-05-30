/*import { Bebida } from "../models/Bebida";
import api from "../api";
import { useEffect, useState } from "react";

//pegar dados da api
const Bebidas: React.FC = () => {

    const [bebidas, setBebidas] = useState<Bebida[]>([]);
    const [novaBebida, setNovaBebida] = useState<Omit<Bebida, 'id'>>({nome: '', preco:0, alcoolica:false});
    const [editaBebida, setEditaBebida] = useState<Bebida | null>(null);


    useEffect(() => {
      getBebidas();
    }, []);


    const getBebidas = async () => {
      const response = await api.get<Bebida[]>('/Bebida/GetAll');
      setBebidas(response.data);
    };


     const getBebida = (id: number): Promise<Bebida | undefined> => {
      return Promise.resolve(bebidas.find(bebida => bebida.id === id));
    };

     const addBebida = (bebida: Bebida): Promise<void> => {
      bebidas.push({ ...bebida, id: bebidas.length + 1 });
      return Promise.resolve();
    };

     const updateBebida = (updatedBebida: Bebida): Promise<void> => {
      bebidas = bebidas.map(bebida => (bebida.id === updatedBebida.id ? updatedBebida : bebida));
      return Promise.resolve();
    };

     const deleteBebida = (id: number): Promise<void> => {
      bebidas = bebidas.filter(bebida => bebida.id !== id);
      return Promise.resolve();
};


};
*/
import axios from "axios";
import { Bebida } from "../models/Bebida";

//codigo anterior ao teste de pegar e mostrar os dados da APi
let bebidas: Bebida[] = [
  { id: 1, nome: "Cerveja", preco: 5.5, alcoolica: true },
  { id: 2, nome: "Suco", preco: 3.0, alcoolica: false }
];


export const getBebidas = (): Promise<Bebida[]> => {

  return Promise.resolve(bebidas);
};


export const getBebida = (id: number): Promise<Bebida | undefined> => {
  return Promise.resolve(bebidas.find(bebida => bebida.id === id));
};

export const addBebida = (bebida: Bebida): Promise<void> => {
  bebidas.push({ ...bebida, id: bebidas.length + 1 });
  return Promise.resolve();
};

export const updateBebida = (updatedBebida: Bebida): Promise<void> => {
  bebidas = bebidas.map(bebida => (bebida.id === updatedBebida.id ? updatedBebida : bebida));
  return Promise.resolve();
};

export const deleteBebida = (id: number): Promise<void> => {
  bebidas = bebidas.filter(bebida => bebida.id !== id);
  return Promise.resolve();
};

export const postBebiddasApi = async(bebida: Bebida) => {
  
  axios({
      method: 'post',
      url: 'https://localhost:7163/Bebida/Insert', 
      headers: {},
      data: {
          nome: bebida.nome,
          alcoolica: bebida.alcoolica,
          id: bebida.id,
          preco: bebida.preco
      } 
  });
};



/**
 * import axios from "axios";
import { Bebida } from "../models/Bebida";
import { useEffect } from "react";


//Post on AP
const AddBebidaApi = (bebida: Bebida): React.FunctionComponent<{}> => {
    
    const postBebiddasApi = async() => {
        axios({
            method: 'post',
            url: 'https://localhost:7163/Bebida/Insert', 
            headers: {},
            data: {
                nome: bebida.nome,
                alcoolica: bebida.alcoolica,
                id: bebida.id,
                preco: bebida.preco
            } 
        });
    };
    
    useEffect(()=>{
    }, []);

    return(
        <div>
            <br></br>
            <h1>Bebida Post on API</h1>
            <button onClick={() => postBebiddasApi()}>POST</button>
        </div>
    );
};

export default AddBebidaApi;
 */
