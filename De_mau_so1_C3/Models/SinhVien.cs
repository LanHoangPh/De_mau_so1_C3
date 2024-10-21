using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace De_mau_so1_C3.Models
{
    public class SinhVien
    {
        [Key]
        public string ID { get; set; }

        [Required]
        public string Ten { get; set; }

        [Required]
        public int NgaySinh { get; set; }

        [Required]
        public string Nganh { get; set; }

        public string MaLop { get; set; }

        [ForeignKey("MaLop")]
        public virtual LopHoc? LopHoc { get; set; }
    }
}
