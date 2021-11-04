# cs_PUCRS-PSA-UniversityWebApp-Tutorial
PUCRS - Programação de Software Aplicado 2021/2 Prof. Alexandre Agustini.

---

### A) Data de entrega da versão final: 01/12 (até o horário de início da aula)

• Apresentações da versão final: dias 01/12 e 06/12

• Entregas parciais serão acordadas com a turma ao longo do semestre


### B) Objetivo:

O objetivo é consolidar o conhecimento sobre conceitos e construção de sistemas web (cliente-servidor e
serviços) empresariais orientados a objetos em arquiteturas cliente-servidor multicamadas através da exploração dos
tópicos discutidos na disciplina de Programação de Software Aplicado.


### C) Enunciado do problema:

Estamos interessados em um sistema de informação para realizar a matrícula dos alunos da PUCRS, em
especial do currículo 4/624 do curso de SI.

O sistema deve permitir os seguintes casos de uso por parte dos alunos do curso (quando logados):

• Visualizar disciplinas, turmas e vagas disponíveis para sua matrícula.

• Solicitar matrícula em disciplina, se a vaga ainda estiver disponível o aluno estará matriculado na disciplina,
caso contrário o aluno é notificado que não há mais vagas

• Cancelar matrícula em disciplina.

• Gera um comprovante de matrícula (em formato html ou pdf).

O sistema deve permitir os seguintes casos de uso por parte do coordenador de curso:

• Gerar relatório contendo o percentual de ocupação de cada uma das disciplinas do curso, por turmas.

• Gerar relatório com alunos matriculados em uma determinada disciplina.

• Gerar relatório com número total de alunos matriculados e o número médio de créditos matriculados.

• Alterar o número de vagas de uma turma.

O sistema deve permitir, ainda, para todos os usuários:

• Listar as disciplinas do curso que possuem turmas cadastradas com seus horários

• Consultar o número de vagas disponíveis para cada uma das turmas de uma determinada disciplina.

• Estas consultas devem estar disponíveis, também, na forma de um serviço RESTful.

IMPORTANTE: O sistema deve implementar a lógica de negócio do sistema atual da universidade, com uma única
simplificação que todos os requisitos especiais devem ser cadastrados como pré-requisitos.


### D) Requisitos:

Os seguintes itens são obrigatórios na implementação do sistema:

• Interface web.

• Arquitetura (limpa) multicamada, com separação de responsabilidades.

• Uso dos padrões de projeto explorados nas disciplinas de Fundamentos de Desenvolvimento de Software
e Programação de Software Aplicado sendo obrigatoriamente:

o Uso do padrão MVC na camada de apresentação;

o Uso do padrão “Facade” para isolar a camada de domínio da camada de apresentação;

o Uso do padrão arquitetural “Domain Model” na camada de domínio;

o Uso do padrão “DAO”/”Repository” na camada de persistência.

• O grupo poderá utilizar outros padrões que julgar necessário para atender os requisitos da aplicação.

• Persistência em base de dados relacional.

• A camada de persistência deve ser implementada utilizando um mapeador objeto-relacional.

• Tratamento correto do encapsulamento de exceções entre as camadas.

• A base de dados deverá ter sido previamente populada com os que permitam validar as funcionalidades
do sistema: disciplinas e requisitos do currículo 4/624, histórico escolar de alguns alunos
(impersonalizados, claro), previsão de turmas e vagas. Um script SQL para geração do BD e carga dos
dados (ou uma classe de inicialização) deverá ser entregue de forma conjunta com os demais códigos da
aplicação.


### E) Desenvolvimento, apresentação e avaliação do trabalho:

• O trabalho pode ser realizado individualmente ou em grupos de, no máximo, 3 alunos.

• Os trabalhos deverão ser apresentados, durante a apresentação, TODOS os alunos devem estar online
e aptos a responder às perguntas. Respostas insatisfatórias por um aluno ou a sua ausência acarretarão
descontos na nota final.

• A apresentação do trabalho é de inteira responsabilidade dos alunos (configuração da máquina, do
ambiente de software, base de dados, etc.) e o código-fonte utilizado deverá ser o mesmo entregue ao
professor. É tarefa do grupo garantir que o sistema esteja apto a ser executado no dia da apresentação.

• Sistemas que não consigam ser executados ou apresentados no dia da apresentação não terão
avaliação.

• Mensagens de erro apresentadas durante a execução do programa, mesmo que a aplicação não pare de
executar, serão consideradas como erros de execução, e acarretarão descontos na nota do trabalho.

• Em caso de erro de sintaxe (compilação), o peso final do trabalho será valorado em zero.

• Em caso de erro de semântica (conteúdo), o peso final do trabalho sofrerá uma redução.

• Os trabalhos serão avaliados de acordo com critérios a serem estabelecidos pelo professor da disciplina,
considerando o que é pedido no enunciado e o que foi realizado com sucesso pelo sistema. Também
serão avaliadas a modelagem do sistema (correta criação das classes necessárias, com seus atributos e
métodos, encapsulamento, e correto estabelecimento de relações entre as classes) e sua implementação
de acordo com os conceitos de orientação a objetos e arquitetura limpa.

• Trabalhos copiados resultarão em nota zero para todos os alunos envolvidos.


### F) Entrega do trabalho:

• Desde o início do desenvolvimento o trabalho deve estar publicado em um repositório do GitHub (ou outro
sistema de versionamento) e o professor deve ser convidado como colaborador (usuário GitHub e BitBucket:
aagustini ou alexandre.agustini@pucrs.br). Todos os integrantes do grupo devem fazer commits ao longo do
trabalho e, preferencialmente, trabalhar em branches distintas.

• Todos os arquivos necessários a execução do sistema, bem como os arquivos-fonte, scripts de banco de
dados e os arquivos de documentação, deverão ser empacotados em um único arquivo (.zip) e submetidos
através do sistema Moodle até a data de entrega.

• A documentação deve ser realizada na forma de um relatório técnico e entregue em formato PDF. Devem
fazer parte da documentação pelo menos:

o Descrição do problema.

o Diagrama de classes do sistema. O diagrama de classes deverá ser entregue junto com
documentação em texto salientando os pontos onde foram utilizados padrões de projeto na
implementação da solução. É importante que as classes estejam agrupadas em pacotes de acordo
com a arquitetura de camadas do sistema.

o Diagrama da base relacional do sistema.

o Os diagramas devem estar disponíveis em imagens com resolução suficiente e de fácil visualização.
Não serão aceitos diagramas que estejam em formato original da ferramenta de desenho (como Visio,
Astah, e outros).

o Dificuldades e lições aprendidas.

• Não serão aceitos trabalhos enviados por correio eletrônico.

• Não serão aceitos trabalhos enviados fora do prazo estabelecido
