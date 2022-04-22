namespace SITHEC.Infrastructure.Seeder
{
    public interface IDbInitializer
    {
        void Initialize();
        void SeedData();
    }
}
