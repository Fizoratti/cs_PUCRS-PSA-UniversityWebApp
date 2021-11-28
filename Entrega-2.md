# Entrega 2

Usuários logados no sistema devem poder

1. visualizar as turmas/horários que ele pode se matricular (apenas as que estão liberadas)
2. solicitar matrícula em uma turma
   - o sistema deve verificar se ainda há vagas na turma solicitada
   - o sistema deve verificar se não há conflito de horários
   - o sistema não deve permitir matricular em duas turmas de uma mesma disciplina (mesmo em horários diferentes)
3. visualizar a sua grade de horários
4. cancelar matrícula em alguma disciplina (turma)

# Plano para a Entrega 2

Decisões de projeto.

1. O menu Turmas lista todas as Turmas da Universidade e permite pesquisar do início ao fim.

Usuários logados no sistema devem poder

### 1. visualizar as turmas/horários que ele pode se matricular (apenas as que estão liberadas)

- [ ] Adicionar um botão 'Matricular-se' em cada turma
  - [ ] Implementar função que cria uma nova matrícula do usuário logado em uma turma específica

### 2. solicitar matrícula em uma turma

- [x] Criar botão solicitar matrícula
- [ ] Implementar a função Matricular no MatriculasControler
- [ ] Editar Index no TurmasController para exibir apenas as que estão liberadas
  - o sistema deve verificar se ainda há vagas na turma solicitada
  - o sistema deve verificar se não há conflito de horários
  - o sistema não deve permitir matricular em duas turmas de uma mesma disciplina (mesmo em horários diferentes)

### 3. visualizar a sua grade de horários

- [x] criar um controller de Matricula chamado MatriculasController
- [x] nomear de Grade De Horarios no link da página HTML,
- [x] editar o metodo Index no MatriculasController pra listar toda a coleção ICollection<Matriculas> da entidade ApplicationUser

### 4. cancelar matrícula em alguma disciplina (turma)

- [ ] Adicionar um botão 'Desmatricular-se' em cada turma na lista de matrículas (grade de horários)
  - [ ] Implementar função que remove esta matrícula do usuário logado nesta uma turma específica

**TODO**

- [x] Criar MatriculasController (Grade de Horários)
- [x] Criar botão solicitar matrícula
- [ ] Implementar a função Matricular no MatriculasControler

**Dívida técnica**

_Negocio_

- [ ] Criar Dao's (interface+EF)
  - [x] Matricula
  - [ ] Historico
  - [ ] Turma
  - [ ] Disciplina
  - [ ] ApplicationUser
- [ ] Add métodos no Facade

- [ ] Criar metodos nos DAO's
  - [ ] Matricula
    - [x] Matricular
    - [ ] Desmatricular
  - [ ] Historico
  - [ ] Turma
  - [ ] Disciplina
  - [ ] ApplicationUser

_Controllers_

- [ ] (P1 !!!) Chamar nos controllers os metodos que estao no Facade do projeto Negocio
- [ ] (P1 !!!) Os métodos Index então funcionando, mas varios outros controllers não estão (clicar edit ou create nao funciona)
- [ ] (P1 !!!) Não tá dando pra obter os dados usando o Postman

_Autenticação_

- [ ] (P2 !!) Encontrar uma forma melhor de obter o id do usuário autenticado: `ApplicationUser user = _context.ApplicationUser.FirstOrDefault();`

_Design_

- [ ] (P2 !!) Fazer aparecer o nome de cada disciplina nas páginas historico e turma
- [ ] (P3 !) Ajustar layout da caixa de pesquisa de turmas (Design)
- [ ] (P3 !) Ajustar a home do app pra ter alguma coisa pelo menos (Design)
