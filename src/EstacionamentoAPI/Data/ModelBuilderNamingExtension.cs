using EstacionamentoAPI.Shared;
using Microsoft.EntityFrameworkCore;
namespace EstacionamentoAPI.Data.Extensions
{

    public static class ModelBuilderNamingExtension
    {
        public static void UseCustomNamingConvention(ModelBuilder modelBuilder)
        {
            foreach (var entity in modelBuilder.Model.GetEntityTypes())
            {
                // Configurar o nome da tabela com o prefixo "tb_"
                var tableName = StringUtils.ToSnakeCase(entity.GetTableName());
                entity.SetTableName($"tb_{tableName}");

                // Configurar os nomes das colunas
                foreach (var property in entity.GetProperties())
                {
                    property.SetColumnName(StringUtils.ToSnakeCase(property.GetColumnName()));
                }

                // Configurar os nomes das chaves e índices
                foreach (var key in entity.GetKeys())
                {
                    key.SetName(StringUtils.ToSnakeCase(key.GetName()));
                }
                foreach (var foreignKey in entity.GetForeignKeys())
                {
                    foreignKey.SetConstraintName(StringUtils.ToSnakeCase(foreignKey.GetConstraintName()));
                }
                foreach (var index in entity.GetIndexes())
                {
                    index.SetDatabaseName(StringUtils.ToSnakeCase(index.GetDatabaseName()));
                }
            }
        }


    }
}
