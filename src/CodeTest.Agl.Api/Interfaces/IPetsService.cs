using System.Threading.Tasks;

namespace CodeTest.Agl.Api.Interfaces
{
    public interface IPetsService
    {
        Task GetCatsByGenderOfOwner();
    }
}
