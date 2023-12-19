using Biblioteca.Data;
using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Control
{
    internal class EmprestimoControl
    {
        public static void FazerEmprestimo(BibliotecaContext context)
        {
            if (Program.usuarioLogado.UsuarioId == 0)
            {
                Console.WriteLine("Nenhum usuário logado. Faça o login antes de fazer um empréstimo.");
                return;
            }

            Console.Write("ID do Livro para Empréstimo: ");
            if (!int.TryParse(Console.ReadLine(), out int livroId))
            {
                Console.WriteLine("ID do livro inválido. Operação de empréstimo cancelada.");
                return;
            }

            var livro = context.Livros.Find(livroId);

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado. Operação de empréstimo cancelada.");
                return;
            }

            var novoEmprestimo = new Emprestimo
            {
                LivroId = livroId,
                UsuarioId = Program.usuarioLogado.UsuarioId,
                DataEmprestimo = DateTime.Now,
                DataDevolucao = DateTime.Now.AddDays(14)
            };

            context.Emprestimos.Add(novoEmprestimo);
            context.SaveChanges();
            Console.WriteLine("Empréstimo de limite de 14 dias adicionado com sucesso!");
        }

        public static void ListarEmprestimosPorId(BibliotecaContext context)
        {
            if (Program.usuarioLogado.UsuarioId == 0)
            {
                Console.WriteLine("Nenhum usuário logado. Faça o login antes de listar os empréstimos.");
                return;
            }

            var emprestimosUsuarioLogado = context.Emprestimos
                .Where(e => e.UsuarioId == Program.usuarioLogado.UsuarioId)
                .ToList();

            if (emprestimosUsuarioLogado.Any())
            {
                Console.WriteLine($"Empréstimos do {Program.usuarioLogado.Nome}):");

                foreach (var emprestimo in emprestimosUsuarioLogado)
                {
                    var titulo = context.Livros.Find(emprestimo.LivroId);
                    Console.WriteLine($"ID do Empréstimo: {emprestimo.EmprestimoId}");
                    Console.WriteLine($"ID do Livro: {emprestimo.LivroId}");
                    Console.WriteLine($"Nome do Livro: {titulo?.Titulo ?? "N/A"}");
                    Console.WriteLine($"Data do Empréstimo: {emprestimo.DataEmprestimo:dd/MM/yyyy}");
                    Console.WriteLine($"Data de Devolução: {emprestimo.DataDevolucao:dd/MM/yyyy}");
                    Console.WriteLine($"------------------------------------------------------------");
                }
            }
            else
            {
                Console.WriteLine("Nenhum empréstimo encontrado para o usuário logado.");
            }
        }

        public static void AdicionarEmprestimo(BibliotecaContext context)
        {
            Console.Write("ID do Livro para o Emprestimo: ");
            if (!int.TryParse(Console.ReadLine(), out int livroId))
            {
                Console.WriteLine("ID do livro inválido. Operação de empréstimo cancelada.");
                return;
            }

            Console.Write("ID do Usuário para o Emprestimo: ");
            if (!int.TryParse(Console.ReadLine(), out int usuarioId))
            {
                Console.WriteLine("ID do usuário inválido. Operação de empréstimo cancelada.");
                return;
            }

            var livro = context.Livros.Find(livroId);
            var usuario = context.Usuarios.Find(usuarioId);

            if (livro == null || usuario == null)
            {
                Console.WriteLine("Livro ou usuário não encontrado. Operação de reserva cancelada.");
                return;
            }

            var novoEmprestimo = new Emprestimo()
            {
                LivroId = livroId,
                UsuarioId = usuarioId,
                DataEmprestimo = DateTime.Now,
                DataDevolucao = DateTime.Now.AddDays(14),
            };

            context.Emprestimos.Add(novoEmprestimo);
            context.SaveChanges();
            Console.WriteLine("Empréstimo de limite de 14 dias adicionado com sucesso!");
        }

        public static void ListarEmprestimos(BibliotecaContext context)
        {
   

            var emprestimos = context.Emprestimos.ToList();
            Console.WriteLine("Empréstimos na biblioteca:");
            foreach (var emprestimo in emprestimos)
                {
                    var titulo = context.Livros.Find(emprestimo.LivroId);
                    Console.WriteLine($"ID do Usuario: {emprestimo.UsuarioId}");
                    Console.WriteLine($"ID do Empréstimo: {emprestimo.EmprestimoId}");
                    Console.WriteLine($"ID do Livro: {emprestimo.LivroId}");
                    Console.WriteLine($"Nome do Livro: {titulo?.Titulo ?? "N/A"}");
                    Console.WriteLine($"Data do Empréstimo: {emprestimo.DataEmprestimo:dd/MM/yyyy}");
                    Console.WriteLine($"Data de Devolução: {emprestimo.DataDevolucao:dd/MM/yyyy}");
                    Console.WriteLine($"------------------------------------------------------------");
                }
        }

        public static void AtualizarEmprestimo(BibliotecaContext context)
        {
            Console.Write("Digite o ID do empréstimo que deseja atualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int emprestimoId))
            {
                Console.WriteLine("ID do empréstimo inválido. Operação de atualização cancelada.");
                return;
            }

            var emprestimoParaAtualizar = context.Emprestimos.Find(emprestimoId);

            if (emprestimoParaAtualizar == null)
            {
                Console.WriteLine("Empréstimo não encontrado. Operação de atualização cancelada.");
                return;
            }

            Console.WriteLine("Informe as novas informações do empréstimo (deixe em branco para manter as informações existentes):");

            Console.Write("Novo ID do Livro: ");
            var novoLivroIdStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoLivroIdStr) && int.TryParse(novoLivroIdStr, out int novoLivroId))
            {
                emprestimoParaAtualizar.LivroId = novoLivroId;
            }

            Console.Write("Nova Data de Devolução (formato: dd/MM/yyyy): ");
            var novaDataDevolucaoStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novaDataDevolucaoStr) && DateTime.TryParseExact(novaDataDevolucaoStr, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime novaDataDevolucao))
            {
                emprestimoParaAtualizar.DataDevolucao = novaDataDevolucao;
            }  

            context.SaveChanges();
            Console.WriteLine("Empréstimo atualizado com sucesso!");
        }
        public static void ExcluirEmprestimos(BibliotecaContext context)
        {
            Console.Write("Digite o ID do empréstimo que deseja excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int emprestimoId))
            {
                Console.WriteLine("ID da empréstimo inválido. Operação de exclusão cancelada.");
                return;
            }

            var emprestimoParaExcluir = context.Emprestimos.Find(emprestimoId);

            if (emprestimoParaExcluir == null)
            {
                Console.WriteLine("Reserva não encontrada. Operação de exclusão cancelada.");
                return;
            }

            context.Emprestimos.Remove(emprestimoParaExcluir);
            context.SaveChanges();

            Console.WriteLine("Emprestimo excluída com sucesso!");
        }

    }
}
