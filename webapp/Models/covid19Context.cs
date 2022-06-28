using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace webapp.Models
{
    public partial class covid19Context : DbContext
    {
        public covid19Context()
        {
        }

        public covid19Context(DbContextOptions<covid19Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<CtHoadon> CtHoadons { get; set; }
        public virtual DbSet<Danhmuc> Danhmucs { get; set; }
        public virtual DbSet<Dantoc> Dantocs { get; set; }
        public virtual DbSet<Gopy> Gopies { get; set; }
        public virtual DbSet<Hoadon> Hoadons { get; set; }
        public virtual DbSet<Hoso> Hosos { get; set; }
        public virtual DbSet<Khachhang> Khachhangs { get; set; }
        public virtual DbSet<Lienhe> Lienhes { get; set; }
        public virtual DbSet<Quoctich> Quoctiches { get; set; }
        public virtual DbSet<Sanpham> Sanphams { get; set; }
        public virtual DbSet<Tkadmin> Tkadmins { get; set; }
        public virtual DbSet<Tokhai> Tokhais { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-BTJRTTO;Initial Catalog=covid19;Integrated Security=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.HasKey(e => e.Mablog)
                    .HasName("PK__BLOG__F7387DBCA04443BD");

                entity.ToTable("BLOG");

                entity.Property(e => e.Mablog).HasColumnName("MABLOG");

                entity.Property(e => e.Anh)
                    .HasMaxLength(255)
                    .HasColumnName("ANH");

                entity.Property(e => e.Ngaydang)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("NGAYDANG");

                entity.Property(e => e.Noidung)
                    .HasMaxLength(2000)
                    .HasColumnName("NOIDUNG");

                entity.Property(e => e.Tieude)
                    .HasMaxLength(100)
                    .HasColumnName("TIEUDE");

                entity.Property(e => e.Tk)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TK");

                entity.HasOne(d => d.TkNavigation)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.Tk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__BLOG__TK__440B1D61");
            });

            modelBuilder.Entity<CtHoadon>(entity =>
            {
                entity.HasKey(e => new { e.Masp, e.Mdhd })
                    .HasName("PK__CT_HOADO__518DC7BDC704019D");

                entity.ToTable("CT_HOADON");

                entity.Property(e => e.Masp).HasColumnName("MASP");

                entity.Property(e => e.Mdhd).HasColumnName("MDHD");

                entity.Property(e => e.Dongia).HasColumnName("DONGIA");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.HasOne(d => d.MaspNavigation)
                    .WithMany(p => p.CtHoadons)
                    .HasForeignKey(d => d.Masp)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CT_HOADON__MASP__3F466844");

                entity.HasOne(d => d.MdhdNavigation)
                    .WithMany(p => p.CtHoadons)
                    .HasForeignKey(d => d.Mdhd)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CT_HOADON__MDHD__403A8C7D");
            });

            modelBuilder.Entity<Danhmuc>(entity =>
            {
                entity.HasKey(e => e.Madm)
                    .HasName("PK__EN__603F005C2A52DB09");

                entity.ToTable("DANHMUC");

                entity.Property(e => e.Madm).HasColumnName("MADM");

                entity.Property(e => e.Tendm)
                    .HasMaxLength(50)
                    .HasColumnName("TENDM");
            });

            modelBuilder.Entity<Dantoc>(entity =>
            {
                entity.HasKey(e => e.Madt)
                    .HasName("PK__DANTOC__603F005BA9E7B9E0");

                entity.ToTable("DANTOC");

                entity.Property(e => e.Madt).HasColumnName("MADT");

                entity.Property(e => e.Tendt)
                    .HasMaxLength(30)
                    .HasColumnName("TENDT");
            });

            modelBuilder.Entity<Gopy>(entity =>
            {
                entity.HasKey(e => e.Magy)
                    .HasName("PK__GOPY__603F38B2A1DFBE63");

                entity.ToTable("GOPY");

                entity.Property(e => e.Magy).HasColumnName("MAGY");

                entity.Property(e => e.Makh).HasColumnName("MAKH");

                entity.Property(e => e.Noidung)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NOIDUNG")
                    .IsFixedLength(true);

                entity.Property(e => e.Tinhtrang)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TINHTRANG")
                    .IsFixedLength(true);

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Gopies)
                    .HasForeignKey(d => d.Makh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GOPY__MAKH__3E52440B");
            });

            modelBuilder.Entity<Hoadon>(entity =>
            {
                entity.HasKey(e => e.Mdhd)
                    .HasName("PK__HOADON__1AF4D8F2B1458E9E");

                entity.ToTable("HOADON");

                entity.Property(e => e.Mdhd).HasColumnName("MDHD");

                entity.Property(e => e.Diachinhan)
                    .HasMaxLength(100)
                    .HasColumnName("DIACHINHAN");

                entity.Property(e => e.Makh).HasColumnName("MAKH");

                entity.Property(e => e.Ngaylap)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYLAP");

                entity.Property(e => e.Nguoinhan)
                    .HasMaxLength(40)
                    .HasColumnName("NGUOINHAN");

                entity.Property(e => e.Sdtnhan)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDTNHAN")
                    .IsFixedLength(true);

                entity.Property(e => e.Tinhtranggiaohang).HasColumnName("TINHTRANGGIAOHANG");

                entity.Property(e => e.Tinhtrangthanhtoan).HasColumnName("TINHTRANGTHANHTOAN");

                entity.Property(e => e.Tongtien)
                    .HasColumnType("money")
                    .HasColumnName("TONGTIEN");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Hoadons)
                    .HasForeignKey(d => d.Makh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HOADON__MAKH__3D5E1FD2");
            });

            modelBuilder.Entity<Hoso>(entity =>
            {
                entity.HasKey(e => e.Mahs)
                    .HasName("PK__HOSO__603F20DD18F7F955");

                entity.ToTable("HOSO");

                entity.Property(e => e.Mahs).HasColumnName("MAHS");

                entity.Property(e => e.Khuvuc)
                    .HasMaxLength(100)
                    .HasColumnName("KHUVUC");

                entity.Property(e => e.Makh).HasColumnName("MAKH");

                entity.Property(e => e.Ngaylap)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYLAP");

                entity.Property(e => e.Tinhtrang).HasColumnName("TINHTRANG");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Hosos)
                    .HasForeignKey(d => d.Makh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HOSO__MAKH__3B75D760");
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makh)
                    .HasName("PK__KHACHHAN__603F592C8E3D8CCC");

                entity.ToTable("KHACHHANG");

                entity.Property(e => e.Makh).HasColumnName("MAKH");

                entity.Property(e => e.Anhdaidien)
                    .HasMaxLength(255)
                    .HasColumnName("ANHDAIDIEN");

                entity.Property(e => e.Cmnd)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .HasColumnName("CMND")
                    .IsFixedLength(true);

                entity.Property(e => e.Diachi)
                    .HasMaxLength(100)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Gioitinh)
                    .HasMaxLength(5)
                    .HasColumnName("GIOITINH");

                entity.Property(e => e.Madt).HasColumnName("MADT");

                entity.Property(e => e.Maqt).HasColumnName("MAQT");

                entity.Property(e => e.Mk)
                    .HasMaxLength(20)
                    .HasColumnName("MK");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("datetime")
                    .HasColumnName("NGAYSINH");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT")
                    .IsFixedLength(true);

                entity.Property(e => e.Tenkh)
                    .HasMaxLength(40)
                    .HasColumnName("TENKH");

                entity.Property(e => e.Tk)
                    .HasMaxLength(20)
                    .HasColumnName("TK");

                entity.HasOne(d => d.MadtNavigation)
                    .WithMany(p => p.Khachhangs)
                    .HasForeignKey(d => d.Madt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KHACHHANG__MADT__4316F928");

                entity.HasOne(d => d.MaqtNavigation)
                    .WithMany(p => p.Khachhangs)
                    .HasForeignKey(d => d.Maqt)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__KHACHHANG__MAQT__4222D4EF");
            });

            modelBuilder.Entity<Lienhe>(entity =>
            {
                entity.HasKey(e => e.Malh)
                    .HasName("PK__LIENHE__603F414D11EA5BAB");

                entity.ToTable("LIENHE");

                entity.Property(e => e.Malh).HasColumnName("MALH");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(100)
                    .HasColumnName("DIACHI");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Facebook)
                    .HasMaxLength(255)
                    .HasColumnName("FACEBOOK");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("SDT")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Quoctich>(entity =>
            {
                entity.HasKey(e => e.Maqt)
                    .HasName("PK__QUOCTICH__602379EC6ACC065C");

                entity.ToTable("QUOCTICH");

                entity.Property(e => e.Maqt).HasColumnName("MAQT");

                entity.Property(e => e.Tenqt)
                    .HasMaxLength(50)
                    .HasColumnName("TENQT");
            });

            modelBuilder.Entity<Sanpham>(entity =>
            {
                entity.HasKey(e => e.Masp)
                    .HasName("PK__SANPHAM__60228A323A49FC72");

                entity.ToTable("SANPHAM");

                entity.Property(e => e.Masp).HasColumnName("MASP");

                entity.Property(e => e.Dongia).HasColumnName("DONGIA");

                entity.Property(e => e.Img)
                    .HasMaxLength(255)
                    .HasColumnName("IMG");

                entity.Property(e => e.Madm).HasColumnName("MADM");

                entity.Property(e => e.Soluong).HasColumnName("SOLUONG");

                entity.Property(e => e.Tensp)
                    .HasMaxLength(50)
                    .HasColumnName("TENSP");

                entity.Property(e => e.Thongtin)
                    .HasMaxLength(1000)
                    .HasColumnName("THONGTIN");

                entity.HasOne(d => d.MadmNavigation)
                    .WithMany(p => p.Sanphams)
                    .HasForeignKey(d => d.Madm)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__SANPHAM__MADM__412EB0B6");
            });

            modelBuilder.Entity<Tkadmin>(entity =>
            {
                entity.HasKey(e => e.Tk)
                    .HasName("PK__ADMIN__3214E400AD5CE45F");

                entity.ToTable("TKADMIN");

                entity.Property(e => e.Tk)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("TK");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Hoten)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("HOTEN")
                    .IsFixedLength(true);

                entity.Property(e => e.Mk)
                    .IsRequired()
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("MK");
            });

            modelBuilder.Entity<Tokhai>(entity =>
            {
                entity.HasKey(e => e.Matokhai)
                    .HasName("PK__TOKHAI__D056C0E80D305F78");

                entity.ToTable("TOKHAI");

                entity.Property(e => e.Matokhai).HasColumnName("MATOKHAI");

                entity.Property(e => e.Dinhungdau)
                    .HasMaxLength(100)
                    .HasColumnName("DINHUNGDAU");

                entity.Property(e => e.Makh).HasColumnName("MAKH");

                entity.Property(e => e.Nguoicobieuhien).HasColumnName("NGUOICOBIEUHIEN");

                entity.Property(e => e.Trieuchung)
                    .HasMaxLength(100)
                    .HasColumnName("TRIEUCHUNG");

                entity.Property(e => e.Txnguoibenh).HasColumnName("TXNGUOIBENH");

                entity.Property(e => e.Txnguoinuocbenh).HasColumnName("TXNGUOINUOCBENH");

                entity.HasOne(d => d.MakhNavigation)
                    .WithMany(p => p.Tokhais)
                    .HasForeignKey(d => d.Makh)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TOKHAI__MAKH__3C69FB99");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
