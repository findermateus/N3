using Emissao_Fatura_N3;
using Emissao_Fatura_N3.Pessoas;
using Emissao_Fatura_N3.Sistema;
using System.Runtime.CompilerServices;
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
    Tela.EscreveMenuOp(menu, posy, "Fatura");
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

                Tela.EscreveMenuOp(opcoes, posy, "Cliente");

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

                    Tela.DesenhaBorda(0, 0, 79, 24, "Dados do Cliente");
                    Tela.EscreveMenu(dados, 1, 1);

                    //PEGO OS DADOS
                    int i = 0;
                    Console.SetCursorPosition(dados[i].Length + 1, i + 1);
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

                }
                else if (op == "3")
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
            movimentacoes.Add("[1] Adicionar servico contratado a cliente");
            movimentacoes.Add("[2] Sair");
            movimentacoes.Add("Opcao: ");
            posy = 1;
            Tela.EscreveMenuOp(movimentacoes, posy, "Movimentacoes");
            op = Console.ReadLine();
            switch (op)
            {
                case "1":
                    List<string> tipos = new List<string>();
                    Console.Clear();
                    int indice = 0;
                    foreach (string tipo in ServicoDesc.tipos)
                    {
                        tipos.Add("[" + Convert.ToString(indice + 1) + "]" + ServicoDesc.tipos[indice] + "  ");
                        indice++;
                    }
                    tipos.Add("[" + (indice + 1) + "]Sair");
                    tipos.Add("Opcao: ");
                    Tela.EscreveMenuOp(tipos, posy, "Tipo");
                    op = Console.ReadLine();
                    int i = Convert.ToInt32(op);
                    if (i >= 1 && i <= 5)
                    {
                        Console.Clear();
                        List<string> valores = new List<string>();
                        valores.Add(ServicoDesc.descricao[i - 1] + "         ");
                        valores.Add("Valor total: " + ServicoDesc.valor[i - 1]);
                        valores.Add("Porcentagem do ICMS: " + ServicoDesc.icms[i - 1] + "%");
                        valores.Add("Confirma: [1] Sim - [2] Nao: ");
                        Tela.EscreveMenuOp(valores, posy, "Valores");
                        op = Console.ReadLine();
                        if (op == "1")
                        {
                            Servico servico = new Servico(i);
                            rodando = true;
                            while (rodando)
                            {
                                Console.Clear();
                                List<string> opcoes = new List<string>();
                                opcoes.Add("[1] Cliente pessoa fisica  ");
                                opcoes.Add("[2] Cliente pessoa juridica");
                                opcoes.Add("[3] Sair                   ");
                                opcoes.Add("Opcao: ");

                                Tela.EscreveMenu(opcoes, 1, 1);
                                Tela.DesenhaBorda(0, 0, 79, 12, "Cliente");
                                posy = 4;
                                Console.SetCursorPosition(8, posy); posy++;
                                op = Console.ReadLine();
                                if (op == "1" || op == "2")
                                {

                                    var achou = false;
                                    Console.SetCursorPosition(1, posy); posy++;
                                    Console.WriteLine("Digite o nome ou codigo de identificacao do cliente:");
                                    Console.SetCursorPosition(1, posy); posy++;
                                    var conferencia = Console.ReadLine();
                                    conferencia = conferencia.ToUpper();
                                    if (op == "1")
                                    {
                                        foreach (ClienteFisico cliente in sistema.clientesFisicos)
                                        {
                                            if (conferencia == cliente.nome.ToUpper() || conferencia == cliente.codigoIdentificador.ToUpper())
                                            {
                                                achou = true;
                                                cliente.servicos.Add(servico);
                                                break;
                                            }
                                        }
                                    }
                                    else if (op == "2")
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
                                    else
                                    {
                                        Console.WriteLine("Digite uma opcao valida!");
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
                                else { break; }
                            }

                        }
                    }
                    else
                    {
                        Console.Clear();
                    }
                    break;
                default:
                    break;
            }
            break;
        case "3":
            Console.Clear();
            List<string> opcao = new List<string>();
            opcao.Add("[1] Cliente pessoa fisica");
            opcao.Add("[2] Cliente pessoa juridica");
            opcao.Add("[3] Sair");
            opcao.Add("Opcao: ");
            Tela.DesenhaBorda(0, 0, 79, 24, "Cliente");
            Tela.EscreveMenu(opcao, 1, 1);
            op = Console.ReadLine();
            var rodar = true;
            while (rodar)
            {
                if (op != "1" && op != "2") { rodar = false; break; }
                List<string> opcoes = new List<string>();
                opcoes.Add("Digite o nome do Cliente ou o codigo identificador: ");
                opcoes.Add("Identificacao: ");
                Tela.EscreveMenu(opcoes, 1, opcao.Count);
                var conferencia = Console.ReadLine();
                conferencia = conferencia.ToUpper();
                List<string> dados = new List<string>();
                List<Servico> servicos = new List<Servico>();
                Fatura fatura = new Fatura();
                List<string> dadinhos = new List<string>();
                dadinhos.Add("Nome: ");
                dadinhos.Add("CPF/CNPJ: ");
                dadinhos.Add("Telefone: ");
                dadinhos.Add("Codigo Identificador: ");
                dadinhos.Add("Servicos Prestados");
                var achou = false;
                if (op == "1")
                {
                    for (int i = 0; i < sistema.clientesFisicos.Count; i++)
                    {
                        if (conferencia == sistema.clientesFisicos[i].nome.ToUpper() || conferencia == sistema.clientesFisicos[i].codigoIdentificador.ToUpper())
                        {
                            dados.Add(dadinhos[i] + sistema.clientesFisicos[i].nome);
                            dados.Add(dadinhos[i + 1] + sistema.clientesFisicos[i].cpf);
                            dados.Add(dadinhos[i + 2] + sistema.clientesFisicos[i].tel);
                            dados.Add(dadinhos[i + 3] + sistema.clientesFisicos[i].codigoIdentificador);
                            servicos = sistema.clientesFisicos[i].servicos;
                            fatura.AddEndereco(sistema.clientesFisicos[i].end);
                            achou = true;
                        }
                    }
                }
                if (op == "2")
                {
                    for (int i = 0; i < sistema.clientesJuridicos.Count; i++)
                    {
                        if (conferencia == sistema.clientesJuridicos[i].nome.ToUpper() || conferencia == sistema.clientesJuridicos[i].codigoIdentificador.ToUpper())
                        {
                            dados.Add(dadinhos[i] + sistema.clientesJuridicos[i].nome);
                            dados.Add(dadinhos[i + 1] + sistema.clientesJuridicos[i].cnpj);
                            dados.Add(dadinhos[i + 2] + sistema.clientesJuridicos[i].tel);
                            dados.Add(dadinhos[i + 3] + sistema.clientesJuridicos[i].codigoIdentificador);
                            servicos = sistema.clientesJuridicos[i].servicos;
                            fatura.AddEndereco(sistema.clientesJuridicos[i].end);
                            achou = true;
                        }
                    }

                }
                if (achou)
                {
                    fatura.AddDados(dados);
                    Console.Clear();
                    fatura.EmitirFatura(servicos);
                    Console.ReadKey();
                    break;
                }
                else
                {
                    Console.SetCursorPosition(1, 8);
                    Console.WriteLine("Cliente nao encontrado!");
                    Console.ReadKey(); break;
                }
            }
            break;
    }
}