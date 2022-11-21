using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Week10API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        Services services = new Services();

        // GET: api/<MonsterController>
        [HttpGet("get-all")]
        public IEnumerable<Monster> Get()
        {
            services.PrepareSQLConnectionString();
            return services.GetAll();
        }

        // GET api/<MonsterController>/5
        [HttpGet("get-by-id/{id}")]
        public Monster Get(int id)
        {
            services.PrepareSQLConnectionString();
            return services.GetMonsterByID(id);
        }

        [HttpGet("get-by-state")]
        public List<DataModel> GetMonsterCountByState()
        {
            services.PrepareSQLConnectionString();
            return services.GetCountByState();
        }

        [HttpGet("get-by-HP")]
        public List<DataModel> GetMonsterCountByHP()
        {
            services.PrepareSQLConnectionString();
            return services.GetCountByHP();
        }

        [HttpGet("get-HPMP")]
        public List<DataModel> GetTopHPMP()
        {
            services.PrepareSQLConnectionString();
            return services.GetTopHPMP();
        }

        // POST api/<MonsterController>
        [HttpPost("update-by-id/{id}/{name}/{type}/{HP}/{MP}/{location}")]
        public void Post([FromRoute] int id, string name, string type, string HP, string MP, string location)
        {
            services.PrepareSQLConnectionString();
            services.UpdateMonsterByID(id, name, type, HP, MP, location);
        }

        // DELETE api/<MonsterController>/5
        [HttpDelete("delete-by-id/{id}")]
        public void Delete(int id)
        {
            services.PrepareSQLConnectionString();
            services.DeleteMonsterByID(id);
        }
    }
}
