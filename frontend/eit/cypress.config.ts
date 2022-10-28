import { defineConfig } from 'cypress'

export default defineConfig({
  chromeWebSecurity: false,
  reporter: 'junit',
  reporterOptions: {
    reportDir: 'cypress/results',
    mochaFile: 'results/test-results-[hash].xml',
  },
  viewportWidth: 1920,
  viewportHeight: 1080,
  defaultCommandTimeout: 60000,
  e2e: {
    // We've imported your old cypress plugins here.
    // You may want to clean this up later by importing these.
    setupNodeEvents(on, config) {
      return require('./cypress/plugins/index.js')(on, config)
    },
    baseUrl: 'https://wa-eit-dk11.azurewebsites.net/',
  },
})
