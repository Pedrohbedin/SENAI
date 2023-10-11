function calcular(event){
    event.preventDefault();
    const n1 = parseFloat(document.getElementById("numero1").value);
    const n2 = parseFloat(document.getElementById("numero2").value);
    const op = document.getElementById("operacao").value;

    if (isNaN(n1) || isNaN(n2)){
        alert("Preencha todos os campos")
        return;
    }

    let resultado;
    switch (op) {
        case '+':
            resultado = Somar(n1, n2);
            break;
        case '-':
            resultado = Subtrair(n1, n2);
            break;
        case '*':
            resultado = Multiplicar(n1, n2);
            break;
        case '/':
            resultado = Dividir(n1, n2);
            break;
        default:
            resultado = 'Operação inválida';
            break;
    }

    console.log('Resultado: ' + resultado);
    document.getElementById("resultado").innerText = resultado;
}

function Somar(x, y) {
    return x + y;
}

function Subtrair(x, y) {
    return x - y;
}

function Dividir(x, y) {
    if (y != 0) {
        return (x / y).toFixed(2);
    }
    else {
        return 'Operação inválida'
    }
}

function Multiplicar(x, y) {
    return x * y;
}