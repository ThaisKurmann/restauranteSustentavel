
import React, {useState } from "react";
import axios from "axios";
import { Bebida } from "../../models/Bebida";


const BebidaFormApi: React.FC=  () => {

    //campos formulario
    const[bebida, setBebida] = useState<Bebida>({nome: '', preco: 0, id: 0, alcoolica: false});
   
    const handleChange = (e: React.ChangeEvent<HTMLInputElement>) => {
      const {name, type, checked, value} = e.target;
      setBebida({
        ...bebida,
        [name]: type === 'checkbox' ? checked: value, 

      });
    };

    const onSave = async () => {
        try {
            const response = await axios.post('https://localhost:7163/Bebida/api/Insert', bebida);
            console.log('Resposta do servidor:', response.data);
        } catch (error) {
            console.error('Erro ao enviar dados:', error);
        }
    };

  return (
    <form>
      <div>
        <label>Nome: </label>
        <input type="text" name="nome" value={bebida.nome} onChange={handleChange} placeholder="nome bebida" />
      </div>

      <div>
        <label>Preço: </label>
        <input type="number" name="preco" value={bebida.preco} onChange={handleChange} placeholder="Preço" />
      </div>

      <div>
        <label>Alcoólica: </label>
        <input type="checkbox" name="alcoolica" checked={bebida.alcoolica} onChange={handleChange} />
      </div>

        <button onClick={onSave}>Salvar</button>
    </form>
    
);
}

export default BebidaFormApi;

