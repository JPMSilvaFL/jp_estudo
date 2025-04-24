using agenda_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace agenda_api.Data.Mappings;

public class LogAtividadeMap : IEntityTypeConfiguration<LogAtividade> {
	public void Configure(EntityTypeBuilder<LogAtividade> builder) {
		builder.ToTable("LogAtividades");

		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.IsRequired();

		builder.Property(x => x.Categoria)
			.HasColumnName("Categoria")
			.HasColumnType("nvarchar")
			.HasMaxLength(40)
			.IsRequired();

		builder.Property(x => x.Descricao)
			.HasColumnName("Descricao")
			.HasColumnType("nvarchar")
			.HasMaxLength(250)
			.IsRequired();

		builder.Property(x => x.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();

		builder.Property(x => x.IdPessoa)
			.HasColumnName("IdPessoa")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasOne<Pessoa>(x => x.Pessoa)
			.WithMany()
			.HasForeignKey(x => x.IdPessoa)
			.OnDelete(DeleteBehavior.Cascade);
	}
}