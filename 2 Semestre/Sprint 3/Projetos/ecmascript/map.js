const numeros = [1, 2, 5, 10, 300]

// const dobro = numeros.map( (n) => {
//     return n * 2
// })  

// console.log('-=-=-=-=--=-=-=-=-=-');
// console.log(`| Os valores são ${numeros}`);
// console.log('-=-=-=-=--=-=-=-=-=-');
// console.log(`| Os dobro dos valores são: ${dobro}`);

// const pares = numeros.filter( (n) => {
//     return n % 2 === 0
// })
// console.log('-=-=-=-=--=-=-=-=-=-');
// console.log(`| Os valores pares são: ${pares}`);
// console.log('-=-=-=-=--=-=-=-=-=-');

// const comentarios = [
//     {comentario: "teste", exibe: true},
//     {comentario: "Evento foi uma", exibe: true},
//     {comentario: "Bosta", exibe: false},
// ] 

// const comentarioFiltrados = comentarios.filter((c) => {
//     return c.exibe == true
// })

// comentarioFiltrados.forEach(element => {
//     console.log(`Comentario: ${element.comentario}`);
// });

const soma = numeros.reduce((vInicial, v) => {
    return vInicial + v;
}, 1)

console.log(soma)