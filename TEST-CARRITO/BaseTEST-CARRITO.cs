using CapaDatos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TEST_CARRITO
{
    public class BaseTEST_CARRITO
    {
        Contexto db = null;
        protected Contexto ConstruirContexto()
        {
            if (db == null)
            {
                var opciones = new DbContextOptionsBuilder<Contexto>().UseSqlServer("Server=NTB707\\SQLEXPRESS;Database=CarritoAPI;Uid=sa;Pwd='Emerix01';",
                options => { }).Options;
                db = new Contexto(opciones);
                return db;
            }
            return db;
        }
    }
}
