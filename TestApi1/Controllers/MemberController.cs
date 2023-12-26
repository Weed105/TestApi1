using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Option_1.Models;
using System.Data;

namespace TestApi1.Controllers
{
    [ApiController]
    [Route("/members")]
    public class MemberController : Controller
    {
        public ApplicationContext ApplicationContext { get; set; }
        
        public MemberController(ApplicationContext applicationContext) 
        { 
            ApplicationContext = applicationContext;
        }

        [HttpGet]
        public ActionResult GetMembers()
        {
            return Ok(ApplicationContext.member.ToList());
        }

        [HttpPost]
        public ActionResult PostMembers([FromBody]Member member)
        {
            ApplicationContext.member.Add(member);
            ApplicationContext.SaveChanges();
            return Ok();
        }
    }

}
