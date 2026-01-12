# SkyNetz - Simulador de Planos de Telefonia

Olá!

Neste projeto eu utilizei as seguintes tecnologias:

* **ASP.NET 4.6** com WebForms
* **Entity Framework** (utilizando Repository Pattern)
* **JavaScript**
* **PostgreSQL** (Banco na AWS via NeonDB)
* **Git** e **GitHub**

O site é composto por 4 telas:

* **Index:** Apresentação inicial do projeto.
* **Planos:** Apresenta uma listagem dos planos disponíveis e a seção para calcular o valor da ligação.
* **ContratarPlano:** Exibe o plano escolhido e um formulário para assiná-lo.
* **Sobre:** Página informativa sobre o sistema.

Na tela de Planos, onde se encontra a principal funcionalidade do projeto, temos um formulário para simular a ligação desejada:

* **Origem:** Selecione o DDD de origem.
* **Destino:** Selecione o DDD de destino.
* **Duração:** Digite a duração da ligação em minutos.
* **Plano:** Selecione o plano FaleMais que deseja simular.

Ao clicar no botão "Calcular", um pop-up exibirá as seguintes informações:

* A tarifa base por minuto entre os DDDs selecionados.
* Indicação se o plano selecionado é o ideal (o sistema sugere a melhor opção caso a duração se encaixe melhor em outro plano).
* O valor final **com** o plano FaleMais.
* O valor final **sem** o plano FaleMais.
* Botão para assinar o plano (redireciona para a tela de contratação com os detalhes).
