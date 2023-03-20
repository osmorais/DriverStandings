# DriverStandings
Aplicação utilizando Angular 15 com TypeScript no frontend, com .NET 6 no backend e um banco de dados postgreSQL.

# Descrição do projeto
- O que o aplicativo faz?
    O usuario faz o upload de um arquivo de log de uma corrida de Kart, a partir desse arquivo o sistema gera a classificação dos corredores.

- Sobre as tecnologias utilizadas
    FRONTEND: No frontend foi usado o Angular 15 juntamente com typescript, os componentes que foram criados foram: Race (Corridas geradas a partir do arquivo de log), Standings (Classificação da corrida selecionada, mostrando o nome, codigo, tempo e voltas completadas do pilo) e a Home que foi usada apenas para indexar a pagina caso fosse necessário alterar o funcionamento do frontend.
    BACKEND: No backend foi utilizado .NET 6, com conexão com o banco de dados PostgreSQL utilizando a classe NpgsqlConnection da biblioteca Npgsql. Foi adotada arquitetura em camadas, seguinda a ideia do DDD, dessa forma, a camada Api guarda as constrollers onde ficam os endpoints, da controller passamos para business (ou service) que fica na camada de application, responsavel por trabalhar os dados para conseguir retornar o que é desejado para esse processamento, na camada Domain, foi guardado nossas models, ou seja, as classes principais relacionadas as regras de negócio do objetivo do sistema, e na camada InfraData temos as classes que fazem consultas e alterações no banco de dados, nesse caso segui o padrão DAO (Data Access Object).

# Instalação e execução do projeto
- Instalação Frontend:
``` 
    Angular CLI: 15.2.4
    Node: 18.15.0
    Package Manager: npm 9.5.0
    OS: win32 x64

    download node v18.15
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

- Criando o banco de dados:
    Executar os comandos presentes no arquivo [DoNet6.DriverStandings/Database/setDatabase.sql](./DoNet6.DriverStandings/Database/setDatabase.sql) para criar o banco de dados e as tabelas;
    Executar as demais procedures dentro do diretorio [DoNet6.DriverStandings/Database](./DoNet6.DriverStandings/Database/);


- Executando o projeto:
     ```cd DriverStandings```
  -  Primeiramente executar o comando abaixo para inicializar uma nova instancia da DotNet6.DriverStandings.Api
     ```dotnet run -p .\Angular.DriverStandings\DotNet6.DriverStandings.Api\```
    > necessário estar dentro do diretorio \DriverStandings.

     ```cd Angular.DriverStandings\DriverStandings-App```
  -  Em seguida, para inicializar o frontend basta executar o comando abaixo:
     ```npm start```
     > necessário estar dentro do diretorio \Angular.DriverStandings\DriverStandings-App.

  -  O swagger da aplicação estará disponivel em:
     ```https://localhost:7098/swagger/index.html```
  
  -  O frontend da aplicação estará disponivel em:
     ```http://localhost:4200/home```

# Uso do projeto
    Ao acessar a primeira pagina do aplicativo, você terá uma lista das corridas ja cadastradas, com um botão de upload de um novo arquivo de log, para fazer o upload do log de uma nova corrida.
    O arquivo de log deverá ser um arquivo separado por ";", conforme o arquivo de exemplo abaixo:
    ```
    Hora;Piloto;Nº Volta;Tempo Volta;Velocidade média da volta 
    23:49:08.277;038 – F.MASSA;1;1:02.852;44,275 
    23:49:10.858;033 – R.BARRICHELLO;1;1:04.352;43,243 
    23:49:11.075;002 – K.RAIKKONEN;1;1:04.108;43,408 
    23:49:12.667;023 – M.WEBBER;1;1:04.414;43,202 
    23:49:30.976;015 – F.ALONSO;1;1:18.456;35,47 
    23:50:11.447;038 – F.MASSA;2;1:03.170;44,053 
    23:50:14.860;033 – R.BARRICHELLO;2;1:04.002;43,48 
    23:50:15.057;002 – K.RAIKKONEN;2;1:03.982;43,493 
    23:50:17.472;023 – M.WEBBER;2;1:04.805;42,941 
    23:50:37.987;015 – F.ALONSO;2;1:07.011;41,528 
    23:51:14.216;038 – F.MASSA;3;1:02.769;44,334 
    23:51:18.576;033 – R.BARRICHELLO;3;1:03.716;43,675 
    23:51:19.044;002 – K.RAIKKONEN;3;1:03.987;43,49 
    23:51:21.759;023 – M.WEBBER;3;1:04.287;43,287 
    23:51:46.691;015 – F.ALONSO;3;1:08.704;40,504 
    23:52:01.796;011 – S.VETTEL;1;3:31.315;13,169 
    23:52:17.003;038 – F.MASSA;4;1:02.787;44,321 
    23:52:22.586;033 – R.BARRICHELLO;4;1:04.010;43,474 
    23:52:22.120;002 – K.RAIKKONEN;4;1:03.076;44,118 
    23:52:25.975;023 – M.WEBBER;4;1:04.216;43,335 
    23:53:06.741;015 – F.ALONSO;4;1:20.050;34,763 
    23:53:39.660;011 – S.VETTEL;2;1:37.864;28,435 
    23:54:57.757;011 – S.VETTEL;3;1:18.097;35,633 
    ```

    Ao fazer o upload do arquivo de log, o sistema ira processar esse arquivo, agrupar as informações dos corredores e das voltas feitas, ordenar por ondem de chegada, e armazenar no banco.
    Sera criada uma nova corrida a partir do arquivo que foi carregado, dessa forma o usuario poderá clicar em "VER CLASSIFICAÇÃO" e será redirecionado para uma tela com a classificação dos pilotos desse corrida.