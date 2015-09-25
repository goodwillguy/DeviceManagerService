using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations.Design;
using System.Data.Entity.Migrations.Model;
using System.Data.Entity.Migrations.Utilities;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tz.Common.DataModel;

namespace Tz.Tz.Common.DataModel.Migrations
{
    public class SkipReadonlyEntityCodeMigration : CSharpMigrationCodeGenerator
    {
        public IList<string> ReadonlyEntities { get; private set; }

        public SkipReadonlyEntityCodeMigration()
        {
            ReadonlyEntities = new List<string>();

        }

        public override ScaffoldedMigration Generate(string migrationId, IEnumerable<MigrationOperation> operations, string sourceModel, string targetModel, string @namespace, string className)
        {
            string checkForReadonlyTableAnnotation = typeof(ReadonlyTableAttribute).ToString();
            var createTable = operations.Where(op => op is CreateTableOperation).Select(op => op as CreateTableOperation).ToList<CreateTableOperation>();

            foreach (var creat in createTable)
            {
                var isReadOnly = creat.Annotations.Any(ano => ano.Value.ToString() == checkForReadonlyTableAnnotation);

                if (isReadOnly)
                {
                    ReadonlyEntities.Add(creat.Name);
                }
            }

            return base.Generate(migrationId, operations, sourceModel, targetModel, @namespace, className);
        }

        protected override void Generate(CreateTableOperation createTableOperation, IndentedTextWriter writer)
        {

            var isReadonly = ReadonlyEntities.Contains(createTableOperation.Name);
            if (!isReadonly)
            {
                base.Generate(createTableOperation, writer);
            }
        }

        protected override void Generate(AddForeignKeyOperation addForeignKeyOperation, IndentedTextWriter writer)
        {
            var isReadonly = ReadonlyEntities.Contains(addForeignKeyOperation.PrincipalTable) || ReadonlyEntities.Contains(addForeignKeyOperation.DependentTable); ;
            if (!isReadonly)
            {
                base.Generate(addForeignKeyOperation, writer);
            }
        }

        protected override void GenerateInline(AddForeignKeyOperation addForeignKeyOperation, IndentedTextWriter writer)
        {

            writer.WriteLine("//foreging key parent table {0} dependent table {1}", addForeignKeyOperation.PrincipalTable, addForeignKeyOperation.DependentTable);

            var isReadonly = ReadonlyEntities.Contains(addForeignKeyOperation.PrincipalTable) || ReadonlyEntities.Contains(addForeignKeyOperation.DependentTable);
            if (!isReadonly)
            {
                base.GenerateInline(addForeignKeyOperation, writer);
            }
        }

        protected override void GenerateInline(CreateIndexOperation createIndexOperation, IndentedTextWriter writer)
        {
            var isReadonly = ReadonlyEntities.Contains(createIndexOperation.Table);
            if (!isReadonly)
            {
                base.GenerateInline(createIndexOperation, writer);
            }
        }
        protected override void Generate(DropTableOperation dropTableOperation, IndentedTextWriter writer)
        {


            var isReadonly = ReadonlyEntities.Contains(dropTableOperation.Name);
            if (!isReadonly)
            {
                base.Generate(dropTableOperation, writer);
            }

        }


        protected override void Generate(DropForeignKeyOperation dropForeignKeyOperation, IndentedTextWriter writer)
        {
            var isReadonly = ReadonlyEntities.Contains(dropForeignKeyOperation.PrincipalTable);
            if (!isReadonly)
            {
                base.Generate(dropForeignKeyOperation, writer);
            }
        }

        protected override void Generate(DropIndexOperation dropIndexOperation, IndentedTextWriter writer)
        {
            var isReadonly = ReadonlyEntities.Contains(dropIndexOperation.Table);
            if (!isReadonly)
            {
                base.Generate(dropIndexOperation, writer);
            }
        }
    }
}
