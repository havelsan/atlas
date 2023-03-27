namespace AtlasDataModel
{
    public interface IAtlasDbContextFactory
    {

        AtlasContext CreateDbContext();

    }
}
