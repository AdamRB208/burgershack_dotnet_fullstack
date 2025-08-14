import { logger } from "@/utils/Logger.js"
import { api } from "./AxiosService.js"
import { Side } from "@/models/Side.js"
import { AppState } from "@/AppState.js"

class SideService {

  async updateSide(itemId, value) {
    const response = await api.put(`api/sides/${itemId}`, value)
    logger.log('Updated Side', response.data)
    const side = AppState.sides
    const index = side.findIndex(side => side.id === itemId)
    side.splice(index, 1, value)
  }

  async getSideById(itemId) {
    const response = await api.get(`api/sides/${itemId}`)
    logger.log('Got Side By Id!', response.data)
    const side = new Side(response.data)
    return side
  }

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

  async deleteSide(sideId) {
    const response = await api.delete(`api/sides/${sideId}`)
    logger.log('Deleted Side!', response.data)
    const side = AppState.sides
    const index = side.findIndex(side => side.id == sideId)
    side.splice(index, 1)
  }
}

export const sideService = new SideService()