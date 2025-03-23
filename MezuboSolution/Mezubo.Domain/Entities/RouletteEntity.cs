namespace Mezubo.Domain.Entities
{
    using Mezubo.Domain.Constanst;
    using Sistran.DataAccess.SqlBuilder;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Representacion de la tabla <see cref="TableName.ROULETTES"/>
    /// </summary>
    [Table(TableName.ROULETTES, Schema = Schema.HEYGIA)]
    public class RouletteEntity : IEntity
    {
        /// <summary>
        /// Id
        /// </summary>
        [Column("RouletteId")]
        public int Id { get; set; }
        /// <summary>
        /// Status
        /// </summary>
        [Column("Status")]
        public string Status { get; set; }
        /// <summary>
        /// CreationDate
        /// </summary>
        [Column("CreatedAt")]
        public DateTime CreationDate { get; set; }
        /// <summary>
        /// OpenDate
        /// </summary>
        [Column("OpenedAt")]
        public DateTime? OpenDate { get; set; }
        /// <summary>
        /// CloseDate
        /// </summary>
        [Column("ClosedAt")]
        public DateTime? CloseDate { get; set; }
        /// <summary>
        /// WinningNumber
        /// </summary>
        [Column("WinningNumber")]
        public int WinningNumber { get; set; }
        /// <summary>
        /// WinningColor
        /// </summary>
        [Column("WinningColor")]
        public string WinningColor { get; set; }
    }
}
