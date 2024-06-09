import React, { useState, useEffect } from "react";
import { addBebida, updateBebida } from "./BebidaService";
import { Bebida } from "../../models/Bebida";

interface BebidaFormProps {
  bebida?: Bebida;
  onSave: () => void;
}

const BebidaForm: React.FC<BebidaFormProps> = ({ bebida, onSave }) => {
  const [nome, setNome] = useState(bebida ? bebida.nome : "");
  const [preco, setPreco] = useState<string>(bebida ? String(bebida.preco) : "");
  const [alcoolica, setAlcoolica] = useState(bebida ? bebida.alcoolica : false);

  useEffect(() => {
    if (bebida) {
      setNome(bebida.nome);
      setPreco(String(bebida.preco));
      setAlcoolica(bebida.alcoolica);
    }
  }, [bebida]);

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    const precoNumber = parseFloat(preco);
    if (isNaN(precoNumber)) {
      alert("Por favor, insira um número válido para o preço.");
      return;
    }

    const newBebida: Bebida = { id: bebida ? bebida.id : 0, nome, preco: precoNumber, alcoolica };

    if (bebida) {
      await updateBebida(newBebida);
    } else {
      await addBebida(newBebida);
    }

    onSave();
  };

  const handlePrecoChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const val = e.target.value;
    if (val === "" || /^-?\d*\.?\d*$/.test(val)) {
      setPreco(val);
    }
  };

  return (
    <form onSubmit={handleSubmit}>
      <div>
        <label>Nome:</label>
        <input
          type="text"
          value={nome}
          onChange={(e) => setNome(e.target.value)}
        />
      </div>
      <div>
        <label>Preço (Float):</label>
        <input
          type="text"
          value={preco}
          onChange={handlePrecoChange}
        />
      </div>
      <div>
        <label>Alcoólica:</label>
        <input
          type="checkbox"
          checked={alcoolica}
          onChange={(e) => setAlcoolica(e.target.checked)}
        />
      </div>
      <button type="submit">Salvar</button>
    </form>
  );
};

export default BebidaForm;
