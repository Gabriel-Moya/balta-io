'use strict';
const mongoose = require('mongoose');
const Product = mongoose.Model('Product');

exports.get = () => {
  return Product
    .find({ active: true }, 'title price slug')
}

exports.getBySlug = (slug) => {
  const res = Product
      .findOne({
          slug: slug,
          active: true
      }, 'title description price slug tags');
  return res;
}

exports.getById = (id) => {
  const res = Product
      .findById(id);
  return res;
}

exports.getByTag = (tag) => {
  const res = Product
      .find({
          tags: tag,
          active: true
      }, 'title description price slug tags');
  return res;
}

exports.create = (data) => {
  var product = new Product(data);
  product.save();
}

exports.update = (id, data) => {
  Product
      .findByIdAndUpdate(id, {
          $set: {
              title: data.title,
              description: data.description,
              price: data.price,
              slug: data.slug
          }
      });
}

exports.delete = (id) => {
  Product
      .findOneAndRemove(id);
}