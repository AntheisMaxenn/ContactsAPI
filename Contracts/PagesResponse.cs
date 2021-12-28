namespace ContactsAPI.Contracts
{
    public class PagesResponse<T>
    {
        public PagesResponse()
        {
            // Parameterless ctor because an sdk using this wont be able to use the ctor
            // to deserialize automatically
        }

        public PagesResponse(IEnumerable<T> data)
        {
            Data = data;
        }

        public IEnumerable<T> Data { get; set; }

        public int? PageNumber { get; set; }

        public int? PageSize { get; set; }

        public int? Total { get; set; }


    }
}
