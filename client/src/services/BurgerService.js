import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Burger } from "@/models/Burger.js"
import { AppState } from "@/AppState.js"


class BurgerService {

  async getBurgers() {
    const response = await api.get('api/burgers')
    logger.log('Got Burgers!', response.data)
    const burger = response.data.map(pojo => new Burger(pojo))
    AppState.burgers = burger
    logger.log('burger', burger)
  }
}

export const burgerService = new BurgerService()