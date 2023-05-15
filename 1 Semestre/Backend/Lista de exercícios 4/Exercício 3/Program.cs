//Faça um algoritmo para ler: a descrição do produto (nome), a quantidade adquirida e o
//preço unitário. Calcular e escrever o total (total = quantidade adquirida * preço unitário), o
//desconto e o total a pagar (total a pagar = total - desconto), sabendo-se que:
//- Se quantidade &lt;= 5 o desconto será de 2%
//- Se quantidade &gt; 5 e quantidade &lt;=10 o desconto será de 3%
//- Se quantidade &gt; 10 o desconto será de 5%

Console.WriteLine($"Digite o nome do produto comprado:");
string nome = Console.ReadLine();

Console.WriteLine($"Digite a quatidade comprada");
int quantidade = int.Parse(Console.ReadLine());

Console.WriteLine($"Digite o preço da unidade do produto:");
float preco = float.Parse(Console.ReadLine());

float desconto = 0;
float total = 0;
float totalapagar = 0;

Console.WriteLine($"O preco total do(a) {nome.ToLower()} é R${Math.Round(Calculartotal(preco, quantidade, total), 2)}");
Console.WriteLine($"O preço a pagar pelo produto é R${Math.Round(Calculartotalapagar(preco, quantidade, total, desconto, totalapagar), 2)}");



static float Calculartotalapagar(float preco, float quantidade,float total, float desconto, float totalapagar) {
    if (quantidade <= 5) {
        desconto = 0.02f;
    }
    else if (quantidade > 5 && quantidade <= 10 ) {
        desconto = 0.03f;
    }
    else {
        desconto = 0.05f;
    }
    totalapagar = Calculartotal(preco, quantidade, total) - (Calculartotal(preco, quantidade, total) * desconto);
    return totalapagar;
}

static float Calculartotal(float preco, float quantidade, float total){
    total = preco * quantidade;
    return total;
}
