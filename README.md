# 📄 README do Projeto (Em Desenvolvimento) 🚧

Com base nos commits fornecidos, este é um resumo da estrutura atual do projeto.
## 💻 Visão Geral do Projeto

Este projeto é uma aplicação web desenvolvida utilizando o framework **ASP.NET Core MVC**. O objetivo principal é criar um sistema completo de gestão e exibição de produtos, seguindo as melhores práticas de arquitetura, como o padrão **Repository/Service**, para garantir a manutenibilidade e escalabilidade do código.

## ⚙️ Tecnologias Principais

*   **Linguagem:** C#
*   **Framework:** ASP.NET Core (versão 8.0.0, baseada nos commits)
*   **Padrão:** MVC (Model-View-Controller)
*   **Persistência:** Entity Framework Core (EF Core)
*   **Banco de Dados:** SQL Server
*   **Estilização:** Bootstrap

*   ## 🛠️ Status Atual e Funcionalidades Implementadas

A arquitetura do projeto está robusta e a funcionalidade CRUD (Criação, Leitura, Atualização e Exclusão) para a entidade **Produto** está em fase avançada.

### ✅ Camadas e Arquitetura

*   **Estrutura Inicial:** Configuração do projeto MVC, Web API (inicial) e instalação dos pacotes EF Core.
*   **Persistência:** `DataContext` configurado, `DbSets` registrados e migrações iniciais aplicadas (`migrations` e `database update`).
*   **Padrão Repository/Service:** Implementação da camada de serviço (`IProdutoInterface`, `ProdutoService`, `ICategoriaInterface`, `CategoriaService`) para isolar a lógica de negócios e acesso a dados.
*   **Injeção de Dependência (DI):** Serviços devidamente registrados no `Program.cs`.

### 📦 Funcionalidades de Produto/Categoria

| Funcionalidade | Status | Detalhes |
| :--- | :--- | :--- |
| **Listagem de Produtos** | ✅ Completa | Implementação do método `ListaProdutos()`, `ProdutoController.Index` e View `Index.cshtml` com estilos Bootstrap. |
| **Criação (Cadastro)** | ✅ Completa | Implementação do DTO (`ProdutoCriacaoDto`), validações, `[HttpGet]` e `[HttpPost]` no Controller, e método de persistência no Service. |
| **Upload de Imagem** | ✅ Completa | Lógica de `GeraCaminhoArquivo` no Service para salvar imagens de forma única no `wwwroot`, incluindo a correção do path de salvamento. |
| **Edição (Atualização)** | ✅ Completa | Implementação do DTO (`EditarProdutoDto`), métodos `[HttpGet]` e `[HttpPost]` e lógica de substituição de imagem antiga no Service. |
| **Listagem de Categorias** | ✅ Em Serviço | Implementação do `ICategoriaInterface` e `CategoriaService`. `BuscarCategorias()` disponível para uso em dropdowns (`ViewBag`). |

---

## 💡 Próximas Implementações (To Do)

As seguintes funcionalidades estão planejadas para o desenvolvimento futuro:

*   **🔒 Autenticação e Autorização:** Implementar o login de usuário (e possivelmente registro).
*   **🖼️ Experiência do Usuário:** Criar uma página com cards para cada produto para uma melhor visualização na interface do usuário (substituindo ou complementando a lista em tabela).
*   **🗑️ Exclusão de Produtos:** Implementar o método de excluir produtos (`[HttpGet]` e `[HttpPost]` para confirmação).
*   **🔍 Funcionalidade de Busca:** Adicionar método de buscar por nome ou categoria na tela de listagem de produtos.
