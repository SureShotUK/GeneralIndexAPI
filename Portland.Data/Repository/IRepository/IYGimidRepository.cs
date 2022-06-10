using Portland.Data.Prices;

namespace Portland.Data.Repository.IRepository
{
    public interface IYGimidRepository : IRepository<YGimid> 
    {
        void Update(YGimid source);

        Task UpdateAsync(YGimid source);
    }

}
