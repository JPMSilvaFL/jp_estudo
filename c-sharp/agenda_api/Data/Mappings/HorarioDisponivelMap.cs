using agenda_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace agenda_api.Data.Mappings;

public class HorarioDisponivelMap : IEntityTypeConfiguration<HorarioDisponivel> {
	public void Configure(EntityTypeBuilder<HorarioDisponivel> builder) {
		builder.ToTable("HorarioDisponivel");

		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.IsRequired();

		builder.Property(x => x.Horario)
			.HasColumnName("Horario")
			.HasColumnType("DateTime")
			.IsRequired();

		builder.Property(x => x.IdFuncionario)
			.HasColumnName("IdFuncionario")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasOne(x => x.Funcionario)
			.WithMany()
			.HasForeignKey(x => x.IdFuncionario)
			.HasConstraintName("Fk_HorarioDisponivel_Funcionario")
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(x => x.Reservado)
			.HasColumnName("Reservado")
			.HasColumnType("bit")
			.IsRequired();
	}
}