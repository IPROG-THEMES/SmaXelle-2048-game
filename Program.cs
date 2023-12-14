// JEU SMAXELLE
//AGEZ Axelle & HEBBAR Esma


//---------------------------------------------------------------------------------------------------------------------------

// PRESENTATION

// Début du jeu : affichage du plateau de jeu et du nom, comme une interface de jeu numérique
System.Console.WriteLine();
System.Console.WriteLine("Bonjour et bienvenue sur le jeu :");
System.Console.WriteLine("**********SMAXELLE**********");
System.Console.WriteLine("Le but du jeu est de gagner un maximum de points en assemblant les bonbons identiques ensemble.");
System.Console.WriteLine();


//---------------------------------------------------------------------------------------------------------------------------


//CREATION DE plateauDeJeu :

//Création d'un tableau imbriqué de char qui s'appelle plateauDeJeu de 9 lignes et de ? colonnes
char[][] plateauDeJeu = new char[9][];

//Création des 9 colonnes pour chacune des 9 lignes 
for (int i = 0; i < 9; i++)//i se balade dans les lignes du plateauDeJeu
{
    plateauDeJeu[i] = new char[9];//dans chaque ligne, on y met 9 colonnes
}
//On a ainsi un plateau de jeu de 16 cases de jeu, et la totalité du reste des cases permet de dessiner les délimitations.


//---------------------------------------------------------------------------------------------------------------------------


//REMPLISSAGE DU plateauDeJeu

//Remplissage de '|' :
for (int k = 0; k < 8; k++)
{
    for (int m = 0; m < 5; m++)//m prend les valeurs 0, 1, 2, 3 et 4
    {
        plateauDeJeu[k][2 * m] = '|';//2*m prend les valeurs 0, 2, 4, 6 et 8
    }
}

//Remplissage de '-' :
//Remplissage de la toute première ligne et de la toute dernière :
for (int m = 0; m < 8; m++)
{
    plateauDeJeu[0][m] = '-';
    plateauDeJeu[8][m] = '-';
}
//remplissage du reste des '-' nécessaires au plateu de jeu :
for (int n = 0; n < 4; n++)//n prend les valeurs 0, 1, 2 et 3
{
    //2*n+1 prendra ainsi les valeurs 1, 3, 5 et 7
    for (int p = 1; p < 4; p++)//p prend les valeurs 1, 2 et 3, donc 2*p prend les valeurs 2, 4 et 6
    {
        plateauDeJeu[2 * p][2 * n + 1] = '-';
    }
}

//Remplissage des '.' (pour les quatres sommets du grand carré)
plateauDeJeu[0][0] = '.';
plateauDeJeu[0][8] = '.';
plateauDeJeu[8][0] = '.';
plateauDeJeu[8][8] = '.';

//Remplissage de toutes les cases non remplies de vide, soit de : ' '.
for (int ligne = 0; ligne < 9; ligne++)//la variable ligne se balade dans les lignes
{
    for (int colonne = 0; colonne < 9; colonne++)//la variable colonne se balade dans les colonnes
    {
        if (plateauDeJeu[ligne][colonne] != '-' && plateauDeJeu[ligne][colonne] != '|' && plateauDeJeu[ligne][colonne] != '.')//si la case n'est pas remplie d'un '_' ni d'un '.' ni d'un '|'
        {
            plateauDeJeu[ligne][colonne] = ' ';//ALORS on la remplie de vide  
        }
    }
}
//Le plateauDeJeu est à présent initialisé (les bordures sont créées, et les 16 cases de jeu sont remplies de vide).


//---------------------------------------------------------------------------------------------------------------------------


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
        Console.WriteLine(); //Pour passer à la ligne suivante après chaque ligne.
    }
}

//Utilisation du sous-programme qui vient d'être créé, afin d'afficher le plateau de jeu vide.
System.Console.WriteLine("Vous jouerez ainsi sur le plateau de jeu suivant : ");
AfficherLeJeu(plateauDeJeu);


//---------------------------------------------------------------------------------------------------------------------------


// NOMBRE DE COUPS

//on demande au joueur le nombre de coups maximum qu'il autorise :
int nbCoupsMax;
Console.Write("Veuillez entrer le nombre de coups maximum : ");
nbCoupsMax = Convert.ToInt32(Console.ReadLine()!);

// on affiche à nouveau le nombre de coups
Console.WriteLine($"Vous avez choisi {nbCoupsMax} coups.");


//---------------------------------------------------------------------------------------------------------------------------


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


//---------------------------------------------------------------------------------------------------------------------------


// CHERCHER LE NOMBRE DE CASES VIDES
//création d'une fonction qui pourra se répéter à chaque fin de partie
// elle prend en argument le plateau de jeu afin de le compléter

