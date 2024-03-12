const express = require('express')

const app = express();

//creating a basic handler
class Product {

    constructor(id, name, price, description)  {
        this.id = id;
        this.name = name;
        this.price = price;
        this.description = description;

    }
}

//storing some default products to store into the array
const products = [
    new Product (1, "Strawberry", 5.00, "Strawberry description"),
    new Product (2, "Chocolate", 5.00, "Chocolate description"),
    new Product (3, "Banana", 5.00, "Banana description"),


];