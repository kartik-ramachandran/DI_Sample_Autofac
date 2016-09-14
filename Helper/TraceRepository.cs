namespace Repository
{
    [DIEngine.RegisterService]
    public class TraceRepository : ITraceRepository
    {
        public string Trace()
        {
            return "test";
        }
    }
}
