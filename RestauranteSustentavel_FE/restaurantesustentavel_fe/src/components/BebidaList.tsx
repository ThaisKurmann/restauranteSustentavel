import React, { useEffect, useState } from "react";
import { Bebida } from "../models/Bebida";
import { getBebidas, deleteBebida} from "../services/BebidaService"


interface BebidaListProps {
  refresh: boolean;
}

const BebidaList: React.FC<BebidaListProps> = ({refresh}) => {
  const [bebidas, setBebidas] = useState<Bebida[]>([]);

  useEffect(() => {
    fetchBebidas();
  }, []);

  const fetchBebidas = async () => {
    const bebidas = await getBebidas();
    setBebidas(bebidas);
    //console.log(bebidas);
  };

  const handleDelete = async (id: number) => {
    await deleteBebida(id);
    fetchBebidas();
  };

  return (
    <div>
      <h2>Lista de Bebidas</h2>
      <ul>
        {bebidas.map(bebida => (
          <li key={bebida.id}>
            {bebida.nome} - R$ {bebida.preco.toFixed(2)} - {bebida.alcoolica ? "Alcoólica" : "Não alcoólica"}
            <button onClick={() => handleDelete(bebida.id)}>Excluir</button>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default BebidaList;
