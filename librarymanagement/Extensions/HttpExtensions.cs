using LibraryManagement.Web.Helpers;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace LibraryManagement.Web.Extensions
{
    public static class HttpExtensions
    {
        public static void AddpaginationHeader(this HttpResponse response, PaginationHeader header)
        {
            var jsonOptions = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            response.Headers.Add("Pagination", JsonSerializer.Serialize(header, jsonOptions));
            response.Headers.Add("Access-Control-Expose-Headers", "Pagination");
        }

    }
}
