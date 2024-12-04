namespace StoreApp.Infrastructe.Extensions
{
    public static class HttpRequestExtension
    {
        public static string PathAndQuery(this HttpRequest request) // Genişletmek istediğimiz sınıf this.
        {
            return request.QueryString.HasValue 
            ? $"{request.Path}{request.QueryString}" // Eğer var ise birleştir.
            :request.Path.ToString();  // Yoksa yolu kopyala.
        }
    }
}