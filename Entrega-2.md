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

## Página "Matrícula" _(basicamente uma lista de turmas)_ _(já temos a página Historico e Turmas)_

### 1. visualizar as turmas/horários que ele pode se matricular (apenas as que estão liberadas)

- [ ] Editar Index no TurmasController para
  - [ ] somente exibir Turmas com o atributo Vagas > (maior que) zero.

### 2. solicitar matrícula em uma turma

- [ ] Editar
  - o sistema deve verificar se ainda há vagas na turma solicitada
  - o sistema deve verificar se não há conflito de horários
  - o sistema não deve permitir matricular em duas turmas de uma mesma disciplina (mesmo em horários diferentes)

### 3. cancelar matrícula em alguma disciplina (turma)

- [ ] Usa o botão scaffoldado 'Delete' para ser o nosso 'Desmatricular'

## Página "Grade de Horários"

### 3. visualizar a sua grade de horários

- [ ] criar um controller de Matricula chamado MatriculasController
- [ ] nomear de Grade De Horarios no link da página HTML,
- [ ] editar o metodo Index no MatriculasController pra listar toda a coleção ICollection<Matriculas> da entidade ApplicationUser

**TODO**

- Criar MatriculasController (Grade de Horários)

**Dívida técnica**

- [] (P1 !!!) Fazer aparecer o nome de cada disciplina nas páginas historico e turma
- [] (P1 !!!) Não tá dando pra obter os dados usando o Postman
- [] (P2 !!) Apenas os métodos Index então funcionando em ambos controllers (clicar edit ou create nao funciona)
- [] (P3 !) Ajustar layout da caixa de pesquisa de turmas (Design)
