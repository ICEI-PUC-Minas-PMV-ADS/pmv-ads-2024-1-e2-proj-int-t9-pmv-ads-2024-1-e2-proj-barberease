# Registro de Testes de Software

<span style="color:red">Pré-requisitos: <a href="3-Projeto de Interface.md"> Projeto de Interface</a></span>, <a href="8-Plano de Testes de Software.md"> Plano de Testes de Software</a>


| **Caso de Teste** | **CT-01 – Cadastro de Cliente** |
| --- | --- |
| Requisito Associado | RF-001 - A aplicação deve permitir ao cliente cadastrar uma conta. |
| Objetivo do Teste | Verificar se um cliente consegue se cadastrar na aplicação. |
| Passos | 1. Acessar a página de registro.<br> 2. Preencher os campos obrigatórios.<br> 3. Aceitar os termos de uso.<br> 4. Clicar em "Registrar". |
| Critério de Êxito | O cliente é registrado com sucesso. |
|Resultados obtidos | Não foi possível cadastrar o cliente. Apesar de ter sido corrigido o erro anterior sobre o formato de entrada no campo do telefone, ainda não é possível cadastrar o cliente   |
| Conclusão | Resultado insatisfatório | 
|Melhorias e recomendações| A equipe irá deverá avançar no desenvolvimento dessa funcionalidade |


<h3><b>Falha</b></h3>
<figure>
    <img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t9-pmv-ads-2024-1-e2-proj-barberease/blob/main/docs/img/IMG_20240512_234252_535.jpg">
    <figcaption>Figura 1 - Nenhum formato de telefone aceito</figure><br>
</figure>
<br><br>


| **Caso de Teste** | **CT-02 – Login do Cliente** |
| --- | --- |
| Requisito Associado | RF-002 - A aplicação deve permitir ao cliente fazer login na sua conta fornecendo email e senha. |
| Objetivo do Teste | Verificar se um cliente consegue fazer login na aplicação. |
| Passos | 1. Acessar a página de login.<br> 2. Preencher os campos de email e senha.<br> 3. Clicar em "Entrar".<br> |
| Critério de Êxito | O cliente é logado com sucesso. |
|Resultados obtidos | Foi utilizado os dados de um client default para realizar o teste. A autenticação dos dados foi realizada com sucesso e exibida mensagem de autenticação bem sucedida. No entanto, a página para onde o cliente será redirecionado ainda está em desenvolvimento, bloqueando o fluxo do usuário.|
| Conclusão | Resultado insatisfatório, porém atende parcialmente o critérios de êxito|
|Melhorias e recomendações| A equipe deverá desenvolver a página para onde será redirecionado o cliente após o login, a página de perfil do cliente |

<h3><b>Falha</b></h3>
<figure>
    <img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t9-pmv-ads-2024-1-e2-proj-barberease/blob/main/docs/img/Falha%20CTS2.jpeg">
    <figcaption>Figura 2 - Página não encontrada </figure><br>
</figure>
<br><br>
<h3><b>Autenticação realizada com sucesso</b></h3>
<figure>
    <img src="https://github.com/ICEI-PUC-Minas-PMV-ADS/pmv-ads-2024-1-e2-proj-int-t9-pmv-ads-2024-1-e2-proj-barberease/blob/main/docs/img/CTS2.png">
    <figcaption>Figura 3 - Mensagem de autenticação </figure><br>
</figure>
<br><br>





| **Caso de Teste** 	| **CT-02 – Realizar login** 	|
|:---:	|:---:	|
|	Requisito Associado 	| RF-00Y - A aplicação deve permitir que um usuário previamente cadastrado faça login |
|Registro de evidência | www.teste.com.br/drive/ct-02 |

## Avaliação

Discorra sobre os resultados do teste. Ressaltando pontos fortes e fracos identificados na solução. Comente como o grupo pretende atacar esses pontos nas próximas iterações. Apresente as falhas detectadas e as melhorias geradas a partir dos resultados obtidos nos testes.
