//Import
const kopek = require('./kopek');
const kopekBakim = require('./kopekBakimUtility');

console.log("kopek adi : ",kopek.name);
console.log("kopek boyu : ",kopek.height);
kopekBakim.kopegiTemizle();
console.log("kopek ilgi saati : ",kopek.weight*kopekBakim.kopekBakimSaati);
