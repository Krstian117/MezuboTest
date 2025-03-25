namespace Mezubo.Domain.Persistence
{
    using ErrorOr;
    using Mezubo.Domain.ModelServices.Bet;

    public interface IBetRepository
    {
        /// <summary>
        /// Metodo encargado de validar si la misma apuesta fue realizada
        /// </summary>
        /// <param name="createBetRequest"></param>
        /// <returns></returns>
        public Task<ErrorOr<Success>> ValidateSameBet(CreateBetRequest createBetRequest);

        /// <summary>
        /// Metodo encargado de validar si la misma apuesta fue realizada
        /// </summary>
        /// <param name="createBetRequest"></param>
        /// <returns></returns>
        public Task<ErrorOr<Success>> CreateBet(CreateBetRequest createBetRequest);
    }
}
