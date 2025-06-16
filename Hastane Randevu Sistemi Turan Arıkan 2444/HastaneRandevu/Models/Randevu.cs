using System;
using System.ComponentModel.DataAnnotations;

namespace HastaneRandevu.Models
{
    public class Randevu
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ad Soyad zorunludur.")]
        [RegularExpression(@"^[a-zA-ZçÇğĞıİöÖşŞüÜ\s]+$", ErrorMessage = "Lütfen sadece harf giriniz.")]
        public string AdSoyad { get; set; }

        [Required(ErrorMessage = "Telefon zorunludur.")]
        [RegularExpression(@"^\d{10,15}$", ErrorMessage = "Lütfen geçerli bir telefon numarası giriniz (sadece rakam, 10-15 hane).")]
        public string Telefon { get; set; }

        [Required(ErrorMessage = "Bölüm zorunludur.")]
        public string Bolum { get; set; }

        [Required(ErrorMessage = "Tarih zorunludur.")]
        [DataType(DataType.Date)]
        public DateTime Tarih { get; set; }
    }
}