Cypress.Commands.add("fromLocation", (location) => {
    cy.get(".ng-select-container").filter(':contains("From location")').click()
    cy.contains(location).click();
    cy.get(".ng-select-container").should("contain", location);
});

Cypress.Commands.add("toLocation", (location) => {
    cy.get(".ng-select-container").filter(':contains("To location")').click()
    cy.contains(location).click();
    cy.get(".ng-select-container").should("contain", location);
});