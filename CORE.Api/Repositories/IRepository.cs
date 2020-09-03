namespace CORE.Api.Repositories
{
    public interface IRepository
    {
        IRouletteRepository RouletteRepository { get; }
        IBetRepository BetRepository { get; }
    }
}
