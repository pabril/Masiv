using CORE.Api.Models;
using System.Collections.Generic;

namespace CORE.Api.Repositories
{
    public interface IBetRepository
    {
        Bet Create(Bet bet);
        Bet Read(string id);
        List<Bet> Read();
        Bet Update(string id, Bet bet);
        Bet Delete(string id, Bet bet);
    }
}
