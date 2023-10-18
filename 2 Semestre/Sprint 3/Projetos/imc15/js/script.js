let usuarios = [];
let usuario
function calcular(event) {
    event.preventDefault();
    let nome = document.getElementById("nome").value;
    let altura = parseFloat(document.getElementById("altura").value);
    let peso = parseFloat(document.getElementById("peso").value);
    let IMC = (peso / (altura * altura));
    let Situacao;
    let now = new Date();

    if (isNaN(peso) || isNaN(altura) || nome.lenght > 2) {
        alert("Preencha todos os campos corretamente");
        return;
    }

    if (IMC <= 17) {
        Situacao = "Muito abaixo do peso";
    }
    else if (IMC > 17 && IMC <= 18.49) {
        Situacao = "Abaixo do peso";
    }
    else if (IMC >= 18.5 && IMC <= 24.99) {
        Situacao = "Peso normal";
    }
    else if (IMC >= 25 && IMC <= 29.99) {
        Situacao = "Sobrepeso";
    }
    else if (IMC >= 30 && IMC <= 34.99) {
        Situacao = "Obesidade I";
    }
    else if (IMC >= 35 && IMC <= 39.99) {
        Situacao = "Obesidade II";
    }
    else if (IMC >= 40) {
        Situacao = "Obesidade III";
    }

    usuario = {
        nome: nome,
        altura: altura.toFixed(2),
        peso: peso.toFixed(2),
        IMC: IMC.toFixed(2),
        Situacao: Situacao,
        Data: `${now.getDate()}/${now.getMonth() + 1}/${now.getFullYear()} ${now.getHours()}:${now.getMinutes()}`
    }

    usuarios.push(usuario);

    adicionarRegistros();
}

function deletarRegistros() {
    usuarios = [];
    document.getElementById('corpo-tabela').innerHTML = "";
}

function adicionarRegistros() {
    let linhas = ""
    usuarios.forEach(function (oPessoa) {
        linhas +=
        `
        <tr>
            <td>${oPessoa.nome}</td>
            <td>${oPessoa.altura}</td>
            <td>${oPessoa.peso}</td>
            <td>${oPessoa.IMC}</td>
            <td>${oPessoa.Situacao}</td>
            <td>${oPessoa.Data}</td>
        </tr>
        `
    });
    document.getElementById('corpo-tabela').innerHTML = linhas;
}