
namespace WebApi.Data
{
    public class Workout
    {
        public string Id { get; set; }
        public Dictionary<string, List<string>> Train { get; set; }
    }
}
