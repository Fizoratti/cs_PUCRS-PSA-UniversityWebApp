<h3 align="center">
  <img src="https://img.shields.io/badge/platform-windows-blue" />
  <img src="https://img.shields.io/badge/.NET-5.0.303-blue" />
  <a href="https://gitpod.io/#https://github.com/Fizoratti/cs_PUCRS-PSA-UniversityWebApp">
    <img src="https://img.shields.io/badge/Gitpod-ready--to--code-blue?logo=gitpod" />
  </a>
  <p></p>
  <p align="center">PUCRS - Escola Politécnica - 2021/1</p>
  <p align="center">Disciplina: Programação de Software Aplicado</p>
  <p align="center">Prof. Alexandre Agustini</p>
</h3>

# Getting Started

UniversityWebApp é um projeto baseado no App _ContosoUniverity_ criado neste [tutorial da Microsoft](https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/intro?view=aspnetcore-5.0). Existem outras dependências como **NuGet** e **Entity Framework** que precisam estar instaladas no computador pra executar este App. Porém, este tutorial não possui instruções de como instalá-las. Você encontrará essas intruções no tutorial da Microsoft citado acima.

# Table of Contents

1. [Pré Requisitos](#pré-requisitos)
2. [Backend](#backend)
   - [Entidades](#)
   - [Persistencia](#)
3. [Frontend](#frontend)
   - [UniversityWebApp](#)
4. [Database](#database)
   - [UniversityDB](#)
     - [Instalando o SQL Express](#)

# Pré Requisitos

### Software

1. [**Git**](https://git-scm.com/downloads)

2. [**SQL Server Express**](https://go.microsoft.com/fwlink/?LinkID=866658)

3. [**.NET 5.0 SDK**](https://dotnet.microsoft.com/download/dotnet/5.0)

4. [**Visual Studio Code**](https://code.visualstudio.com/download)

Required Extensions:

- [x] [vscode-solution-explorer](https://marketplace.visualstudio.com/items?itemName=fernandoescolar.vscode-solution-explorer)

- [x] [C#](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)

- [x] [SQL Server (mssql)](https://marketplace.visualstudio.com/items?itemName=ms-mssql.mssql)

Recommended extensions:

- [ ] [Bracket Pair Colorizer](https://marketplace.visualstudio.com/items?itemName=CoenraadS.bracket-pair-colorizer)

- [ ] [Prettier - Code Formatter](https://marketplace.visualstudio.com/items?itemName=esbenp.prettier-vscode)

- [ ] [C# Extensions](https://marketplace.visualstudio.com/items?itemName=jchannon.csharpextensions)

---

#### Instruções para executar o App no VSCode

Os comandos abaixo devem ser executados no PowerShell do Windows.

### Clone

```powershell
    git clone https://github.com/Fizoratti/cs_PUCRS-PSA-UniversityWebApp.git
    cd .\cs_PUCRS-PSA-UniversityWebApp # Current path should be ~\cs_PUCRS-PSA-UniversityWebApp
    code .
```

### Dependencies

#### NuGet

```Powershell
    # Vem instalado junto quando instala o SDK do .NET
```

#### Entity Framework

How to Install Entity Framework tutorial in 5 minutes at [this link](https://docs.microsoft.com/pt-br/ef/core/get-started/overview/install). Entity Framework overview tutorial in 5 minutes at [this link](https://docs.microsoft.com/pt-br/ef/core/).

```Powershell
    dotnet tool install --global dotnet-ef
    # dotnet tool update --global dotnet-ef  (Caso já tenha dotnet-ef instalado e queira atualizar a versão)
```

# Backend

###### Current path should be ~\cs_PUCRS-PSA-UniversityWebApp

## 1) Entidades

```Powershell
    cd .\Entidades # Current path should be ~\cs_PUCRS-PSA-UniversityWebApp\Entidades
```

**Instalar dependencias:**

##### [Microsoft.AspNetCore.Identity.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore/)

```Powershell
    dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 5.0.11
```

**Verificar dependencias:** verifica se todas as dependencias do projeto foram instaladas:

```Powershell
    dotnet restore
```

**Recompilar o projeto:** neste momento sabemos se existe algum erro de compilação no código do projeto Entidades.

```Powershell
    dotnet build
```

## 2) Persistencia

```Powershell
    cd .\Persistencia # Current path should be ~\cs_PUCRS-PSA-UniversityWebApp\Persistencia
```

**Instalar dependencias:**

##### [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer)

```Powershell
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.11
```

##### [Microsoft.EntityFrameworkCore.Design](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Design)

```Powershell
    dotnet add package Microsoft.EntityFrameworkCore.Design --version 5.0.11
```

##### []()

```Powershell
    # Precisamos confirmar quais são as dependencias necessárias pra este projeto além das acima
```

**Verificar dependencias:** verifica se todas as dependencias do projeto foram instaladas:

```Powershell
    dotnet restore
```

**Recompilar o projeto:** neste momento sabemos se existe algum erro de compilação no código do projeto Persistencia (backend).

```Powershell
    dotnet build
```

### Migrations

##### Add new migration

Você pode excluir a pasta `Persistencia\Migrations` antes de rodar o comando abaixo. **`PeixeEspada` é um nome para a migration. Este nome só pode ser usado uma vez. Quando for executar uma nova migration (executar o comando mais de uma vez) escolha outro nome de peixe.**

```Powershell
    dotnet ef migrations add PeixeEspada --no-build --startup-project .\Persistencia.csproj
```

##### Update database

Usamos este comando quando os arquivos em `Entidades\Models` forem alterados. Para que a alteração nesses arquivos tenham efeito, é necessário realizar uma nova migration (para atualizar os arquivos no projeto Persistência)

```Powershell
    dotnet ef database update --no-build --startup-project .\Persistencia.csproj
```

##### Drop database

Este comando só é necessário caso já exista um banco de dados.

```Powershell
    dotnet ef database drop -f --no-build --startup-project .\Persistencia.csproj
```

# Frontend

###### Current path should be ~\cs_PUCRS-PSA-UniversityWebApp

## 3) UniversityWebApp

```Powershell
    cd .\UniversityWebApp # Current path should be ~\cs_PUCRS-PSA-UniversityWebApp\UniversityWebApp
```

**Instalar dependencias:**

##### [Microsoft.VisualStudio.Web.CodeGeneration.Design](https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design/)

```Powershell
    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 5.0.2
```

##### []()

```Powershell
    # Precisamos confirmar quais são as dependencias necessárias pra este projeto além das acima
```

**Verificar dependencias:** verifica se todas as dependencias do projeto foram instaladas:

```Powershell
    dotnet restore
```

**Recompilar o projeto:** neste momento sabemos se existe algum erro de compilação no código do projeto UniversityWebApp (frontend).

```Powershell
    dotnet build
```

**Confie no certificado de desenvolvimento HTTPS:** Só precisa ser executado uma vez no computador.

```Powershell
    dotnet dev-certs https --trust
```

**Rodar a aplicação:** este mesmo comando vai executar o backend **e** o frontend.

```Powershell
    dotnet watch run
```

O navegador deve ser aberto na URL https://localhost:5001/ (talvez seja necessário abrir em https://localhost:5001/Home/index/).

Registrar um novo usuário (exemplo: `user@email.com`, `123456`).

# Database

**Nome da máquina:** é possivel descobrir o `hostname` (nome da máquina) usando o comando abaixo:

```Powershell
    hostname
```

**Instancia do banco:** one instance can contain multiple databases.

**String de conexão:** é composta pelo nome da máquina seguido pelo nome da instância do banco. Se encontra no arquivo `appsettings.json` no projeto Persistencia.

Exemplo:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=W10781D0B3\\SQLEXPRESS;Database=UniversityDB;Trusted_Connection=True;MultipleActiveResultSets=true",
    ...
}

```

Nesse exemplo, hostname é _W10781D0B3_ e a instancia do banco é _SQLEXPRESS_.

### Instalando o SQL Express 2019

É importante possuir o SQL Express para a string de conexão funcionar. Também será necessário alterar a string para ela conter o “hostname”.

1. Baixe a versão **developer** e instale o **BASIC**. Se você já tem instalado pesquise no Windows por _“SQL Server 2019 Installation Center”_.
   Obs.: não é o SQL Server Management.

2. Abra o programa e vá na aba “Installation”, depois na opção “New SQL Server stand-alone...”

3. Caso peça um nome, coloque SQLEXPRESS.

4. Na janela que abriu, procure onde está instalado seu SQL2019 e clique em “OK”, conforme imagem abaixo:

![sqlexpressinstallimg1](https://gcdn.pbrd.co/images/9EXuDyQ4lCLX.png?o=1)

5. Siga as instruções clicando em “Next” até a opção “Feature Selection”. Aqui é um ponto importante. As opções “Database Engine Services” e “Full-Text and Semantic Extractions for Search” devem estar marcadas. Depois prossiga com a instalação, conforme imagem abaixo:

![sqlexpressinstallimg2](https://gcdn.pbrd.co/images/kblViCjsY3VS.png?o=1)

## 4. UniversityDB

##### Executar script SQL que adiciona uma matricula ao novo usuário criado.

```sql
update AspNetUsers set Matricula=15111090, Nome='User' where ApplicationUserID=0;
```

##### Executar script SQL que adiciona dados de histórico ao novo usuário.

```sql
insert into Historico (Nota, Semestre, Codcred, nomeDisciplina, Matricula)
    values (7.0, '2021-1', '4653B-04', 'Programação de Software Aplicado', 15111090);
insert into Historico (Nota, Semestre, Codcred, nomeDisciplina, Matricula)
    values (7.0, '2020-2', '4351B-04', 'Fundamentos de Programação', 15111090);
insert into Historico (Nota, Semestre, Codcred, nomeDisciplina, Matricula)
    values (7.0, '2020-1', '4636D-04', 'Sistemas Operacionais', 15111090);
insert into Historico (Nota, Semestre, Codcred, nomeDisciplina, Matricula)
    values (7.0, '2021-1', '4650A-02', 'Fundamentos de Banco de Dados', 15111091);
```

##### Executar script SQL que adiciona turmas.

```sql
insert into Turma (Codcred, Horario, Numero)
    values ('4653B-04', '2LM4LM', '168',);
```

## NuGet Packages

##### [Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore)

```Powershell
    dotnet add package Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore --version 5.0.11
```

##### [Microsoft.AspNetCore.Identity.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.EntityFrameworkCore/)

```Powershell
    dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore --version 5.0.11
```

##### [Microsoft.AspNetCore.Identity.UI ](https://www.nuget.org/packages/Microsoft.AspNetCore.Identity.UI/)

```Powershell
    dotnet add package Microsoft.AspNetCore.Identity.UI --version 5.0.11
```

##### [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer)

```Powershell
    dotnet add package Microsoft.EntityFrameworkCore.SqlServer --version 5.0.11
```

##### [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools/)

```Powershell
    dotnet add package Microsoft.EntityFrameworkCore.Tools --version 5.0.11
```

##### [Microsoft.VisualStudio.Web.CodeGeneration.Design](https://www.nuget.org/packages/Microsoft.VisualStudio.Web.CodeGeneration.Design/)

```Powershell
    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design --version 5.0.2
```

.csproj referência

```xml
<ItemGroup>
    <PackageReference Include="Microsoft.AspNetCore.Diagnostics.EntityFrameworkCore" Version="5.0.10" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.EntityFrameworkCore" Version="5.0.10" />
    <PackageReference Include="Microsoft.AspNetCore.Identity.UI" Version="5.0.10" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.SqlServer" Version="5.0.11" />
    <PackageReference Include="Microsoft.EntityFrameworkCore.Tools" Version="5.0.11">
      <PrivateAssets>all</PrivateAssets>
      <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    </PackageReference>
    <PackageReference Include="Microsoft.VisualStudio.Web.CodeGeneration.Design" Version="5.0.2" />
</ItemGroup>
```

---

Instruções para executar o App no Visual Studio

# Visual Studio

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

