# EF Core Consignes - Agence de voyage

## Contexte

Créez une application pour la gestion d'une agence de voyage.
L'application doit permettre de gérer les destinations, les activités proposées, les réservations des clients.

## Modèles de données

1. **Destination**

   - Id (int, clé primaire auto-incrémentée)
   - Pays (string) ex: "France"
   - Nom (string) ex: "Paris"
   - Description (string) ex: "Ville lumière"

2. **Activité**

   - Id (int, clé primaire auto-incrémentée)
   - Nom (string) ex: "Visite du Louvre"
   - Description (string) ex: "Découverte des œuvres d'art"
   - Prix (decimal) ex: 50.00
   - Destination (relation vers Destination)

3. **Réservation**
   - Id (int, clé primaire auto-incrémentée)
   - ClientNom (string) ex: "Bill Cypher"
   - DateRéservation (DateTime) ex: "2024-07-15"
   - Activitées (relations vers Activité)

## Exemples de fonctionnement (Console)

### Menu principal

```
Bienvenue dans l'application de gestion de l'agence de voyage!
1. Ajouter une destination
2. Ajouter une activité
3. Voir les destinations
4. Faire une réservation
```

### Ajouter une destination

```
Enregistrer une nouvelle destination:
Entrez le pays: <France>
Entrez le nom de la destination: <Paris>
Entrez une description: <Ville lumière>
Destination ajoutée avec succès!

(Appuyer sur [ENTRER] pour revenir au menu)
```

### Ajouter une activité

```
Enregistrer une nouvelle activité:
Entrez le nom de l'activité: <Visite du Louvre>
Entrez une description: <Découverte des œuvres d'art>
Entrez le prix: <50.00>
Entrez l'ID de la destination: <1>
Activité ajoutée avec succès!

(Appuyer sur [ENTRER] pour revenir au menu)
```

### Voir les destinations

```
Liste des destinations:
1. France - Paris: Ville lumière
2. Italie - Rome: Ville éternelle
(Afficher toutes les destinations)

Sélectionnez une destination pour voir les activités (entrez l'ID ou 0 pour revenir au menu principal): <1>
Activités pour la destination France - Paris:
1. Visite du Louvre - 50.00 EUR
2. Tour Eiffel - 30.00 EUR
3. Croisière sur la Seine - 40.00 EUR

(Appuyer sur [ENTRER] pour revenir au menu)
```

### Faire une réservation

```
Faire une nouvelle réservation:
Entrez le nom du client: <Bill Cypher>
Entrez la date de réservation (YYYY-MM-DD): <2024-07-15>
Entrez l'ID du pays: <1>

Les activités disponibles pour cette destination sont:
1. Visite du Louvre - 50.00 EUR
2. Tour Eiffel - 30.00 EUR
3. Croisière sur la Seine - 40.00 EUR
(Afficher toutes les activités disponibles)

Entrez l'ID de l'activité (0 pour continuer): <1>
Entrez l'ID de l'activité (0 pour continuer): <2>
Entrez l'ID de l'activité (0 pour continuer): <0>

Réservation effectuée avec succès!

Nom du client: Bill Cypher
Date de réservation: 2024-07-15
Destinations: France
Activité:
- Visite du Louvre - 50.00 EUR
- Tour Eiffel - 30.00 EUR
Total: 80.00 EUR
```
