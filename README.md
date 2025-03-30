# 🌑Robô Tupiniquim🌑

![](https://revistapagu.com.br/wp-content/uploads/2013/08/tumblr_mqlvni3ZuV1roc8sco1_500.gif)

## Introdução

O Robô Tupiniquim é um programa de simulação que permite que o usuário controle dois robôs em um campo de pesquisa, movendo-os de acordo com os comandos fornecidos. O sistema valida as entradas, detecta colisões e fornece instruções claras para os funcionários da Agência Espacial Brasileira (AEB).

## Propriedades do programa

- **Definição de mapa**: O programa permite definir o tamanho do campo de pesquisa onde os robôs irão se mover. O tamanho do plano de simulação pode ser ajustado, oferecendo flexibilidade no ambiente.
<br> <br>
- **Validação de Entrada**: As entradas são verificadas para garantir que sejam válidas. Caso valores incorretos sejam inseridos, o sistema notificará o erro e solicitará uma nova entrada, garantindo a integridade da simulação.
<br> <br>
- **Colisão**: O sistema simula colisões entre os robôs caso ambos ocupem a mesma posição ao mesmo tempo. Caso isso aconteça, a colisão será detectada e o sistema notificará sobre o incidente.
<br> <br>
- **Avisos**: Caso um robô ultrapasse os limites da área de simulação ou colida com outro, o sistema notificará a ocorrência, garantindo o controle da simulação.
<br> <br>
- **Instruções**: O programa permite que o seja acessado as instruções a qualquer momento, através de uma opção no menu, facilitando a consulta durante a execução da simulação.
<br> <br>
- **Estruturada**: O código é estruturado de maneira modular, com funções e arquivos separados, assegurando maior organização, legibilidade e reutilização do código. Isso facilita a manutenção e a evolução do sistema.
<br> <br>
![](https://i.imgur.com/5CdRk37.gif)

## Tecnologias

[![Tecnologias](https://skillicons.dev/icons?i=git,github,visualstudio,cs,dotnet)](https://skillicons.dev)

## Como utilizar

1. Clone o repositório ou baixe o código fonte.
2. Abra o terminal ou o prompt de comando e navegue até a pasta raiz
3. Utilize o comando abaixo para restaurar as dependências do projeto.

```
dotnet restore
```

4. Em seguida, compile a solução utilizando o comando:
   
```
dotnet build --configuration Release
```

5. Para executar o projeto compilando em tempo real
   
```
dotnet run --project RoboTupiniquim.ConsoleApp
```

6. Para executar o arquivo compilado, navegue até a pasta `./RoboTupiniquim.ConsoleApp/bin/Release/net8.0/` e execute o arquivo:
   
```
RoboTupiniquim.ConsoleApp.exe
```

## Requisitos

- .NET SDK (recomendado .NET 8.0 ou superior) para compilação e execução do projeto.

# Venha fazer parte da AEB e ajude a transformar o futuro da tecnologia e inovação!
![](https://s2.glbimg.com/97FvnvQgQUnkbsPfDLBw7MQ83S4=/e.glbimg.com/og/ed/f/original/2016/05/06/wall-e.gif) 
