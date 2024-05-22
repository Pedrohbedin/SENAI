describe('template spec', () => {
  let musicItem;
  before('passes', () => {
    cy.visit('/')
  });

  it('Redirecionar para tela de buscar', () => {
    cy.get("[href='/Search']").click();
    cy.scrollTo("top");
  });

  it("Procurar uma música especifica", () => {
    cy.get("[data-testid='campoBusca']").type("Trem Bala");
    cy.scrollTo("top");
  })

  it('Verificar se tem uma lista com as playlist exibida', () => {
    cy.wait(2000);
    cy.get("[aria-label='music-item']").should("have.length.greaterThan", 0);
  });

  it('Clicar na música desejada', () => {
    musicItem = cy.get("[aria-label='music-item']").contains('Ana Vilela');
    musicItem.click()
  });

  it('Clicar no curtir da música', () => {
    cy.get(musicItem).get("[data-testid='icon-button']").first().click();
  });

})