int ChercherNbCasesVides (char[][] tab)
{
    int nbCasesVides=0; // création de la variable nbCasesVides qui va servir de compteur et nous permettre de savoir si le plateau possède encore de l'espace

    for (int i = 0; i < plateauDeJeu.Length; i++)
    {
        for (int j = 0; j < plateauDeJeu.Length; j++)
        {
            if (plateauDeJeu[i][j]==' '){nbCasesVides++;} //on regarde si la case i,j est bien vide et si c'est le cas, le compteur augmente
        }
    }

    return nbCasesVides;
}


//---------------------------------------------------------------------------------------------------------------------------


// PLACER LES BONBONS ALEATOIREMENT

//création d'une fonction qui pourra se répéter à chaque fin de partie
//la fonction prend en argument le plateau de jeu afin de le compléter

void PlacerBonbonsAleatoirement (char[][] tab)
{
    ChercherNbCasesVides (plateauDeJeu);
    
    if (ChercherNbCasesVides(plateauDeJeu)==1)
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
        tab[ligne][colonne]='¤';// lorsque la boucle est finie, le bonbon est attribué à la case choisie
    }
    if (ChercherNbCasesVides(plateauDeJeu)>=2)
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
}

// on affiche à nouveau le plateau afin que le joueur puisse reconnaitre les nouveaux bonbons
// pour cela, on appelle ainsi à nouveau PlacerBonbonsAleatoirement et AfficherLeJeu
PlacerBonbonsAleatoirement(plateauDeJeu);
AfficherLeJeu(plateauDeJeu);
Console.WriteLine("");


//---------------------------------------------------------------------------------------------------------------------------


//CREATION DE FONCTIONS QUI SERONT APPELEES PAR LA SUITE :
//Création des fonctions FusionGoRight, FusionGoLeft, FusionGoUp et FusionGoDown :

