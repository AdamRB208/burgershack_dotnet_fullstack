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

  async createSide(sideData) {
    const response = await api.post('api/sides', sideData)
    logger.log('Created Side!', response.data)
    const side = new Side(response.data)
    return side
  }

}

export const sideService = new SideService()