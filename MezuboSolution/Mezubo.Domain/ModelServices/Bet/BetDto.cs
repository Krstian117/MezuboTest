namespace Mezubo.Domain.ModelServices.Bet
{
    public class BetDto
    {
        /// <summary>
        /// Id Ruleta
        /// </summary>
        public int RouletteId { get; set; }
        /// <summary>
        /// Tipo de apuesta (Color o numero)
        /// </summary>
        public string BetType { get; set; }
        /// <summary>
        /// valor de la apuesta(Si es color, blanco o negro, si es numero de 0 a 36)
        /// </summary>
        public string BetValue { get; set; }
        /// <summary>
        /// Valor
        /// </summary>
        public decimal Amount { get; set; }
    }
}
