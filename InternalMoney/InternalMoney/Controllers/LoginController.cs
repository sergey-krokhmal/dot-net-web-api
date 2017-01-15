using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using InternalMoney.Models;

namespace InternalMoney.Controllers
{
    public class LoginController : ApiController
    {
        private InternalMoneyContext db = new InternalMoneyContext();

        // POST api/Login
		[HttpPost]
        [ResponseType(typeof(User))]
        public async Task<IHttpActionResult> Login(LoginInput li)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            // Is user exist
			User existUser = await db.Users.Where(u => u.Email == li.Login).FirstOrDefaultAsync();
			return Ok(existUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UserExists(int id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}