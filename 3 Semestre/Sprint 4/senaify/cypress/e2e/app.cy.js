describe('template spec', () => {
  it('passes', () => {
    cy.visit('/')

    cy.viewport("iphone-xr")
  })

  it('Verificar se será exibido', () => {
    cy.get("[aria-label='title-head']")
    cy.get("[aria-label='title-head']").should("contain", "Good morning")
  });

  it('Verificar se tem uma lista com as playlist exibida', () => {
    cy.wait(2000)
    cy.get("[aria-label='playlist-item']").should("have.length.greaterThan", 0)
  });

  it('Clicar em uma opção de playlist e listar suas músicas', () => {
    cy.contains("Pagodeira").click()
    cy.wait(1000)
    cy.get("[aria-label='music-item']").should("have.length.greaterThan", 0)
  });

  it('Clicar em uma opção de música dentro da playlist listada', () => {
    cy.contains("Vamo de Pagodin").click() 
    cy.scrollTo("top")
  });
})