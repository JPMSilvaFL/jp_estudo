using agenda_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace agenda_api.Data.Mappings;

public class AtendimentoMap : IEntityTypeConfiguration<Atendimento> {
	public void Configure(EntityTypeBuilder<Atendimento> builder) {
		builder.ToTable("Atendimento");

		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.IsRequired();

		builder.Property(x => x.IdFuncionario)
			.HasColumnName("IdFuncionario")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasOne(x => x.Funcionario)
			.WithMany()
			.HasForeignKey(x => x.IdFuncionario)
			.HasConstraintName("FK_Atendimento_Funcionario")
			.OnDelete(DeleteBehavior.NoAction);

		builder.Property(x => x.IdCliente)
			.HasColumnName("IdCliente")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasOne(x => x.Cliente)
			.WithOne()
			.HasForeignKey<Atendimento>(x => x.IdCliente)
			.HasConstraintName("FK_Atendimento_Cliente")
			.OnDelete(DeleteBehavior.NoAction);

		builder.Property(x => x.IdSecretaria)
			.HasColumnType("uniqueidentifier")
			.HasColumnName("IdSecretaria")
			.IsRequired();
		builder.HasOne(x => x.Secretaria)
			.WithOne()
			.HasForeignKey<Atendimento>(x => x.IdSecretaria)
			.HasConstraintName("Fk_Atendimento_Secretaria")
			.OnDelete(DeleteBehavior.NoAction);

		builder.Property(x => x.IdHorario)
			.HasColumnName("IdHorario")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasIndex(x => x.IdHorario)
			.IsUnique();
		builder.HasOne(x => x.HorarioDisponivel)
			.WithOne()
			.HasForeignKey<Atendimento>(x => x.IdHorario)
			.HasConstraintName("FK_Atendimento_Horario")
			.OnDelete(DeleteBehavior.NoAction);
	}
}