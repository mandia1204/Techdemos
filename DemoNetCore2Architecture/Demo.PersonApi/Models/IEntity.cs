using Newtonsoft.Json;

namespace Demo.PersonApi.Models
{
    public interface IEntity
    {
        [JsonIgnore]
        int Id { get;}
    }
}