namespace GdzieIzKim.DAL
{
    using GdzieIzKim.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class gdzieDB : DbContext
    {
        // Your context has been configured to use a 'gdzieDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'GdzieIzKim.DAL.gdzieDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'gdzieDB' 
        // connection string in the application configuration file.
        public gdzieDB()
            : base("name=gdzieDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Lokalizacja> Lokalizacja { get; set; }
        public virtual DbSet<Kategoria> Kategoria { get; set; }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}