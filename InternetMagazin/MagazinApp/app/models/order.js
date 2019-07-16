var Order = /** @class */ (function () {
    function Order(id, customerId, status, shipmentDate, orderNumber, orderItems) {
        this.id = id;
        this.customerId = customerId;
        this.status = status;
        this.shipmentDate = shipmentDate;
        this.orderNumber = orderNumber;
        this.orderItems = orderItems;
    }
    return Order;
}());
export { Order };
//# sourceMappingURL=order.js.map