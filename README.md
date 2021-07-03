# Estudos Sobre AWS SQS 

Este projeto foi feito com o intuito de servir como base para implementação de Simple Queue Service da AWS.
Construído após estudos de artigos do assunto. 

Funções implementadas: 
* Leitura (GET)
* Escrita (POST) 
* Remoção (DELETE)


# Configurações iniciais

Antes de executar o projeto deve ser feito as seguintes configurações abaixo: 
* Variável de ambiente 'QUEUEURL', com a URL de acesso a fila, no arquivo base lauchSettings.json. 
* Arquivo appsettings.json deve conter um bloco no seguinte formato: 
```
 "AWS": {
    "Profile": "NAME_PROFILE",
    "Region": "XXXXX"
  }
```
Essa configuração serve para que a aplicação saiba quais credenciais de acesso
serão usadas para acesso, o que significa que o acesso já deve ter sido configurado
por meio do aws cli.
Utilizando o comando 
```
aws configure --profile 'NAME_PROFILE'
```

