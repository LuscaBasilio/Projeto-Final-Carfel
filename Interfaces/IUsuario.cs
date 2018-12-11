using Projeto_Final_Carfel.Models;
using System.Collections.Generic;
namespace Projeto_Final_Carfel.Interfaces
{
    public interface IUsuario
    {
         UsuarioModel Cadastro(UsuarioModel usuario);
         List<UsuarioModel> Carregar();
         UsuarioModel BuscarPorId(int id);
         UsuarioModel Logar(string email, string senha);
    }
}