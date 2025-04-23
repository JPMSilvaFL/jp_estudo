using agenda_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Agenda_EFMigratios.Data.Mappings;

public class ClienteMap : IEntityTypeConfiguration<Cliente> {
	public void Configure(EntityTypeBuilder<Cliente> builder)
	{
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
			.WithMany()
			.HasForeignKey(p => p.PessoaId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.Property(p => p.CreatedAt)
			.HasColumnName("CreatedAt")
			.HasColumnType("datetime")
			.IsRequired();
	}
}

// CREATE TABLE Cliente(
// 	id uniqueidentifier primary key default newsequentialid(),
// 	idPerson uniqueidentifier not null
// constraint FK_Cliente_Person
// foreign key (idPerson)
// references Person(id)
// on delete cascade,
// 	)