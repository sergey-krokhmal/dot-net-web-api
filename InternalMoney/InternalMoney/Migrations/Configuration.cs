namespace InternalMoney.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
	using InternalMoney.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<InternalMoney.Models.InternalMoneyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(InternalMoney.Models.InternalMoneyContext context)
        {
			context.Users.AddOrUpdate(x => x.Id,
			   new User() { Id = 1, Name = "Jane Austen", Email = "test@email", Password = "123", Balance = 500 },
			   new User() { Id = 2, Name = "Sergey Krokhmal", Email = "test2@email", Password = "123", Balance = 500 }
		   );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
