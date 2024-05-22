describe('template spec', () => {
  it('passes', () => {
    cy.visit('/')
  })

  it('Redirecionar para tela de Favoritos', () => {
    cy.get("[href='/Favorites']").click();
    cy.scrollTo("top");
  });

  it('Verificar se existe alguma música na lista de músicas favoritas', () => {
    cy.get("[aria-label='music-item']").should("have.length.greaterThan", 0);
  });


  it('Clicar na música desejada', () => {
    cy.get("[aria-label='music-item']").contains('Trem Bala').click();
    cy.scrollTo("top");
  });
})