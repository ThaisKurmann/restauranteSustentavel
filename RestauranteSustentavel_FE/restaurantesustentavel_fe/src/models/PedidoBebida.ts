export interface PedidoBebida{
    quantidade: number;
    idBebida: number;
    idPedido: number;
}

export interface BebidasSelecionada{
    idBebida: number|null;
    quantidadeBebida: number
};
