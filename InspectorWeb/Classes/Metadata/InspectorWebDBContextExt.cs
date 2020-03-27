using InspectorWeb.ModelsDB;
using Microsoft.EntityFrameworkCore;

namespace InspectorWeb.Classes.Metadata
{
	//public class InspectorWebDBContext : InspectorWebDBContext
	//{
	//	public InspectorWebDBContext(DbContextOptions<InspectorWebDBContext> options) : base(options)
	//	{
	//	}

	//	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	//	{
	//	}

	//	protected override void OnModelCreating(ModelBuilder modelBuilder)
	//	{
	//		base.OnModelCreating(modelBuilder);

	//		//modelBuilder.Entity<DocsConclusionsExamination>(entity =>
	//		//{
	//		//	entity
	//		//	.HasOne(e => e.Gu)
	//		//	.WithOne(e => e.DocsConclusionsExamination)
	//		//	.HasForeignKey<DocsConclusionsExamination>(e => e.Guid)
	//		//	.OnDelete(DeleteBehavior.Cascade);
	//		//});

	//		//modelBuilder.Entity<DocsWithGoods>(entity =>
	//		//{
	//		//	entity
	//		//	.HasOne(e => e.Gu)
	//		//	.WithOne(e => e.DocsWithGoods)
	//		//	.HasForeignKey<DocsWithGoods>(e => e.Guid)
	//		//	.OnDelete(DeleteBehavior.Cascade);
	//		//});
	//	}
	//}
}