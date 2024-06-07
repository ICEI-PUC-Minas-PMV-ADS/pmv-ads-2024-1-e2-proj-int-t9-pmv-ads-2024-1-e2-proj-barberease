# Instruções de utilização

## Instalação do Site

O site em HTML/CSS/JS é um projeto estático, logo pode ser utilizado tanto em servidores quanto localmente.

A api é feita em C#, em .NET 8, necessário ambos instalados no computador para rodar localmente.


## Histórico de versões

### [0.4.4] - 07/06/2024

#### Adição da entidade de horário de funcionamento

- Criação da entidade para horário de funcionamento no backend
- Criação de migração para a entidade horário de funcionamento dos estabelecimentos no backend
- Implementada EstablishmentPeriod CRUD e rotas no backend


### [0.3.4] - 06/06/2024

#### Adição da entidade de serviço e agendamentos

- Criação da entidade para os serviços dos estabelecimentos no backend
- Criação da entidade para os agendamentos no backend
- Criação de migração para a entidade serviço dos estabelecimentos no backend
- Criação de migração para a entidade agendamento no backend
- Ajustes no frontend e deploy do mesmo: https://icei-puc-minas-pmv-ads.github.io/pmv-ads-2024-1-e2-proj-int-t9-pmv-ads-2024-1-e2-proj-barberease/
- Implementada EstablishmentService CRUD e rotas no backend
- Implementada Appointment CRUD e rotas no backend
- Atualização da documentação


### [0.2.3] - 09/05/2024

#### Adição da entidade de estabelecimento

- Criação da entidade para o estabelecimento no backend
- Criação de migração para a entidade de estabelecimento no backend
- Refatoração na lógica de login para incluir estabelecimento
- Implementada Establishment CRUD e rotas no backend


### [0.1.2] - 08/05/2024

#### Integração com frontend (página de login)

- Implementada Client CRUD e rotas no backend
- Implementa rota de login no backend
- Faz integração com rota de login no frontend ao logar como cliente


### [0.1.1] - 07/05/2024

#### Adição de estrutura backend

- Implementada estrutura inicial do backend usando C# com .NET 8
- Adiciona páginas de login e cadastro


### [0.1.0] - 06/05/2024

#### Estrutura inicial Front-End

- Implementada estrutura inicial do Front-End

  - Nesta etapa inicial, foi desenvolvido o esqueleto da aplicação. Cada página está encapsulada dentro de uma div com o id "page", contendo seu respectivo HTML e JavaScript incorporado neste arquivo inicial através de um iFrame. Essa abordagem permite evitar a redundância na criação dos componentes Header e Sidebar em cada página, além de simplificar o desenvolvimento do restante do projeto ao longo do tempo.

  - Foi criado um sistema simples de rotas para acessar as páginas, buscando replicar o funcionamento de uma Single Page Application (SPA). O acesso às páginas é bem simples, bastando passar dois parâmetros na URL:
  - "page": Neste parâmetro, especifica-se o nome da página atual da aplicação
