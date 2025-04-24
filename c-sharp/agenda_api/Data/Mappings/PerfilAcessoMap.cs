using agenda_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace agenda_api.Data.Mappings;

public class PerfilAcessoMap : IEntityTypeConfiguration<PerfilAcesso> {
	public void Configure(EntityTypeBuilder<PerfilAcesso> builder) {
		builder.ToTable("PerfilAcesso");

		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id)
			.HasColumnName("Id")
			.HasColumnType("uniqueidentifier")
			.IsRequired();

		builder.Property(x => x.Nome)
			.HasColumnName("Nome")
			.HasColumnType("nvarchar")
			.HasMaxLength(40)
			.IsRequired();
	}
}