using CapaAplicacion.SERVICIOS;
using CapaDatos;
using CapaDatos.COMANDOS;
using CapaDominio.DTOS;
using CapaDominio.ENTIDADES;
using CapaDominio.QUERYS;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;

namespace TEST_CARRITO
{
    [TestFixture]
    public class CarritoProductoServicesTest : BaseTEST_CARRITO
    {
        Contexto _db;
        GenericsRepository _genericsRepository;
        CarritoProductoServicio _carritoService;
        Mock<IQueryCarritoProducto> _querycarrito;

        [SetUp]
        public void Setup()
        {
            _db = ConstruirContexto();
            _genericsRepository = new GenericsRepository(_db);
            _querycarrito = new Mock<IQueryCarritoProducto>();
            _carritoService = new CarritoProductoServicio(_genericsRepository, _querycarrito.Object);
        }

        [Test]

        public void InsertShoppingCartProductCountTest()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                PublicacionCarritoDto dto = new PublicacionCarritoDto()
                {
                    productoID = 1,
                    carritoID = 1,
                    cantidad = 10,
                };

                List<CarritoProducto> carritoProductoCantidad = _carritoService.InsertarCarritoProductoCantidad(dto);
                Assert.IsNotNull(carritoProductoCantidad);
                transaction.Rollback();
            }
        }

        [Test]

        public void InsertShoppingCartProductCountNegativeTest()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                PublicacionCarritoDto dto = new PublicacionCarritoDto()
                {
                    productoID = 1,
                    carritoID = 1,
                    cantidad = -1,
                };

                List<CarritoProducto> carritoProductoCantidad = _carritoService.InsertarCarritoProductoCantidad(dto);
                Assert.IsNotNull(carritoProductoCantidad);
                transaction.Rollback();
            }
        }

        [Test]

        public void InsertShoppingCartNotExistProIdTest()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                PublicacionCarritoDto dto = new PublicacionCarritoDto()
                {
                    productoID = -1,
                    carritoID = 1,
                    cantidad = 2,
                };

                List<CarritoProducto> carritoProductoCantidad = _carritoService.InsertarCarritoProductoCantidad(dto);
                Assert.IsNotNull(carritoProductoCantidad);
                transaction.Rollback();
            }
        }

        [Test]
        public void InsertShoppingCartNotExistCardIdTest()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                PublicacionCarritoDto dto = new PublicacionCarritoDto()
                {
                    productoID = 1,
                    carritoID = -1,
                    cantidad = 2,
                };
                List<CarritoProducto> carritoProductoCantidad = _carritoService.InsertarCarritoProductoCantidad(dto);
                Assert.IsNotNull(carritoProductoCantidad);
                transaction.Rollback();
            }
        }


        [Test]
        public void InsertShoppingCartProductClient()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                
                CarritoProducto shoppingCartProductClient = _carritoService.InsertarCarritoProductoCliente(1,1);
                Assert.IsNotNull(shoppingCartProductClient);
                transaction.Rollback();
            }
        }

    }
}
