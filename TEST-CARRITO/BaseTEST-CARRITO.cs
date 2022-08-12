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
                var opciones = new DbContextOptionsBuilder<Contexto>().UseSqlServer("Server=DESKTOP-NBSBBH9;Database=CarritoAPI;Trusted_Connection=true;",
                options => { }).Options;
                db = new Contexto(opciones);
                return db;
            }
            return db;
        }
    }
}
