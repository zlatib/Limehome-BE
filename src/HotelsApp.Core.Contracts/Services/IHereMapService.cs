namespace HotelsApp.Core.Contracts.Services
{
    using HotelsApp.Core.Models;
    using System.Threading.Tasks;

    public interface IHereMapService
    {
        Task<PropertyModel[]> GetProperties(string latitude, string longtitude);
    }
}