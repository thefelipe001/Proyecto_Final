using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IProductoService
    {
        IEnumerable<Producto> GetAll();
        bool Add(Producto model);
        bool Delete(int codigo);
        bool Update(Producto model);
        Producto Get(int id);
    }

    public class ProductoService : IProductoService
    {
        private readonly ProductoDbContext _productoDbContext;

        public ProductoService(
            ProductoDbContext productoDbContext
        )
        {
            _productoDbContext = productoDbContext;
        }

        public IEnumerable<Producto> GetAll()
        {
            var result = new List<Producto>();

            try
            {
                result = _productoDbContext.Producto.ToList();
            }
            catch (System.Exception)
            {
                
            }

            return result;
        }

        public Producto Get(int codigo)
        {
            var result = new Producto();

            try
            {
                result = _productoDbContext.Producto.Single(x => x.codigo == codigo);
            }
            catch (System.Exception)
            {

            }

            return result;
        }

        public bool Add(Producto model)
        {
            try
            {
                _productoDbContext.Add(model);
                _productoDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Update(Producto model)
        {
            try
            {
                var originalModel = _productoDbContext.Producto.Single(x =>
                    x.codigo == model.codigo
                );

                originalModel.nombre = model.nombre;
                originalModel.descripcion = model.descripcion;
                originalModel.precio = model.precio;

                _productoDbContext.Update(originalModel);
                _productoDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }

        public bool Delete(int codigo)
        {
            try
            {
                _productoDbContext.Entry(new Producto { codigo = codigo }).State = EntityState.Deleted; ;
                _productoDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}
