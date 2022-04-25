using LuckyDraw.Service.Extensions;
using LuckyDraw.Service.Interface.Interfaces;
using LuckyDraw.Service.Interface.Models;
using System.Collections.Concurrent;

namespace LuckyDraw.Service
{
    public class DrawService : IDrawService
    {
        public async Task<IEnumerable<IEnumerable<int>>> GenerateResult(ResultAnalysis resultAnalysis)
        {
            var results = new ConcurrentBag<IEnumerable<int>>();

            await Parallel.ForEachAsync(new Task[resultAnalysis.TotalCombo], async (task, CancellationToken) =>
            {
                var pool = Enumerable.Range(resultAnalysis.MinPoolNumber, resultAnalysis.MaxPoolNumber).ToList();
                if (resultAnalysis.Pools is not null && resultAnalysis.Pools.Any())
                {
                    foreach (var historyPool in resultAnalysis.Pools.OrderByDescending(x => x.Priority))
                    {
                        if (historyPool.Numbers is not null && historyPool.Numbers.Any())
                        {
                            var count = 0;
                            while (count < historyPool.Priority)
                            {
                                pool.AddRange(historyPool.Numbers);
                                count++;
                            }
                        }
                    }
                }
                var result = pool.GetRandomNumbers(resultAnalysis.TotalSelectedNumber).OrderBy(x => x);
                results.Add(result);
            });
            return results;
        }
    }
}
