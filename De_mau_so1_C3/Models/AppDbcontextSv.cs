using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace De_mau_so1_C3.Models
{
    public class AppDbcontextSv : DbContext
    {
        public AppDbcontextSv(DbContextOptions options) : base(options)
        {
        }

        public DbSet<LopHoc> LopHocs { get; set; }
        public DbSet<SinhVien> SinhViens { get; set; }


    }
}
