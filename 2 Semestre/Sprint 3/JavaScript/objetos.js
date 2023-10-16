let pedro = {
    nome: "Pedro",
    idade: 41,
    altura: 1.75
};

let Eduardo = new Object();

Eduardo.nome = "Eduardo"
Eduardo.idade = 36
Eduardo.sobrenome = "Costa" 

let pessoas = []

pessoas.push()

pessoas.push(pedro)

pessoas.forEach(function (p, i){
    console.log(`Nome ${i+1}: ${p.nome}`)
})