import { Bebida } from "../models/Bebida";
import React, {useState } from "react";
import { addBebida, postBebiddasApi, updateBebida } from "../services/BebidaService";
import axios from "axios";

interface BebidaFormApiProps {
    bebida?: Bebida;
    onSave: () => void; //aqui precisa ser salv no BD
}


const BebidaFormApi: React.FC=  () => {

    //campos formulario
    const[bebida, setBebida] = useState<Bebida>({nome: '', preco: 0, id: 0, alcoolica:false});
   
    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
      const {name, type, checked, value} = e.target;
      setBebida({
        ...bebida,
        [name]: type === 'checkbox' ? checked: value, 

      });
    };

    const onSave = async () => {
      try {
          const response = await axios.post('https://localhost:7163/Bebida/Insert', bebida);
          console.log('Resposta do servidor:', response.data);
      } catch (error) {
          console.error('Erro ao enviar dados:', error);
      }
  };

  return (
    <div>
        <input type="text" name="nome" value={bebida.nome} onChange={handleChange} placeholder="Nome" />
        <input type="number" name="preco" value={bebida.preco} onChange={handleChange} placeholder="Preço" />
        <label>
            Alcoólica:
            <input type="checkbox" name="alcoolica" checked={bebida.alcoolica} onChange={handleChange} />
        </label>
        <button onClick={onSave}>Salvar</button>
    </div>
);
}

export default BebidaFormApi;

