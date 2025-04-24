using agenda_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace agenda_api.Data.Mappings;

public class PessoaMap : IEntityTypeConfiguration<Pessoa> {
	public void Configure(EntityTypeBuilder<Pessoa> builder) {
		builder.ToTable("Pessoa");

		builder.HasKey(p => p.Id);
		builder.Property(p => p.Id)
			.HasColumnName("Id")
			.HasColumnType("UniqueIdentifier")
			.IsRequired();

		builder.Property(p => p.Cpf)
			.HasColumnName("Cpf")
			.HasColumnType("varchar")
			.HasMaxLength(11)
			.IsRequired();
		builder.HasIndex(p => p.Cpf)
			.IsUnique();

		builder.Property(p => p.FullName)
			.HasColumnName("NomeCompleto")
			.HasColumnType("nvarchar")
			.HasMaxLength(100)
			.IsRequired();

		builder.Property(p => p.Email)
			.HasColumnName("Email")
			.HasColumnType("nvarchar")
			.HasMaxLength(100)
			.IsRequired();
		builder.HasIndex(p => p.Email)
			.IsUnique();

		builder.Property(p => p.Endereco)
			.HasColumnName("Endereco")
			.HasColumnType("nvarchar")
			.HasMaxLength(150)
			.IsRequired();

		builder.Property(p => p.Contato)
			.HasColumnName("Contato")
			.HasColumnType("varchar")
			.HasMaxLength(30)
			.IsRequired();

		builder.Property(p => p.IsActive)
			.HasColumnName("IsActive")
			.HasColumnType("bit")
			.HasDefaultValue(true);

		builder.Property(p => p.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();

		builder.Property(p => p.UpdatedAt)
			.HasColumnName("UpdatedAt")
			.HasColumnType("datetime");
	}
}