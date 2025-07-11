import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Side } from "@/models/Side.js"
import { AppState } from "@/AppState.js"

class SideService {

  async getSides() {
    const response = await api.get('api/sides')
    logger.log('Got Sides!', response.data)
    const side = response.data.map(pojo => new Side(pojo))
    AppState.sides = side
    logger.log('side', side)
  }


}

export const sideService = new SideService()