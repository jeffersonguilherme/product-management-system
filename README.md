# 📦 Gerenciamento de Produtos ASP.NET Core MVC

Este projeto é um sistema básico de **Gerenciamento de Produtos** desenvolvido em **ASP.NET Core MVC**. Ele permite o **Cadastro**, **Listagem** e **Edição** de produtos, incluindo a gestão de categorias e o upload de imagens para os produtos.

## 🚀 Tecnologias Utilizadas

* **ASP.NET Core MVC:** Estrutura principal da aplicação.
* **Entity Framework Core:** ORM utilizado para interagir com o banco de dados.
* **Padrão Repository/Service:** Separação das preocupações (lógica de negócios e acesso a dados).
* **Bootstrap/Razor:** Utilizados para o *front-end* (visto nos arquivos `.cshtml`).

## ⚙️ Estrutura do Projeto (Análise do Código)

O código está estruturado em diferentes componentes:

### 1. Camada de Controle (Controller)

O arquivo `ProdutoController.cs` (na *namespace* `Controllers`) gerencia as requisições HTTP relacionadas a produtos:

*   **Injeção de Dependência:** Utiliza injeção dos serviços `IProdutoInterface` e `ICategoriaInterface`.
*   **Listagem (`Index` - GET):** Retorna a *View* com a lista de produtos, buscando-os através de `ListaProdutos()`.
*   **Cadastro (GET e POST):**
    *   O método GET (`Cadastrar`) retorna a *View* de cadastro, carregando a lista de categorias para o `ViewBag`.
    *   O método POST (`Cadastrar` com `[HttpPost]`) recebe um `ProdutoCriacaoDto` e um `IFormFile` (foto), valida o modelo, cadastra o produto e redireciona para a listagem.
*   **Edição (GET e POST):**
    *   O método GET (`Editar`) busca o produto pelo `Id`, mapeia para um `EditarProdutoDto`, carrega as categorias para o `ViewBag` e retorna a *View*.
    *   O método POST (`Editar` com `[HttpPost]`) recebe o `EditarProdutoDto` e o `IFormFile` (foto opcional), valida o modelo, edita o produto (incluindo a exclusão da foto antiga, se uma nova for fornecida) e redireciona.

### 2. Camada de Serviços (Services)

Implementa a lógica de negócios e orquestra as operações de dados.

*   **`IProdutoInterface` e `ProdutoService.cs`:**
    *   `ListaProdutos()`: Retorna todos os produtos, incluindo a categoria associada (`.Include(c => c.Categoria)`).
    *   `Cadastrar()`: Cria um novo `ProdutoModel` a partir do DTO, salva a imagem no sistema de arquivos (`GeraCaminhoArquivo`), adiciona ao banco de dados e salva as mudanças.
    *   `Editar()`: Busca o produto, atualiza suas propriedades com base no DTO. Se uma nova foto for enviada, a foto antiga é excluída do sistema de arquivos e a nova é salva e associada ao produto.
    *   **Gestão de Imagens:** O método privado `GeraCaminhoArquivo` gera um nome de arquivo único, salva o arquivo no diretório `wwwroot/imagem` e retorna o nome do arquivo para ser armazenado no banco de dados.
*   **`ICategoriaInterface` e `CategoriaService.cs`:**
    *   `BuscarCategorias()`: Retorna uma lista de todas as categorias.

### 3. Camada de Dados (Data, DTOs e Models)

*   **`DataContext.cs` (Entity Framework Core):**
    *   Define o contexto do banco de dados com `DbSet` para `Produtos` e `Categorias`.
*   **Models:**
    *   `ProdutoModel`: Modelo de dados para produtos, com propriedades como `NomeProduto`, `Marca`, `Valor`, `QuantidadeEstoque`, `Foto` e `CategoriaId`. Inclui uma propriedade de navegação (`Categoria`).
    *   `CategoriaModel`: Modelo de dados simples para categorias.
*   **DTOs (Data Transfer Objects):**
    *   `ProdutoCriacaoDto`: Utilizado para o cadastro de novos produtos. Possui **DataAnnotations** para validação básica (`[Required]`).
    *   `EditarProdutoDto`: Herda de `ProdutoCriacaoDto` e adiciona a propriedade `Id` (necessária para a edição).

4. Views (Razor - Front-end)
Index.cshtml: Exibe a lista de produtos em uma tabela (incluindo a imagem e a categoria). Contém links para Cadastrar e Editar.

Cadastrar.cshtml: Formulário para criar um novo produto. Utiliza Tag Helpers do ASP.NET Core e um dropdown para selecionar a categoria (alimentado pelo ViewBag.Categorias). Permite o upload de arquivo (enctype="multipart/form-data").

Editar.cshtml: Formulário para editar um produto existente. Carrega os dados atuais do produto e permite atualizar os campos, incluindo a substituição da foto.

🔑 Configuração e Uso
Configuração do Banco de Dados: É necessário configurar a connection string no appsettings.json e garantir que o DataContext esteja registrado no container de serviços (geralmente em Program.cs).

Migrações: Execute as migrações do Entity Framework Core para criar o schema do banco de dados.

Registro de Serviços: Os serviços (ProdutoService e CategoriaService) e suas interfaces devem ser registrados no container de serviços (Program.cs).

Estrutura de Arquivos: Certifique-se de que a aplicação tenha acesso a um diretório wwwroot para o salvamento de imagens. O ProdutoService salva as imagens no subdiretório wwwroot/imagem.

📌 Próximos Passos Sugeridos
Implementar a funcionalidade de Remoção de produtos (método Remove na Index.cshtml e lógica no Controller e Service).

Implementar a funcionalidade de CRUD para Categorias.

Adicionar validações de front-end e tratamento de erros mais robusto nas operações de serviço.

Melhorar a gestão de imagens, talvez utilizando um serviço de storage em produção.

<img width="1226" height="912" alt="image" src="https://github.com/user-attachments/assets/e6229ae8-c2be-4f3b-8ecf-5781850fe197" />

