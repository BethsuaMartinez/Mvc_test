using ballfight.Models;
using Microsoft.AspNetCore.Mvc;

namespace ballfight.Controllers
{
    public class userController : Controller
    {
        public ballfightContext ctx = new ballfightContext(@"server=localhost;userid=root;password=root;database=ballfight");
        public IActionResult Index()
        {

           


            List<User> list = ctx.GetAllUsers();

            
            return View(list);

        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Create([Bind(include: "name, email, password")] User user)
        {
            if (ModelState.IsValid)
            {

                var name = user.name;
                var email = user.email;
                var password = user.password;

                ctx.createUser(name, email, password);

                
                return RedirectToAction("Index");
            }

            return View(user);
        }

        public IActionResult Delete(){
            return View();
        }

        public IActionResult Login([Bind(include: "email, password")] User user) {
            var userLocal = HttpContext.Session.GetInt32("_userID");
            if (userLocal != null) return RedirectToAction("Index", "Home");

   
                var email = user.email;
                var password = user.password;

                var i = ctx.Login(email, password);

                if ( i != null)
                {
                    HttpContext.Session.SetInt32("_userID", i.id);
                    return RedirectToAction("Index", "Home");
                }

                else {
                    TempData["msg"] = "<script>alert('FALSE');</script>";
                    return View(user);
                }
           
            return View(user);      
        }
    }
}
