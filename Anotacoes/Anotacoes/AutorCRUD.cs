using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anotacoes
{
    public class AutorCRUD
    {
        private string codigo, nome, nacionalidade;
        private BancoDados bd;
        private Tela tl;
        private int posicao;


        public AutorCRUD(BancoDados banco, Tela tela)
        {
            this.bd = banco;
            this.tl = tela;
        }

        public void executarCRUD()
        {
            string resp;
            this.posicao = -1;

            this.montarTela();
            this.entrarCodigo();
            this.posicao = bd.buscar("autor", this.codigo);

            if (this.posicao == -1)
            {
                // cadastro
                resp = tl.fazerPergunta(11, 11, "Registro NÃO encontrado. Deseja cadastrar (S/N):");
                if (resp.ToUpper() == "S")
                {
                    this.entrarDados();
                    resp = tl.fazerPergunta(11, 11, "Confirma cadastro (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.gravar("autor", new Autor(this.codigo, this.nome, this.nacionalidade));
                    }
                }
            }
            else
            {
                // alteração / exclusão
                Autor obj = (Autor)bd.recuperar("autor", this.posicao);
                this.nome = obj.Nome;
                this.nacionalidade = obj.Nacionalidade;

                this.mostrarDados();
                resp = tl.fazerPergunta(11, 11, "Deseja alterar/excluir/voltar (A/E/V):");
                if (resp.ToUpper() == "A")
                {
                    this.tl.limparArea(27, 9, 69, 10);
                    this.entrarDados();
                    resp = tl.fazerPergunta(11, 11, "Confirma alteração (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        Autor novoObj = new Autor(this.codigo, this.nome, this.nacionalidade);
                        bd.alterar("autor", obj, novoObj);
                    }
                }
                if (resp.ToUpper() == "E")
                {
                    resp = tl.fazerPergunta(11, 11, "Confirma exclusão (S/N):");
                    if (resp.ToUpper() == "S")
                    {
                        bd.excluir("autor", obj);
                    }
                }
            }

        }

        public void montarTela()
        {
            tl.montarMoldura(10, 6, 70, 12, "Cadastro de Autors");
            Console.SetCursorPosition(11, 8);
            Console.Write("Codigo        :");
            Console.SetCursorPosition(11, 9);
            Console.Write("Nome          :");
            Console.SetCursorPosition(11, 10);
            Console.Write("Nacionalidade :");
        }

        public void entrarCodigo()
        {
            Console.SetCursorPosition(27, 8);
            this.codigo = Console.ReadLine();
        }

        public void entrarDados()
        {
            Console.SetCursorPosition(27, 9);
            this.nome = Console.ReadLine();
            Console.SetCursorPosition(27, 10);
            this.nacionalidade = Console.ReadLine();
        }

        public void mostrarDados()
        {
            Console.SetCursorPosition(27, 9);
            Console.Write(this.nome);
            Console.SetCursorPosition(27, 10);
            Console.Write(this.nacionalidade);
        }
    }
}
