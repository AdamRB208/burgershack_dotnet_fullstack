import { reactive } from 'vue'

// NOTE AppState is a reactive object to contain app level data
export const AppState = reactive({
  /**@type {import('@bcwdev/auth0provider-client').Identity} */
  identity: null,
  /** @type {import('./models/Account.js').Account} user info from the database*/
  account: null,
  /** @type {import('./models/Burger.js').Burger []} user info from the database*/
  burgers: [],
  /** @type {import('./models/Burger.js').Burger []} user info from the database*/
  activeBurger: null,
  /** @type {import('./models/Side.js').Side []} user info from the database*/
  sides: [],
  /** @type {import('./models/Side.js').Side []} user info from the database*/
  activeSide: null
})

