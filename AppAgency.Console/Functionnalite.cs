using AppAgency.Console.Utils;
using AppAgency.DAL;
using AppAgency.Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace AppAgency.Console
{
    public static class Functionnalite
    {
        public static void AddDestination()
        {
            System.Console.WriteLine("Ajouter une destination:");
            string country, name, description;
            System.Console.Write("Entrez le pays: ");
            country = System.Console.ReadLine() ?? "";
            System.Console.Write("Entrez le nom de la destination: ");
            name = System.Console.ReadLine() ?? "";
            System.Console.Write("Entrez une description: ");
            description = System.Console.ReadLine() ?? "";

            Destination dest = new Destination
            {
                Country = country,
                City = name,
                Description = description
            };
            using (AgenceDbContext dbContext = new AgenceDbContext())
            {
                dbContext.Destinations.Add(dest);
                try
                {
                    dbContext.SaveChanges();
                    System.Console.WriteLine("Destination ajoutée avec succès!");
                }
                catch (Exception ex)
                {
                    System.Console.WriteLine("Erreur lors de l'ajout de la destination: " + ex.Message);
                }
            }

            System.Console.WriteLine("(Appuyer sur [ENTRER] pour revenir au menu)");
            System.Console.ReadLine();
        }
    
        public static void AddActivity()
        {
            using (AgenceDbContext dbContext = new AgenceDbContext())
            {
                System.Console.WriteLine("Enregistrer une nouvelle activité:");
                string activityName, activityDescription;
                decimal price;
                int destinationId;
                System.Console.Write("Entrez le nom de l'activité: ");
                activityName = System.Console.ReadLine() ?? "";
                System.Console.Write("Entrez une description: ");
                activityDescription = System.Console.ReadLine() ?? "";
                System.Console.Write("Entrez le prix: ");
                price = InputUtils.ReadDecimal();

                bool giveUp = false;
                Destination? destination = null;
                do
                {
                    System.Console.Write("Entrez l'ID de la destination: ");
                    destinationId = InputUtils.ReadInt("", 1);
                    // check if destination exists

                    destination = dbContext.Destinations.FirstOrDefault(d => d.Id == destinationId);
                    if (destination is null)
                    {
                        System.Console.WriteLine("Destination non trouvée. Voulez-vous réessayer? (o/n)");
                        string? retry = System.Console.ReadLine();
                        if (retry?.ToLower() != "o")
                        {
                            giveUp = true;
                        }
                    }
                } while (giveUp == false && destination is null);

                if (destination is not null)
                {
                    Activity activity = new Activity()
                    {
                        Title = activityName,
                        Description = activityDescription,
                        Price = price,
                        Destination = destination
                    };

                    dbContext.Activities.Add(activity);
                    try
                    {
                        dbContext.SaveChanges();
                        System.Console.WriteLine("Activité ajoutée avec succès!");
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Erreur lors de l'ajout de l'activité: " + ex.Message);
                    }
                }
                else
                {
                    System.Console.WriteLine("Abandon de la création de l'activitée...");
                }

                System.Console.WriteLine("(Appuyer sur [ENTRER] pour revenir au menu)");
                System.Console.ReadLine();
            }
        }
    
        public static void ListDestination()
        {
            using (AgenceDbContext dbContext = new AgenceDbContext())
            {
                System.Console.WriteLine("Liste des destinations:");
                foreach (Destination desti in dbContext.Destinations)
                {
                    System.Console.WriteLine($"\t {desti.Id}. {desti.Country} - {desti.City}: {desti.Description}");
                }

                //Sélectionnez une destination pour voir les activités (entrez l'ID ou 0 pour revenir au menu principal): <1>
                Destination? selectedDestination = null;
                bool exitDestSelection = false;
                do
                {
                    int destId = InputUtils.ReadInt("Sélectionnez une destination pour voir les activités (entrez l'ID ou 0 pour revenir au menu principal):", 0);
                    if (destId == 0)
                    {
                        exitDestSelection = true;
                    }
                    else
                    {
                        selectedDestination = dbContext.Destinations
                            .Where(d => d.Id == destId)
                            .FirstOrDefault();
                        if (selectedDestination is null)
                        {
                            System.Console.WriteLine("Destination non trouvée.");
                        }
                    }
                } while (exitDestSelection == false && selectedDestination is null);

                if (selectedDestination is not null)
                {
                    System.Console.WriteLine($"Activités pour la destination {selectedDestination.Country} - {selectedDestination.City}:");
                    var activities = dbContext.Activities
                        .Where(a => a.Destination.Id == selectedDestination.Id)
                        .ToList();
                    foreach (var activity in activities)
                    {
                        System.Console.WriteLine($"\t {activity.Id}. {activity.Title} - {activity.Price:F2} EUR");
                    }
                }

                System.Console.WriteLine("(Appuyer sur [ENTRER] pour revenir au menu)");
                System.Console.ReadLine();
            }
        }
    
        public static void MakeBooking()
        {
            using (AgenceDbContext dbContext = new AgenceDbContext())
            {
                System.Console.WriteLine("Faire une nouvelle réservation:");
                string clientName;
                DateTime reservationDate;
                System.Console.Write("Entrez le nom du client: ");
                clientName = System.Console.ReadLine() ?? "";
                reservationDate = InputUtils.ReadDate("Entrez la date de réservation (YYYY-MM-DD): ");

                bool giveUpReservation = false;
                Destination? destinationReservation = null;
                do
                {
                    int destinationId = InputUtils.ReadInt("Entrez l'ID de la destination: ", 1);
                    // check if destination exists
                    destinationReservation = dbContext.Destinations.Include(d => d.Activities).FirstOrDefault(d => d.Id == destinationId);
                    if (destinationReservation is null)
                    {
                        System.Console.WriteLine("Destination non trouvée. Voulez-vous réessayer? (o/n)");
                        string? retry = System.Console.ReadLine();
                        if (retry?.ToLower() != "o")
                        {
                            giveUpReservation = true;
                        }
                    }
                } while (giveUpReservation == false && destinationReservation is null);

                if (destinationReservation is not null)
                {
                    System.Console.WriteLine($"Les activités disponibles pour cette destination sont:");
                    foreach (Activity a in destinationReservation.Activities)
                    {
                        System.Console.WriteLine($"\t {a.Id}. {a.Title} - {a.Price:F2} EUR");
                    }

                    List<Activity> selectedActivities = new List<Activity>();
                    bool selectingActivities = true;
                    do
                    {
                        int activityId = InputUtils.ReadInt("Entrez l'ID de l'activité (0 pour continuer): ", 0);
                        if (activityId == 0)
                        {
                            selectingActivities = false;
                        }
                        else
                        {
                            bool alreadySelected = selectedActivities.Any(a => a.Id == activityId);
                            if (alreadySelected)
                            {
                                System.Console.WriteLine("Activité déjà sélectionnée.");
                            }
                            else
                            {
                                Activity? selectedActivity = destinationReservation.Activities.FirstOrDefault(a => a.Id == activityId);
                                if (selectedActivity is not null)
                                {
                                    selectedActivities.Add(selectedActivity);
                                }
                                else
                                {
                                    System.Console.WriteLine("Activité non trouvée.");
                                }
                            }
                        }
                    } while (selectingActivities);

                    Booking booking = new Booking()
                    {
                        ClientName = clientName,
                        BookingDate = reservationDate,
                        Activities = selectedActivities,
                        Destination = destinationReservation
                    };
                    dbContext.Bookings.Add(booking);
                    try
                    {
                        dbContext.SaveChanges();
                        System.Console.WriteLine("Réservation effectuée avec succès!");
                        System.Console.WriteLine($"Nom du client: {booking.ClientName}");
                        System.Console.WriteLine($"Date de réservation: {booking.BookingDate:yyyy-MM-dd}");
                        System.Console.WriteLine($"Destination: {booking.Destination.Country} - {booking.Destination.City}");
                        System.Console.WriteLine("Activités:");
                        foreach (var act in booking.Activities)
                        {
                            System.Console.WriteLine($"- {act.Title} - {act.Price:F2} EUR");
                        }
                        decimal totalPrice = selectedActivities.Sum(a => a.Price);
                        System.Console.WriteLine($"Total: {totalPrice:F2} EUR");
                    }
                    catch (Exception ex)
                    {
                        System.Console.WriteLine("Erreur lors de la création de la réservation: " + ex.Message);
                    }
                }

                if (giveUpReservation)
                {
                    System.Console.WriteLine("Abandon de la réservation...");
                }

                System.Console.WriteLine("(Appuyer sur [ENTRER] pour revenir au menu)");
                System.Console.ReadLine();
            }
        }
    }
}
