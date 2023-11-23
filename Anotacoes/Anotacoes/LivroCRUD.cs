using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anotacoes
{
    public class LivroCRUD
    {
        private string codigo, titulo, autor, editora;
        private string autorNome, editoraNome;
        private int paginas, qtdAnotacoes, posicao, nota;
        private List<Anotacao> anotacoes;
        private BancoDados bd;
        private Tela tl;


        public LivroCRUD(BancoDados banco, Tela tela)
        {
            this.bd = banco;
            this.tl = tela;
        }


        public void gerirAnotacoes()
        {
            this.montarTela("notas");
            this.entrarCodigo("notas");
            this.posicao = bd.buscar("livro", this.codigo);
            if (this.posicao == -1)
            {
                Console.SetCursorPosition(19,6);
                Console.Write("Livro não existe. Pressione uma tecla para continuar.");
                Console.ReadKey();
            }
            else
            {
                Livro obj = this.obterDados();
                this.mostrarDados("notas");
                this.navegarNotas();
            }
        }


        public void executarCRUD()
        {
            string resp;
            this.posicao = -1;

            this.montarTela();
            this.entrarCodigo();
            this.posicao = bd.buscar("livro", this.codigo);

            if (this.posicao == -1)
            {
                // cadastro
                resp = tl.fazerPergunta(20, 14, "Registro NÃO encontrado. Deseja cadastrar (S/N):");
                if (resp.ToUpper() == "S")
                {
                    this.entrarDados();
                    resp = tl.fazerPergunta(20, 14, "Confirma cadastro (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.gravar("livro", new Livro(this.codigo, this.titulo, this.autor, this.editora, this.paginas));
                    }
                }
            }
            else
            {
                // alteração / exclusão
                Livro obj = this.obterDados();
                this.mostrarDados();
                resp = tl.fazerPergunta(20, 14, "Deseja alterar/excluir/voltar (A/E/V):");
                if (resp.ToUpper() == "A")
                {
                    this.tl.limparArea(34, 9, 77, 12);
                    this.entrarDados();
                    resp = tl.fazerPergunta(20, 14, "Confirma alteração (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        Livro novoObj = new Livro(this.codigo, this.titulo, this.autor, this.editora, this.paginas);
                        bd.alterar("livro", obj, novoObj);
                    }
                }
                if (resp.ToUpper() == "E")
                {
                    resp = tl.fazerPergunta(20, 14, "Confirma exclusão (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.excluir("livro", obj);
                    }
                }
            }

        }

        public void montarTela(string qual="cadastro")
        {
            if (qual == "cadastro")
            {
                tl.montarMoldura(19, 6, 78, 15, "Cadastro de Livros");
                Console.SetCursorPosition(20, 8);  Console.Write("Codigo      :");
                Console.SetCursorPosition(20, 9);  Console.Write("Título      :");
                Console.SetCursorPosition(20, 10); Console.Write("Autor       :");
                Console.SetCursorPosition(20, 11); Console.Write("Editora     :");
                Console.SetCursorPosition(20, 12); Console.Write("Num paginas :");
                Console.SetCursorPosition(20, 13); Console.Write("Anotações   :");
            }
            if (qual == "notas")
            {
                tl.montarMoldura(18, 3, 77, 23, "Anotações");
                tl.montarLinhaHor(7, 18, 77);
                Console.SetCursorPosition(19, 5); Console.Write("Livro :");
            }
            if (qual == "navegar")
            {
                tl.montarMoldura(2, 14, 18, 23, "Navegação");
                Console.SetCursorPosition(3, 16); Console.Write("1 - Primeira");
                Console.SetCursorPosition(3, 17); Console.Write("A - Anterior");
                Console.SetCursorPosition(3, 18); Console.Write("P - Próxima");
                Console.SetCursorPosition(3, 19); Console.Write("0 - Última");
                Console.SetCursorPosition(3, 20); Console.Write("N - Nova");
                Console.SetCursorPosition(3, 21); Console.Write("X - Apagar");
                Console.SetCursorPosition(3, 22); Console.Write("S - Sair");
            }
        }

        public void entrarCodigo(string qual="cadastro")
        {
            if (qual == "cadastro") Console.SetCursorPosition(34, 8);
            if (qual == "notas") Console.SetCursorPosition(27, 5);
            this.codigo = Console.ReadLine();
        }

        public void entrarDados()
        {
            Console.SetCursorPosition(34, 9);
            this.titulo = Console.ReadLine();
            
            Console.SetCursorPosition(34, 10);
            this.autor = Console.ReadLine();
            Console.SetCursorPosition(34 + this.autor.Length, 10);
            Console.Write(" - " + bd.recuperarNome("autor", this.autor));

            Console.SetCursorPosition(34, 11);
            this.editora = Console.ReadLine();
            Console.SetCursorPosition(34 + this.editora.Length, 11);
            Console.Write(" - " + bd.recuperarNome("editora", this.editora));

            Console.SetCursorPosition(34, 12);
            this.paginas = int.Parse(Console.ReadLine());
        }


        public Livro obterDados()
        {
            Livro obj = (Livro)bd.recuperar("livro", this.posicao);
            this.titulo = obj.Titulo;
            this.autor = obj.Autor;
            this.editora = obj.Editora;
            this.paginas = obj.Paginas;
            this.autorNome = bd.recuperarNome("autor", this.autor);
            this.editoraNome = bd.recuperarNome("editora", this.editora);
            this.qtdAnotacoes = obj.Notas.Count;
            this.anotacoes = obj.Notas;
            return obj;
        }


        public void mostrarDados(string qual="cadastro")
        {
            if (qual == "cadastro")
            {
                Console.SetCursorPosition(34, 9);  Console.Write(this.titulo);
                Console.SetCursorPosition(34, 10); Console.Write(this.autor + " - " + this.autorNome);
                Console.SetCursorPosition(34, 11); Console.Write(this.editora + " - " + this.editoraNome);
                Console.SetCursorPosition(34, 12); Console.Write(this.paginas);
                Console.SetCursorPosition(34, 13); Console.Write(this.qtdAnotacoes);
            }
            if (qual == "notas")
            {
                Console.SetCursorPosition(27+this.codigo.Length, 5); Console.Write(" - " + this.titulo);
                Console.SetCursorPosition(27, 6); Console.Write(this.qtdAnotacoes.ToString()+" anotações");
            }
        }


        public void navegarNotas()
        {
            this.montarTela("navegar");
            
            this.nota = 0;
            while (true)
            {
                if (this.qtdAnotacoes == 0)
                { 
                }
                else
                { 
                }

                ConsoleKeyInfo tecla = Console.ReadKey(true);

                if (tecla.Key == ConsoleKey.S) break;
            }
        }
    }
}
