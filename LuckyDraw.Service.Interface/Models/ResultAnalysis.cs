namespace LuckyDraw.Service.Interface.Models
{
    public class ResultAnalysis
    {
        public int TotalSelectedNumber { get; set; }
        public int MinPoolNumber { get; set; } = 0;
        public int MaxPoolNumber { get; set; }
        public int TotalCombo { get; set; }
        public IEnumerable<FrenquentPool>? Pools { get; set; }
    }

    public class FrenquentPool
    {
        public int Priority { get; set; }
        public IEnumerable<int>? Numbers { get; set; }
    }
}
