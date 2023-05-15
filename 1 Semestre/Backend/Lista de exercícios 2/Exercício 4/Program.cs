Console.WriteLine($"Responda com s ou n");
int contador = 0;

Console.WriteLine($"Telefonou para a vítima?");
string resposta1 = Console.ReadLine().ToUpper();

Console.WriteLine($"Esteve no local do crime?");
string resposta2 = Console.ReadLine().ToUpper();

Console.WriteLine($"Mora perto da vítima?");
string resposta3 = Console.ReadLine().ToUpper();

Console.WriteLine($"Devia para a vítima?");
string resposta4 = Console.ReadLine().ToUpper();

Console.WriteLine($"Já trabalhou com a vítima?");
string resposta5 = Console.ReadLine().ToUpper();

if (resposta1 == "S") {
    contador++;
}
if (resposta2 == "S") {
    contador++;
}
if (resposta3 == "S") {
    contador++;
}
if (resposta4 == "S") {
    contador++;
}
if (resposta5 == "S") {
    contador++;
}

if (contador == 2) {
    Console.WriteLine($"Suspeita");
}
else if (contador == 3 || contador == 4) {
    Console.WriteLine($"Cúmplice");
}
else if (contador == 5) {
    Console.WriteLine($"Culpado");
}

else {
    Console.WriteLine($"Inocente");
}
