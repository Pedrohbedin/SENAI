string resposta = "";
string input = "";
string answer = "";
string pergunta = "";


int e = 0;
//Nesta aula vamos aplicar o seguinte projeto para gerenciamento de 10 produtos pelo console:

//Os produtos terão os seguintes atributos:
string[] nome = new string[10];
float[]? preco = new float[10];
bool[] promocao = new bool[10];
//bool Promocao (se está em promoção ou não)

//O sistema deverá ter as seguintes funcionalidades:
//CadastrarProduto
//ListarProdutos
//MostrarMenu
//Crie função(ões) para otimizar o código.
//Incremente o que achar necessário. Utilize sua lógica e sua criatividade.
do {

        Console.WriteLine(MostrarMenu(resposta, input, nome, preco, promocao, answer, pergunta, e));
        testar(input, nome, preco, promocao, answer, pergunta, resposta, e);

} while (input != "0" && input != "1" && input != "2");



static string MostrarMenu(string resposta, string input, string[] ne, float[] pr, bool[] po, string answer, string pergunta, int e){

        Console.ForegroundColor = ConsoleColor.Blue;
                
        Console.WriteLine(@$"
        _____________________________
        |                           |
        |    0 - Sair               |
        |    1 - Cadastrar produtos |
        |    2 - Listar produtos    |
        |___________________________|

        ");

        Console.ResetColor();

        input = Console.ReadLine();

        if (input != "0" && input != "1" && input != "2") {
        Console.ForegroundColor = ConsoleColor.Red;

        Console.WriteLine($"\nResposta inválida, tente novamente...");
                
        }
        
        Console.ResetColor();

        testar(input, ne, pr, po, answer, pergunta, resposta, e);

        return resposta;
}
static void testar(string input, string[] ne, float[] pr, bool[] po, string answer, string pergunta, string resposta, int e) {
                switch (input) { 
                case "0":
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"Saindo do programa...");
                        Console.ResetColor();
                        Environment.Exit(0);
                break;
                case "1":
                for(int i = e; i < 10; i++) {
                        
                                
                        
                        do {
                                Console.WriteLine($"Insira o nome do produto:");
                                ne[i] = Console.ReadLine();
                                if (ne[i] == "") {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"\nResposta inválida, tente novamente...");
                                        Console.ResetColor();
                                }
                                else {
                                        e++;
                                }
                        } while (ne[i] == "");
                        do {
                                Console.WriteLine($"Insira o preco do produto:");
                                resposta = Console.ReadLine();
                                bool isNumber = float.TryParse(resposta, out pr[i]);
                                if (resposta == "" || pr[i] == 0) {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"\nResposta inválida, tente novamente...");
                                        Console.ResetColor();
                                }
                        } while (pr[i] == 0);
                        do {
                                Console.WriteLine($"O produto está em promoção? S/N");
                                pergunta = Console.ReadLine().ToUpper() ;
                                if (pergunta == "S") {
                                        po[i] = true;
                                }
                                else if (pergunta== "N") {
                                        po[i] = false;
                                }
                                else {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine($"Resposta inválida, tente novamente...");
                                        Console.ResetColor();
                                }
                        } while (pergunta != "S" && pergunta != "N");
                        
                        do {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine($"Deseja cadastrar mais um produto... S/N");
                        Console.ResetColor(); 
                        answer = Console.ReadLine().ToUpper();
                } while (answer != "S" && answer != "N");
                if (answer == "N") {
                        MostrarMenu(resposta, input, ne, pr, po, answer, pergunta, e);
                }
                }
                break;
                case "2":
                for(int i = 0; i < e; i++){
                Console.WriteLine($"\nNome {i+1}º produto: {ne[i]}");
                Console.WriteLine($"Preço {i+1}º produto: R${pr[i]}");
                if (po[i] == true) {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"O produto está em promoção\n");
                        Console.ResetColor();
                }
                else {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"O produto não está em promoção\n");
                        Console.ResetColor();
                }
                
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Finalizando programa..");
                Console.ResetColor();
                Environment.Exit(0);
                break;
                
        }
}