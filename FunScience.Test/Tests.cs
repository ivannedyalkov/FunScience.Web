namespace FunScience.Test
{
    using AutoMapper;
    using FunScience.Web.Infrastructure.Mapping;

    public class Test
    {
        private static bool testsInitialized = false;

        public static void Initialize()
        {
            if (!testsInitialized)
            {
                Mapper.Initialize(config => config.AddProfile<AutoMapperProfile>());
                testsInitialized = true;
            }
        }
    }
}
