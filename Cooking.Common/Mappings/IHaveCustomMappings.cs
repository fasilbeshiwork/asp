namespace Cooking.Common.Mappings
{
    using AutoMapper;
    using AutoMapper.Configuration;

    public interface IHaveCustomMappings
    {
        void CreateMappings(IConfiguration configuration);
    }
}
