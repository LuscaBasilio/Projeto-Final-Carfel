using System;

namespace Projeto_Final_Carfel.Models
{
    public class UsuarioModel
    {
        public string Nome;
        public string Email;
        public string Senha;
        public int Id;
        public DateTime DataCriacao;
        public bool Tipo;

        public UsuarioModel(int Id, string Nome, string Email, string Senha){
            this.Id = Id;
            this.Nome = Nome;
            this.Email = Email.ToLower();
            this.Senha = Senha;
            this.DataCriacao = DateTime.Now;
        }
    }
}