using System.ComponentModel.DataAnnotations;

namespace De_mau_so1_C3.Models
{
    public class LopHoc
    {
        [Key]
        public string? MaLop { get; set; }

        [Required]
        public string? TenLop { get; set; }

        [Required]
        public int Khoa { get; set; }

        public virtual ICollection<SinhVien>? SinhViens { get; set; }
    }
}
