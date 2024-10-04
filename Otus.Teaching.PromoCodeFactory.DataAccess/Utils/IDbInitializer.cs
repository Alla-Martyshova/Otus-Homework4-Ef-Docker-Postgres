namespace Otus.Teaching.PromoCodeFactory.DataAccess.Utils
{
    public interface IDbInitializer
    {
        void DbReCreate();

        void DbMigrate();
    }
}
