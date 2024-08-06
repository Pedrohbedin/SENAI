using ProductsAPI.Domains;

namespace ProductsAPI.Interfaces
{
    public interface IProductsRepository
    {
        void Cadastrar(Products products);
        void Deletar(Guid id);
        List<Products> Listar();
        Products BuscarPorId(Guid Id);
        void Atualizar(Products product,Guid id);
    }
}
