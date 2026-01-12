Olá!

Neste projeto eu utilizei as seguintes tecnologias:

. ASP.NET 4.6 com WebForms
. Entity Framework com Repository Pattern
. Javascript
. PostgreSQL - Banco na AWS - hospedado no site NeonDB
. Git e GitHub


O Site tem 4 telas, sendo elas:

. Index: Apresentação inicial do projeto
. Planos: Apresenta uma listagem dos planos e a aba de calcular o valor da ligação
. ContratarPlano: Apresenta o plano escolhido e um formulário para assiná-lo
. Sobre: Página informativa.

Na tela de Planos, onde se encontra a principal funcionalidade do projeto, temos um formulário simples com os campos para simular a ligação que você quer calcular:

. Origem: Selecione a origem da ligação
. Destino:  Selecione o destino da ligação
. Duração: Digite a duração da ligação
. Plano: Selecione o plano que você quer simular

Clicando no botão "Calcular", você verá um pop-up que contará com as informações:

. Tarifa base por minuto entre os DDD's selecionados
. Indicação se o plano selecionado é o ideal para a sua ligação (caso você escolha uma duração que se encaixe melhor em outro plano, o sistema irá te indicar)
. Valor com o plano FaleMais
. Valor sem o plano FaleMais
. Botão para assinar o plano (irá te levar para uma tela com mais detalhes do plano)


Leonardo Dias dos Santos
