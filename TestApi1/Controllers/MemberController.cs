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
        [HttpDelete]
        public ActionResult DeleteMembers([FromBody]Member member)
        {
            ApplicationContext.member.Remove(member);
            ApplicationContext.SaveChanges();
            return Ok();
        }
        [HttpPut]
        public ActionResult PutMembers([FromBody]Member member)
        {
            Member member1 = ApplicationContext.member.FirstOrDefault(u => u.Id == member.Id);
            if (member1 == null) return BadRequest(new {message = "Пользователь не найден"});
            member1.Surname = member.Surname;
            member1.Name = member.Name;
            member1.Patronymic = member.Patronymic;
            member1.Date = member.Date;
            member1.Experiece = member.Experiece;
            member1.Login = member.Login;
            member1.Password = member.Password;
            ApplicationContext.SaveChanges();
            return Ok();

        }
    }

}
