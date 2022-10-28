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

Cypress.Commands.add("clickSearch", () => {
    cy.get("button").filter(':contains("Search")').should("be.enabled");
    cy.get("button").filter(':contains("Search")').click();
});

Cypress.Commands.add("selectFirstRoute", () => {
    cy.get(".route-item").first().click();
});

Cypress.Commands.add("clickNext", () => {
    cy.get("button").filter(':contains("Next")').should("be.enabled");
    cy.get("button").filter(':contains("Next")').click();
});

Cypress.Commands.add("enterName", (name) => {
    cy.get("input").first().clear().type(name)
    cy.get("body").click()
});

Cypress.Commands.add("enterEmail", (email) => {
    cy.get("input").last().clear().type(email)
    cy.get("body").click()
});

Cypress.Commands.add("clickBook", () => {
    cy.get("button").filter(':contains("Book")').should("be.enabled");
    cy.get("button").filter(':contains("Book")').click();
});

Cypress.Commands.add("clickFinish", () => {
    cy.get("button").filter(':contains("Finish")').should("be.enabled");
    cy.get("button").filter(':contains("Finish")').click();
});

