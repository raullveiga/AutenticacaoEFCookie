using AutenticacaoEFCookie.Model;

namespace AutenticacaoEFCookie.Dados
{
    public class CodeFirstBanco
    {
        public static void Inicializar(AutenticacaoContext contexto)
        {
            contexto.Database.EnsureCreated();

            var usuario = new Usuario(){
                NomeUsuario = "Fernando",
                EmailUsuario = "fernando.guerra@corujasdev.com.br",
                Senha = "123123"
            };

            contexto.Usuario.Add(usuario);

            var permissao = new Permissao(){
                NomePermissao = "Financeiro"
            };

            contexto.Permissoes.Add(permissao);

            var usuariopermissao = new UsuarioPermissao(){
                IdPermissao = permissao.IdPermissao,
                IdUsuario = usuario.IdUsuario
            };

            contexto.UsuarioPermissoes.Add(usuariopermissao);

            contexto.SaveChanges();

        }

    }
}