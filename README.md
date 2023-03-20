# DriverStandings
Aplicação utilizando Angular com TypeScript no frontend, com .NET 6 no backend e um banco de dados postgreSQL.

    Angular CLI: 15.2.4
    Node: 18.15.0
    Package Manager: npm 9.5.0
    OS: win32 x64
    Angular: 15.2.3
    
# Descrição do projeto
- O que o aplicativo faz?<br/><br/>
    O usuario faz o upload de um arquivo de log de uma corrida de Kart, a partir desse arquivo o sistema gera a classificação dos corredores.

- Sobre as tecnologias utilizadas<br/><br/>
    FRONTEND: No frontend foi usado o Angular 15 juntamente com typescript, os componentes que foram criados foram: Race (Corridas geradas a partir do arquivo de log), Standings (Classificação da corrida selecionada, mostrando o nome, codigo, tempo e voltas completadas do pilo) e a Home que foi usada apenas para indexar a pagina caso fosse necessário alterar o funcionamento do frontend.
    <br/><br/>
    BACKEND: No backend foi utilizado .NET 6, com conexão com o banco de dados PostgreSQL utilizando a classe NpgsqlConnection da biblioteca Npgsql. Foi adotada arquitetura em camadas, seguinda a ideia do DDD, dessa forma, a camada Api guarda as constrollers onde ficam os endpoints, da controller passamos para business (ou service) que fica na camada de application, responsavel por trabalhar os dados para conseguir retornar o que é desejado para esse processamento, na camada Domain, foi guardado nossas models, ou seja, as classes principais relacionadas as regras de negócio do objetivo do sistema, e na camada InfraData temos as classes que fazem consultas e alterações no banco de dados, nesse caso segui o padrão DAO (Data Access Object).

# Instalação e execução do projeto
- Instalação Frontend:
  - Realizar o download e instalação do node v18.15
``` 
    npm install -g @angular/cli
    npm install --save ngx-bootstrap 
    npm install bootstrap@4
    npm install --save ngx-loading
    npm install --save ngx-toastr 
```

- NuGet Package Manager:
```
    dotnet add package Npgsql --version 7.0.2
    dotnet add package xunit --version 2.4.2
    dotnet add package xunit.runner.visualstudio --version 2.4.5
    dotnet add package Swashbuckle.AspNetCore --version 6.2.3
```

- Criando o banco de dados:<br/>
    Executar os comandos presentes no arquivo [setDatabase.sql](./DoNet6.DriverStandings/Database/setDatabase.sql) para criar o banco de dados e as tabelas;<br/>
    Executar as demais procedures dentro do diretorio [/Database](./DoNet6.DriverStandings/Database/);


- Executando o projeto:<br/><br/>
     
  -  Primeiramente executar o comando abaixo para inicializar uma nova instancia da DotNet6.DriverStandings.Api<br/>
     > necessário estar dentro do diretorio \DriverStandings.<br/>
     ```cd DriverStandings```<br/>
     ```dotnet run -p .\Angular.DriverStandings\DotNet6.DriverStandings.Api\```<br/><br/>
   

  -  Em seguida, para inicializar o frontend basta executar o comando abaixo:<br/>
     > necessário estar dentro do diretorio \Angular.DriverStandings\DriverStandings-App.<br/>
     ```cd Angular.DriverStandings\DriverStandings-App```<br/>
     ```npm start```<br/><br/>

  -  O swagger da aplicação estará disponivel em:
     ```https://localhost:7098/swagger/index.html```
  
  -  O frontend da aplicação estará disponivel em:
     ```http://localhost:4200/home```

# Uso do projeto
  - Ao acessar a primeira pagina do aplicativo, você terá uma lista das corridas ja cadastradas, com um botão de upload de um novo arquivo de log, para fazer o upload do log de uma nova corrida.<br/>
  - O arquivo de log deverá ser um arquivo separado por ";", conforme o arquivo de exemplo [/RaceLogFile.txt](./RaceLogFile.txt)<br/>
  - Ao fazer o upload do arquivo de log, o sistema ira processar esse arquivo, agrupar as informações dos corredores e das voltas feitas, ordenar por ondem de chegada, e armazenar no banco.<br/>
  - Sera criada uma nova corrida a partir do arquivo que foi carregado, dessa forma o usuario poderá clicar em "VER CLASSIFICAÇÃO" e será redirecionado para uma tela com a classificação dos pilotos desse corrida.<br/>


