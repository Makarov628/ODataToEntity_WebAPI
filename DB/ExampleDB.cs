using System;
using System.Collections.Generic;

using LinqToDB;
using LinqToDB.Configuration;
using LinqToDB.Data;
using LinqToDB.Mapping;

using OdataToEntity.Linq2Db;


namespace ODataToEntity_WebAPI.DB
{
    public partial class ExampleDB : DataConnection, IOeLinq2DbDataContext
    {
        OeLinq2DbDataContext IOeLinq2DbDataContext.DataContext
        {
            get;
            set;
        }
        public ITable<DictArea> DictAreas { get { return this.GetTable<DictArea>(); } }
        public ITable<DictCity> DictCities { get { return this.GetTable<DictCity>(); } }

        #warning Change connection string.
        public ExampleDB()
            : base("System.Data.SqlClient", @"Data Source=<source>;Database<databaseName>;User Id=<user>;Password=<password>")
        {
            InitDataContext();
            InitMappingSchema();
        }

        public ExampleDB(string configuration)
            : base(configuration)
        {
            InitDataContext();
            InitMappingSchema();
        }

        public ExampleDB(LinqToDbConnectionOptions options)
            : base(options)
        {
            InitDataContext();
            InitMappingSchema();
        }

        partial void InitDataContext();
        partial void InitMappingSchema();

        
    }

    [Table(Schema = "dbo", Name = "DictArea")]
    public partial class DictArea
    {
        [PrimaryKey, Identity] public int AreaID { get; set; } // int
        [Column, NotNull] public string Name { get; set; } // nvarchar(50)

        [Column, Nullable] public string Code { get; set; } // nvarchar(10)
 
        [Association(ThisKey = "AreaID", OtherKey = "AreaID", CanBeNull = true, Relationship = LinqToDB.Mapping.Relationship.OneToMany, IsBackReference = true)]
        public IEnumerable<DictCity> DictCities { get; set; }

    }


    [Table(Schema = "dbo", Name = "DictCities")]
    public partial class DictCity
    {
        [PrimaryKey, Identity] public int CitiesID { get; set; } // int
        [Column, NotNull] public string Name { get; set; } // nvarchar(50)
        [Column, NotNull] public int AreaID { get; set; } // int
        [Column, Nullable] public bool? IsVillage { get; set; } // bit
        [Column, NotNull] public bool IsActive { get; set; } // bit
        [Column, Nullable] public string Code { get; set; } // nvarchar(10)
        [Column, NotNull] public bool IsDefault { get; set; } // bit
        [Column, Nullable] public int? LocationID { get; set; } // int

    
        [Association(ThisKey = "AreaID", OtherKey = "AreaID", CanBeNull = false, Relationship = LinqToDB.Mapping.Relationship.ManyToOne, KeyName = "FK_DictCities_DictArea", BackReferenceName = "DictCities")]
        public DictArea Area { get; set; }

    }
}