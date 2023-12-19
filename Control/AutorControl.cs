using Biblioteca.Data;
using Biblioteca.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Control
{
    internal class AutorControl
    {
        public static void AdicionarAutor(BibliotecaContext context)
        {
            Console.WriteLine("Informe os detalhes do novo autor:");

            Console.Write("Nome: ");
            var nome = Console.ReadLine();


            var novoAutor = new Autor
            {
                Nome = nome,
            };

            context.Autores.Add(novoAutor);
            context.SaveChanges();
            Console.WriteLine("Autor adicionado com sucesso!");
        }

        public static void ListarAutores(BibliotecaContext context)
        {
            var autores = context.Autores.ToList();

            Console.WriteLine("Autores na biblioteca:");

            foreach (var autor in autores)
            {
                Console.WriteLine($"ID: {autor.AutorId}");
                Console.WriteLine($"Nome: {autor.Nome}");
                Console.WriteLine($"------------------------------------------------------------");
            }
        }

        public static void AtualizarAutor(BibliotecaContext context)
        {
            Console.Write("Digite o ID do autor que deseja atualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int autorId))
            {
                Console.WriteLine("ID do autor inválido. Operação de atualização cancelada.");
                return;
            }

            var autorParaAtualizar = context.Autores.Find(autorId);

            if (autorParaAtualizar == null)
            {
                Console.WriteLine("Autor não encontrado. Operação de atualização cancelada.");
                return;
            }

            Console.WriteLine("Informe o novo nome do autor (deixe em branco para manter o nome existente):");

            Console.Write("Novo Nome: ");
            var novoNome = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoNome))
            {
                autorParaAtualizar.Nome = novoNome;
            }

            context.SaveChanges();
            Console.WriteLine("Autor atualizado com sucesso!");
        }

        public static void ExcluirAutor(BibliotecaContext context)
        {
            Console.Write("Digite o ID do autor que deseja excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int autorId))
            {
                Console.WriteLine("ID do autor inválido. Operação de exclusão cancelada.");
                return;
            }

            var autorParaExcluir = context.Autores.Find(autorId);

            if (autorParaExcluir == null)
            {
                Console.WriteLine("Autor não encontrado. Operação de exclusão cancelada.");
                return;
            }

            context.Autores.Remove(autorParaExcluir);
            context.SaveChanges();

            Console.WriteLine("Autor excluído com sucesso!");
        }
    }
}
