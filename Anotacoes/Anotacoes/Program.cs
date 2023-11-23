using Anotacoes;

Tela tela = new Tela();
BancoDados bancoDados = new BancoDados();
EditoraCRUD editora = new EditoraCRUD(bancoDados, tela);
AutorCRUD autor = new AutorCRUD(bancoDados, tela);
LivroCRUD livro = new LivroCRUD(bancoDados, tela);

List<string> menu = new List<string>();
menu.Add("1 - Editoras ");
menu.Add("2 - Autores  ");
menu.Add("3 - Livros   ");
menu.Add("4 - Anotações");
menu.Add("0 - Sair");

string op;

while (true)
{
    tela.montarTelaSistema("Sistemas de Anotações");
    op = tela.mostrarMenu(menu, 2, 3);

    if (op == "0") break;
    if (op == "1") editora.executarCRUD();
    if (op == "2") autor.executarCRUD();
    if (op == "3") livro.executarCRUD();
    if (op == "4") livro.gerirAnotacoes();
}