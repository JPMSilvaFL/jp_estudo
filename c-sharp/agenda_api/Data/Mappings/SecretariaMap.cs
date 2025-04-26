using agenda_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace agenda_api.Data.Mappings;

public class SecretariaMap : IEntityTypeConfiguration<Secretaria> {
	public void Configure(EntityTypeBuilder<Secretaria> builder) {
		builder.ToTable("Secretaria");

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
			.WithOne()
			.HasForeignKey<Secretaria>(x => x.IdFuncionario)
			.HasConstraintName("FK_Secretaria_Funcionario")
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(x => x.IdSala)
			.HasColumnName("IdSala")
			.HasColumnType("uniqueidentifier");

	}
}