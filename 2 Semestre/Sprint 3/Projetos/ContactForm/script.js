async function cadastrar(event) {
    event.preventDefault(); // capturar o evento de submit do form

    // pegar os dados do formulário
    let cep = document.getElementById('cep').value;
    let rua = document.getElementById('rua').value;
    let numero = document.getElementById('numero').value;
    let complemento = document.getElementById('complemento').value;
    let bairro = document.getElementById('bairro').value;
    let cidade = document.getElementById('cidade').value;
    let uf = document.getElementById('uf').value;
    let anotacoes = document.getElementById(anotacoes).value;
    
    // dados adicionais

    let pais = document.getElementById('pais').value;
    let ddd = document.getElementById('ddd').value;
    let telefone = document.getElementById('telefone').value;

    const urlLocal = "http://localhost:3000/contatos";
    const objDados = { cep, rua, numero, complemento, bairro, cidade, uf, pais, ddd, telefone };

    try {
        const promise = await fetch(urlLocal, {
            // transforma um objeto em um json
            body: JSON.stringify(objDados),
            headers: { "Content-Type": "application/json" },
            method: "post"
        });

        const retorno = promise.json(); // pega o retorno da API
        console.log(retorno);
    } catch (error) {
        alert("Deu ruim: " + error);
    }
}

// // get
// const retorno = fetch("https://viacep.com.br/ws/09510200/json/")
// .then((retorno) => {
//     // console.log(retorno);
//     console.log("Deu bom na API");
// }) // quando for resolvida
// .catch((erro) => {
//     console.log("Deu ruim na API");
// }) // quando for rejeitada

async function chamarApi() {
    const cep = document.getElementById("cep").value;
    const url = `https://viacep.com.br/ws/${cep}/json/`;
    
    try {
        // resolvida ou fullfilled
        const promise = await fetch(url);
        const resposta = await promise.json();
        

        exibirEndereco(resposta);
    } catch (error) {
        // rejected
        console.log("Deu ruim na API");
        
    }
    
}

function exibirEndereco(resposta) {
    document.getElementById('rua').value = resposta.logradouro;
    document.getElementById('bairro').value = resposta.bairro;
    document.getElementById('cidade').value = resposta.localidade;
    document.getElementById('uf').value = resposta.uf;
}

function limparDados() {

    document.getElementById('cep').value = ''
    document.getElementById('rua').value = '';
    document.getElementById('numero').value = '';
    document.getElementById('bairro').value = '';
    document.getElementById('cidade').value = '';
    document.getElementById('complemento').value = '';
    document.getElementById('uf').value = '';
    document.getElementById('pais').value = '';
    document.getElementById('ddd').value = '';
    document.getElementById('telefone').value = '';
}