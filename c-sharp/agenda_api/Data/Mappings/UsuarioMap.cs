using agenda_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace agenda_api.Data.Mappings;

public class UsuarioMap : IEntityTypeConfiguration<Usuario> {
	public void Configure(EntityTypeBuilder<Usuario> builder) {
		builder.ToTable("Usuario");

		builder.HasKey(u => u.Id);
		builder.Property(u => u.Id)
			.HasColumnName("Id")
			.HasColumnType("UniqueIdentifier")
			.IsRequired();

		builder.Property(u => u.Username)
			.HasColumnName("Username")
			.HasColumnType("varchar")
			.HasMaxLength(50)
			.IsRequired();

		builder.Property(u => u.Password)
			.HasColumnName("Password")
			.HasColumnType("nvarchar")
			.IsRequired();

		builder.Property(u => u.PessoaId)
			.HasColumnName("PessoaId")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasOne(u => u.Pessoa)
			.WithOne()
			.HasForeignKey<Usuario>(u => u.PessoaId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(u => u.PerfilAcessoId)
			.HasColumnName("PerfilAcessoId")
			.HasColumnType("uniqueidentifier")
			.IsRequired();
		builder.HasOne(p => p.Acesso)
			.WithMany()
			.HasForeignKey(x => x.PerfilAcessoId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.Property(u => u.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();
	}
}