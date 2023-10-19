const evento = {
    dataEvento: `${new Date().getDate()}/${new Date().getMonth() + 1}/${new Date().getFullYear()}`,
    descricaoDoEvento: 'Evento de JavaScript',
    titulo: 'JT',
    presenca: true,
    comentario: 'Muito bom',
    exibe: true
}

const {...resto} = evento;

console.log(resto);

// console.log(`
// Data do evento: ${dataEvento}
// Descrição do evento: ${descricaoDoEvento}
// Título: ${titulo}
// Presença: ${presenca ? 'Comfirmada' : 'Não Confirmada'}
// Cometario: ${comentario}
// Exibe: ${exibe}
// -=-=-=-=-==-=-=-=-=-=-=-
// `);