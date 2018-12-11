using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Projeto_Final_Carfel.Interfaces;
using Projeto_Final_Carfel.Models;

namespace Projeto_Final_Carfel.Serializar
{
    public class UsuarioSerializado : IUsuario 
    {
        
        private const string Caminho = "Database/usuarios.dat";
        private List<UsuarioModel> ListaUsuarios;
        
        public UsuarioModel Cadastro(UsuarioModel usuario)
        {
            ListaUsuarios.Add(usuario);
            Serializar();
            return usuario;
        }
        //Carrega uma lista de usuário
        public List<UsuarioModel> Carregar()
        {
            byte[] InfoDados = File.ReadAllBytes(Caminho);
            //Le os bytes e armazena na memória
            MemoryStream memoria = new MemoryStream(InfoDados);
            //O formatador binario para converter bytes
            BinaryFormatter Desserializador = new BinaryFormatter();

            return Desserializador.Deserialize(memoria) as List<UsuarioModel>;

        }
        //Busca um usuário por Id
        public UsuarioModel BuscarPorId(int id)
        {
            foreach (UsuarioModel item in ListaUsuarios)
            {
                if(item.Id == id){
                    return item;
                }
            }
            return null;
        }

        public UsuarioModel Logar(string email, string senha)
        {
            
            foreach (UsuarioModel item in ListaUsuarios)
            {
                if(item.Email == email && item.Senha ==senha){
                    return item;
                }
            }
            return null;
        }

        private void Serializar(){
            MemoryStream memoria = new MemoryStream();
            BinaryFormatter serializar = new BinaryFormatter();
            
            serializar.Serialize(memoria, ListaUsuarios);

            File.WriteAllBytes(Caminho, memoria.ToArray());
            ListaUsuarios = Carregar();
        }

        public UsuarioSerializado(){
            bool existe = File.Exists(Caminho);
            //Se esta variavel existir, ele carrega
            if(existe){
                Carregar();
            }else{
                //Se não, ele cria uma nova lista
                ListaUsuarios = new List<UsuarioModel>();
            Serializar();
            }
        }
    }
}