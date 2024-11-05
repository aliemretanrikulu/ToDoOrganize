using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using ToDoOrganize.Models.Entities;

namespace ToDoOrganize.DataAccess.Configurations;

public class TodoConfiguration : IEntityTypeConfiguration<ToDo>
{
    public void Configure(EntityTypeBuilder<ToDo> builder)
    {
        builder.ToTable("ToDos").HasKey(x => x.Id);
        builder.Property(x => x.Id).HasColumnName("ToDoId"); 
        builder.Property(x => x.CreatedDate).HasColumnName("CreatedTime");
        builder.Property(x => x.UpdatedDate).HasColumnName("UpdatedTime");
        builder.Property(x => x.Title).HasColumnName("Title");
        builder.Property(x => x.Description).HasColumnName("Description");
        builder.Property(x => x.UserId).HasColumnName("User_Id");
        builder.Property(x => x.CategoryId).HasColumnName("Category_Id");

        builder.HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(x => x.Category)
            .WithMany(x => x.ToDos)
            .HasForeignKey(x => x.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.Property(t => t.Priority)
            .IsRequired();

        builder.Property(t => t.Completed)
            .IsRequired()
            .HasDefaultValue(false);

    }
}