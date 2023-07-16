using FluentMigrator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewComplexManagment.Migration.Migrations
{
    [Migration(202307131049)]
    public class _202307131049_AddedAllTable : FluentMigrator.Migration
    {
        public override void Up()
        {
            CreateComplex();
            CreateBlock();
            CreateUnit();
            CreateUsageType();
            CreateComplexUsageType();
        }
        public override void Down()
        {
            Delete.Table("ComplexUsageType");
            Delete.Table("UsageTypes");
            Delete.Table("Units");
            Delete.Table("Blocks");
            Delete.Table("Complexes");


        }
        public void CreateComplex()
        {
            Create.Table("Complexes")
             .WithColumn("Id").AsInt32().PrimaryKey().Identity()
             .WithColumn("Name").AsString(50).NotNullable()
             .WithColumn("UnitCount").AsInt32().NotNullable();
        }
        public void CreateBlock()
        {
            Create.Table("Blocks")
                .WithColumn("Id").AsInt32().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("UnitCount").AsInt32().NotNullable()
                .WithColumn("ComplexId").AsInt32().NotNullable()
                .ForeignKey("FK_Blocks_Complexes", "Complexes", "Id");
        }
        public void CreateUnit()
        {
            Create.Table("Units")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("Name").AsString().NotNullable()
               .WithColumn("ResidenceType").AsInt32().NotNullable()
               .WithColumn("BlockId").AsInt32().NotNullable()
               .ForeignKey("FK_Units_Blocks", "Blocks", "Id");
        }
        public void CreateUsageType()
        {
            Create.Table("UsageTypes")
               .WithColumn("Id").AsInt32().PrimaryKey().Identity()
               .WithColumn("Name").AsString().NotNullable();
        }
        public void CreateComplexUsageType()
        {
            Create.Table("ComplexUsageTypes")
               .WithColumn("ComplexId").AsInt32().PrimaryKey()
               .WithColumn("UsageTypeId").AsInt32().PrimaryKey();
    
        }

    }

}

