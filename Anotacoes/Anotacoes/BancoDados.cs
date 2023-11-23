using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anotacoes
{
    // esta classe fornece serviço de guarda dos dados
    public class BancoDados
    {
        List<Editora> editoras = new List<Editora>();
        List<Autor> autores = new List<Autor>();
        List<Livro> livros = new List<Livro>();
        List<Anotacao> anotacoes = new List<Anotacao>();

        public BancoDados() 
        {
            // cria alguns registros para realizar permitir o uso rápido do sistema


            // adiciona algumas editoras
            this.editoras.Add(new Editora("1", "Um Bertrand Brasil"));
            this.editoras.Add(new Editora("2", "Dois LVM Editorial"));
            this.editoras.Add(new Editora("3", "Tres"));
            this.editoras.Add(new Editora("4", "Quatro"));
            this.editoras.Add(new Editora("5", "Cinco"));
            this.editoras.Add(new Editora("6", "Seis"));

            // adiciona alguns autores
            this.autores.Add(new Autor("1", "Max Gallo", "Francês"));
            this.autores.Add(new Autor("2", "Alexandre Otrowiecki", "Brasileiro"));

            // adiciona alguns livros

            // um livro já com anotações
            List<Anotacao> anotacoes = new List<Anotacao>();
            anotacoes.Add(new Anotacao(DateTime.Now, "Ficção história ambientada durante a II Guerra Mundial"));
            anotacoes.Add(new Anotacao(DateTime.Now, "Conta um parte da história da Resistência Francesa"));
            this.livros.Add(new Livro("1", "Os Patriotas, vol 1", "1", "1", 332, anotacoes) );

            // outro livro sem qualquer anotação
            this.livros.Add(new Livro("2", "O modedor de pobres", "2", "2", 278));
        }


        public int buscar(string onde, string oque)
        {
            int posicao = -1;

            //
            // várias formas diferentes de achar o índice de um registro
            //

            if (onde == "editora")
            {
                for (int x = 0; x < this.editoras.Count; x++)
                {
                    if (editoras[x].Codigo == oque)
                    {
                        posicao = x;
                        break;
                    }
                }
            }

            if (onde == "autor") posicao = this.autores.FindIndex(o => o.Codigo == oque);

            if (onde == "livro") posicao = this.livros.FindIndex(o => o.Codigo.Equals(oque));

            return posicao;
        }


        public object recuperar(string onde, int qual)
        {
            Object obj = null;
            if (onde == "editora") obj = this.editoras[qual];
            if (onde == "autor") obj = this.autores[qual];
            if (onde == "livro") obj = this.livros[qual];
            if (onde == "anotacao") obj = this.anotacoes[qual];
            return obj;
        }


        public void gravar(string onde, Object oque) 
        {
            if (onde == "editora") this.editoras.Add((Editora)oque);
            if (onde == "autor") this.autores.Add((Autor)oque);
            if (onde == "livro") this.livros.Add((Livro)oque);
        }


        public void alterar(string onde, Object oque, Object novo)
        {
            if (onde == "editora")
            {
                int x = this.buscar("editora", ((Editora)oque).Codigo);
                this.editoras[x] = (Editora)novo;
            }

            if (onde == "autor")
            {
                int x = this.buscar("autor", ((Autor)oque).Codigo);
                this.autores[x] = (Autor)novo;
            }

            if (onde == "livro")
            {
                int x = this.buscar("livro", ((Livro)oque).Codigo);
                this.livros[x] = (Livro)novo;
            }
        }


        public void excluir(string onde, Object oque)
        {
            if (onde == "editora") this.editoras.Remove((Editora)oque);
            if (onde == "autor") this.autores.Remove((Autor)oque);
            if (onde == "livro") this.livros.Remove((Livro)oque);
        }


        public string recuperarNome(string onde, string oque)
        {
            string result = "Não encontrado";
            int pos = this.buscar(onde,oque);

            if (pos >= 0) 
            {
                if (onde == "autor") result = this.autores[pos].Nome;
                if (onde == "editora") result = this.editoras[pos].Nome;
            }

            return result;
        }
    }
}
