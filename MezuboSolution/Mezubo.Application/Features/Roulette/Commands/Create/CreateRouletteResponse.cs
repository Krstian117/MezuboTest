namespace Mezubo.Application.Features.Roulette.Commands.Create
{
    /// <summary>
    /// Respuesta de creación de una ruleta
    /// </summary>
    public class CreateRouletteResponse
    {
        /// <summary>
        /// Id de la ruleta
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Mensaje 
        /// </summary>
        public string Message { get; set; }
    }
}
