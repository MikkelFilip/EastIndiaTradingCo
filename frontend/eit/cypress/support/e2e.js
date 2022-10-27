// ***********************************************************
// This example support/index.js is processed and
// loaded automatically before your test files.
//
// This is a great place to put global configuration and
// behavior that modifies Cypress.
//
// You can change the location of this file or turn off
// automatically serving support files with the
// 'supportFile' configuration option.
//
// You can read more here:
// https://on.cypress.io/configuration
// ***********************************************************

// Import commands.js using ES2015 syntax:
import "./commands";
import "./searchCommands";

// Alternatively you can use CommonJS syntax:
// require('./commands')



before(() => {
  if (Cypress.browser.isHeaded) {
    cy.clearCookie("shouldSkip");
  } else {
    cy.getCookie("shouldSkip").then((cookie) => {
      if (cookie && typeof cookie === "object" && cookie.value === "true") {
        Cypress.runner.stop();
      }
    });
  }
});

afterEach(function onAfterEach() {
  if (this.currentTest.state === "failed") {
    // if (cy.url() === Cypress.config('baseUrl') + "/api/v1/inventory/status?itemsNumbers=") {
    //   cy.visit("/")
    // }

    // eslint-disable-next-line no-underscore-dangle
    if (this.currentTest._currentRetry === this.currentTest._retries) {
      cy.setCookie("shouldSkip", "true");
      // set cookie to skip tests for further specs
      Cypress.runner.stop();
      // this will skip tests only for current spec
    }
  }
});

// TODO: Check if this should remain
Cypress.on("uncaught:exception", (err, runnable) => {
  // returning false here prevents Cypress from
  // failing the test
  return false;
});

Cypress.on("fail", (err, runnable) => {

});
