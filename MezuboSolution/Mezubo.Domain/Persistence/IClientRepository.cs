namespace Mezubo.Domain.Persistence
{
    using ErrorOr;

    /// <summary>
    /// Interfaz para la gestion de clientes
    /// </summary>
    public interface IClientRepository
    {
        /// <summary>
        /// Metodo encargado de validar si el cliente existe
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public Task<ErrorOr<Success>> ValidateExistClient(string Name);
        /// <summary>
        /// Metodo encargado de validar si el cliente existe
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        public Task<ErrorOr<Success>> ValidateExistClient(int Id);
        /// <summary>
        /// Metodo encargado de crear clientes
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public Task<ErrorOr<Success>> CreateClient(string Name);
    }
}
