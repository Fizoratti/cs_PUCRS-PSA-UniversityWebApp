# Getting Started

UniversityWebApp é um projeto baseado no App _ContosoUniverity_ criado neste [tutorial da Microsoft](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-5.0). Existem outras dependências como **NuGet** e **Entity Framework** que precisam estar instaladas no computador pra executar este App. Porém, este tutorial não possui instruções de como instalá-las. Você encontrará essas intruções no tutorial da Microsoft citado acima.

Required software:

1. [Visual Studio Code]()

2. [.NET 5.0 SDK](https://dotnet.microsoft.com/download/dotnet/5.0)

3. [SQL Server Express](https://go.microsoft.com/fwlink/?LinkID=866658)

Dependencies: NuGet, [Entity Framework](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore/6.0.0-rc.2.21480.5),

## Visual Studio Code

#### VSCode Extensions

Required Extensions:

1. [vscode-solution-explorer](https://marketplace.visualstudio.com/items?itemName=fernandoescolar.vscode-solution-explorer)

2. [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)

3. [SQL Server (mssql)](https://marketplace.visualstudio.com/items?itemName=ms-mssql.mssql)

Recommended extensions:

- [C# Extensions](https://marketplace.visualstudio.com/items?itemName=jchannon.csharpextensions)

- [Bracket Pair Colorizer](https://marketplace.visualstudio.com/items?itemName=CoenraadS.bracket-pair-colorizer)

- [Prettier - Code Formatter](https://marketplace.visualstudio.com/items?itemName=esbenp.prettier-vscode)

---

#### Instruções para executar o App no VSCode

Os comandos abaixo devem ser executados no PowerShell do Windows.

### Backend

```Powershell
    cd .\persistencia
```

###### Current path should be '~\UniversityWebApp\Persistencia

Verifica as dependencias do projeto

```Powershell
    dotnet restore
```

##### Recompilar o projeto

Neste momento sabemos se existe algum erro de compilação no código do projeto Persistencia (backend).

```Powershell
    dotnet build
```

##### Drop database

Este comando só é necessário caso já exista um banco de dados.

```Powershell
    dotnet ef database drop -f --no-build --startup-project .\Persistencia.csproj
```

##### Add new migration

Você pode excluir a pasta 'Migrations' em '~\UniversityWebApp\Persistencia' antes de rodar o comando abaixo. **Alterar `<nomeDaMigration>` para o nome de um peixe, por exemplo `PeixeEspada`.**

```Powershell
    dotnet ef migrations add <nomeDaMigration> --no-build --startup-project .\Persistencia.csproj
```

##### Update database

Não sei quando se faz necessário usar este comando.

```Powershell
    dotnet ef database update --no-build --startup-project .\Persistencia.csproj
```

```Powershell
    cd ..
```

###### Current path should be '~\UniversityWebApp

### Frontend

```Powershell
    cd .\UniversityWebApp
```

###### Current path should be '~\UniversityWebApp\UniversityWebApp

Verifica as dependencias do projeto

```Powershell
    dotnet restore
```

##### Recompilar o projeto

Neste momento sabemos se existe algum erro de compilação no código do projeto UniversityWebApp (frontend).

```Powershell
    dotnet build
```

##### Confie no certificado de desenvolvimento HTTPS

Só precisa ser executado uma vez no computador.

```Powershell
    dotnet dev-certs https --trust
```

##### Rodar a aplicação

Este mesmo comando vai executar o backend **e** o frontend.

```Powershell
    dotnet watch run
```

O navegador deve ser aberto na URL https://localhost:5001/ (talvez seja necessário abrir em https://localhost:5001/Home/index/).

Registrar um novo usuário (`user@email.com`, `123456`).

Executar script SQL que adiciona uma matricula ao novo usuário criado.

```sql
update AspNetUsers set Matricula=15111090, Nome='User' where ApplicationUserID=0;
```

Executar script SQL que adiciona dados de histórico ao novo usuário.

```sql
insert into Historico (Nota, Semestre, Matricula) values (7.0, '2021-1', 15111090);
insert into Historico (Nota, Semestre, Matricula) values (7.0, '2020-2', 15111090);
insert into Historico (Nota, Semestre, Matricula) values (7.0, '2020-1', 15111090);
insert into Historico (Nota, Semestre, Matricula) values (7.0, '2021-1', 15111091);
```

---

#### Instruções para executar o App no Visual Studio

## Visual Studio

- Menu Compilação>Recompilar Solução

- Apagar pasta 'Migrations' no projeto 'Persistencia'

- Excluir BD

- Abrir o Console do Gerenciador de Pacotes NuGet

- Selecionar 'Persistencia' no Projeto padrão

- Add-Migration PeixeEspada -context SchoolContext

- Update-Database -Context SchoolContext

- Rodar a aplicação

- Registrar novo usuário

- Executar script SQL que adiciona matriculas

- Executar script SQL que adiciona uma matrícula ao usuário logado/registrado/autenticado
