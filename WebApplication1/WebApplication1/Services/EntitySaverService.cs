using Newtonsoft.Json;
using System.Threading.Tasks;
using WebApplication1.DTOs;

namespace WebApplication1.Services
{
    public class EntitySaverService : IEntitySaverService
    {
        public Task SaveEntity(EntityDTO entity)
        {
            var jsonResult = JsonConvert.SerializeObject(entity);
            return System.IO.File.WriteAllTextAsync("1.json", jsonResult);
        }
    }
}
