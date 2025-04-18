namespace GamesEthic.Server.Models.Generic
{
    public sealed class Page<T> where T : class
    {
        public IList<T> Data { get; set; }
        public int Index { get; set; }
        public int Size { get; set; }
        public int TotalPages { get; set; }
    }
}
