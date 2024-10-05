
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class BookConfig : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        builder.ToTable("Bookss");
        
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedOnAdd();
        builder.Property(x => x.Id).IsRequired();

        builder.Property(x=>x.Author).IsRequired();
        builder.Property(x=>x.Title).IsRequired();
        builder.Property(x=>x.Description).IsRequired();
    }
}