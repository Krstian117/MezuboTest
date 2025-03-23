namespace Mezubo.Domain.Persistence
{
    using ErrorOr;
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
    }
}
