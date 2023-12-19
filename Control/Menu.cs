using Biblioteca.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Control
{
    public class Menu
    {
        public static void MostrarMenuLogin()
        {
            Console.WriteLine("==== Menu ====");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Cadastro");
            Console.WriteLine("3. Sair");
            Console.Write("Escolha uma opção: ");
        }

        public static void MenuUsuario(BibliotecaContext context)
        {
            while (true)
            {
                Console.WriteLine("==== Menu do Usuário ====");
                Console.WriteLine("1. Reservar Livro");
                Console.WriteLine("2. Listar Reservas");
                Console.WriteLine("3. Listar Livros");
                Console.WriteLine("4. Emprestimo de Livro");
                Console.WriteLine("5. Listar Emprestimos");
                Console.WriteLine("6. Sair");

                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ReservaControl.FazerReserva(context);
                        break;
                    case "2":
                        ReservaControl.ListarReservasPorId(context);
                        break;
                    case "3":
                        LivroControl.ListarLivros(context);
                        break;
                    case "4":
                        EmprestimoControl.FazerEmprestimo(context);
                        break;
                    case "5":
                        EmprestimoControl.ListarEmprestimosPorId(context);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
        public static void MenuAdministrador(BibliotecaContext context)
        {
            while (true)
            {
                Console.WriteLine("==== Menu Administrador ====");
                Console.WriteLine("1. Livros");
                Console.WriteLine("2. Autores");
                Console.WriteLine("3. Usuários");
                Console.WriteLine("4. Reservas");
                Console.WriteLine("5. Empréstimos");
                Console.WriteLine("6. Sair");

                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        MenuLivros(context);
                        break;
                    case "2":
                        MenuAutores(context);
                        break;
                    case "3":
                        MenuUsuarios(context);
                        break;
                    case "4":
                        MenuReservas(context);
                        break;
                    case "5":
                        MenuEmprestimos(context);
                        break;
                    case "6":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
        static void MenuLivros(BibliotecaContext context)
        {
            while (true)
            {
                Console.WriteLine("==== Menu Livros ====");
                Console.WriteLine("1. Adicionar Livro");
                Console.WriteLine("2. Listar Livros");
                Console.WriteLine("3. Atualizar Livro");
                Console.WriteLine("4. Excluir Livro");
                Console.WriteLine("5. Voltar");

                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        LivroControl.AdicionarLivro(context);
                        break;
                    case "2":
                        LivroControl.ListarLivros(context);
                        break;
                    case "3":
                        LivroControl.AtualizarLivro(context);
                        break;
                    case "4":
                        LivroControl.ExcluirLivro(context);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
        static void MenuAutores(BibliotecaContext context)
        {
            while (true)
            {
                Console.WriteLine("==== Menu Autores ====");
                Console.WriteLine("1. Adicionar Autor");
                Console.WriteLine("2. Listar Autores");
                Console.WriteLine("3. Atualizar Autor");
                Console.WriteLine("4. Excluir Autor");
                Console.WriteLine("5. Voltar");

                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AutorControl.AdicionarAutor(context);
                        break;
                    case "2":
                        AutorControl.ListarAutores(context);
                        break;
                    case "3":
                        AutorControl.AtualizarAutor(context);
                        break;
                    case "4":
                        AutorControl.ExcluirAutor(context);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void MenuUsuarios(BibliotecaContext context)
        {
            while (true)
            {
                Console.WriteLine("==== Menu Usuários ====");
                Console.WriteLine("1. Adicionar Usuário");
                Console.WriteLine("2. Listar Usuários");
                Console.WriteLine("3. Atualizar Usuário");
                Console.WriteLine("4. Excluir Usuário");
                Console.WriteLine("5. Voltar");

                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        UsuarioControl.AdicionarUsuario(context);
                        break;
                    case "2":
                        UsuarioControl.ListarUsuarios(context);
                        break;
                    case "3":
                        UsuarioControl.AtualizarUsuario(context);
                        break;
                    case "4":
                        UsuarioControl.ExcluirUsuario(context);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void MenuReservas(BibliotecaContext context)
        {
            while (true)
            {
                Console.WriteLine("==== Menu Reservas ====");
                Console.WriteLine("1. Adicionar Reserva");
                Console.WriteLine("2. Listar Reservas");
                Console.WriteLine("3. Atualizar Reserva");
                Console.WriteLine("4. Excluir Reserva");
                Console.WriteLine("5. Voltar");

                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        ReservaControl.AdicionarReserva(context);
                        break;
                    case "2":
                        ReservaControl.ListarReservas(context);
                        break;
                    case "3":
                        ReservaControl.AtualizarReserva(context);
                        break;
                    case "4":
                        ReservaControl.ExcluirReserva(context);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        static void MenuEmprestimos(BibliotecaContext context)
        {
            while (true)
            {
                Console.WriteLine("==== Menu Emprestimos ====");
                Console.WriteLine("1. Adicionar Emprestimos");
                Console.WriteLine("2. Listar Emprestimos");
                Console.WriteLine("3. Atualizar Emprestimos");
                Console.WriteLine("4. Excluir Emprestimos");
                Console.WriteLine("5. Voltar");

                Console.Write("Escolha uma opção: ");
                var opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        EmprestimoControl.AdicionarEmprestimo(context);
                        break;
                    case "2":
                        EmprestimoControl.ListarEmprestimos(context);
                        break;
                    case "3":
                        EmprestimoControl.AtualizarEmprestimo(context);
                        break;
                    case "4":
                        EmprestimoControl.ExcluirEmprestimos(context);
                        break;
                    case "5":
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

    }
}
