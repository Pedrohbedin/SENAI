describe('template spec', () => {
  let musicItem;

  it('passes', () => {
    cy.visit('/')
  })

  //Visualizar playlists e executar uma música

  it('Verificar se será exibido', () => {
    cy.get("[aria-label='title-head']")
    cy.get("[aria-label='title-head']").should("contain", "Good morning")
  });

  it('Verificar se tem uma lista com as playlist exibida', () => {
    cy.get("[aria-label='playlist-item']").should("have.length.greaterThan", 0)
  });

  it('Clicar em uma opção de playlist e listar suas músicas', () => {
    cy.get("[aria-label='playlist-item']").first().click()
    cy.get("[aria-label='music-item']").should("have.length.greaterThan", 0)
  });

  it('Clicar no botão de voltar', () => {
    cy.get("[aria-label='music-item']").first().click()
  });

  //Navegar entre playlists e executar outra música

  it('Clicar no botão de voltar', () => {
    cy.get("[aria-label='angle-item']").click();
  });

  it('Verificar se será exibido', () => {
    cy.get("[aria-label='title-head']")
    cy.get("[aria-label='title-head']").should("contain", "Good morning")
  });

  it('Verificar se tem uma lista com as playlist exibida', () => {
    cy.get("[aria-label='playlist-item']").should("have.length.greaterThan", 0)
  });

  it('Clicar em uma opção de playlist e listar suas músicas', () => {
    cy.contains("Pagodeira").click()
    cy.get("[aria-label='music-item']").should("have.length.greaterThan", 0)
  });

  it('Clicar em uma opção de música dentro da playlist listada', () => {
    cy.contains("Vamo de Pagodin").click()
  });

  //Procurar e favoritar uma música

  it('Redirecionar para tela de buscar', () => {
    cy.get("[href='/Search']").click();
  });

  it("Procurar uma música especifica", () => {
    cy.get("[data-testid='campoBusca']").type("Montagem");
  })

  it('Verificar se tem uma lista com as playlist exibida', () => {
    cy.wait(2000);
    cy.get("[aria-label='music-item']").should("have.length.greaterThan", 0);
  });

  it('Clicar na música desejada', () => {
    musicItem = cy.get("[aria-label='music-item-sch']").contains('Montagem');
    musicItem.click()
  });

  it('Clicar no curtir da música', () => {
    cy.get(musicItem).get("[data-testid='icon-button-sch']").first().click()
  });

  //Verificar música favoritada na tela de Favoritos

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