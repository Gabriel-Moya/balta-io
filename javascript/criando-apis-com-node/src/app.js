'use strict';

const express = require('express');
const bodyParser = require('body-parser');
const dotenv = require('dotenv');
const mongoose = require('mongoose');

const app = express();
const router = express.Router();
dotenv.config();

mongoose.connect(`${process.env.CONNECTION_STRING}`);

const Product = require('./models/product');
const Customer = require('./models/customer');
const Order = require('./models/order');

const indexRoute = require('./routes/index-route');
const productRoute = require('./routes/product-route');

app.use(bodyParser.json());
app.use(bodyParser.urlencoded({ extended: false }));

app.use('/', indexRoute);
app.use('/products', productRoute);

module.exports = app;