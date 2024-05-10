# Instruções de utilização

## Instalação do Site

O site em HTML/CSS/JS é um projeto estático, logo pode ser utilizado tanto em servidores quanto localmente.

A api é feita em C#, em .NET 8, necessário ambos instalados no computador para rodar localmente.

## Histórico de versões

### [0.2.3] - 08/05/2024

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
    - "page": Neste parâmetro, especifica-se o nome da página principal da aplicação, com opções disponíveis como: login, criar-conta e home.
    - "second-page": Aqui é inserido o nome das páginas que contêm os componentes Header e Sidebar, ou que serão renderizadas dentro da página home, incluindo: página-inicial, barbearia, barbearias, carrinho, assinatura e anuncie-conosco.
