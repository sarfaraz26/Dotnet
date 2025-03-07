using Newtonsoft.Json;

namespace Product.Core.Specs
{
    public class Pagination
    {
        [JsonProperty("pageNumber")]
        public int PageNumber { get; set; }

        [JsonProperty("pageSize")]
        public int PageSize { get; set; }
    }
}