//1.FusionGoRight : fonction qui permet de fusionner deux éléments identiques et de mettre l'élément résultant de la fusion dans la case la plus à droite entre les deux cases évaluées (pour toutes les lignes)
void FusionGoRight(char[][] tab)
{
    for (int j = 0; j < 4; j++)//j permet de parcourir chaque ligne du tableau
    {
        int i =2*j+1; // i nous permet d'obtenir les indices des lignes sur les lesquelles on joue seulement (et non les lignes de délimitations des cases), ce qui permet au programme de ne pas tester des cases 'inutilement'
        //stockage des valeurs de chacune des cases de jeu de chacune des lignes, avec var1 celle la plus à droite, et var4 celle la plus à gauche
        char var1 = tab[i][7];
        char var2 = tab[i][5];
        char var3 = tab[i][3];
        char var4 = tab[i][1];
        //#0 : cas où une ligne entière est remplie par la même treat
        if (var1==var2 && var1==var3 && var1==var4 && var1!=' ')
        {
            //on fusionne les treats, et on met le résultat de la fusion dans la case la plus à droite entre les deux cases évaluées
            if (var1 == '¤')
            {
                tab[i][7] = '@';
                tab[i][5] = ' ';//on vide la case de gauche puisqu"='on veut aller à droite
                tab[i][3] = '@';
                tab[i][1] = ' ';//on vide la case de gauche
            }
            if (var1 == '@')
            {
                tab[i][7] = 'o';
                tab[i][5] = ' ';
                tab[i][3] = 'o';
                tab[i][1] = ' ';
            }
            if (var1 == 'o')
            {
                tab[i][7] = 'J';
                tab[i][5] = ' ';
                tab[i][3] = 'J';
                tab[i][1] = ' ';
            }
        }
        //#1
        else if (var1 != ' ' && var1 == var2)//on a alors le même bonbon dans les 2 cases les plus à droite, et on est sûr de ne pas avoir de vide dans ces deux cases là
        {
            //fusionnage des treats, et on met le résultat de la fusion dans la case la plus à droite entre les deux cases évaluées
            if (var1 == '¤')
            {
                tab[i][7] = '@';//on met le résultat de la fusion dans la case de droite
                tab[i][5] = ' ';//on vide la case de gauche
            }
            if (var1 == '@')
            {
                tab[i][7] = 'o';//on met le résultat de la fusion dans la case de droite
                tab[i][5] = ' ';//on vide la case de gauche
            }
            if (var1 == 'o')
            {
                tab[i][7] = 'J';//on met le résultat de la fusion dans la case de droite
                tab[i][5] = ' ';//on vide la case de gauche
            }
        }
        //#2
        else if (var1!=' ' && var1!=var2 && var2!=' ' && var2==var3 && var3==var4)
        {
            if (var2 == '¤')
            {
                tab[i][5] = '@';
                tab[i][3] = ' ';
            }
            if (var2 == '@')
            {
                tab[i][5] = 'o';
                tab[i][3] = ' ';
            }
            if (var2 == 'o')
            {
                tab[i][5] = 'J';
                tab[i][3] = ' ';
            }
        }
        //#9
        else if(var1!=' ' && var1==var2 && var2==var3 && var4!=var1)
        {
            if (var2 == '¤')
            {
                tab[i][7] = '@';
                tab[i][1] = ' ';
            }
            if (var2 == '@')
            {
                tab[i][7] = 'o';
                tab[i][1] = ' ';
            }
            if (var2 == 'o')
            {
                tab[i][7] = 'J';
                tab[i][1] = ' ';
            }
        }
        //#3
        else if (var2 != ' ' && var3 == var2)
        {
            if (var2 == '¤')
            {
                tab[i][5] = '@';
                tab[i][3] = ' ';
            }
            if (var2 == '@')
            {
                tab[i][5] = 'o';
                tab[i][3] = ' ';
            }
            if (var2 == 'o')
            {
                tab[i][5] = 'J';
                tab[i][3] = ' ';
            }

        }
        //#4
        else if (var4 != ' ' && var3 == var4)
        {
            if (var3 == '¤')
            {
                tab[i][3] = '@';
                tab[i][1] = ' ';
            }
            if (var3 == '@')
            {
                tab[i][3] = 'o';
                tab[i][1] = ' ';
            }
            if (var3 == 'o')
            {
                tab[i][3] = 'J';
                tab[i][1] = ' ';
            }
        }
        //#5
        else if (var4 != ' ' && var2 == ' ' && var3 == ' ' && var1 == var4)
        {
            if (var1 == '¤')
            {
                tab[i][7] = '@';
                tab[i][1] = ' ';
            }
            if (var1 == '@')
            {
                tab[i][7] = 'o';
                tab[i][1] = ' ';
            }
            if (var1 == 'o')
            {
                tab[i][7] = 'J';
                tab[i][1] = ' ';
            }
        }
        //#6
        else if (var1 != ' ' && var2 == ' ' && var3 == var1)//On met un 'else if' ici puisqu'on veut que la condition soit true ssi les conditions précédentes étaient toutes fausses. 
        //En effet, on veut que cette partie du code ne concerne que le cas où il y a deux treats dès le début à fusionner, mais qui ne résultent pas d'une fusion due à l'un des 'if' précédents.
        {
            if (var3 == '¤')
            {
                tab[i][7] = '@';
                tab[i][3] = ' '; 
            }
            if (var3 == '@')
            {
                tab[i][7] = 'o';
                tab[i][3] = ' ';
            }
            if (var3 == 'o')
            {
                tab[i][7] = 'J';
                tab[i][3] = ' ';
            }
        }
        //#7
        else if ( var4 != ' ' && var1 == ' ' && var3 == ' ' && var2 == var4)
        {
            if (var2 == '¤')
            {
                tab[i][5] = '@';
                tab[i][1] = ' ';
            }
            if (var2 == '@')
            {
                tab[i][5] = 'o';
                tab[i][1] = ' ';
            }
            if (var2 == 'o')
            {
                tab[i][5] = 'J';
                tab[i][1] = ' ';
            }
        }
        //#8
        else if ( var4 != ' ' && var1 != ' ' && var3 == ' ' && var2 == var4 && var1!=var2)
        {
            if (var2 == '¤')
            {
                tab[i][5] = '@';
                tab[i][1] = ' ';
            }
            if (var2 == '@')
            {
                tab[i][5] = 'o';
                tab[i][1] = ' ';
            }
            if (var2 == 'o')
            {
                tab[i][5] = 'J';
                tab[i][1] = ' ';
            }
        }
    }
}

