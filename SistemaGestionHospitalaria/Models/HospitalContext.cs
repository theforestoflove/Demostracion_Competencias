using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SistemaGestionHospitalaria.Models;

public partial class HospitalContext : DbContext
{
    public HospitalContext()
    {
    }

    public HospitalContext(DbContextOptions<HospitalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cita> Citas { get; set; }

    public virtual DbSet<Consultorio> Consultorios { get; set; }

    public virtual DbSet<Especialidade> Especialidades { get; set; }

    public virtual DbSet<Habitacione> Habitaciones { get; set; }

    public virtual DbSet<HistoriasClinica> HistoriasClinicas { get; set; }

    public virtual DbSet<Internacione> Internaciones { get; set; }

    public virtual DbSet<Medicamento> Medicamentos { get; set; }

    public virtual DbSet<Medico> Medicos { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Receta> Recetas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=hospital;Username=postgres;Password=123456");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("citas_pkey");

            entity.ToTable("citas");

            entity.Property(e => e.IdCita).HasColumnName("id_cita");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Pendiente'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.Hora).HasColumnName("hora");
            entity.Property(e => e.IdConsultorio).HasColumnName("id_consultorio");
            entity.Property(e => e.IdMedico).HasColumnName("id_medico");
            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

            entity.HasOne(d => d.IdConsultorioNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdConsultorio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("citas_id_consultorio_fkey");

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("citas_id_medico_fkey");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("citas_id_paciente_fkey");
        });

        modelBuilder.Entity<Consultorio>(entity =>
        {
            entity.HasKey(e => e.IdConsultorio).HasName("consultorios_pkey");

            entity.ToTable("consultorios");

            entity.Property(e => e.IdConsultorio).HasColumnName("id_consultorio");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasColumnName("numero");
            entity.Property(e => e.Piso).HasColumnName("piso");
        });

        modelBuilder.Entity<Especialidade>(entity =>
        {
            entity.HasKey(e => e.IdEspecialidad).HasName("especialidades_pkey");

            entity.ToTable("especialidades");

            entity.Property(e => e.IdEspecialidad).HasColumnName("id_especialidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Habitacione>(entity =>
        {
            entity.HasKey(e => e.IdHabitacion).HasName("habitaciones_pkey");

            entity.ToTable("habitaciones");

            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.Estado)
                .HasMaxLength(20)
                .HasDefaultValueSql("'Libre'::character varying")
                .HasColumnName("estado");
            entity.Property(e => e.Numero)
                .HasMaxLength(10)
                .HasColumnName("numero");
            entity.Property(e => e.Tipo)
                .HasMaxLength(50)
                .HasColumnName("tipo");
        });

        modelBuilder.Entity<HistoriasClinica>(entity =>
        {
            entity.HasKey(e => e.IdHistoria).HasName("historias_clinicas_pkey");

            entity.ToTable("historias_clinicas");

            entity.Property(e => e.IdHistoria).HasColumnName("id_historia");
            entity.Property(e => e.Diagnostico).HasColumnName("diagnostico");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.Tratamiento).HasColumnName("tratamiento");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.HistoriasClinicas)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("historias_clinicas_id_paciente_fkey");
        });

        modelBuilder.Entity<Internacione>(entity =>
        {
            entity.HasKey(e => e.IdInternacion).HasName("internaciones_pkey");

            entity.ToTable("internaciones");

            entity.Property(e => e.IdInternacion).HasColumnName("id_internacion");
            entity.Property(e => e.FechaIngreso).HasColumnName("fecha_ingreso");
            entity.Property(e => e.FechaSalida).HasColumnName("fecha_salida");
            entity.Property(e => e.IdHabitacion).HasColumnName("id_habitacion");
            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

            entity.HasOne(d => d.IdHabitacionNavigation).WithMany(p => p.Internaciones)
                .HasForeignKey(d => d.IdHabitacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("internaciones_id_habitacion_fkey");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Internaciones)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("internaciones_id_paciente_fkey");
        });

        modelBuilder.Entity<Medicamento>(entity =>
        {
            entity.HasKey(e => e.IdMedicamento).HasName("medicamentos_pkey");

            entity.ToTable("medicamentos");

            entity.Property(e => e.IdMedicamento).HasColumnName("id_medicamento");
            entity.Property(e => e.Descripcion).HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Medico>(entity =>
        {
            entity.HasKey(e => e.IdMedico).HasName("medicos_pkey");

            entity.ToTable("medicos");

            entity.Property(e => e.IdMedico).HasColumnName("id_medico");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Correo)
                .HasMaxLength(100)
                .HasColumnName("correo");
            entity.Property(e => e.IdEspecialidad).HasColumnName("id_especialidad");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdEspecialidadNavigation).WithMany(p => p.Medicos)
                .HasForeignKey(d => d.IdEspecialidad)
                .HasConstraintName("medicos_id_especialidad_fkey");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IdPaciente).HasName("pacientes_pkey");

            entity.ToTable("pacientes");

            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");
            entity.Property(e => e.Apellido)
                .HasMaxLength(100)
                .HasColumnName("apellido");
            entity.Property(e => e.Direccion)
                .HasMaxLength(200)
                .HasColumnName("direccion");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fecha_nacimiento");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Sexo)
                .HasMaxLength(10)
                .HasColumnName("sexo");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Receta>(entity =>
        {
            entity.HasKey(e => e.IdReceta).HasName("recetas_pkey");

            entity.ToTable("recetas");

            entity.Property(e => e.IdReceta).HasColumnName("id_receta");
            entity.Property(e => e.Dosis)
                .HasMaxLength(100)
                .HasColumnName("dosis");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdMedicamento).HasColumnName("id_medicamento");
            entity.Property(e => e.IdMedico).HasColumnName("id_medico");
            entity.Property(e => e.IdPaciente).HasColumnName("id_paciente");

            entity.HasOne(d => d.IdMedicamentoNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.IdMedicamento)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recetas_id_medicamento_fkey");

            entity.HasOne(d => d.IdMedicoNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.IdMedico)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recetas_id_medico_fkey");

            entity.HasOne(d => d.IdPacienteNavigation).WithMany(p => p.Receta)
                .HasForeignKey(d => d.IdPaciente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("recetas_id_paciente_fkey");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
