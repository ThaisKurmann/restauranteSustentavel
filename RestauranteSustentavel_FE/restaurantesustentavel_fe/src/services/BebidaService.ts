import { Bebida } from "../models/Bebida";

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
