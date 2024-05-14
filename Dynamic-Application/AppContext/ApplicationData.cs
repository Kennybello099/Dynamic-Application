using Dynamic_Application.model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System.Data.Common;

namespace Dynamic_Application.AppContext
{
    public class ApplicationData : DbContext
    {
        public ApplicationData(DbContextOptions<ApplicationData> options) : base(options)
        {
                
        }

        public DbSet<UserApplication> Applications { get; set; }
        public DbSet<Programs> Programs { get; set; }

        public DbSet<QuestionAndAnswer> questionAndAnswers { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }

    }
}
