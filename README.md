# Dojô .net 7
Projeto criado em dojô utilizando .net 7 com Visual Studio Community.


## Como preparar o ambiente para rodar o projeto
1 - Instalar o docker no sistema operacional (https://www.docker.com/)

2 - Instalar o docker-compose (https://docs.docker.com/compose/)

3 - Instalar o Visual Studio Community (https://visualstudio.microsoft.com/pt-br/vs/community/)

5 - Instalar o SDK do .net 7 (https://dotnet.microsoft.com/en-us/download/dotnet/7.0)

6 - Instalar o Postman para testar e brincar com os dados da api (https://www.postman.com/downloads/)


Após a instalação de todos os requisitos, vamos rodar o docker com a image do banco de dados MongoDB pra armazenar os nossos dados. Pra isso, vamos utilizar a configuração à seguir:
  - criar um arquivo chamado docker-compose.yml e salvar dentro dele o conteúdo à seguir
```
version: '3.1'

services:

  mongo:
    image: mongo
    restart: always
    ports:
      - 27017:27017
    environment:
      MONGO_INITDB_ROOT_USERNAME: root
      MONGO_INITDB_ROOT_PASSWORD: root

  mongo-express:
    image: mongo-express
    restart: always
    ports:
      - 8081:8081
    environment:
      ME_CONFIG_MONGODB_ADMINUSERNAME: root
      ME_CONFIG_MONGODB_ADMINPASSWORD: root
      ME_CONFIG_MONGODB_URL: mongodb://root:root@mongo:27017/
```
  - na mesma pasta onde o arquivo foi criado, rodar o comando `docker-compose up -d` para criar os contêineres do MongoDB e MongoExpress para rodar a parte de armazenamento de dados
  - o banco de dados ficará acessível utilizando a string de conexão que está salva no arquivo `appsettings.json` do projeto
  - para visualizar os dados do banco no navegador pode ser utilizado o acesso do Express disponibilizado na porta `8081` do `localhost`


Pronto, agora você já tem o banco de dados disponibilizado na porta 27017 e pode rodar a api para manipular os seus dados.

## Executando a API
Para rodar a api, basta abrir o arquivo `DojoDaGalera.sln` com o Visual Studio e executar no ![image](https://github.com/luishti/dojo-dotnet-beachycode/assets/2211110/69e72bc7-2cbc-4542-b5b8-dc4f6e2c0892)

## Manipulando os dados
Para manipular os dados na api vamos utilizar o Postman, você pode utilizar os seguintes endpoints com os métodos e dados à seguir:
- #### $\textcolor{#F7DC6F}{\textsf{POST}}$ (criar dojo):
    `https://localhost:5001/dojo`
    ```
    {
      "titulo": "Dojo Javascript",
      "descricao": "Dojo de Javascript na ulbra com a galera"
    }
    ```
- #### $\textcolor{#58D68D}{\textsf{GET}}$ (ler dojos):
    `https://localhost:5001/dojo`
- #### $\textcolor{#58D68D}{\textsf{GET}}$ (ler um dojo):
    `https://localhost:5001/dojo/{ID_DE_ALGUM_OBJETO_DO_BANCO}`
- #### $\textcolor{#5DADE2}{\textsf{PUT}}$ (atualizar um dojo):
    `https://localhost:5001/dojo/{ID_DE_ALGUM_OBJETO_DO_BANCO}`
    ```
      {
        "titulo": "Dojo JS",
        "descricao": "Dojo de JS na ulbra com a galera massa demais"
      }
    ```
- #### $\textcolor{#EC7063}{\textsf{DELETE}}$ (remover um dojo): 
    `https://localhost:5001/dojo/{ID_DE_ALGUM_OBJETO_DO_BANCO}`