//2.FusionGoLeft
void FusionGoLeft(char[][] tab)
{
    for (int j = 0; j < 4; j++)//i permet de passer sur chaque ligne du tableau, et ainsi de trier toutes les lignes
    {
        int i =2*j+1; // i nous permet d'obtenir les indices des lignes sur les lesquelles on joue seulement (et non les lignes de délimitations des cases)
        
        //stockage des valeurs de chacune des cases de la première ligne, avec var1 celle la + à droite et var4 celle la + à gauche :
        char var1 = tab[i][1];
        char var2 = tab[i][3];
        char var3 = tab[i][5];
        char var4 = tab[i][7];

        if(var1==var2 && var1==var3 && var1==var4 && var1!=' ')        
        {
            if (var1 == '¤')
            {
                tab[i][1] = '@';
                tab[i][3] = ' ';
                tab[i][5] = '@';
                tab[i][7] = ' ';
            }
            if (var1 == '@')
            {
                tab[i][1] = 'o';
                tab[i][3] = ' ';
                tab[i][5] = 'o';
                tab[i][7] = ' ';
            }
            if (var1 == 'o')
            {
                tab[i][1] = 'J';
                tab[i][3] = ' ';
                tab[i][5] = 'J';
                tab[i][7] = ' ';
            }
        }
        else if (var1 != ' ' && var1 == var2)//on a alors le même bonbon dans les 2cases les + à gauche, et on est sûr de ne pas avoir de vide dans ces deux cases là
        {
            //fusionnage des bonbons, et on met le résultat de la fusion dans la case la plus à gauche entre les deux cases évaluées
            if (var1 == '¤')
            {
                tab[i][1] = '@';
                tab[i][3] = ' ';
            }
            if (var1 == '@')
            {
                tab[i][1] = 'o';
                tab[i][3] = ' ';
            }
            if (var1 == 'o')
            {
                tab[i][1] = 'J';
                tab[i][3] = ' ';
            }
        }
        else if (var1!=' ' && var1!= var2 && var2 !=' ' && var2==var3 && var3==var4)
        {
            if (var2 == '¤')
            {
                tab[i][3] = '@';
                tab[i][5] = ' ';
            }
            if (var2 == '@')
            {
                tab[i][3] = 'o';
                tab[i][5] = ' ';
            }
            if (var2 == 'o')
            {
                tab[i][3] = 'J';
                tab[i][5] = ' ';
            }
        }
        else if (var1==var2 &&  var2==var3 && var3!= ' ' &&var3!=var4)
        {
            if (var2 == '¤')
            {
                tab[i][1] = '@';
                tab[i][3] = ' ';
            }
            if (var2 == '@')
            {
                tab[i][1] = 'o';
                tab[i][3] = ' ';
            }
            if (var2 == 'o')
            {
                tab[i][1] = 'J';
                tab[i][3] = ' ';
            }
        }
        else if (var2 != ' ' && var3 == var2)
        {
            if (var2 == '¤')
            {
                tab[i][3] = '@';
                tab[i][5] = ' ';
            }
            if (var2 == '@')
            {
                tab[i][3] = 'o';
                tab[i][5] = ' ';
            }
            if (var2 == 'o')
            {
                tab[i][3] = 'J';
                tab[i][5] = ' ';
            }
        }
        else if (var4 != ' ' && var3 == var4)
        {
            if (var3 == '¤')
            {
                tab[i][5] = '@';
                tab[i][7] = ' ';
            }
            if (var3 == '@')
            {
                tab[i][5] = 'o';
                tab[i][7] = ' ';
            }
            if (var3 == 'o')
            {
                tab[i][5] = 'J';
                tab[i][7] = ' ';
            }
        }
        else if (var4 != ' ' && var2 == ' ' && var3 == ' ' && var1 == var4)
        {
            if (var1 == '¤')
            {
                tab[i][1] = '@';
                tab[i][7] = ' ';
            }
            if (var1 == '@')
            {
                tab[i][1] = 'o';
                tab[i][7] = ' ';
            }
            if (var1 == 'o')
            {
                tab[i][1] = 'J';
                tab[i][7] = ' ';
            }
        }
        else if (var1 != ' ' && var2 == ' ' && var3 == var1)
        {
            if (var3 == '¤')
            {
                tab[i][1] = '@';
                tab[i][5] = ' ';
            }
            if (var3 == '@')
            {
                tab[i][1] = 'o';
                tab[i][5] = ' ';
            }
            if (var3 == 'o')
            {
                tab[i][1] = 'J';
                tab[i][5] = ' ';
            }
        }
        else if ( var4 != ' ' && var1 == ' ' && var3 == ' ' && var2 == var4)
        {
            if (var2 == '¤')
            {
                tab[i][3] = '@';
                tab[i][7] = ' ';
            }
            if (var2 == '@')
            {
                tab[i][3] = 'o';
                tab[i][7] = ' ';
            }
            if (var2 == 'o')
            {
                tab[i][3] = 'J';
                tab[i][7] = ' ';
            }
        }
        else if ( var4 != ' ' && var1 != ' ' && var3 == ' ' && var2 == var4 && var1!=var2)
        {
            if (var2 == '¤')
            {
                tab[i][3] = '@';
                tab[i][7] = ' ';
            }
            if (var2 == '@')
            {
                tab[i][3] = 'o';
                tab[i][7] = ' ';
            }
            if (var2 == 'o')
            {
                tab[i][3] = 'J';
                tab[i][7] = ' ';
            }
        }
        
    }
}

