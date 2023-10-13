# Projeto Mobile:

## Objetivo:
- Criar uma aplicação mobile que cadastra treinos de academia baseado em quantidade de treinos semanais do usuário
-  As tecnologias usadas foram: Kotlin, C# e Mongo Db
-  Segue o padrão MVC: Model(Data), View(front-end) e Controller.
-  A api possuí o método POST para cadastrar uma lista de exercicios baseado no tipo de treino, um método GET para pegar todos os os treinos do usuário e outro método GET para pegar um treino específico, um método PUT para caso o usuário queira mudar algo no treino e um método DELETE se quiser deletar o treino.

## Arquitetura MVC:


Model (Modelo):

O modelo representa os dados e a lógica de negócios da aplicação.

1.Usuário: Representa os dados do usuário, como nome, idade, altura, peso, etc,

2.Plano de Treinamento): Define o plano de treinamento de um usuário, incluindo detalhes como a quantidade de treinos semanais, exercícios, séries, repetições, etc,

3.Exercício: Define informações sobre um exercício, como nome, descrição, grupo muscular alvo, etc.


View (Visão):

A visão é responsável por apresentar os dados ao usuário e receber entradas do usuário.

1.Telas de cadastro de usuário,

2.Telas de cadastro de treinos,

3.Telas de listagem de treinos.

4.Telas para exibir detalhes do plano de treinamento.



Controller (Controlador):

O controlador atua como um intermediário entre o modelo e a visão. Ele lida com a lógica de negócios e responde às interações do usuário.

1.Controladores de usuário para lidar com o cadastro e autenticação,

2.Controladores de treinamento para criar e gerenciar os planos de treinamento,

3.Controladores de exercício para adicionar, editar e excluir exercícios.



Banco de dados(MongoDB):

Vai ser interligado o MongoDB com o modelo do MVC. Será desenvolvido em C#.



## Equipe:
- Eric Dennis de Freitas Carvalho
- Erick Goldberg Bezerra
- João Francisco de Albuquerque Veiga Moraes
- Luiz Felipe Dias da Silva
- Rafael Josivaldo dos Santos
- Thomas Sousa Hinders    
