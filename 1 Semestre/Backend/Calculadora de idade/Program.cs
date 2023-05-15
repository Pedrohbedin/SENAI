Console.Write("Digite o ano do seu nascimento: ");
int anoNascimento = int.Parse(Console.ReadLine());

Console.Write("Digite o mês do seu nascimento: ");
int mesNascimento = int.Parse(Console.ReadLine());

Console.Write("Digite o dia do seu nascimento: ");
int diaNascimento = int.Parse(Console.ReadLine());

int idadeAnos = (int)Math.Floor((DateTime.Now - new DateTime(anoNascimento, mesNascimento, diaNascimento)).TotalDays / 365);
int idadeSemanas = (int)Math.Floor((DateTime.Now - new DateTime(anoNascimento, mesNascimento, diaNascimento)).TotalDays / 7);
int idade_meses = (int)Math.Floor((DateTime.Now - new DateTime(anoNascimento, mesNascimento, diaNascimento)).TotalDays / 12);
int idade_horas = (int)Math.Floor((DateTime.Now - new DateTime(anoNascimento, mesNascimento, diaNascimento)).TotalHours);
int idade_minutos = (int)Math.Floor((DateTime.Now - new DateTime(anoNascimento, mesNascimento, diaNascimento)).TotalMinutes);
int idade_dias = (int)Math.Floor((DateTime.Now - new DateTime(anoNascimento, mesNascimento, diaNascimento)).TotalDays);

Console.WriteLine($"\n-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");
Console.WriteLine($"\nIdade em anos: {idadeAnos}");
Console.WriteLine($"\nIdade em semanas: {idadeSemanas}");
Console.WriteLine($"\nIdade em meses: {idade_meses}");
Console.WriteLine($"\nIdade em dias: {idade_dias}");
Console.WriteLine($"\nIdade em horas: {idade_horas}");
Console.WriteLine($"\nIdade em minutos: {idade_minutos}");
Console.WriteLine($"\n-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-");

Console.WriteLine($"\nPress any key to continue...");

Console.ReadLine();