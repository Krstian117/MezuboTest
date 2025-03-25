namespace Mezubo.Domain.Entities
{
    using Mezubo.Domain.Constanst;
    using Sistran.DataAccess.SqlBuilder;
    using System.ComponentModel.DataAnnotations.Schema;
    /// <summary>
    /// Representacion de la tabla <see cref="TableName.CLIENTS"/>
    /// </summary>
    [Table(TableName.CLIENTS, Schema = Schema.HEYGIA)]
    public class ClientEntity : IEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Column("ClientId")]
        public int Id { get; set; }
        /// <summary>
        /// Nombre
        /// </summary>
        [Column("Name")]
        public string Name { get; set; }
    }
}
