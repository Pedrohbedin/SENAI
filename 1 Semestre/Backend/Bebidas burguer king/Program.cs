Console.WriteLine("Escolha uma das bebidas abaixo:");
    Console.WriteLine("1 - Coca cola");
    Console.WriteLine("2 - Pepsi");
    Console.WriteLine("3 - Fanta");
    Console.WriteLine("4 - Monster");
    Console.WriteLine("5 - Chá Gelado");
    Console.WriteLine("6 - Guaraná");

    int opcao = int.Parse(Console.ReadLine());

    string bebida = "";

    switch(opcao) {
      case 1:
        bebida = "Coca cola";
        break;
      case 2:
        bebida = "Pepsi";
        break;
      case 3:
        bebida = "Fanta";
        break;
      case 4:
        bebida = "Monster";
        break;
    case 5:
        bebida = "Fanta";
        break;
    case 6:
        bebida = "Guaraná";
        break;
      default:
        Console.WriteLine("Opção inválida");
        break;
    }

    if (bebida != "") {
      Console.WriteLine("Deseja adicionar gelo à sua " + bebida + "? (s/n)");
      char resposta = char.Parse(Console.ReadLine().ToLower());

      if (resposta == 's') {
        Console.WriteLine("Sua " + bebida + " será servida com adicional de gelo");
      } else if (resposta == 'n') {
        Console.WriteLine("Sua " + bebida + " será servida sem adicional de gelo");
      }
      else {
        Console.WriteLine("ERROR");
      }
    }