using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MVCAPIAuthenticationTecsaUser.Moldels
{
    public partial class tecsaofficeContext : DbContext
    {
        public tecsaofficeContext()
        {
        }

        public tecsaofficeContext(DbContextOptions<tecsaofficeContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Module> Modules { get; set; }
        public virtual DbSet<Operation> Operations { get; set; }
        public virtual DbSet<Rol> Rols { get; set; }
        public virtual DbSet<RolOperation> RolOperations { get; set; }
        public virtual DbSet<RollCall> RollCalls { get; set; }
        public virtual DbSet<Tecsauser> Tecsausers { get; set; }
        public virtual DbSet<WorkinTecsauser> WorkinTecsausers { get; set; }
        public virtual DbSet<Working> Workings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=tecnicaencolectores.com.mx;database=tecsaoffice;uid=tecnicae;pwd=empresa21Tecs@;sslmode=none", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.3.31-mariadb"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("latin1")
                .UseCollation("latin1_swedish_ci");

            modelBuilder.Entity<Module>(entity =>
            {
                entity.HasKey(e => e.IdModule)
                    .HasName("PRIMARY");

                entity.ToTable("module");

                entity.Property(e => e.IdModule)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_module");

                entity.Property(e => e.NameModule)
                    .HasMaxLength(49)
                    .HasColumnName("name_module")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Operation>(entity =>
            {
                entity.HasKey(e => e.IdOperation)
                    .HasName("PRIMARY");

                entity.ToTable("operation");

                entity.HasIndex(e => e.IdModule, "id_module");

                entity.Property(e => e.IdOperation)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_operation");

                entity.Property(e => e.IdModule)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_module");

                entity.Property(e => e.NameOperation)
                    .HasMaxLength(49)
                    .HasColumnName("name_operation")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdModuleNavigation)
                    .WithMany(p => p.Operations)
                    .HasForeignKey(d => d.IdModule)
                    .HasConstraintName("operation_ibfk_1");
            });

            modelBuilder.Entity<Rol>(entity =>
            {
                entity.HasKey(e => e.IdRol)
                    .HasName("PRIMARY");

                entity.ToTable("rol");

                entity.Property(e => e.IdRol)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_rol");

                entity.Property(e => e.Name)
                    .HasMaxLength(49)
                    .HasColumnName("name")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<RolOperation>(entity =>
            {
                entity.HasKey(e => e.IdUp)
                    .HasName("PRIMARY");

                entity.ToTable("rol_operation");

                entity.HasIndex(e => e.IdOperation, "id_operation");

                entity.HasIndex(e => e.IdRol, "id_rol");

                entity.Property(e => e.IdUp)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_up");

                entity.Property(e => e.IdOperation)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_operation");

                entity.Property(e => e.IdRol)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_rol");

                entity.HasOne(d => d.IdOperationNavigation)
                    .WithMany(p => p.RolOperations)
                    .HasForeignKey(d => d.IdOperation)
                    .HasConstraintName("rol_operation_ibfk_2");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.RolOperations)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("rol_operation_ibfk_1");
            });

            modelBuilder.Entity<RollCall>(entity =>
            {
                entity.HasKey(e => e.IdDay)
                    .HasName("PRIMARY");

                entity.ToTable("roll_call");

                entity.HasIndex(e => e.IdUser, "id_user");

                entity.Property(e => e.IdDay)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_day");

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_user");

                entity.Property(e => e.NameDay)
                    .HasColumnType("date")
                    .HasColumnName("name_day");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.RollCalls)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("roll_call_ibfk_1");
            });

            modelBuilder.Entity<Tecsauser>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PRIMARY");

                entity.ToTable("tecsauser");

                entity.HasIndex(e => e.IdRol, "id_rol");

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_user");

                entity.Property(e => e.DateUser)
                    .HasColumnType("date")
                    .HasColumnName("date_user");

                entity.Property(e => e.EmailUser)
                    .HasMaxLength(49)
                    .HasColumnName("email_user")
                    .IsFixedLength(true);

                entity.Property(e => e.IdRol)
                    .HasColumnType("int(9)")
                    .HasColumnName("id_rol");

                entity.Property(e => e.NameUser)
                    .HasMaxLength(49)
                    .HasColumnName("name_user")
                    .IsFixedLength(true);

                entity.Property(e => e.PasswordUser)
                    .HasMaxLength(200)
                    .HasColumnName("password_user");

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Tecsausers)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("tecsauser_ibfk_1");
            });

            modelBuilder.Entity<WorkinTecsauser>(entity =>
            {
                entity.HasKey(e => e.IdWt)
                    .HasName("PRIMARY");

                entity.ToTable("workin_tecsauser");

                entity.HasIndex(e => e.IdUser, "id_user");

                entity.HasIndex(e => e.IdWork, "id_work");

                entity.Property(e => e.IdWt)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_wt");

                entity.Property(e => e.DETask)
                    .HasMaxLength(25)
                    .HasColumnName("d_e_task")
                    .IsFixedLength(true);

                entity.Property(e => e.DSTask)
                    .HasMaxLength(25)
                    .HasColumnName("d_s_task")
                    .IsFixedLength(true);

                entity.Property(e => e.HETask)
                    .HasMaxLength(25)
                    .HasColumnName("h_e_task")
                    .IsFixedLength(true);

                entity.Property(e => e.HSTask)
                    .HasMaxLength(25)
                    .HasColumnName("h_s_task")
                    .IsFixedLength(true);

                entity.Property(e => e.IdUser)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_user");

                entity.Property(e => e.IdWork)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_work");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.WorkinTecsausers)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("workin_tecsauser_ibfk_2");

                entity.HasOne(d => d.IdWorkNavigation)
                    .WithMany(p => p.WorkinTecsausers)
                    .HasForeignKey(d => d.IdWork)
                    .HasConstraintName("workin_tecsauser_ibfk_1");
            });

            modelBuilder.Entity<Working>(entity =>
            {
                entity.HasKey(e => e.IdWork)
                    .HasName("PRIMARY");

                entity.ToTable("working");

                entity.HasIndex(e => e.IdRol, "id_rol");

                entity.Property(e => e.IdWork)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_work");

                entity.Property(e => e.DescriptionWork)
                    .HasMaxLength(99)
                    .HasColumnName("description_work");

                entity.Property(e => e.IdRol)
                    .HasColumnType("int(11)")
                    .HasColumnName("id_rol");

                entity.Property(e => e.StatusWork)
                    .HasMaxLength(49)
                    .HasColumnName("status_work")
                    .IsFixedLength(true);

                entity.Property(e => e.TitleWork)
                    .HasMaxLength(49)
                    .HasColumnName("title_work")
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdRolNavigation)
                    .WithMany(p => p.Workings)
                    .HasForeignKey(d => d.IdRol)
                    .HasConstraintName("working_ibfk_1");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
