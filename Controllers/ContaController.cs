using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using AutenticacaoEFCookie.Dados;
using AutenticacaoEFCookie.Model;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AutenticacaoEFCookie.Controllers
{
    public class ContaController : Controller
    {
        readonly AutenticacaoContext _contexto;

        public ContaController(AutenticacaoContext context)
        {
            _contexto = context;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(Usuario usuario)
        {
            try
            {
                Usuario user = _contexto.Usuario.Include("UsuarioPermissao").Include("UsuarioPermissao.Permissao")
                .FirstOrDefault(c => c.EmailUsuario == usuario.EmailUsuario && c.Senha == usuario.Senha);

                if (user != null)
                {
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Email, user.EmailUsuario));
                    claims.Add(new Claim(ClaimTypes.Name, user.NomeUsuario));
                    claims.Add(new Claim(ClaimTypes.Sid, user.IdUsuario.ToString()));

                    foreach (var item in user.UsuarioPermissao)
                        claims.Add(new Claim(ClaimTypes.Role, item.Permissao.NomePermissao));
                    

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme
                    );

                    HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                    return RedirectToAction("Index", "Financeiro");
                }

                return View(usuario);
            }
            catch (System.Exception)
            {
                return View(usuario);
            }

        }

        [HttpPost]
        public void Cadastrar([FromBody] Usuario usuario)
        {
            _contexto.Usuario.Add(usuario);
            _contexto.SaveChanges();
        }

    }
}