//3. FusionGoUp
void FusionGoUp(char[][] tab)
{
    for (int j = 0; j < 4; j++)//i permet de passer sur chaque colonne du tableau, et ainsi de trier toutes les lignes
    {
        int i =2*j+1; // i nous permet d'obtenir les indices des colonnes sur les lesquelles on joue seulement (et non les colonnes de délimitations des cases)
        
        //parcours du plateau de jeu colonne par colonne :
        char var1 = tab[1][i];
        char var2 = tab[3][i];
        char var3 = tab[5][i];
        char var4 = tab[7][i];

        if (var1==var2 && var1==var3 && var1==var4 && var1!=' ')
        {
            if (var1 == '¤')
            {
                tab[1][i] = '@';
                tab[3][i] = ' ';
                tab[5][i] = '@';
                tab[7][i] = ' ';
            }
            if (var1 == '@')
            {
                tab[1][i] = 'o';
                tab[3][i] = ' ';
                tab[5][i] = 'o';
                tab[7][i] = ' ';
            }
            if (var1 == 'o')
            {
                tab[1][i] = 'J';
                tab[3][i] = ' ';
                tab[5][i] = 'J';
                tab[7][i] = ' ';
            }
        }
        else if (var1 != ' ' && var1 == var2)
        {
            if (var1 == '¤')
            {
                tab[1][i] = '@';
                tab[3][i] = ' ';
            }
            if (var1 == '@')
            {
                tab[1][i] = 'o';
                tab[3][i] = ' ';
            }
            if (var1 == 'o')
            {
                tab[1][i] = 'J';
                tab[3][i] = ' ';
            }
        }
        else if (var1!=' ' && var1!=var2 && var2!= ' ' && var2==var3 && var3==var4)
        {
             if (var2 == '¤')
            {
                tab[3][i] = '@';
                tab[5][i] = ' ';
            }
            if (var2 == '@')
            {
                tab[3][i] = 'o';
                tab[5][i] = ' ';
            }
            if (var2 == 'o')
            {
                tab[3][i] = 'J';
                tab[5][i]= ' ';
            }
        }
        else if (var1==var2 && var2==var3 && var4!=var1 && var1!= ' ')
        {
             if (var2 == '¤')
            {
                tab[1][i] = '@';
                tab[3][i] = ' ';
            }
            if (var2 == '@')
            {
                tab[1][i] = 'o';
                tab[3][i] = ' ';
            }
            if (var2 == 'o')
            {
                tab[1][i] = 'J';
                tab[3][i]= ' ';
            }
        }
        else if (var2 != ' ' && var3 == var2)
        {
            if (var2 == '¤')
            {
                tab[3][i] = '@';
                tab[5][i] = ' ';
            }
            if (var2 == '@')
            {
                tab[3][i] = 'o';
                tab[5][i] = ' ';
            }
            if (var2 == 'o')
            {
                tab[3][i] = 'J';
                tab[5][i]= ' ';
            }
        }
        else if (var4 != ' ' && var3 == var4)
        {
            if (var3 == '¤')
            {
                tab[5][i] = '@';
                tab[7][i] = ' ';
            }
            if (var3 == '@')
            {
                tab[5][i] = 'o';
                tab[7][i] = ' ';
            }
            if (var3 == 'o')
            {
                tab[5][i] = 'J';
                tab[7][i] = ' ';
            }
        }
        else if (var4 != ' ' && var2 == ' ' && var3 == ' ' && var1 == var4)
        {
            if (var1 == '¤')
            {
                tab[1][i] = '@';
                tab[7][i] = ' ';
            }
            if (var1 == '@')
            {
                tab[1][i] = 'o';
                tab[7][i] = ' ';
            }
            if (var1 == 'o')
            {
                tab[1][i] = 'J';
                tab[7][i]= ' ';
            }
        }
        else if (var1 != ' ' && var2 == ' ' && var3 == var1)
        {
            if (var3 == '¤')
            {
                tab[1][i] = '@';
                tab[5][i] = ' ';
            }
            if (var3 == '@')
            {
                tab[1][i] = 'o';
                tab[5][i] = ' ';
            }
            if (var3 == 'o')
            {
                tab[1][i] = 'J';
                tab[5][i] = ' ';
            }
        }
        else if ( var4 != ' ' && var1 == ' ' && var3 == ' ' && var2 == var4)
        {
            if (var2 == '¤')
            {
                tab[3][i] = '@';
                tab[7][i] = ' ';
            }
            if (var2 == '@')
            {
                tab[3][i] = 'o';
                tab[7][i] = ' ';
            }
            if (var2 == 'o')
            {
                tab[3][i] = 'J';
                tab[7][i] = ' ';
            }
        }
        else if ( var4 != ' ' && var1 != ' ' && var3 == ' ' && var2 == var4 && var1 !=var2)
        {
            if (var2 == '¤')
            {
                tab[3][i] = '@';
                tab[7][i] = ' ';
            }
            if (var2 == '@')
            {
                tab[3][i] = 'o';
                tab[7][i] = ' ';
            }
            if (var2 == 'o')
            {
                tab[3][i] = 'J';
                tab[7][i] = ' ';
            }
        }
    }
}

