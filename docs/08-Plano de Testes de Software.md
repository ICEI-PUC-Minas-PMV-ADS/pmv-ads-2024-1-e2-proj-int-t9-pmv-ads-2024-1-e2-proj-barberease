# Plano de Testes de Software

<span style="color:red">Pré-requisitos: <a href="2-Especificação do Projeto.md"> Especificação do Projeto</a></span>, <a href="3-Projeto de Interface.md"> Projeto de Interface</a>

Esses são os cenários de testes que serão utilizados na realização dos testes da aplicação, eles foram escolhidos para demonstrar os requisitos sendo satisfeitos.
 
| **Caso de Teste** | **CT-01 – Cadastro de Cliente** |
| --- | --- |
| Requisito Associado | RF-001 - A aplicação deve permitir ao cliente cadastrar uma conta. |
| Objetivo do Teste | Verificar se um cliente consegue se cadastrar na aplicação. |
| Passos | 1. Acessar a página de registro.<br> 2. Preencher os campos obrigatórios.<br> 3. Aceitar os termos de uso.<br> 4. Clicar em "Registrar". |
| Critério de Êxito | O cliente é registrado com sucesso. |

| **Caso de Teste** | **CT-02 – Login do Cliente** |
| --- | --- |
| Requisito Associado | RF-002 - A aplicação deve permitir ao cliente fazer login na sua conta fornecendo email e senha. |
| Objetivo do Teste | Verificar se um cliente consegue fazer login na aplicação. |
| Passos | 1. Acessar a página de login.<br> 2. Preencher os campos de email e senha.<br> 3. Clicar em "Entrar".<br> |
| Critério de Êxito | O cliente é logado com sucesso. |

| **Caso de Teste** | **CT-03 – Visualização de Estabelecimentos e Serviços** |
| --- | --- |
| Requisito Associado | RF-003 - A aplicação deve permitir ao cliente visualizar os estabelecimentos e seus serviços oferecidos. |
| Objetivo do Teste | Verificar se um cliente consegue visualizar os estabelecimentos e os serviços oferecidos. |
| Passos | 1. Acessar a página de busca de estabelecimentos.<br> 2. Navegar pela lista de estabelecimentos.<br> 3. Visualizar os serviços oferecidos por cada estabelecimento.<br> |
| Critério de Êxito | O cliente consegue visualizar os estabelecimentos e os serviços oferecidos corretamente. |
 
| **Caso de Teste** | **CT-04 – Escolha de Serviços do Estabelecimento** |
| --- | --- |
| Requisito Associado | RF-004 - A aplicação deve permitir ao cliente escolher os serviços do estabelecimento. |
| Objetivo do Teste | Verificar se um cliente consegue escolher os serviços oferecidos por um estabelecimento. |
| Passos | 1. Selecionar um estabelecimento.<br> 2. Visualizar os serviços oferecidos pelo estabelecimento.<br> 3. Escolher serviço.<br> |
| Critério de Êxito | O cliente consegue selecionar os serviços desejados corretamente. |

| **Caso de Teste** | **CT-05 – Visualização de Dias e Horários Disponíveis** |
| --- | --- |
| Requisito Associado | RF-005 - A aplicação deve permitir ao cliente visualizar os dias e horários disponíveis para atendimento. |
| Objetivo do Teste | Verificar se um cliente consegue visualizar os dias e horários disponíveis para agendamento. |
| Passos | 1. Selecionar um estabelecimento desejado.<br> 2. Visualizar os dias e horários disponíveis para o atendimento. |
| Critério de Êxito | O cliente consegue visualizar os dias e horários disponíveis corretamente. |

| **Caso de Teste** | **CT-06 – Agendamento de Atendimento** |
| --- | --- |
| Requisito Associado | RF-006 - A aplicação deve permitir ao cliente agendar seu atendimento com o estabelecimento. |
| Objetivo do Teste | Verificar se um cliente consegue agendar seu atendimento com um estabelecimento. |
| Passos | 1. Selecionar um serviço, um estabelecimento, um dia e um horário disponíveis.<br> 2. Confirmar o agendamento. |
| Critério de Êxito | O cliente consegue agendar seu atendimento com sucesso. |

| **Caso de Teste** | **CT-07 – Cadastro de Conta do Estabelecimento** |
| --- | --- |
| Requisito Associado | RF-007 - A aplicação deve permitir ao estabelecimento cadastrar uma conta. |
| Objetivo do Teste | Verificar se um estabelecimento consegue se cadastrar na aplicação. |
| Passos | 1. Acessar a página de registro do estabelecimento.<br> 2. Preencher os campos obrigatórios.<br> 3. Aceitar os termos de uso.<br> 4. Clicar em "Registrar".<br> |
| Critério de Êxito | O estabelecimento é registrado com sucesso. |

| **Caso de Teste** | **CT-08 – Login do Estabelecimento** |
| --- | --- |
| Requisito Associado | RF-008 - A aplicação deve permitir ao estabelecimento fazer login na sua conta. |
| Objetivo do Teste | Verificar se um estabelecimento consegue fazer login na aplicação. |
| Passos | 1. Acessar a página de login.<br> 2.Preencher os campos de email e senha.<br> 3. Clicar em "Entrar".<br> |
| Critério de Êxito | O estabelecimento é logado com sucesso. |

| **Caso de Teste** | **CT-09 – Visualização de Informações de Agendamentos dos Clientes** |
| --- | --- |
| Requisito Associado | RF-009 - A aplicação deve permitir ao estabelecimento visualizar informações de agendamentos dos clientes. |
| Objetivo do Teste | Verificar se um estabelecimento consegue visualizar as informações de agendamentos dos clientes. |
| Passos | 1. Acessar a página de gerenciamento de agendamentos.<br> 2.Verificar a lista de agendamentos marcados. |
| Critério de Êxito | O estabelecimento consegue visualizar corretamente a lista de agendamentos marcados. |

| **Caso de Teste** | **CT-10 – Cancelamento de Agendamento** |
| --- | --- |
| Requisito Associado | RF-010 - A aplicação deve permitir ao estabelecimento cancelar agendamentos dos clientes. |
| Objetivo do Teste | Verificar se um estabelecimento consegue cancelar agendamentos dos clientes. |
| Passos | 1. Acessar a lista de agendamentos marcados.<br> Selecionar o agendamento desejado.<br> 3. Cancelar o agendamento. |
| Critério de Êxito | O agendamento é cancelado com sucesso e removido da lista de agendamentos do estabelecimento. |
