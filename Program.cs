// Brief SIMPLON Calculatrice C#
List<double> numbers = new List<double>();
String verif;
String cadre;

cadre = "----------------------------";

void Calcul(List<double> result) // Function saisie de nombre ( les nombres saisie son stocké dans la list numbers qui elle meme est stocké dans la list result ). 
{
    result.Clear();
    bool continueInput = true;

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("\t-- Entrez des nombres --");
    Console.ForegroundColor = ConsoleColor.White;
        
    while (continueInput)
    {
        Console.Write("\nSaisir une valeur : ");
        if (double.TryParse(Console.ReadLine(), out double number))
        {
            result.Add(number);
            Console.WriteLine($"Nombre ajouté : {number}");
        }
        else
        {
            Console.WriteLine("Entrée invalide. Veuillez saisir un nombre valide.");
        }
        
        Console.Write("Voulez-vous ajouter un autre nombre ? (y/n) : ");
        verif = Console.ReadLine().ToLower();
        if (verif != "y")
        {
            continueInput = false;
        }
    }

    Console.WriteLine("Nombres saisis : " + string.Join(", ", result));
    Console.WriteLine("Appuyez sur une touche pour retourner au menu...");
    Console.ReadKey();
    Console.Clear();
}

void AddCalc(List<double> result) // Function Addition.
{
    if (result.Count >= 2) // Verifie si il y'a bien deux nombres min rentrer dans la saisie pour faire l'operation.
    {
        double sum = result.Sum();
        GreenColors();
        Console.WriteLine(cadre);
        Console.Write($"Le résultat de l'addition est : {sum}");
        Console.WriteLine("\n" + cadre);
        WhiteColors();
    }
    else // sinon message d'erreur.
    {
        RedColors();
        Console.WriteLine("Veuillez d'abord saisir au moins deux nombres.");
        WhiteColors();
    }
}

void SousCalc(List<double> result) // Function Soustraction.
{
    if (result.Count >= 2) // Verifie si il y'a bien deux nombres min rentrer dans la saisie pour faire l'operation.
    {
        double diff = result[0];
        for (int i = 1; i < result.Count; i++) // Boucle for
        {
            diff -= result[i]; // prend les nombre dans la liste et les soustrait.
        }
        GreenColors();
        Console.WriteLine(cadre);
        Console.Write($"Le résultat de la soustraction est : {diff}");
        Console.WriteLine("\n" + cadre);
        WhiteColors();
    }
    else // Message d'erreur. 
    {
        RedColors();
        Console.WriteLine("Veuillez d'abord saisir au moins deux nombres.");
        WhiteColors();
    }
}

void MultCalc(List<double> result) // Function Multiplication.
{
    if (result.Count >= 2) // Verifie si il y'a bien deux nombres min rentrer dans la saisie pour faire l'operation.
    {
        double product = result.Aggregate((a, b) => a * b); // fait le calcul.
        GreenColors();
        Console.WriteLine(cadre);
        Console.Write($"Le résultat de la multiplication est : {product}");
        Console.WriteLine("\n" + cadre);
        WhiteColors();
    }
    else // Sinon message d'erreur.
    {
        RedColors();
        Console.WriteLine("Veuillez d'abord saisir au moins deux nombres.");
        WhiteColors();
    }
}

void DivCalc(List<double> result) // Function Division.
{
    if (result.Count >= 2) // Verifie si il y'a bien deux nombres min rentrer dans la saisie pour faire l'operation.
    {
        double quotient = result[0];
        for (int i = 1; i < result.Count; i++)
        {
            if (result[i] != 0) // Verifie que ce n'est pas une division par zero.
            {
                quotient /= result[i]; // Calcul
            }
            else // Message pas divisible par zero.
            {
                RedColors();
                Console.WriteLine("Division par zéro impossible.");
                WhiteColors();
                return;
            }
        }

        GreenColors();
        Console.WriteLine(cadre);
        Console.Write($"Le résultat de la division est : {quotient}");
        Console.WriteLine("\n" + cadre);
        WhiteColors();
    }
    else // Message si il n'y a pas de données numbers.
    {
        RedColors();
        Console.WriteLine("Veuillez d'abord saisir au moins deux nombres.");
        WhiteColors();
    }
}

void DisplayMenu() // Menu
{
    List<double> result = new List<double>();
    bool isEnd = false;
    do
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\t---- Calculatrice ----\n");
        WhiteColors();
        Console.WriteLine("\t-------------------------");
        Console.WriteLine("\t| Saisir des nombres  1 |");
        Console.WriteLine("\t| Additionner         2 |");
        Console.WriteLine("\t| Soustraire          3 |");
        Console.WriteLine("\t| Multiplier          4 |");
        Console.WriteLine("\t| Diviser             5 |");
        Console.WriteLine("\t| Quitter             0 |");
        Console.WriteLine("\t-------------------------");
        Console.Write("Faites votre choix : ");
        bool isValidChoice = int.TryParse(Console.ReadLine(), out int choice);
        switch (choice) // Creation des choix.
        {
            case 0:
                if (isValidChoice)
                {
                    isEnd = true;
                }
                break;
            case 1:
                Console.Clear();
                Calcul(result);
                break;
            case 2:
                Console.Clear();
                AddCalc(result);
                break;
            case 3:
                Console.Clear();
                SousCalc(result);
                break;
            case 4:
                Console.Clear();
                MultCalc(result);
                break;
            case 5:
                Console.Clear();
                DivCalc(result);
                break;
            default:
                Console.Clear();
                RedColors();
                Console.WriteLine("Erreur de saisie, faites votre choix !\n");
                WhiteColors();
                break;
        }

        if (!isValidChoice)
        {
            Console.Clear();
            RedColors();
            Console.WriteLine("Erreur de saisie, faites votre choix !\n");
            WhiteColors();
        }
    } while (!isEnd);
}

// Function colors pour evitier le copier coller ( et plus rapide a utiliser ).
void RedColors()
{
    Console.ForegroundColor = ConsoleColor.Red;
}
void GreenColors()
{
    Console.ForegroundColor = ConsoleColor.Green;
}
void WhiteColors()
{
    Console.ForegroundColor = ConsoleColor.White;
}

// On active le programme. 
DisplayMenu();