//4.FusionGoDown
void FusionGoDown(char[][] tab)  
{
    for (int j = 0; j < 4; j++)
    {
        int i =2*j+1;

        char var1 = tab[1][i];
        char var2 = tab[3][i];
        char var3 = tab[5][i];
        char var4 = tab[7][i];

        if (var1==var2 && var1==var3 && var1==var4 && var1!=' ')
        {
            if (var1 == '¤')
            {
                tab[7][i] = '@';
                tab[5][i] = ' ';
                tab[3][i] = '@';
                tab[1][i] = ' ';
            }
            if (var1 == '@')
            {
                tab[7][i] = 'o';
                tab[5][i] = ' ';
                tab[3][i] = 'o';
                tab[1][i] = ' ';
            }
            if (var1 == 'o')
            {
                tab[7][i] = 'J';
                tab[5][i] = ' ';
                tab[3][i] = 'J';
                tab[1][i] = ' ';
            }
        }
        else if (var1 != ' ' && var1 == var2)
        {
            if (var1 == '¤')
            {
                tab[3][i] = '@';
                tab[1][i] = ' ';
            }
            if (var1 == '@')
            {
                tab[3][i] = 'o';
                tab[1][i] = ' ';
            }
            if (var1 == 'o')
            {
                tab[3][i] = 'J';
                tab[1][i] = ' ';
            }
        }
        else if (var4!=' ' && var4!=var3 && var3!= ' ' && var3==var2 && var2==var1)
        {
            if (var2 == '¤')
            {
                tab[5][i] = '@';
                tab[3][i] = ' ';
            }
            if (var2 == '@')
            {
                tab[5][i] = 'o';
                tab[3][i] = ' ';
            }
            if (var2 == 'o')
            {
                tab[5][i] = 'J';
                tab[3][i]= ' ';
            }
        }
        else if (var4==var3 && var3==var2 && var1!=var2 && var4!=' ')
        {
            if (var2 == '¤')
            {
                tab[7][i] = '@';
                tab[5][i] = ' ';
            }
            if (var2 == '@')
            {
                tab[7][i] = 'o';
                tab[5][i] = ' ';
            }
            if (var2 == 'o')
            {
                tab[7][i] = 'J';
                tab[5][i]= ' ';
            }
        }
        else if (var2 != ' ' && var3 == var2)
        {
            if (var2 == '¤')
            {
                tab[5][i] = '@';
                tab[3][i] = ' ';
            }
            if (var2 == '@')
            {
                tab[5][i] = 'o';
                tab[3][i] = ' ';
            }
            if (var2 == 'o')
            {
                tab[5][i] = 'J';
                tab[3][i]= ' ';
            }
        }
        else if (var4 != ' ' && var3 == var4)
        {
            if (var3 == '¤')
            {
                tab[7][i] = '@';
                tab[5][i] = ' ';
            }
            if (var3 == '@')
            {
                tab[7][i] = 'o';
                tab[5][i] = ' ';
            }
            if (var3 == 'o')
            {
                tab[7][i] = 'J';
                tab[5][i] = ' ';
            }
        }
        else if (var4 != ' ' && var2 == ' ' && var3 == ' ' && var1 == var4)
        {
            if (var1 == '¤')
            {
                tab[7][i] = '@';
                tab[1][i] = ' ';
            }
            if (var1 == '@')
            {
                tab[7][i] = 'o';
                tab[1][i] = ' ';
            }
            if (var1 == 'o')
            {
                tab[7][i] = 'J';
                tab[1][i]= ' ';
            }
        }
        else if (var1 != ' ' && var2 == ' ' && var3 == var1)
        {
            if (var3 == '¤')
            {
                tab[5][i] = '@';
                tab[1][i] = ' ';
            }
            if (var3 == '@')
            {
                tab[5][i] = 'o';
                tab[1][i] = ' ';
            }
            if (var3 == 'o')
            {
                tab[5][i] = 'J';
                tab[1][i] = ' ';
            }
        }
        else if ( var4 != ' ' && var1 == ' ' && var3 == ' ' && var2 == var4)
        {
            if (var2 == '¤')
            {
                tab[7][i] = '@';
                tab[3][i] = ' ';
            }
            if (var2 == '@')
            {
                tab[7][i] = 'o';
                tab[3][i] = ' ';
            }
            if (var2 == 'o')
            {
                tab[7][i] = 'J';
                tab[3][i] = ' ';
            }
        }
        else if ( var4 != ' ' && var1 != ' ' && var2 == ' ' && var2 == var4 && var4!=var3)
        {
            if (var2 == '¤')
            {
                tab[7][i] = '@';
                tab[3][i] = ' ';
            }
            if (var2 == '@')
            {
                tab[7][i] = 'o';
                tab[3][i] = ' ';
            }
            if (var2 == 'o')
            {
                tab[7][i] = 'J';
                tab[3][i] = ' ';
            }
        }
    }
}


//---------------------------------------------------------------------------------------------------------------------------


//Ensuite, on s'occupe de décaller au max les bonbons vers la droite, vers la gauche, le haut ou le bas, selon la touche pressée par l'utilisateur, en comblant les blancs, mais en ne fusionnant rien du tout.
//Les fonctions s'appeleront : DecallerLesTreatsDroite, DecallerLesTreatsGauche, DecallerLesTreatsHaut et enfin, DecallerLesTreatsBas.

