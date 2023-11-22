using Emissao_Fatura_N3;
using Emissao_Fatura_N3.Pessoas;
using Emissao_Fatura_N3.Sistema;

Sistema sistema = new Sistema();

while (true)
{
    Console.WriteLine("Selecione a opcao desejada: ");
    Console.WriteLine("[1] Adicionar cliente. ");
    Console.WriteLine("[2] Movimentacoes. ");
    Console.WriteLine("[3] Emitir fatura. ");
    
    var op = Console.ReadLine();

    switch (op)
    {
        //ADICIONAR CLIENTE
        case "1":
            Console.Clear();
            var rodando = true;
            while (rodando)
            {
                Console.Clear();
                Console.WriteLine("[1] Cliente pessoa fisica");
                Console.WriteLine("[2] Cliente pessoa juridica");
                Console.WriteLine("[3] Sair");

                op = Console.ReadLine();
                if (op == "1" || op == "2")
                {
                    //PEGANDO INFORMACOES BASICAS
                    Console.Clear();
                    Console.WriteLine("Digite as informacoes do cliente: ");
                    Console.Write("\nNome: ");
                    var nome = Console.ReadLine();
                    Console.Write("Telefone: ");
                    var telefone = Console.ReadLine();
                    Console.Write("CEP: ");
                    var cep = Console.ReadLine();
                    Console.Write("Estado: ");
                    var estado = Console.ReadLine();
                    Console.Write("Cidade: ");
                    var cidade = Console.ReadLine();
                    Console.Write("Bairro: ");
                    var bairro = Console.ReadLine();
                    Console.Write("Rua: ");
                    var rua = Console.ReadLine();
                    Console.Write("Complemento: ");
                    var complemento = Console.ReadLine();
                    
                    //CHECA SE É PESSOA FISICA
                    
                    if (op == "1")
                    {
                        Console.Write("CPF: "); var cpf = Console.ReadLine();
                        Console.WriteLine("Confirma: [1] Sim - [2] Nao");
                        op = Console.ReadLine();
                        if (op == "1")
                        {
                                var codigoIdentificador = Guid.NewGuid().ToString();
                                Console.Write("Codigo identificador do cliente: ");
                                Console.WriteLine(codigoIdentificador);
                                
                            Endereco endereco = new Endereco(estado, cidade, cep, complemento);
                            ClienteFisico clienteFisico = new ClienteFisico(cpf, telefone, endereco, codigoIdentificador, nome);
                            sistema.clientesFisicos.Add(clienteFisico);
                            Console.ReadKey();
                            Console.Clear();
                            Console.WriteLine("Cliente Adicionado com sucesso!");
                            Console.ReadKey();
                            rodando = false;
                        }
                    }
                    else
                    {
                    //PESSOA JURIDICA
                        Console.Write("CNPJ: "); 
                        var cnpj = Console.ReadLine();
                        Console.WriteLine("Confirma: [1] Sim - [2] Nao");
                        op = Console.ReadLine();
                        if (op == "1")
                        {
                            var codigoIdentificador = Guid.NewGuid().ToString();
                                Console.Write("Codigo identificador do cliente: ");
                                Console.WriteLine(codigoIdentificador);
                             
                            Endereco endereco = new Endereco(estado, cidade, cep, complemento);
                            ClienteJuridico clienteJuridico = new ClienteJuridico(cnpj, telefone, endereco, codigoIdentificador, nome);
                            sistema.clientesJuridicos.Add(clienteJuridico);
                            Console.ReadLine();
                            Console.Clear();
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
            Console.WriteLine("[1] - Adicionar servico contratado a cliente");
            op = Console.ReadLine();
            switch (op)
            {
                case "1":
                    Console.Clear();
                    int indice = 0;
                    foreach(string tipo in ServicoDesc.tipos)
                    {
                        Console.WriteLine("["+Convert.ToString(indice+1)+"]" + ServicoDesc.tipos[indice]);
                        indice++;
                    }
                    
                    op = Console.ReadLine();
                    int i = Convert.ToInt32(op);
                    if (i >= 1 && i <= 5)
                    {
                        Console.Clear();
                        Console.WriteLine(ServicoDesc.descricao[i - 1]);
                        Console.WriteLine("Valor total: " + ServicoDesc.valor[i - 1]);
                        Console.WriteLine("Porcentagem do ICMS: " + ServicoDesc.icms[i - 1] + "%");

                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("Confirma: [1] Sim - [2] Nao");
                        op = Console.ReadLine();
                        if (op == "1")
                        {
                            Servico servico = new Servico(i);
                            rodando = true;
                            while(rodando)
                            {
                                Console.Clear();
                                Console.WriteLine("[1] Cliente pessoa fisica");
                                Console.WriteLine("[2] Cliente pessoa juridica");
                                op = Console.ReadLine();
                                var achou = false;
                                Console.WriteLine("Digite o nome ou codigo de identificacao do cliente:");
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
                                    Console.WriteLine("Cliente nao encontrado!");
                                    Console.ReadKey();
                                    Console.Clear();
                                    break;
                                }
                                else
                                {
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
                        Console.Write("Digite uma opcao valida!");
                        Console.ReadKey();
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
                fatura.EmitirFatura(servicos);
                Console.WriteLine("Valor total: R$"+fatura.CalcutaTotal(servicos));
                Console.ReadKey();
                Console.Clear();
                break;
            }

            break;
    
    }
}