// JEU SMAXELLE

// PRESENTATION

// début du jeu : affichage du plateau de jeu et du nom, comme une interface de jeu numérique
System.Console.WriteLine("Bonjour et bienvenue sur le jeu ");
System.Console.WriteLine("**********SMAXELLE**********");
System.Console.WriteLine("Le but du jeu est de gagner un maximum de points en assemblant les bonbons identiques ensemble.");
System.Console.WriteLine("Votre terrain de jeu sera ce plateau : ");


//CREATION DU plateauDeJeu :

//Création d'un tableau imbriqué de char qui s'appelle plateauDeJeu de 9 lignes et de ? colonnes
char [][] plateauDeJeu = new char [9][];

//Création des 9 colonnes pour chacune des 9 lignes 
for (int i = 0; i < 9; i++)//i se balade dans les lignes du plateauDeJeu
{
    plateauDeJeu[i]=new char[9];//dans chaque ligne, on y met 9 colonnes
}
//on a ainsi un plateau de jeu de 16 cases de jeu, et tout le reste des cases permettent de dessiner le cadrillage


//REMPLISSAGE DU plateauDeJeu

//Remplissage de '|' :
for (int k = 0; k < 8; k++)
{
    for (int m = 0; m < 5; m++)//m prend les valeurs 0, 1, 2, 3 et 4
    {
        plateauDeJeu[k][2*m]='|';//2*m prend les valeurs 0, 2, 4, 6 et 8
    }
}

//Remplissage de '-' :
//Remplissage de la toute première ligne et de la toute dernière :
for (int m = 0; m < 8; m++)
{
    plateauDeJeu[0][m]='-';
    plateauDeJeu[8][m]='-';
}

for (int n = 0; n < 4; n++)//n prend les valeurs 0, 1, 2 et 3
{
    //2*n+1 prendra ainsi les valeurs 1, 3, 5 et 7
    for (int p = 1; p < 4; p++)//p prend les valeurs 1, 2 et 3, donc 2*p prend les valeurs 2, 4 et 6
    {
        plateauDeJeu[2*p][2*n+1]='-';
    }
}

//Remplissage de '.' (pour les quatres sommets du grand carré)
plateauDeJeu[0][0]='.';
plateauDeJeu[0][8]='.';
plateauDeJeu[8][0]='.';
plateauDeJeu[8][8]='.';

//Remplissage de toutes les cases non remplies de vide, soit de ' '.
for (int ligne = 0; ligne < 9; ligne++)//la variable ligne se balade dans les lignes
{
    for (int colonne = 0; colonne < 9; colonne++)//la variable colonne se balade dans les colonnes
    {
        if (plateauDeJeu[ligne][colonne] != '-' && plateauDeJeu[ligne][colonne] != '|' && plateauDeJeu[ligne][colonne]!='.')//si la case n'est pas remplie d'un '_' ni d'un '.' ni d'un '|'
        {
            plateauDeJeu[ligne][colonne] = ' ';//ALORS on la remplie de vide  
        }
    }
}
//le plateauDeJeu est à présent initialisé (les bordures sont créées, et les 16 cases de jeu sont remplies de vide)


// FONCTION AFFICHERLEJEU

//création du sous-programme AfficherLeJeu qui nous permettra, lorsqu'il sera appelé, d'afficher la totalité du plateau de jeu
void AfficherLeJeu(char[][] tab)
{
    for (int ligne = 0; ligne < tab.Length; ligne++)
    {
        for (int colonne = 0; colonne < tab[ligne].Length; colonne++)
        {
            Console.Write(tab[ligne][colonne] + " ");
        }
        Console.WriteLine(); // Pour passer à la ligne suivante après chaque ligne
    }
}

//Utilisation du sous-programme qui vient d'être créé, afin d'afficher le plateau de jeu vide
AfficherLeJeu(plateauDeJeu);


// NOMBRE DE COUPS

//on demande au joueur le nombre de coups maximum autorisé
int nbCoupsMax;
Console.Write("Veuillez entrer le nombre de coups maximum : ");
nbCoupsMax = Convert.ToInt32(Console.ReadLine()!);

// on affiche à nouveau le nombre de coups
Console.WriteLine($"Vous avez choisi {nbCoupsMax} coups.");


// DEBUT DU JEU ET CONSIGNES

//on dit au joueur que le jeu va commencer et on lui explique les règles
Console.WriteLine();
Console.WriteLine("Le jeu va dès à présent débuter.");
Console.WriteLine($"Vous allez devoir assembler les bonbons de même forme afin d'obtenir un maximum de points en seulement {nbCoupsMax} coups!");
Console.WriteLine("Pour déplacer les bonbons vers le haut, veuillez entrer la lettre E.");
Console.WriteLine("Pour déplacer les bonbons vers le bas, veuillez entrer la lettre D.");
Console.WriteLine("Pour déplacer les bonbons vers la droite, veuillez entrer la lettre F.");
Console.WriteLine("Pour déplacer les bonbons vers la gauche, veuillez entrer la lettre S.");
Console.WriteLine("BONNE CHANCE!");
Console.WriteLine();


// PLACER LES BONBONS ALEATOIREMENT

//création d'une fonction qui pourra se répéter à chaque fin de partie
//la fonction prend en argument le plateau de jeu afin de le compléter

void PlacerBonbonsAleatoirement (char[][] tab)
{
    for (int bonbon = 1; bonbon<=2; bonbon++) // utilisation d'une boucle afin de répéter l'opération deux fois
    {
        Random caseDuPlateau = new Random(); // utilisation d'un tirage pour déterminer une ligne et une colonne aléatoirement
        int ligne;
        int colonne;
        do
        {
            ligne = caseDuPlateau.Next(0, 9);
            colonne = caseDuPlateau.Next(0, 9);
        }
        while (tab[ligne][colonne]!=' '); // la boucle do-while continue tant que la case choisie n'est pas vide, peu importe le bonbon qu'elle comporte
        tab[ligne][colonne]='¤';// lorsque la boucle est finie, le premier bonbon est attribué à la case choisie
    }
}

