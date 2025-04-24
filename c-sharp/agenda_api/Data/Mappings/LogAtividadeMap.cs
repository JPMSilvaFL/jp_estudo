using agenda_api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace agenda_api.Data.Mappings;

public class LogAtividadeMap : IEntityTypeConfiguration<LogAtividade> {
	public void Configure(EntityTypeBuilder<LogAtividade> builder) { }
}