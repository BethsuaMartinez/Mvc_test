using ballfight.Models;
using Microsoft.AspNetCore.Mvc;

namespace ballfight.Controllers
{
    public class userController : Controller
    {
        public ballfightContext ctx = new ballfightContext(@"server=localhost;userid=root;password=root;database=ballfight");
        public IActionResult Index()
        {

            //ballfightContext context = HttpContext.RequestServices.GetService(typeof(ballfight.Models.ballfightContext)) as ballfightContext;


            List<userModel> list = ctx.GetAllUsers();

            //consol
            //return View(context.GetAllUsers());
            return View(list);

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create([Bind(include: "name, email, password")] userModel user)
        {
            if (ModelState.IsValid)
            {

                var name = user.name;
                var email = user.email;
                var password = user.password;

                ctx.createUser(name, email, password);

                //users.Add(user);
                //db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public IActionResult Delete(){
            return View();
        }
    }
}
