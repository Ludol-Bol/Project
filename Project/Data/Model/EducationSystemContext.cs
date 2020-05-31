using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Project
{
    public partial class EducationSystemContext : DbContext
    {
        public EducationSystemContext()
        {
        }

        public EducationSystemContext(DbContextOptions<EducationSystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Parents> Parents { get; set; }
        public virtual DbSet<Pupils> Pupils { get; set; }
        public virtual DbSet<School> School { get; set; }
        public virtual DbSet<Subject> Subject { get; set; }
        public virtual DbSet<Teachers> Teachers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-BKGU4FGD\\NEWSQL;Initial Catalog=EducationSystem;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(e => e.Idcourse)
                    .HasName("PK_Course");

                entity.HasIndex(e => e.Idschool);

                entity.HasIndex(e => e.Idsubgect);

                entity.HasIndex(e => e.Idteachers);

                entity.Property(e => e.Idcourse).HasColumnName("IDCourse");

                entity.Property(e => e.Idschool).HasColumnName("IDSchool");

                entity.Property(e => e.Idsubgect).HasColumnName("IDSubgect");

                entity.Property(e => e.Idteachers).HasColumnName("IDTeachers");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(3000);

                entity.HasOne(d => d.IdschoolNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Idschool)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Courses_School");

                entity.HasOne(d => d.IdsubgectNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Idsubgect)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Courses_Subject");

                entity.HasOne(d => d.IdteachersNavigation)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.Idteachers)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Courses_Teachers");
            });

            modelBuilder.Entity<Parents>(entity =>
            {
                entity.HasKey(e => e.Idparent)
                    .HasName("PK_Parent_1");

                entity.Property(e => e.Idparent)
                    .HasColumnName("IDParent")
                    .ValueGeneratedNever();

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.NameFather).HasMaxLength(50);

                entity.Property(e => e.NameMather).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PatronymicFather).HasMaxLength(200);

                entity.Property(e => e.PatronymicMather).HasMaxLength(200);

                entity.Property(e => e.PhoneFather)
                    .HasMaxLength(12)
                    .IsFixedLength();

                entity.Property(e => e.PhoneMathe)
                    .HasMaxLength(12)
                    .IsFixedLength();

                entity.Property(e => e.SurnameFather).HasMaxLength(200);

                entity.Property(e => e.SurnameMather).HasMaxLength(200);
            });

            modelBuilder.Entity<Pupils>(entity =>
            {
                entity.HasKey(e => e.Idpupil);

                entity.HasIndex(e => e.Idparent);

                entity.HasIndex(e => e.Idschool);

                entity.Property(e => e.Idpupil).HasColumnName("IDPupil");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Idparent).HasColumnName("IDParent");

                entity.Property(e => e.Idschool).HasColumnName("IDSchool");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(200);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.IdparentNavigation)
                    .WithMany(p => p.Pupils)
                    .HasForeignKey(d => d.Idparent)
                    .HasConstraintName("FK_Pupil_Parent");

                entity.HasOne(d => d.IdschoolNavigation)
                    .WithMany(p => p.Pupils)
                    .HasForeignKey(d => d.Idschool)
                    .HasConstraintName("FK_Pupils_School");
            });

            modelBuilder.Entity<School>(entity =>
            {
                entity.HasKey(e => e.Idschool);

                entity.Property(e => e.Idschool).HasColumnName("IDSchool");

                entity.Property(e => e.NameSchool).IsRequired();
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(e => e.Idsubject);

                entity.Property(e => e.Idsubject).HasColumnName("IDSubject");

                entity.Property(e => e.NamrSubject)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Teachers>(entity =>
            {
                entity.HasKey(e => e.Idteacher);

                entity.Property(e => e.Idteacher).HasColumnName("IDTeacher");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Idschool).HasColumnName("IDSchool");

                entity.Property(e => e.Idsubject).HasColumnName("IDSubject");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Patronymic).HasMaxLength(200);

                entity.Property(e => e.Phone)
                    .HasMaxLength(12)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
