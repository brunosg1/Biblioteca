using Biblioteca.Data;
using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Control
{
    internal class Login
    {
        

        public static Usuario RealizarLogin(BibliotecaContext context)
        {
            Console.Write("Digite o email: ");
            var email = Console.ReadLine();

            Console.Write("Digite a senha: ");
            var senha = Console.ReadLine();

            return context.Usuarios.SingleOrDefault(u => u.Email == email && u.Senha == senha);
        }

        public static void RealizarCadastro(BibliotecaContext context)
        {
            Console.Write("Digite um nome de usuário: ");
            var nomeUsuario = Console.ReadLine();

            Console.Write("Digite seu email: ");
            var email = Console.ReadLine();

            Console.Write("Digite uma senha: ");
            var senha = Console.ReadLine();

            Console.Write("Digite sua data de nascimento (yyyy-MM-dd): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime nascimento))
            {
                var novoUsuario = new Usuario
                {
                    Nome = nomeUsuario,
                    Senha = senha,
                    Email = email,
                    Nascimento = nascimento
                };

                context.Usuarios.Add(novoUsuario);
                context.SaveChanges();
                Console.WriteLine("Cadastro realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Data de nascimento inválida. Cadastro falhou.");
            }
        }
    }
}
