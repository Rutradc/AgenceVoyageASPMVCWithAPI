using AppAgency.Console;
using AppAgency.Console.Utils;

Console.WriteLine("Bienvenue dans l'application de gestion de l'agence de voyage!");

bool exit = false;
while (!exit)
{
    Console.Clear();
    Console.WriteLine(@"1. Ajouter une destination
2. Ajouter une activité
3. Voir les destinations
4. Faire une réservation

0. Quitter");
    int choice = InputUtils.ReadInt("Votre choix > ", 0, 4);

    switch (choice)
    {
        case 1:
            Functionnalite.AddDestination();
            break;
        case 2:
            Functionnalite.AddActivity();
            break;
        case 3:
            Functionnalite.ListDestination();
            break;
        case 4:
            Functionnalite.MakeBooking();
            break;
        case 0:
            Console.WriteLine("Aurevoir!");
            exit = true;
            break;
    }
}
