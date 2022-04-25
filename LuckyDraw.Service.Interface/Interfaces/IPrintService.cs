namespace LuckyDraw.Service.Interface.Interfaces
{
    public interface IPrintService
    {
        void Print(IEnumerable<IEnumerable<int>> result);
    }
}
