using System.Globalization;

//Um posto está vendendo combustíveis com a seguinte tabela de descontos:
//Álcool:
//. até 20 litros, desconto de 3% por litro Álcool
//. acima de 20 litros, desconto de 5% por litro
//Gasolina:
//. até 20 litros, desconto de 4% por litro Gasolina
//. acima de 20 litros, desconto de 6% por litro

//Escreva um algoritmo que leia o número de litros vendidos e o tipo de combustível (codificado
//da seguinte forma: A-álcool, G-gasolina), calcule e imprima o valor a ser pago pelo cliente
//sabendo-se que o preço do litro da gasolina é R$ 5,30 e o preço do litro do álcool é R$ 4,90.
float preco = 0f;
char tipo = ' ';
do 
{

Console.WriteLine($"Digite o total de litros comprado:");
float litro = float.Parse(Console.ReadLine());
float valor = 0;

Console.WriteLine($"\nDigite A para álcool ou G para gasolina:");
tipo = char.Parse(Console.ReadLine().ToUpper());

switch (tipo) {
    case 'A':
    if (litro <= 20) {
        valor = 0.853f;
        
    }
    else {
        valor = 0.745f;
    }
    preco = litro * valor;
    Console.WriteLine($"\nO total a ser pago é R${Math.Round(preco, 2)}");
    break;
    case 'G':
    if (litro <= 20) {
        valor = 0.788f;
        
    }
    else {
        valor = 0.682f;
    }
    preco = litro * valor;
    Console.WriteLine($"\nO total a ser pago é R${Math.Round(preco, 2)}");
    break;
    default:
    Console.WriteLine($"\nNão possuimos essa opção...");
    break;
}


}while(tipo != 'A' && tipo != 'G');


