using agenda_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace agenda_api.Data.Mappings;

public class ClienteMap : IEntityTypeConfiguration<Cliente> {
	public void Configure(EntityTypeBuilder<Cliente> builder) {
		builder.ToTable("Cliente");

		builder.HasKey(x => x.Id);
		builder.Property(x => x.Id)
			.HasColumnType("uniqueidentifier")
			.HasColumnName("Id")
			.IsRequired();

		builder.Property(x => x.PessoaId)
			.HasColumnType("uniqueidentifier")
			.HasColumnName("IdPerson")
			.IsRequired();
		builder.HasOne(p => p.Pessoa)
			.WithOne()
			.HasForeignKey<Cliente>(p => p.PessoaId)
			.HasConstraintName("FK_Cliente_Pessoa")
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(p => p.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();
	}
}