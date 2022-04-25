namespace LuckyDraw.Service.Extensions
{
    public static class RandomExtensions
    {
        public static IEnumerable<int> GetRandomNumbers(this IEnumerable<int> source, int totalResult)
        {
            if (source is null || !source.Any() || source.Count() < totalResult)
            {
                return Enumerable.Empty<int>();
            }

            var target = source;
            var result = new List<int>();
            while (result.Count < totalResult)
            {
                var random = new Random();
                var selectedIndex = random.Next(0, target.Count());
                var selectedNumber = target.ElementAt(selectedIndex);
                target = target.Except(new int[] { selectedNumber }).ToArray();
                if (!result.Contains(selectedNumber))
                {
                    result.Add(selectedNumber);
                }
            }
            return result;
        }
    }
}
