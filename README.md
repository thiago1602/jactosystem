# jactosystem
Sistema de agendamentos

# AgroLa

#### :book: Resumo:

Esse sistema foi desenvolvido para que técnicos agricolas possam cadastrar visitas e acompanha-las em tempo real. Com o intuito de tornar a experiência de um tecnico agrícola mais simplificada e acessível cadastro de agendamentos em fazendas, se tornando o portal de contato entre a AgroLab e esses agricultores.


#### :rocket: Versão (DEV 2.0): 

A API foi totalmente desenvolvida em [Javasript e Jquery](https://www.javascript.com/,https://api.jquery.com/). Responsável por realizar toda a requisição dos dados entre a Aplicação (AspNet) 
e o Via Cep (https://viacep.com.br/).


##### Versão:

  - Inclusão/Remoção/Edição de agendamentos;
  - Validações de datas;
- Criação das rotas de manutenção dos produtos;
  - Busca dos produtos;
  - Criar novo agendamento;
  - Atualização de agendamento;
- Rota de agendamentos contendo dados dos agendamentos concluidos e não concluidos;


#### :runner: Running:

Passos para rodar localmente o projeto:

- Clonar este repositório dentro de uma pasta;


- Instalar o Visual Studio 2022;
  - [Link de download](https://visualstudio.microsoft.com/pt-br/downloads/)
-DotNet 6
  -https://dotnet.microsoft.com/pt-br/download/dotnet/6.0
-Banco de Dados Relacional (Mysql, Pgsql)
  -Configurar as variáveis de conexão no arquivo Program.cs
-Criar uma tabela com o nome Agenda no Banco escolhido
  -em seguida executar o comando add-migrate "Nome da migrate"
  -dotnet run para rodar o projeto localmente

