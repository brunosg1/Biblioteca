using Biblioteca.Data;
using Biblioteca.Models;
using Biblioteca.Control;
using System;
using System.Linq;


namespace Biblioteca
{
    internal class Program
    {
        public static Usuario usuarioLogado;
        static void Main(string[] args)
        {
            using (var context = new BibliotecaContext())
            {
                // Criar um usuário administrador para fins de demonstração
                //CriarUsuarioAdmin(context);

                while (true)
                {
                    Menu.MostrarMenuLogin();



                    // Ler a opção do usuário
                    var opcaoLogin = Console.ReadLine();

                    if (opcaoLogin == "1")
                    {
                        // Opção de login
                        usuarioLogado = Login.RealizarLogin(context);
                        if (usuarioLogado != null)
                        {
                            Console.WriteLine($"Bem-vindo, {usuarioLogado.Nome}!");
                            if (usuarioLogado.Adm)
                            {
                                // Se o usuário é administrador, mostrar opções de admin
                                Menu.MenuAdministrador(context);
                            }
                            else
                            {
                                // Se o usuário não é administrador, mostrar opções de usuário padrão
                                Menu.MenuUsuario(context);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Login falhou. Tente novamente.");
                        }
                    }
                    else if (opcaoLogin == "2")
                    {
                        // Opção de cadastro
                        Login.RealizarCadastro(context);
                    }
                    else if (opcaoLogin == "3")
                    {
                        // Sair do aplicativo
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Opção inválida. Tente novamente.");
                    }
                }
            }
        }
    }
}