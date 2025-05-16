using Microsoft.AspNetCore.Mvc;

[Route("api/data")]
[ApiController]
public class DataController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<dynamic>> GetComplexData()
    {
        var result = GetData().Select(x => new {
            x.Key,
            Value = x.Value.Where(v => v > 0).Sum() * (x.Key.Length % 2 == 0 ? 1.5 : 1.0)
        }).OrderByDescending(x => x.Value).Take(5).ToList();

        return Ok(result);
    }

    private static Dictionary<string, List<int>> GetData()
    {
        return new Dictionary<string, List<int>>
        {
            { "A", new List<int> { 1, -1, 3, 4 } },
            { "B", new List<int> { -2, 5, 6, 7 } },
            { "C", new List<int> { 3, 0, 4, -3 } },
            { "D", new List<int> { 1, 2, 3, 4 } },
            { "E", new List<int> { -5, 6, -7, 8 } }
        };
    }
}
