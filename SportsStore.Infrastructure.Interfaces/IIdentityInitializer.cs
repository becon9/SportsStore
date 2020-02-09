using System.Threading.Tasks;

namespace SportsStore.Infrastructure.Interfaces
{
    public interface IIdentityInitializer
    {
        Task SeedData();
    }
}
