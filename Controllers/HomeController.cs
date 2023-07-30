using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using mrteam.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace mrteam.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MrteamContext _context;

        public HomeController(ILogger<HomeController> logger, MrteamContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ClaimsPrincipal claimuser = User; 
            string name = "";
            if (claimuser.Identity.IsAuthenticated)
            {
                name = claimuser.Claims.Where(c => c.Type == ClaimTypes.Name)
                    .Select(c => c.Value).SingleOrDefault();
            }

            ViewData["nombreUsuario"] = name;
            return View();
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

        public async Task<IActionResult> CerrarSesion()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("IniciarSesion", "Inicio");
        }

        public IActionResult Pagos()
        {
            return View();
        }

        public IActionResult GetTablaPagos(int turnoId) 
        {
            List<Pago> pagos = _context.Pagos.ToList();
            return PartialView("_TablaPagos", pagos);
        }
    }
}
