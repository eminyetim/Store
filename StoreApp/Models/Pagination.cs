namespace StoreApp.Models
{
    public class Pagination
    {
        public int TotalItems { get; set; }  // Kaç ürün listelediğim
        public int ItemsPerPage { get; set; }  // Sayfa başına düşen kayıt sayısı
        public int CurrenPage { get; set; }  // Mevcut sayfa bilgisi
        public int TotalPage => (int)Math.Ceiling((decimal)TotalItems/ItemsPerPage); //Toplam sayfa sayısı // Ceiling yuvarlama
    }
}