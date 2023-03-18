namespace DotNet6.DriverStandings.Api.TransferObjects
{
    public class _Base
    {
        public class _BaseRequest
        {
            public object Item { get; set; }
        }
        public class _BaseResponse
        {
            public object Item { get; set; }
            public bool Success { get; set; }
            public string Message { get; set; }
        }

        public class _BaseListResponse<T>
        {
            public List<T> Items { get; set; }
            public bool Success { get; set; }
            public string Message { get; set; }
        }

    }
}
