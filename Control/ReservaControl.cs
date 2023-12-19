using Biblioteca.Data;
using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Control
{
    internal class ReservaControl
    {
        public static void FazerReserva(BibliotecaContext context)
        {
            if (Program.usuarioLogado.UsuarioId == 0)
            {
                Console.WriteLine("Nenhum usuário logado. Faça o login antes de fazer uma reserva.");
                return;
            }

            Console.Write("ID do Livro para Reserva: ");
            if (!int.TryParse(Console.ReadLine(), out int livroId))
            {
                Console.WriteLine("ID do livro inválido. Operação de reserva cancelada.");
                return;
            }

            var livro = context.Livros.Find(livroId);
            var usuario = context.Usuarios.Find(Program.usuarioLogado.UsuarioId);

            if (livro == null || usuario == null)
            {
                Console.WriteLine("Livro não encontrado. Operação de reserva cancelada.");
                return;
            }

            var novaReserva = new Reserva
            {
                LivroId = livroId,
                Livro = livro,
                Usuario = usuario,
                UsuarioId = Program.usuarioLogado.UsuarioId,
                DataReserva = DateTime.Now
            };

            context.Reservas.Add(novaReserva);
            context.SaveChanges();
            Console.WriteLine("Reserva adicionada com sucesso!");
        }

        public static void AdicionarReserva(BibliotecaContext context)
        {
            Console.Write("ID do Livro para Reserva: ");
            if (!int.TryParse(Console.ReadLine(), out int livroId))
            {
                Console.WriteLine("ID do livro inválido. Operação de reserva cancelada.");
                return;
            }

            Console.Write("ID do Usuário para Reserva: ");
            if (!int.TryParse(Console.ReadLine(), out int usuarioId))
            {
                Console.WriteLine("ID do usuário inválido. Operação de reserva cancelada.");
                return;
            }

            var livro = context.Livros.Find(livroId);
            var usuario = context.Usuarios.Find(usuarioId);

            if (livro == null || usuario == null)
            {
                Console.WriteLine("Livro ou usuário não encontrado. Operação de reserva cancelada.");
                return;
            }

            var novaReserva = new Reserva
            {
                LivroId = livroId,
                Livro = livro,
                UsuarioId = usuarioId,
                Usuario = usuario,
                DataReserva = DateTime.Now
            };

            context.Reservas.Add(novaReserva);
            context.SaveChanges();
            Console.WriteLine("Reserva adicionada com sucesso!");
        }

        public static void ListarReservas(BibliotecaContext context)
        {
            var reservas = context.Reservas.ToList();

            Console.WriteLine("Reservas na biblioteca:");

            foreach (var reserva in reservas)
            {
                var titulo = context.Livros.Find(reserva.LivroId);
                Console.WriteLine($"ID: {reserva.ReservaId}");
                Console.WriteLine($"ID do Livro: {reserva.LivroId}");
                Console.WriteLine($"Nome do Livro: {titulo?.Titulo ?? "N/A"}");
                Console.WriteLine($"ID do Usuário: {reserva.UsuarioId}");
                Console.WriteLine($"Data da Reserva: {reserva.DataReserva:dd/MM/yyyy}");
                Console.WriteLine($"------------------------------------------------------------");
            }
        }

        public static void ListarReservasPorId(BibliotecaContext context)
        {
            if (Program.usuarioLogado.UsuarioId == 0)
            {
                Console.WriteLine("Nenhum usuário logado. Faça o login antes de listar as reservas.");
                return;
            }

            var reservasUsuarioLogado = context.Reservas
                .Where(r => r.UsuarioId == Program.usuarioLogado.UsuarioId)
                .ToList();

            if (reservasUsuarioLogado.Any())
            {
                Console.WriteLine($"Reservas do {Program.usuarioLogado.Nome}):");

                foreach (var reserva in reservasUsuarioLogado)
                {
                    var titulo = context.Livros.Find(reserva.LivroId);
                    Console.WriteLine($"ID da Reserva: {reserva.ReservaId}");
                    Console.WriteLine($"ID do Livro: {reserva.LivroId}");
                    Console.WriteLine($"Nome do Livro: {titulo?.Titulo ?? "N/A"}");
                    Console.WriteLine($"Data da Reserva: {reserva.DataReserva:dd/MM/yyyy}");
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Nenhuma reserva encontrada para o usuário logado.");
            }
        }

        public static void AtualizarReserva(BibliotecaContext context)
        {
            Console.Write("Digite o ID da reserva que deseja atualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int reservaId))
            {
                Console.WriteLine("ID da reserva inválido. Operação de atualização cancelada.");
                return;
            }

            var reservaParaAtualizar = context.Reservas.Find(reservaId);

            if (reservaParaAtualizar == null)
            {
                Console.WriteLine("Reserva não encontrada. Operação de atualização cancelada.");
                return;
            }

            Console.WriteLine("Informe os novos detalhes da reserva (deixe em branco para manter as informações existentes):");

            Console.Write("Novo ID do Livro: ");
            var novoLivroIdStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoLivroIdStr) && int.TryParse(novoLivroIdStr, out int novoLivroId))
            {
                reservaParaAtualizar.LivroId = novoLivroId;
            }


            context.SaveChanges();
            Console.WriteLine("Reserva atualizada com sucesso!");
        }

        public static void ExcluirReserva(BibliotecaContext context)
        {
            Console.Write("Digite o ID da reserva que deseja excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int reservaId))
            {
                Console.WriteLine("ID da reserva inválido. Operação de exclusão cancelada.");
                return;
            }

            var reservaParaExcluir = context.Reservas.Find(reservaId);

            if (reservaParaExcluir == null)
            {
                Console.WriteLine("Reserva não encontrada. Operação de exclusão cancelada.");
                return;
            }

            context.Reservas.Remove(reservaParaExcluir);
            context.SaveChanges();

            Console.WriteLine("Reserva excluída com sucesso!");
        }
    }
}
