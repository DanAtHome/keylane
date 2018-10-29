namespace TriangleAnalyzer.Infrastructure.Context
{
    using System;
    using System.Data.Entity;
    using System.Linq;
    using TriangleAnalyzer.Service.Model;
    using TriangleAnalyzer.Service.Model.Core;

    public class TriangleAnalyzerDB : DbContext
    {
        // Your context has been configured to use a 'TriangleAnalyzerDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'TriangleAnalyzer.Infrastructure.Context.TriangleAnalyzerDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'TriangleAnalyzerDB' 
        // connection string in the application configuration file.
        public TriangleAnalyzerDB()
            : base("name=TriangleAnalyzerDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Triangle> Triangles { get; set; }
        public virtual DbSet<TriangleStageItem> TriangleStageItems { get; set; }
    }


}