// on affiche à nouveau le plateau afin que le joueur puisse reconnaitre les nouveaux bonbons
// pour cela, on appelle ainsi à nouveau PlacerBonbonsAleatoirement et AfficherLeJeu
PlacerBonbonsAleatoirement(plateauDeJeu);
AfficherLeJeu(plateauDeJeu);


// FAIRE FONCTIONNER LE JEU PAR UNE BOUCLE

// le jeu doit s'arrêter lorsque le nombre de coups maximum (nbCoupsMax) est atteint ou lorsque le plateau est bloqué
// dans ce but, une boucle est placée avant le déroulement d'un tour
// nous utilisons une boucle do-while afin que les tours se suivent jusqu'à ce que la condition ne soit plus remplie
int nbDeTours=1; // nbDeTours est une variable utilisée en tant que compteur
bool jeuBloqué=false; // création d'une variable jeuBloqué qui nous permettra de déterminer lorsque le jeu est bloqué

do
{
// DEROULEMENT D'UN TOUR 

// création d'une variable directionVoulue
char directionVoulue;
// demander au joueur de choisir une direction
// utilisation de ESDF pour que chaque forme d'ordinateur s'y retrouve
Console.Write("Choisissez une direction (E vers le haut, D vers le bas, S vers la gauche, F vers la droite) : ");
directionVoulue = Convert.ToChar(Console.ReadLine()!);

// si la personne se trompe de touche et mets une autre lettre, le programme lui demande de recommencer
// boucle while parce que l'action va se répéter tant que l'utilisateur ne rentre pas une des lettres proposées
// utilisation des "&&" donc "et" parce que l'utilisateur a le choix entre ces 4 lettres et doit en choisir une
while (directionVoulue!='E' && directionVoulue!='D' && directionVoulue!='S' && directionVoulue!='F')
{
    Console.WriteLine("ERREUR");
    Console.Write("Choisissez à nouveau une direction parmi les propositions (E vers le haut, D vers le bas, S vers la gauche, F vers la droite) : ");
    directionVoulue = Convert.ToChar(Console.ReadLine()!);
}


//
//
// PROGRAMME DE ESMA
//
//


// à la fin du tour, on rajoute des bonbons aléatoirement dans le plateau de jeu
// on appelle ainsi à nouveau PlacerBonbonsAleatoirement et AfficherLeJeu

PlacerBonbonsAleatoirement(plateauDeJeu);
AfficherLeJeu(plateauDeJeu);

// VERIFICATION PLATEAU PLEIN

// afin de verifier que le plateau n'est pas plein, on parcourt chaque case du plateauDeJeu, d'où le double for pour les lignes et les colonnes
int nbCasesVides=0; // création de la variable nbCasesVides qui va servir de compteur et nous permettre de savoir si le plateau possède encore de l'espace
for (int i = 0; i < plateauDeJeu.Length; i++)
{
    for (int j = 0; j < plateauDeJeu.Length; j++)
    {
        if (plateauDeJeu[i][j]==' '){nbCasesVides++;} //on regarde si la case i,j est bien vide et si c'est le cas, le compteur augmente
    }
}
if (nbCasesVides==0) {jeuBloqué=true;} // si le compteur vaut 0, alors le plateau est plein et le jeu doit s'arrêter


nbDeTours++; // le compteur nbDeTours s'incrémente de 1 afin de compter le nombre de tours et de s'arrêter lorsque le maximum est atteint

}
while (nbDeTours<=nbCoupsMax && jeuBloqué==false);


// CAUSE FIN DU JEU
Console.WriteLine();
Console.WriteLine("FIN DE LA PARTIE");
Console.WriteLine();
// lorsque le jeu se finit, le joueur voit apparaitre la cause
// on utilise une boucle if dans le but de différencier les deux possibilités
if (jeuBloqué==true) {Console.WriteLine("Vous avez rempli chaque case du plateau, le jeu est bloqué et s'arrête là !");}
else {Console.WriteLine($"Vous avez joué {nbCoupsMax} coup(s), soit le maximum de coups possibles !");}


// CALCUL ET AFFICHAGE DU SCORE
// le score est calculé à la fin de la partie. Le programme parcourt chaque case du tableau est somme les valeurs de chaque bonbon présent
int scoreFinal=0; // création de la variable nbCasesVides qui va servir de compteur et nous permettre de savoir si le plateau possède encore de l'espace
for (int i = 0; i < plateauDeJeu.Length; i++)
{
    for (int j = 0; j < plateauDeJeu.Length; j++)
    {
        if (plateauDeJeu[i][j]=='¤'){scoreFinal+=1;} // si la case comporte un bonbon, la valeur est de 1 point
        if (plateauDeJeu[i][j]=='@'){scoreFinal+=3;} // si la case comporte un réglisse, la valeur est de 3 points
        if (plateauDeJeu[i][j]=='o'){scoreFinal+=7;} // si la case comporte un cookie, la valeur est de 7 points
        if (plateauDeJeu[i][j]=='J'){scoreFinal+=15;} // si la case comporte un sucre d'orge, la valeur est de 15 points
    }
}

Console.WriteLine();
Console.WriteLine("*********************************************************************");
Console.WriteLine($"Vous obtenez un superbe score de {scoreFinal} points! Félicitations!");
Console.WriteLine("*********************************************************************");
Console.WriteLine();
