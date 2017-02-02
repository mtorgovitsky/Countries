namespace Countries.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class CountriesDB : DbContext
    {
        // Your context has been configured to use a 'CountriesDB' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'Countries.Models.CountriesDB' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'CountriesDB' 
        // connection string in the application configuration file.
        public CountriesDB()
            : base("name=CountriesDB")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<CountriesDB>(new CitiesDBInitializer());
        }

        public DbSet<City> Cities { get; set; }
        public DbSet<Country> Countries { get; set; }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }

    public class CitiesDBInitializer : DropCreateDatabaseAlways<CountriesDB>
    {
        protected override void Seed(CountriesDB context)
        {
            context.Countries.Add(new Country { Name = "Israel" });
            context.Countries.Add(new Country { Name = "Jordan" });
            context.Countries.Add(new Country { Name = "Ukraine" });
            context.Countries.Add(new Country { Name = "USA" });

            context.SaveChanges();

            var countriesById = context.Countries.ToDictionary(x => x.Name, x => x.CountryID);

            context.Cities.Add(new City() { Name = "Kdumim", CountryID = countriesById["Israel"] });
            context.Cities.Add(new City() { Name = "Bnei Brak", CountryID = countriesById["Israel"] });
            context.Cities.Add(new City() { Name = "Tel Aviv", CountryID = countriesById["Israel"] });
            context.Cities.Add(new City() { Name = "Haresha", CountryID = countriesById["Israel"] });

            context.Cities.Add(new City() { Name = "New York", CountryID = countriesById["USA"] });
            context.Cities.Add(new City() { Name = "Polo Alto", CountryID = countriesById["USA"] });
            context.Cities.Add(new City() { Name = "Chicago", CountryID = countriesById["USA"] });
            context.Cities.Add(new City() { Name = "Boston", CountryID = countriesById["USA"] });

            context.Cities.Add(new City() { Name = "Uman", CountryID = countriesById["Ukraine"] });
            context.Cities.Add(new City() { Name = "Kiev", CountryID = countriesById["Ukraine"] });
            context.Cities.Add(new City() { Name = "Braslev", CountryID = countriesById["Ukraine"] });
            context.Cities.Add(new City() { Name = "Tultshin", CountryID = countriesById["Ukraine"] });
            context.Cities.Add(new City() { Name = "Nikolaev", CountryID = countriesById["Ukraine"] });

            context.Cities.Add(new City() { Name = "Amman", CountryID = countriesById["Jordan"] });
            context.Cities.Add(new City() { Name = "Madaba", CountryID = countriesById["Jordan"] });
            context.Cities.Add(new City() { Name = "Jerash", CountryID = countriesById["Jordan"] });
            context.Cities.Add(new City() { Name = "Zarqa", CountryID = countriesById["Jordan"] });
            context.Cities.Add(new City() { Name = "Salt", CountryID = countriesById["Jordan"] });

            //context.Cities.Add(new City { CityID = 1, Name = "Kdumim", CounrtyID = 1 });
        }


    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}