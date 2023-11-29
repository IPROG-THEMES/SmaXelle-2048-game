// SmaXelle - JEU

// début 

// CREER LE PLATEAU


// NOMBRE DE COUPS
//on demande au joueur le nombre de coups maximum autorisé

using System.Collections;

int nbCoupsMax;
Console.Write("Veuillez entrer le nombre de coups maximum : ");
nbCoupsMax = Convert.ToInt32(Console.ReadLine()!);

// demander : si chiffre pas un int, message erreur + recommencer
if (nbCoupsMax)

// on affiche à nouveau le nombre de coups
Console.WriteLine($"Vous avez choisi {nbCoupsMax} coups.");



// DEBUT DU JEU ET CONSIGNES
//on dit au joueur que le jeu va commencer et on lui explique les règles
Console.WriteLine("Le jeu va dès à présent débuter.");
Console.WriteLine($"Vous allez devoir assembler les bonbons de même forme afin d'obtenir un maximum de points en seulement {nbCoupsMax} coups!");
Console.WriteLine("Pour déplacer les bonbons vers le haut, veuillez entrer la lettre E");
Console.WriteLine("Pour déplacer les bonbons vers le bas, veuillez entrer la lettre D");
Console.WriteLine("Pour déplacer les bonbons vers la droite, veuillez entrer la lettre F");
Console.WriteLine("Pour déplacer les bonbons vers la gauche, veuillez entrer la lettre S");
Console.WriteLine("BONNE CHANCE!");



// PLACER LES BONBONS ALEATOIREMENT
//création d'une fonction qui pourra se répéter à chaque fin de partie
//la fonction prend en argument le plateau de jeu afin de le compléter
void PlacerBonbonsAleatoirement (ref plateauDeJeu)
{
    for (int bonbon = 1; bonbon<=2; bonbon++) // utilisation d'une boucle afin de répéter l'opération deux fois
    {
        Random caseDuPlateau = new Random(); // utilisation d'un tirage pour déterminer une ligne et une colonne aléatoirement
        char caseChoisie;
        do
        {
            int ligne = caseDuPlateau.Next(0, 9);
            int colonne = caseDuPlateau.Next(0, 9);
            caseChoisie = plateauDeJeu[ligne,colonne];
        }
        while (caseChoisie!=' '); // la boucle do-while continue tant que la case choisie c'est pas vide, peu importe le bonbon qu'elle comporte
        caseChoisie='¤'; // lorsque la boucle est finie, le premier bonbon est attribué à la case choisie
    }
}
