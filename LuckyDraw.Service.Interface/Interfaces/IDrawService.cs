using LuckyDraw.Service.Interface.Models;

namespace LuckyDraw.Service.Interface.Interfaces
{
    public interface IDrawService
    {
        Task<IEnumerable<IEnumerable<int>>> GenerateResult(ResultAnalysis resultAnalysis);
    }
}
