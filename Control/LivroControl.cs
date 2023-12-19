using Biblioteca.Data;
using Biblioteca.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Control
{
    internal class LivroControl
    {
        public static void AdicionarLivro(BibliotecaContext context)
        {
            Console.WriteLine("Informe os detalhes do novo livro:");

            Console.Write("Título: ");
            var titulo = Console.ReadLine();
            if (string.IsNullOrEmpty(titulo))
            {
                Console.WriteLine("O título do livro não pode ser nulo ou vazio. Abortando a operação.");
                return;
            }

            Console.Write("Descricão: ");
            var descricao = Console.ReadLine();
            if (string.IsNullOrEmpty(descricao))
            {
                Console.WriteLine("A descricão do livro não pode ser nulo ou vazio. Abortando a operação.");
                return;
            }

            Console.Write("Data de Publicação (yyyy-MM-dd): ");
            if (!DateTime.TryParse(Console.ReadLine(), out DateTime dataPublicacao))
            {
                Console.WriteLine("Data de publicação inválida. Abortando a operação.");
                return;
            }

            Console.Write("ID do Autor: ");
            if (!int.TryParse(Console.ReadLine(), out int autorId))
            {
                Console.WriteLine("ID do Autor inválido. Abortando a operação.");
                return;
            }

            var novoLivro = new Livro
            {
                Titulo = titulo,
                Descricao = descricao,
                Publicacao = dataPublicacao,
                AutorId = autorId
            };

            context.Livros.Add(novoLivro);
            context.SaveChanges();
            Console.WriteLine("Livro adicionado com sucesso!");
        }

        public static void ListarLivros(BibliotecaContext context)
        {
            var livros = context.Livros.ToList();
            Console.WriteLine("Livros na biblioteca:");
            foreach (var livro in livros)
            {
                var autor = context.Autores.Find(livro.AutorId);
                Console.WriteLine($"ID: {livro.LivroId}");
                Console.WriteLine($"Título: {livro.Titulo}");
                Console.WriteLine($"Descrição: {livro.Descricao}");
                Console.WriteLine($"Data de Publicação: {livro.Publicacao:MM/yyyy}");
                Console.WriteLine($"Autor: {autor?.Nome ?? "N/A"}");
                Console.WriteLine($"------------------------------------------------------------");
            }
        }

        public static void AtualizarLivro(BibliotecaContext context)
        {
            Console.Write("Digite o ID do livro que deseja atualizar: ");
            if (!int.TryParse(Console.ReadLine(), out int livroId))
            {
                Console.WriteLine("ID do livro inválido. Operação de atualização cancelada.");
                return;
            }

            var livroParaAtualizar = context.Livros.Find(livroId);

            if (livroParaAtualizar == null)
            {
                Console.WriteLine("Livro não encontrado. Operação de atualização cancelada.");
                return;
            }

            Console.WriteLine("Informe os novos detalhes do livro (deixe em branco para manter as informações existentes):");

            Console.Write("Novo Título: ");
            var novoTitulo = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoTitulo))
            {
                livroParaAtualizar.Titulo = novoTitulo;
            }

            Console.Write("Nova Descrição: ");
            var novaDescricao = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novaDescricao))
            {
                livroParaAtualizar.Descricao = novaDescricao;
            }

            Console.Write("Nova Data de Publicação (yyyy-MM-dd): ");
            var novaDataPublicacaoStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novaDataPublicacaoStr) && DateTime.TryParse(novaDataPublicacaoStr, out DateTime novaDataPublicacao))
            {
                livroParaAtualizar.Publicacao = novaDataPublicacao;
            }

            Console.Write("Novo ID do Autor: ");
            var novoAutorIdStr = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(novoAutorIdStr) && int.TryParse(novoAutorIdStr, out int novoAutorId))
            {
                livroParaAtualizar.AutorId = novoAutorId;
            }

            context.SaveChanges();
            Console.WriteLine("Livro atualizado com sucesso!");
        }

        public static void ExcluirLivro(BibliotecaContext context)
        {
            Console.Write("Digite o ID do livro que deseja excluir: ");
            if (!int.TryParse(Console.ReadLine(), out int livroId))
            {
                Console.WriteLine("ID do livro inválido. Operação de exclusão cancelada.");
                return;
            }

            var livroParaExcluir = context.Livros.Find(livroId);

            if (livroParaExcluir == null)
            {
                Console.WriteLine("Livro não encontrado. Operação de exclusão cancelada.");
                return;
            }

            context.Livros.Remove(livroParaExcluir);
            context.SaveChanges();

            Console.WriteLine("Livro excluído com sucesso!");
        }
    }
}
