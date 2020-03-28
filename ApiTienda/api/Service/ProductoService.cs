using Microsoft.EntityFrameworkCore;
using Model;
using Persistence;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public interface IStudentService
    {
        IEnumerable<Producto> GetAll();
        bool Add(Producto model);
        bool Delete(int codigo);
        bool Update(Producto model);
        Producto Get(int codigo);
    }

    public class ProductoService : IStudentService
    {
        private readonly ProductoDbContext _studentDbContext;

        public ProductoService(
            ProductoDbContext studentDbContext
        )
        {
            _studentDbContext = studentDbContext;
        }

        public IEnumerable<Producto> GetAll()
        {
            var result = new List<Producto>();

            try
            {
                result = _studentDbContext.producto.ToList();
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
                result = _studentDbContext.producto.Single(x => x.codigo == codigo);
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
                _studentDbContext.Add(model);
                _studentDbContext.SaveChanges();
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
                var originalModel = _studentDbContext.producto.Single(x =>
                    x.codigo == model.codigo
                );

                originalModel.Nombre = model.Nombre;
                originalModel.descripcion = model.descripcion;
                originalModel.precio = model.precio;

                _studentDbContext.Update(originalModel);
                _studentDbContext.SaveChanges();
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
                _studentDbContext.Entry(new Producto { codigo = codigo }).State = EntityState.Deleted; ;
                _studentDbContext.SaveChanges();
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
    }
}
