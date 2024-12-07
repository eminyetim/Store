using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos
{
    public record RegisterDto // Record olmasının sebebi veri taşıma oku işlemi yapıcağımızdan dolayı.
    {
        [Required(ErrorMessage = "User Name is required.")]
        public string UserName { get; init; }  // Değerler tanımlandığı anda verilmeli. Sonradan değiştirilemez.

        [Required(ErrorMessage = "Email is required.")]
        public string? Email { get; init; }
        
        [Required(ErrorMessage = "Password is required.")]
        public string? Password { get; init; }
    }
}