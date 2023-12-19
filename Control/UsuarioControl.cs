using Biblioteca.Data;
using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Control
{
    internal class UsuarioControl
    {
        public static void AdicionarUsuario(BibliotecaContext context)
        {
            Console.WriteLine("Informe os detalhes do novo usuário:");

            Console.Write("Nome de Usuário: ");
            var nome = Console.ReadLine();

            Console.Write("Senha: ");
            var senha = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Data de Nascimento (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime nascimento))
            {
                Console.WriteLine("Data de publicação inválida. Abortando a operação.");
                return;
            }

            Console.Write("É Administrador (true/false): ");
            if (!bool.TryParse(Console.ReadLine(), out bool adm))
            {
                Console.WriteLine("Valor inválido para administrador. Operação de adição cancelada.");
                return;
            }

            var novoUsuario = new Usuario
            {
                Nome = nome,
                Senha = senha,
                Email = email,
                Nascimento = nascimento,
                Adm = adm
            };

            context.Usuarios.Add(novoUsuario);
            context.SaveChanges();
            Console.WriteLine("Usuário adicionado com sucesso!");
        }

        public static void ListarUsuarios(BibliotecaContext context)
        {
            var usuarios = context.Usuarios.ToList();

            Console.WriteLine("Usuários na biblioteca:");

            foreach (var usuario in usuarios)
            {
                Console.WriteLine($"ID: {usuario.UsuarioId}");
                Console.WriteLine($"Nome de Usuário: {usuario.Nome}");
                Console.WriteLine($"Email: {usuario.Email}");
                Console.WriteLine($"Data de Nascimento: {usuario.Nascimento:dd/MM/yyyy}");
                Console.WriteLine($"É Administrador: {usuario.Adm}");
                Console.WriteLine($"------------------------------------------------------------");
            }
        }

        public static void AtualizarUsuario(BibliotecaContext context)
        {
            Console.Write("Digite o ID do usuário que deseja atualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int usuarioId))
            {
                Console.WriteLine("ID do usuário inválido. Operação de atualização cancelada.");
                return;
            }

            var usuarioParaAtualizar = context.Usuarios.Find(usuarioId);

            if (usuarioParaAtualizar == null)
            {
                Console.WriteLine("Usuário não encontrado. Operação de atualização cancelada.");
                return;
            }

            Console.WriteLine("Informe os novos detalhes do usuário (deixe em branco para manter as informações existentes):");

            Console.Write("Novo Nome de Usuário: ");
            var novoNome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoNome))
            {
                usuarioParaAtualizar.Nome = novoNome;
            }

            Console.Write("Nova Senha: ");
            var novaSenha = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novaSenha))
            {
                usuarioParaAtualizar.Senha = novaSenha;
            }

            Console.Write("Novo Email: ");
            var novoEmail = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoEmail))
            {
                usuarioParaAtualizar.Email= novoEmail;
            }

            Console.Write("Novo Data de Nascimento: ");
            var novoNascimentostr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoNascimentostr) && DateTime.TryParse(novoNascimentostr, out DateTime novoNascimento))
            {
                usuarioParaAtualizar.Nascimento = novoNascimento;
            }

            Console.Write("É Administrador (true/false): ");
            var admStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(admStr) && bool.TryParse(admStr, out bool novoAdm))
            {
                usuarioParaAtualizar.Adm = novoAdm;
            }

            context.SaveChanges();
            Console.WriteLine("Usuário atualizado com sucesso!");
        }

        public static void ExcluirUsuario(BibliotecaContext context)
        {
            Console.Write("Digite o ID do usuário que deseja excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int usuarioId))
            {
                Console.WriteLine("ID do usuário inválido. Operação de exclusão cancelada.");
                return;
            }

            var usuarioParaExcluir = context.Usuarios.Find(usuarioId);

            if (usuarioParaExcluir == null)
            {
                Console.WriteLine("Usuário não encontrado. Operação de exclusão cancelada.");
                return;
            }

            context.Usuarios.Remove(usuarioParaExcluir);
            context.SaveChanges();

            Console.WriteLine("Usuário excluído com sucesso!");
        }
    }
}
