# DevFreela

## Descrição
O **DevFreela** é uma API REST projetada para facilitar a gestão de projetos, conectando clientes e freelancers de forma simples e eficiente. A plataforma permite a criação, gerenciamento e finalização de projetos.

## Tecnologias Utilizadas
O projeto foi desenvolvido utilizando as seguintes tecnologias, frameworks e padrões arquiteturais:

- 🔹 **C#**
- 🔹 **ASP.NET Core**
- 🔹 **Entity Framework Core**
- 🔹 **SQL Server**
- 🔹 **Clean Architecture**
- 🔹 **CQRS (Command Query Responsibility Segregation)**
- 🔹 **MediatR**
- 🔹 **xUnit** (para testes unitários)

## Estrutura do Projeto
O projeto segue os princípios da **Clean Architecture**, garantindo separação de responsabilidades e modularidade. A estrutura é composta pelos seguintes componentes:

- **Application**: Contém os casos de uso e regras de negócio utilizando o padrão CQRS e MediatR.
- **Domain**: Define as entidades e regras de domínio.
- **Infrastructure**: Responsável pelo acesso a dados via Entity Framework Core e outras dependências externas.
- **API**: Exposição dos endpoints da aplicação.

## Como Executar o Projeto

1. Clone o repositório:
   ```sh
   git clone https://github.com/seu-usuario/devfreela.git
   ```
2. Navegue até a pasta do projeto:
   ```sh
   cd devfreela
   ```
3. Configure a string de conexão no **appsettings.json**:
   ```json
   "ConnectionStrings": {
     "DefaultConnection": "Server=SEU_SERVIDOR;Database=DevFreelaDB;User Id=SEU_USUARIO;Password=SUA_SENHA;"
   }
   ```
4. Execute as migrações do banco de dados:
   ```sh
   dotnet ef database update
   ```
5. Inicie a API:
   ```sh
   dotnet run
   ```
6. Acesse a documentação via Swagger em:
   ```
   http://localhost:5000/swagger
   ```

## Testes
O projeto inclui testes automatizados utilizando **xUnit**. Para rodar os testes, utilize o seguinte comando:
```sh
   dotnet test
```



