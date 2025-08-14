import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Burger } from "@/models/Burger.js"
import { AppState } from "@/AppState.js"


class BurgerService {
  async updateBurger(itemId, value) {
    logger.log('itemId and value', itemId, value)
    const response = await api.put(`api/burgers/${itemId}`, value)
    logger.log('Updated Burger!', response.data)
    const burger = AppState.burgers
    const index = burger.findIndex(burger => burger.id === itemId)
    burger.splice(index, 1, value)
  }

  async getBurgersById(itemId) {
    // AppState.activeBurger = null
    const response = await api.get(`api/burgers/${itemId}`)
    logger.log('ItemId', itemId)
    logger.log('Got Burger By Id!', response.data)
    const burger = new Burger(response.data)
    // AppState.activeBurger = burger
    return burger
  }

  async getBurgers() {
    const response = await api.get('api/burgers')
    logger.log('Got Burgers!', response.data)
    const burger = response.data.map(pojo => new Burger(pojo))
    AppState.burgers = burger
    logger.log('burger', burger)
  }


  async createBurger(burgerData) {
    const response = await api.post('api/burgers', burgerData)
    logger.log('Created Burger!', response.data)
    const burger = new Burger(response.data)
    return burger
  }

  async deleteBurger(burgerId) {
    const response = await api.delete(`api/burgers/${burgerId}`)
    logger.log('Deleted Burger!', response.data)
    const burger = AppState.burgers
    const index = burger.findIndex(burger => burger.id == burgerId)
    burger.splice(index, 1)
  }
}

export const burgerService = new BurgerService()