using Microsoft.AspNetCore.Http.HttpResults;
using ProductsAPI.Context;
using ProductsAPI.Domains;
using ProductsAPI.Interfaces;

namespace ProductsAPI.Repository
{
    public class ProductsRepository : IProductsRepository
    {
        private readonly ProductsContext ctx;
        public ProductsRepository() => ctx = new ProductsContext();
        public void Atualizar(Products product,Guid id)
        {
            Products produtoExistente = BuscarPorId(id);
            ctx.Entry(produtoExistente).CurrentValues.SetValues(product);
            ctx.SaveChanges();
        }

        public Products BuscarPorId(Guid Id) => ctx.Products.FirstOrDefault(x => x.IdProduct == Id)!;

        public void Cadastrar(Products products)
        {
            try
            {
                ctx.Products.Add(products);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public void Deletar(Guid id)
        {
            try
            {
                ctx.Products.Remove(ctx.Products.FirstOrDefault(x => x.IdProduct == id)!);
                ctx.SaveChanges();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public List<Products> Listar() => ctx.Products.ToList();
    }
}
