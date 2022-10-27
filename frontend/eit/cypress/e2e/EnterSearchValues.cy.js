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

  });
});
