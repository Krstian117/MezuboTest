namespace Mezubo.Domain.Persistence
{
    using ErrorOr;
    using Mezubo.Domain.Enums;
    using System.Threading.Tasks;

    /// <summary>
    /// Interfaz para la gestion de ruletas
    /// </summary>
    public interface IRouletteRepository
    {
        /// <summary>
        /// Metodo encargado de crear ruletas
        /// </summary>
        /// <returns></returns>
        public Task<ErrorOr<int>> CreateRoulette();
        /// <summary>
        /// Metodo encargado de validar si existe la ruleta
        /// </summary>
        /// <param name="RouletteId"></param>
        /// <returns></returns>
        public Task<ErrorOr<Success>> ValidateExistRoulette(int RouletteId);
        /// <summary>
        /// Metodo encargado de actualizar ruletas
        /// </summary>
        /// <param name="RouletteId"></param>
        /// <param name="enumRoulette"></param>
        /// <returns></returns>
        public Task<ErrorOr<Success>> UpdateRoulette(int RouletteId, EnumRoulette enumRoulette);
    }
}
