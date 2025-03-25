namespace Mezubo.Domain.Entities
{
    using Mezubo.Domain.Constanst;
    using Sistran.DataAccess.SqlBuilder;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Representacion de la tabla <see cref="TableName.BETS"/>
    /// </summary>
    [Table(TableName.BETS, Schema = Schema.HEYGIA)]
    public class BetEntity : IEntity
    {
        /// <summary>
        /// BetId
        /// </summary>
        [Column("BetId")]
        public int BetId { get; set; }
        /// <summary>
        /// ClientId
        /// </summary>
        [Column("ClientId")]
        public int ClientId { get; set; }
        /// <summary>
        /// RouletteId
        /// </summary>
        [Column("RouletteId")]
        public int RouletteId { get; set; }
        /// <summary>
        /// BetType
        /// </summary>
        [Column("BetType")]
        public string BetType { get; set; }
        /// <summary>
        /// BetValue
        /// </summary>
        [Column("BetValue")]
        public string BetValue { get; set; }
        /// <summary>
        /// Amount
        /// </summary>
        [Column("Amount")]
        public double Amount { get; set; }

    }
}
