using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using services.Models;
using services.s;

namespace services.Controllers
{
    public class HomeController : Controller
    {
        private readonly IScoped _scoped1;
        private readonly IScoped _scoped2;

        private readonly ISingleton _singleton1;
        private readonly ISingleton _singleton2;

        private readonly ITransient _transient1;
        private readonly ITransient _transient2;

        //private readonly ISingleton _singleton3;
        //private readonly ISingleton _singleton4;

        public HomeController(IScoped scoped1, IScoped scoped2,
            ISingleton singleton1, ISingleton singleton2,
            ITransient transient1, ITransient transient2,
            //ISingleton temp,ISingleton temp1
            )
        {
            _scoped1 = scoped1;
            _scoped2 = scoped2;
            _singleton1 = singleton1;
            _singleton2 = singleton2;
            _transient1 = transient1;
            _transient2 = transient2;

            //_singleton3 = temp;
            //_singleton4 = temp1;
        }

        public IActionResult Index()
        {
            StringBuilder messages = new StringBuilder();
            messages.Append($"Transient 1 :{_transient1.GetGuid()}\n");
            messages.Append($"Transient 2 :{_transient2.GetGuid()}\n\n");
            messages.Append($"Scoped 1 :{_scoped1.GetGuid()}\n");
            messages.Append($"Scoped 2 :{_scoped2.GetGuid()}\n\n");
            messages.Append($"Singleton 1 :{_singleton1.GetGuid()}\n");
            messages.Append($"Singleton 2 :{_singleton2.GetGuid()}\n\n");

            return Ok(messages.ToString());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
