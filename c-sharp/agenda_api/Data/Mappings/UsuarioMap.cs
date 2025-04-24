using agenda_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace agenda_api.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<Usuario> {
	public void Configure(EntityTypeBuilder<Usuario> builder) {
		builder.HasKey(u => u.Id);
		builder.Property(u => u.Id)
			.HasColumnName("Id")
			.HasColumnType("UniqueIdentifier")
			.IsRequired();

		builder.Property(u => u.Username)
			.HasColumnName("Username")
			.HasColumnType("varchar(100)")
			.IsRequired();

		builder.Property(u => u.Password)
			.HasColumnName("Password")
			.HasColumnType("varchar(100)")
			.IsRequired();

		builder.Property(u => u.PessoaId)
			.HasColumnName("PessoaId")
			.HasColumnType("uniqueidentifier")
			.IsRequired();

		builder.Property(u => u.PerfilAcessoId)
			.HasColumnName("PerfilAcessoId")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasOne<PerfilAcesso>(p => p.Acesso)
			.WithMany()
			.HasForeignKey(x => x.PessoaId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(u => u.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();
	}
}