//1.DecallerLesTreatsDroite :
void DecallerLesTreatsDroite(char[][] tab)
{
    for (int m = 0; m < 9; m++)//pour parcourir chacune des 9 lignes du plateauDeJeu
    {
        for (int n = 0; n < 7; n++)//on le fait 7 fois car cest le max pour tout decaller à droite (il y a 7 combinaisons possibles de répartition des treats sur une ligne)
        {
            for (int i = 3; i > 0; i--) //i prend les valeurs 3 2 1 
            {
                int p = 2 * i + 1;//p prend les valeurs 7 5 3

                char varD = tab[m][p];//avec m la ligne, et p = 7, 5 ou 3, càd que varD prend la valeur de var1, var2 ou var3
                char varG = tab[m][p - 2]; //p-2 prend les valeurs 5, 3, ou 1, càd que varG prend les valeurs de var2, var3 ou var4

                if (varD == ' ')//si case de droite est vide
                {
                    if (varG != ' ')//si case de gacuhe non vide
                    {
                        tab[m][p] = varG;//alors on décale varG dans varD
                        tab[m][p - 2] = ' ';//on vide la case de gauche
                    }
                }
            }
        }
    }
}

//2.DecallerLesTreatsGauche :
void DecallerLesTreatsGauche(char[][] tab)
{
    for (int m = 0; m < 9; m++)//pour parcourir chacune des 9 lignes du plateauDeJeu
    {
        for (int n = 0; n < 7; n++)//on le fait 7 fois car cest le max pour tout decaller à gauche (il y a 7 combinaisons possibles de répartition des treats sur une ligne)
        {
            for (int i = 0; i <3; i++) //i prend les valeurs 0 1 2 
            {
                int p = 2 * i + 1;//p prend les valeurs 1 3 5

                char varG = tab[m][p];//avec m la ligne, et p = 1 3 5, càd que varG prend la valeur de var4, var3 ou var2
                char varD = tab[m][p + 2]; //p+2 prend les valeurs 3, 5 ou 7, càd que varD prend les valeurs de var3, var2 ou var1

                if (varG == ' ')//si case de gauche est vide
                {
                    if (varD != ' ')//si case de droite non vide
                    {
                        tab[m][p] = varD;//alors on décale varD dans varG
                        tab[m][p + 2] = ' ';//on vide la case de droite
                    }
                }
            }
        }
    }
}

//3.DecallerLesTreatsHaut :
void DecallerLesTreatsHaut(char[][] tab)
{
    for (int m = 0; m < 9; m++)//pour parcourir chacune des 9 colonnes du plateauDeJeu
    {
        for (int n = 0; n < 7; n++)//il y a 7 combinaisons possibles de répartition des treats sur une colonne
        {
            for (int i = 0; i <3; i++) //i prend les valeurs 0 1 2 
            {
                int p = 2 * i + 1;//p prend les valeurs 1 3 5

                char varH = tab[p][m];//avec m la ligne, et p = 1 3 5, càd que varG prend la valeur de var4, var3 ou var2
                char varB = tab[p + 2][m]; //p+2 prend les valeurs 3, 5 ou 7, càd que varD prend les valeurs de var3, var2 ou var1

                if (varH == ' ')//si case de gauche est vide
                {
                    if (varB != ' ')//si case de droite non vide
                    {
                        tab[p][m] = varB;//alors on décale varD dans varG
                        tab[p + 2][m] = ' ';//on vide la case de droite
                    }
                }
            }
        }
    }
}

//4.DecallerLesTreatsBas :
void DecallerLesTreatsBas(char[][] tab)
{
    for (int m = 0; m < 9; m++)//pour parcourir chacune des 9 lignes du plateauDeJeu
    {
        for (int n = 0; n < 7; n++)//on le fait 7 fois car cest le max pour tout decaller à gauche (il y a 7 combinaisons possibles de répartition des treats sur une ligne)
        {
            for (int i = 3; i > 0; i--) //i prend les valeurs 3 2 1
            {
                int p = 2 * i + 1;//p prend les valeurs 7 5 3

                char varB = tab[p][m];
                char varH = tab[p - 2][m]; //p-2 prend les valeurs 5 3 1

                if (varB == ' ')//si case du bas est vide
                {
                    if (varH != ' ')//si case du haut non vide
                    {
                        tab[p][m] = varH;
                        tab[p - 2][m] = ' ';
                    }
                }
            }
        }
    }
}


//---------------------------------------------------------------------------------------------------------------------------


// FAIRE FONCTIONNER LE JEU PAR UNE BOUCLE

