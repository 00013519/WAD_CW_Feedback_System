export interface Feedback {
    id: number,
    content: string,
    username: string,
    rating: string,
    createdAt: string,
    productId: number,
    product: {
      id: number,
      name: string
    }
}
//13519
