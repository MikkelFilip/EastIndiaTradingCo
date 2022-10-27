// -- Default setup command - needs to be called as the first test, to set up the app --
// before: default webpage is loaded, with settings dialog in focus
// during: in the settings dialog, first options for store, workstation and printers are chosen and saved
// after: the settings dialog is hidden - webpage ready

Cypress.Commands.add("Open", () => {
  cy.visit("/");
})

Cypress.Commands.add("SetupTest", () => {
  cy.openApplication();
  cy.wait(5000);
  cy.fixture("applicationSetup").then((data) => {
    cy.selectShop(data.shops);
    cy.selectWorkstation(data.workstations);
    cy.selectFiscalPrinter(data.fiscalPrinters);
    cy.selectPrinter(data.printer);
    cy.selectLanguage(data.languages);
    cy.checkClearSalesHandler();
    cy.saveSetting();
    cy.showAllProducts();
  });
});
