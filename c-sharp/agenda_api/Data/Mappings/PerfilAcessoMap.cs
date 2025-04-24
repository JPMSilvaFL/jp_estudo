using agenda_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace agenda_api.Data.Mappings;

public class PerfilAcessoMap : IEntityTypeConfiguration<PerfilAcesso> {
	public void Configure(EntityTypeBuilder<PerfilAcesso> builder) { }
}