using CapaAplicacion.SERVICIOS;
using CapaDatos;
using CapaDatos.COMANDOS;
using CapaDominio.ENTIDADES;
using CapaDominio.QUERYS;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_CARRITO
{
    public class CarritoServiceTest : BaseTEST_CARRITO
    {
        Contexto _db;
        GenericsRepository _genericsRepository;
        CarritoServicio _carritoService;
        Mock<IQueryCarrito> _querycarrito;

        [SetUp]
        public void Setup()
        {
            _db = ConstruirContexto();
            _genericsRepository = new GenericsRepository(_db);
            _querycarrito = new Mock<IQueryCarrito>();
            _carritoService = new CarritoServicio(_genericsRepository, _querycarrito.Object, _db);
        }


        [Test]
        public void DeleteProductShoppingCartComplet()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                bool deleteProduct = _carritoService.BorrarCarritoCompleto(1);
                Assert.IsTrue(deleteProduct);
                transaction.Rollback();
            }

        }

        [Test]
        public void DeleteProductShoppingCartNotExistComplet()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                bool deleteProduct = _carritoService.BorrarCarritoCompleto(100000);
                Assert.IsFalse(deleteProduct);
                transaction.Rollback();
            }

        }

        [Test]
        public void DeleteProductShoppingCartIsNegativeComplet()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                bool deleteProduct = _carritoService.BorrarCarritoCompleto(-1);
                Assert.IsFalse(deleteProduct);
                transaction.Rollback();
            }

        }

        [Test]
        public void InsertShoppingCartClient()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                Carrito insertShoppingCart = _carritoService.InsertarCarritoCliente(1);
                Assert.IsNotNull(insertShoppingCart);
                transaction.Rollback();
            }
        }

        [Test]
        public void InsertShoppingCartNotExistClient()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                Carrito insertShoppingCart = _carritoService.InsertarCarritoCliente(-1);
                Assert.IsNull(insertShoppingCart);
                transaction.Rollback();
            }
        }

        [Test]
        public void VerifyClientShoppingCartNotExist()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                int veryfyClient = _carritoService.VerificarClienteCarrito(-1);
                Assert.Positive(veryfyClient);
                transaction.Rollback();
            }
        }

        [Test]
        public void VerifyClientShoppingCartIfExist()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                int veryfyClient = _carritoService.VerificarClienteCarrito(1);
                Assert.AreEqual(veryfyClient,1);
                transaction.Rollback();
            }
        }

        [Test]
        public void DeleteProductShoppingCartTrue()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                bool productCart = _carritoService.BorrarProductoCarrito(2,1);
                Assert.IsTrue(productCart);
                transaction.Rollback();
            }
        }

        [Test]
        public void DeleteProductShoppingCartIfProductNegative()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                bool productCart = _carritoService.BorrarProductoCarrito(-1,2);
                Assert.IsFalse(productCart);
                transaction.Rollback();
            }
        }

        [Test]
        public void DeleteProductShoppingCartIfNegative()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                bool productCart = _carritoService.BorrarProductoCarrito(1, -2);
                Assert.IsFalse(productCart);
                transaction.Rollback();
            }
        }

        [Test]
        public void DeleteProductShoppingCartAndProductIfNegative()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                bool productCart = _carritoService.BorrarProductoCarrito(-1, -2);
                Assert.IsFalse(productCart);
                transaction.Rollback();
            }
        }

        [Test]
        public void ProductValueShoppingCartClient()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                var productCart = _carritoService.ProductosValorCarritoCliente(1);
                Assert.IsNotNull(productCart);
                transaction.Rollback();
            }
        }

        [Test]
        public void ProductValueShoppingCartNotExistClient()
        {
            using (Microsoft.EntityFrameworkCore.Storage.IDbContextTransaction transaction = _db.Database.BeginTransaction())
            {
                var productCart = _carritoService.ProductosValorCarritoCliente(-1);
                Assert.IsNotNull(productCart);
                transaction.Rollback();
            }
        }
    }
}
