namespace AtlasDataModel
{
    public class AtlasDbContextFactory 
    {
        public static IAtlasDbContextFactory _contextFactory;

        public static void SetFactoryInstance(IAtlasDbContextFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public static IAtlasDbContextFactory Instance
        {
            get
            {
                return _contextFactory;
            }
        }
    }
}
