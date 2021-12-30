using AutoMapper;

namespace EvolentHealthTest.Mapper
{
    /// <summary>
    /// Item mapper profile
    /// </summary>
    public class ItemMapperProfile : Profile
    {
        #region Public Constructor

        /// <summary>
        /// Create mapping between models and entities
        /// </summary>
        public ItemMapperProfile()
        {
            CreateMap<Models.Contact, Entities.Contact>();
            CreateMap<Entities.Contact, Models.Contact>();
        }

        #endregion
    }
}
