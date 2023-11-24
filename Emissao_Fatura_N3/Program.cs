using Emissao_Fatura_N3;
using Emissao_Fatura_N3.Pessoas;
using Emissao_Fatura_N3.Sistema;
using System.Security.Cryptography;

Sistema sistema = new Sistema();
List<string> menu = new List<string>();
menu.Add("[1] Adicionar cliente. ");
menu.Add("[2] Movimentacoes. ");
menu.Add("[3] Emitir fatura. ");
menu.Add("Opcao: ");



while (true)
{
    Console.Clear();
    int posy = 1;   
    CRUD.EscreveMenuOp(menu, posy,"Fatura");
    var op = Console.ReadLine();
    switch (op)
    {
        //ADICIONAR CLIENTE
        case "1":

            var rodando = true;
            while (rodando)
            {
                Console.Clear();
                List<string> opcoes = new List<string>();
                opcoes.Add("[1] Cliente pessoa fisica  ");
                opcoes.Add("[2] Cliente pessoa juridica");
                opcoes.Add("[3] Sair                   ");
                opcoes.Add("Opcao: ");

                CRUD.EscreveMenuOp(opcoes, posy,"Cliente");
               
                op = Console.ReadLine();
                if (op == "1" || op == "2")
                {
                    //PEGANDO INFORMACOES BASICAS
                    List<string> dados = new List<string>();
                    Console.Clear();

                    dados.Add("Nome: ");
                    dados.Add("Telefone: ");
                    dados.Add("CEP: ");
                    dados.Add("Estado: ");
                    dados.Add("Cidade: ");
                    dados.Add("Bairro: ");
                    dados.Add("Rua: ");
                    dados.Add("Complemento: ");
                    
                    Tela.DesenhaBorda(0,0,79,24,"Dados do Cliente");
                    CRUD.EscreveMenu(dados,1,1);

                    //PEGO OS DADOS
                    int i = 0;
                    Console.SetCursorPosition(dados[i].Length+1,i+1);
                    i++;
                    var nome = Console.ReadLine();
                    Console.SetCursorPosition(dados[i].Length + 1, i + 1);
                    i++;
                    var telefone = Console.ReadLine();
                    Console.SetCursorPosition(dados[i].Length + 1, i + 1);
                    i++;
                    var cep = Console.ReadLine();
                    Console.SetCursorPosition(dados[i].Length + 1, i + 1);
                    i++;
                    var estado = Console.ReadLine();
                    Console.SetCursorPosition(dados[i].Length + 1, i + 1);
                    i++;
                    var cidade = Console.ReadLine();
                    Console.SetCursorPosition(dados[i].Length + 1, i + 1);
                    i++;
                    var bairro = Console.ReadLine();
                    Console.SetCursorPosition(dados[i].Length + 1, i + 1);
                    i++;
                    var rua = Console.ReadLine();
                    Console.SetCursorPosition(dados[i].Length + 1, i + 1);
                    var complemento = Console.ReadLine();
                    //CHECA SE É PESSOA FISICA
                    var pos = 2;
                    if (op == "1")
                    {
                        Console.SetCursorPosition(1, i + pos); pos++;
                        Console.Write("CPF: "); var cpf = Console.ReadLine();
                        Console.SetCursorPosition(1, i + pos); pos++;
                        Console.Write("Confirma: [1] Sim - [2] Nao: ");
                        op = Console.ReadLine();
                        if (op == "1")
                        {
                                var codigoIdentificador = Guid.NewGuid().ToString();
                                Console.SetCursorPosition(1, i + pos); pos++;
                                Console.Write("Codigo identificador do cliente: ");
                                Console.WriteLine(codigoIdentificador);
                                
                            Endereco endereco = new Endereco(estado, cidade, cep, complemento);
                            ClienteFisico clienteFisico = new ClienteFisico(cpf, telefone, endereco, codigoIdentificador, nome);
                            sistema.clientesFisicos.Add(clienteFisico);
                            Console.ReadKey();
                            Console.SetCursorPosition(1, i + pos); pos++;
                            Console.WriteLine("Cliente Adicionado com sucesso!");
                            Console.ReadKey();
                            rodando = false;
                        }
                    }
                    else
                    {
                        //PESSOA JURIDICA
                        Console.SetCursorPosition(1, i + pos); pos++;
                        Console.Write("CNPJ: "); var cnpj = Console.ReadLine();
                        Console.SetCursorPosition(1, i + pos); pos++;
                        Console.Write("Confirma: [1] Sim - [2] Nao: ");
                        op = Console.ReadLine();
                        if (op == "1")
                        {
                            var codigoIdentificador = Guid.NewGuid().ToString();
                            Console.SetCursorPosition(1, i + pos); pos++;
                            Console.Write("Codigo identificador do cliente: ");
                            Console.WriteLine(codigoIdentificador);
                             
                            Endereco endereco = new Endereco(estado, cidade, cep, complemento);
                            ClienteJuridico clienteJuridico = new ClienteJuridico(cnpj, telefone, endereco, codigoIdentificador, nome);
                            sistema.clientesJuridicos.Add(clienteJuridico);
                            Console.ReadLine();
                            Console.SetCursorPosition(1, i + pos); pos++;
                            Console.WriteLine("Cliente Adicionado com sucesso!");
                            Console.ReadKey();
                            rodando = false;
                        }
                    }
                       
                }else if (op == "3")
                {
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Digite uma opcao valida!");
                    Console.ReadKey();
                }
            }
            Console.Clear();
            break;
        //movimentacoes
        case "2":
            Console.Clear();
            List<string> movimentacoes = new List<string>();
            movimentacoes.Add("[1] - Adicionar servico contratado a cliente");
            movimentacoes.Add("Opcao: ");
            posy = 1;
            CRUD.EscreveMenuOp(movimentacoes,posy,"Movimentacoes");
            op = Console.ReadLine();
            switch (op)
            {
                case "1":
                    List <string> tipos = new List<string>();
                    Console.Clear();
                    int indice = 0;
                    foreach(string tipo in ServicoDesc.tipos)
                    {
                        tipos.Add("["+Convert.ToString(indice+1)+"]" + ServicoDesc.tipos[indice]+"  ");
                        indice++;
                    }
                    tipos.Add("["+(indice+1)+"]Sair");
                    tipos.Add("Opcao: ");
                    CRUD.EscreveMenuOp(tipos,posy,"Tipo");
                    op = Console.ReadLine();
                    int i = Convert.ToInt32(op);
                    if (i >= 1 && i <= 5)
                    {
                        Console.Clear();
                        List<string> valores = new List<string>();
                        valores.Add(ServicoDesc.descricao[i - 1]+"         ");
                        valores.Add("Valor total: " + ServicoDesc.valor[i - 1]);
                        valores.Add("Porcentagem do ICMS: " + ServicoDesc.icms[i - 1] + "%");
                        valores.Add("Confirma: [1] Sim - [2] Nao: ");
                        CRUD.EscreveMenuOp(valores,posy,"Valores");
                        op = Console.ReadLine();
                        if (op == "1")
                        {
                            Servico servico = new Servico(i);
                            rodando = true;
                            while(rodando)
                            {
                                Console.Clear();
                                List<string> opcoes = new List<string>();
                                opcoes.Add("[1] Cliente pessoa fisica  ");
                                opcoes.Add("[2] Cliente pessoa juridica");
                                opcoes.Add("[3] Sair                   ");
                                opcoes.Add("Opcao: ");

                                CRUD.EscreveMenu(opcoes,1,1);
                                Tela.DesenhaBorda(0,0,79,12,"Cliente");
                                posy = 4;
                                Console.SetCursorPosition(8,posy); posy++;
                                op = Console.ReadLine();
                                var achou = false;
                                Console.SetCursorPosition(1,posy);posy++;
                                Console.WriteLine("Digite o nome ou codigo de identificacao do cliente:");
                                Console.SetCursorPosition(1, posy); posy++;
                                var conferencia = Console.ReadLine();
                                conferencia = conferencia.ToUpper();
                                if (op == "1")
                                {
                                    foreach(ClienteFisico cliente in sistema.clientesFisicos)
                                    {
                                        if (conferencia == cliente.nome.ToUpper() || conferencia == cliente.codigoIdentificador.ToUpper())
                                        {
                                            achou = true;
                                            cliente.servicos.Add(servico);
                                            break;
                                        }
                                    }
                                }else if(op == "2")
                                {
                                    foreach (ClienteJuridico cliente in sistema.clientesJuridicos)
                                    {
                                        if (conferencia == cliente.nome.ToUpper() || conferencia == cliente.codigoIdentificador.ToUpper())
                                        {
                                            achou = true;
                                            cliente.servicos.Add(servico);
                                            break;
                                        }
                                    }
                                }
                                else { Console.WriteLine("Digite uma opcao valida!");
                                    Console.ReadKey();
                                }
                                if (!achou)
                                {
                                    Console.SetCursorPosition(1, posy); posy++;
                                    Console.WriteLine("Cliente nao encontrado!");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
                                    Console.SetCursorPosition(1, posy); posy++;
                                    Console.WriteLine("Servico adicionado com sucesso!");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                            }
                        }
                    }
                    else 
                    { 
                        Console.Clear();
                    }
                    break;    
            }
            break;
        case "3":
            Console.Clear();
            Console.WriteLine("[1] Cliente pessoa fisica");
            Console.WriteLine("[2] Cliente pessoa juridica");
            Console.WriteLine("[3] Sair");
            op = Console.ReadLine();
            var rodar = true;
            while (rodar) {
                Console.Write("\nDigite o nome ou codigo identificador do cliente: ");
                var id = Console.ReadLine();
                var achou = false;
                Fatura fatura = new Fatura();
                List<Servico> servicos = new List<Servico>();
                List<string> dados = new List<string>();
                //string cep, rua, comp, cidade, estado;
                switch (op)
                {
                    case "1":

                        foreach(ClienteFisico cliente in sistema.clientesFisicos)
                        {
                            if (cliente.nome == id || cliente.codigoIdentificador == id)
                            {
                                dados.Add(cliente.nome);
                                dados.Add(cliente.cpf);
                                dados.Add(cliente.codigoIdentificador);
                                foreach(Servico servico in cliente.servicos)
                                {
                                    servicos.Add(servico);
                                }
                                achou = true;
                            }
                        }
                        break;
                    case "2":
                        foreach (ClienteJuridico cliente in sistema.clientesJuridicos)
                        {
                            if (cliente.nome == id || cliente.codigoIdentificador == id)
                            {
                                dados.Add(cliente.nome);
                                dados.Add(cliente.cnpj);
                                dados.Add(cliente.codigoIdentificador);
                                foreach (Servico servico in cliente.servicos)
                                {
                                    servicos.Add(servico);
                                }
                                achou = true;
                            }
                        }
                        break;
                    case "3":
                        rodar = false;
                        Console.Clear();
                        break;
                    default:
                        Console.WriteLine("Digite uma opcao valida!");
                        Console.ReadKey();
                    break;
                }
                if (!achou)
                {
                    Console.WriteLine("Cliente nao encontrado!");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                fatura.AddDados(dados);
                Console.Clear();
                Tela.DesenhaBorda(0,0,79,24,"Fatura");
                dados.Add("Valor total: R$"+fatura.CalcutaTotal(servicos));
                CRUD.EscreveMenu(dados, 1, 1);
                Console.ReadKey();
                Console.Clear();
                break;
            }
            break;
    }
}