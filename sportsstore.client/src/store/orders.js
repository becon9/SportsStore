import Axios from "axios";

const ORDERS_URL = "http://localhost:5000/api/order";

export default {
    actions: {
        async storeOrder(context, order) {
            order.cartLines = context.rootState.cart.lines;
            return (await Axios.post(ORDERS_URL, order)).data;
        }
    }
}