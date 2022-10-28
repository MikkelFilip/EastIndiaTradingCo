context("The flow", () => {
  describe("Searching for delivery", () => {
    const FIXTURE = "application";

    it("Open page", () => {
      cy.visit("/");
    });

    it("Search for a from location", () => {
      cy.fixture(FIXTURE).then((data) => {
        cy.fromLocation(data.from);
      })
    });

    it("Search for a to location", () => {
      cy.fixture(FIXTURE).then((data) => {
        cy.toLocation(data.to);
      })
    });

    it("Click search button", () => {
      cy.clickSearch();
    });

    it("Select the first route", () => {
      cy.selectFirstRoute();
    });

    it("Click next button", () => {
      cy.clickNext();
    });

    it("Enter name", () => {
      cy.fixture(FIXTURE).then((data) => {
        cy.enterName(data.name);
      })
    });

    it("Enter Email", () => {
      cy.fixture(FIXTURE).then((data) => {
        cy.enterEmail(data.email);
      })
    });

    it("Click book button", () => {
      cy.clickBook();
      cy.wait(500);
    });

    it("Click finish button", () => {
      cy.clickFinish();
    });
  });
});
