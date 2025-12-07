📄 README do Projeto (Em Desenvolvimento) 🚧
💻 Visão Geral do Projeto

Este projeto é uma aplicação web desenvolvida utilizando o framework ASP.NET Core MVC.
O objetivo principal é criar um sistema completo de gestão e exibição de produtos, seguindo boas práticas de arquitetura como o padrão Repository/Service, garantindo manutenibilidade, organização e escalabilidade.

⚙️ Tecnologias Principais

Linguagem: C#

Framework: ASP.NET Core 8.0

Padrão Arquitetural: MVC (Model-View-Controller)

Persistência: Entity Framework Core (EF Core)

Banco de Dados: SQL Server

Estilização: Bootstrap

🛠️ Status Atual e Funcionalidades Implementadas

A arquitetura do projeto está bem estruturada e a funcionalidade CRUD para a entidade Produto está em fase avançada.

✅ Camadas e Arquitetura

Estrutura Inicial

Configuração do projeto MVC

Web API (estrutura inicial)

Instalação e configuração dos pacotes EF Core

Persistência

DataContext configurado

DbSet das entidades registrados

Migrações criadas e aplicadas (migrations + database update)

Padrão Repository/Service

Implementação da camada de serviço:

IProdutoInterface, ProdutoService

ICategoriaInterface, CategoriaService

Lógica de negócios isolada da camada de apresentação

Injeção de Dependência (DI)

Interfaces e serviços devidamente registrados no Program.cs

📦 Funcionalidades de Produto e Categoria
Funcionalidade	Status	Detalhes
Listagem de Produtos	✅ Completa	Método ListaProdutos(), ProdutoController.Index, View Index.cshtml utilizando Bootstrap
Criação (Cadastro)	✅ Completa	DTO ProdutoCriacaoDto, validações, métodos [HttpGet] e [HttpPost], persistência no Service
Upload de Imagem	✅ Completa	Lógica GeraCaminhoArquivo salva imagens no wwwroot com nomes únicos
Edição (Atualização)	✅ Completa	DTO EditarProdutoDto, métodos [HttpGet] e [HttpPost], substituição da imagem antiga
Listagem de Categorias	⚠️ Em Serviço	ICategoriaInterface e CategoriaService implementados; BuscarCategorias() disponível para dropdowns
💡 Próximas Implementações (To Do)

🔒 Autenticação e Autorização
Implementar login de usuário e, futuramente, sistema de registro.

🖼️ Melhoria de UI/UX
Criar página com cards de produtos para uma visualização mais moderna e agradável.

🗑️ Exclusão de Produtos
Implementar remoção com confirmação: métodos [HttpGet] e [HttpPost].

🔍 Funcionalidade de Busca
Filtro de produtos por nome e/ou categoria na tela de listagem.

📂 Estrutura Geral do Projeto (Simplificada)
Projeto/
│── Controllers/
│   ├── ProdutoController.cs
│   └── CategoriaController.cs
│
│── Data/
│   └── DataContext.cs
│
│── Models/
│   ├── Produto.cs
│   └── Categoria.cs
│
│── Services/
│   ├── Interfaces/
│   │   ├── IProdutoInterface.cs
│   │   └── ICategoriaInterface.cs
│   ├── ProdutoService.cs
│   └── CategoriaService.cs
│
│── Views/
│   ├── Produto/
│   └── Categoria/
│
│── wwwroot/
│   └── imagens/
│
└── Program.cs

📌 Observação

Este projeto ainda está em desenvolvimento e novas funcionalidades serão adicionadas conforme os commits forem evoluindo.