// le jeu doit s'arrêter lorsque le nombre de coups maximum (nbCoupsMax) est atteint ou lorsque le plateau est bloqué
// dans ce but, une boucle est placée avant le déroulement d'un tour
// nous utilisons une boucle do-while afin que les tours se suivent jusqu'à ce que la condition ne soit plus remplie
int nbDeTours=1; // nbDeTours est une variable utilisée en tant que compteur
bool jeuBloqué=false; // création d'une variable jeuBloqué qui nous permettra de déterminer lorsque le jeu est bloqué
int nbDeFoisEnigme=0; // création d'un compteur afin de faire en sorte que le joueur ne puisse avoir une énigme qu'une seule fois

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

    if (directionVoulue == 'F')
    {
        FusionGoRight(plateauDeJeu);
        DecallerLesTreatsDroite(plateauDeJeu);
    }
    if (directionVoulue=='S')
    {
        FusionGoLeft(plateauDeJeu);
        DecallerLesTreatsGauche(plateauDeJeu);
    }
    if (directionVoulue == 'E')
    {
        FusionGoUp(plateauDeJeu);
        DecallerLesTreatsHaut(plateauDeJeu);
    }
    if (directionVoulue=='D')
    {
        FusionGoDown(plateauDeJeu);
        DecallerLesTreatsBas(plateauDeJeu);
    }


    // à la fin du tour, on rajoute des bonbons aléatoirement dans le plateau de jeu
    // on appelle ainsi à nouveau PlacerBonbonsAleatoirement et AfficherLeJeu
    PlacerBonbonsAleatoirement(plateauDeJeu);
    AfficherLeJeu(plateauDeJeu);

    // après l'affichage de chaque plateau, le joueur est informé du nombre de coups restants
    int nbCoupsRestants = nbCoupsMax - nbDeTours;
    Console.WriteLine ($"Il vous reste {nbCoupsRestants} coups.");

    // VERIFICATION PLATEAU PLEIN

    // afin de verifier que le plateau n'est pas plein, on parcourt chaque case du plateauDeJeu, d'où le double for pour les lignes et les colonnes
    ChercherNbCasesVides (plateauDeJeu);
    if (ChercherNbCasesVides(plateauDeJeu)==0) {jeuBloqué=true;} // si le compteur vaut 0, alors le plateau est plein et le jeu doit s'arrêter


    // mise en place d'une énigme afin de permettre au joueur de gagner 3 coups supplémentaires
    // cette énigme s'affiche si le nombre de coups maximal est atteint, pas si le plateau est bloqué
    if ((nbDeTours==nbCoupsMax) && (nbDeFoisEnigme!=1)) // on vérifie que le joueur n'a plus de coups et qu'il n'a pas déjà fait l'énigme au tour d'avant
    {
        Console.WriteLine($"Vous avez déjà atteint vos {nbCoupsMax} coups!");
        Console.Write("Voulez-vous tenter de répondre à une énigme afin de récupérer 3 coups? Répondez par 'oui' ou par 'non' : ");
        string choixEnigme = Console.ReadLine()!;
        if (choixEnigme=="oui")
        {
            Console.WriteLine ("Vous avez choisi de répondre à une énigme, la voici : ");
            Console.Write("Qu'est-ce qui est jaune et qui attend ? ");
            string reponseEnigme = Console.ReadLine()!;
            if ((reponseEnigme == "Jonathan") || (reponseEnigme == "jonathan") || (reponseEnigme == "JONATHAN")) // on laisse deux possibilités dans le cas où le joueur oublie une majuscule 
            {
                Console.WriteLine("BONNE REPONSE ! Vous venez de gagner 3 coups supplémentaires ! Bravo !");
                nbCoupsMax+=3; // le joueur peut donc jouer à nouveau 3 tours
            }
            else {Console.WriteLine("Mauvaise réponse, une prochaine fois !");}
        }
        nbDeFoisEnigme++;
    }

    if (nbCoupsMax!=nbDeTours)
    {
        Console.Write("Souhaitez-vous mettre fin à la partie ? si oui, écrivez 'oui', si non, tapez sur une touche au hasard : ");
        string souhaitFin = Console.ReadLine()!;
        if (souhaitFin == "oui") {break;}
    }

    Console.WriteLine("");


    nbDeTours++; // le compteur nbDeTours s'incrémente de 1 afin de compter le nombre de tours et de s'arrêter lorsque le maximum est atteint

} while (nbDeTours<=nbCoupsMax && jeuBloqué==false);


//---------------------------------------------------------------------------------------------------------------------------


// CAUSE FIN DU JEU
Console.WriteLine();
Console.WriteLine("FIN DE LA PARTIE");
Console.WriteLine();
// lorsque le jeu se finit, le joueur voit apparaitre la cause
// on utilise une boucle if dans le but de différencier les deux possibilités
if (jeuBloqué==true) {Console.WriteLine("Vous avez rempli chaque case du plateau, le jeu est bloqué et s'arrête là !");}
if (nbDeTours==nbCoupsMax) {Console.WriteLine($"Vous avez joué {nbCoupsMax} coup(s), soit le maximum de coups possibles !");}
else {Console.WriteLine("Vous avez arrêté la partie volontairement.");}


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


