// SmaXelle - JEU


//---------------------------------------------------------------------------------------------------------------------------


//CREATION DU PLATEAU DE JEU
//Création d'un tableau imbriqué de char qui s'appelle plateauDeJeu de 9 lignes et de ? colonnes
char[][] plateauDeJeu = new char[9][];

//Création des 9 colonnes pour chacune des 9 lignes 
for (int i = 0; i < 9; i++)//i se balade dans les lignes du plateauDeJeu
{
    plateauDeJeu[i] = new char[9];//dans chaque ligne, on y met 9 colonnes
}
//on a ainsi un plateau de jeu de 16 cases de jeu, et la totalité du reste des cases permet de dessiner les délimitations


//---------------------------------------------------------------------------------------------------------------------------


// NOMBRE DE COUPS
//on demande au joueur le nombre de coups maximum autorisé
int nbCoupsMax;//la variable nbCoupsMax correspond ainsi au nombre de coups autorisés par l'utilisateur
Console.Write("Veuillez entrer le nombre de coups maximum : ");
nbCoupsMax = Convert.ToInt32(Console.ReadLine()!);
Console.WriteLine($"Vous avez choisi {nbCoupsMax} coups.");// on affiche à nouveau le nombre de coups


//---------------------------------------------------------------------------------------------------------------------------


//Remplissage du plateauDeJeu :

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

for (int n = 0; n < 4; n++)//n prend les valeurs 0, 1, 2 et 3
{
    //2*n+1 prendra ainsi les valeurs 1, 3, 5 et 7
    for (int p = 1; p < 4; p++)//p prend les valeurs 1, 2 et 3, donc 2*p prend les valeurs 2, 4 et 6
    {
        plateauDeJeu[2 * p][2 * n + 1] = '-';
    }
}


//Remplissage de '.' (pour les quatres sommets du grand carré)
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


//Création du sous-programme AfficherLeJeu qui nous permettra, lorsqu'il sera appelé, d'afficher la totalité du plateau de jeu.
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


// DEBUT DU JEU ET CONSIGNES
//On dit au joueur que le jeu va commencer, et on lui explique les règles.
Console.WriteLine();
Console.WriteLine("Le jeu va dès à présent débuter.");
Console.WriteLine($"Vous allez devoir assembler les bonbons de même forme afin d'obtenir un maximum de points en seulement {nbCoupsMax} coups!");
Console.WriteLine("Pour déplacer les bonbons vers le haut, veuillez entrer la lettre E.");
Console.WriteLine("Pour déplacer les bonbons vers le bas, veuillez entrer la lettre D.");
Console.WriteLine("Pour déplacer les bonbons vers la droite, veuillez entrer la lettre F.");
Console.WriteLine("Pour déplacer les bonbons vers la gauche, veuillez entrer la lettre S.");
Console.WriteLine("BONNE CHANCE!");

// ici mettre un truc pour que l'utilisateur choisisse le niveau de son jeu (tapez respectivement 1 2 3 ou 4 si vous voulez facile moyen difficile hardcore)
//---------------------------------------------------------------------------------------------------------------------------


// PLACER LES BONBONS ALEATOIREMENT
//création d'une fonction qui pourra se répéter à chaque fin de partie
//la fonction prend en argument le plateau de jeu afin d'y mettre deux bonbons de manière aléatoire
void PlacerBonbonsAleatoirement(char[][] tab)
{
    for (int bonbon = 1; bonbon <= 2; bonbon++) // utilisation d'une boucle afin de répéter l'opération deux fois, pour les deux bonbons à mettre aléatoirement dans le plateau de jeu
    {
        Random caseDuPlateau = new Random(); // utilisation d'un tirage pour déterminer une ligne et une colonne aléatoirement
        int ligne;
        int colonne;
        do
        {
            ligne = caseDuPlateau.Next(0, 9);//tirage d'une ligne de manière aléatoire
            colonne = caseDuPlateau.Next(0, 9);//tirage d'une colonne de manière aléatoire
        }
        while (tab[ligne][colonne] != ' '); // la boucle do-while continue tant que la case choisie c'est pas vide, peu importe le motif qu'elle comporte
        tab[ligne][colonne] = '¤';// lorsque la boucle est finie, le premier bonbon est attribué à la case choisie
    }
}


//---------------------------------------------------------------------------------------------------------------------------
//*******************************************************ici commencer une grosse boucle qui se termine si nombre de coups max a été atteint

//début d'un tour :
PlacerBonbonsAleatoirement(plateauDeJeu);
AfficherLeJeu(plateauDeJeu);

//on demande à l'utilisateur ce qu'il veut jouer
char directionVoulue;
Console.Write("Quelle direction voulez vous ? ");
directionVoulue = Convert.ToChar(Console.ReadLine()!);//directionVoulue prend donc les valeurs 'F', 'E', 'S' ou 'D'


//---------------------------------------------------------------------------------------------------------------------------


//Création des fonctions FusionGoRight, FusionGoLeft, FusionGoUp et FusionGoDown :

//1.FusionGoRight : fonction qui permet de fusionner deux éléments identiques et de mettre l'élément résultant de la fusion sur la droite (pour toutes les lignes)
void FusionGoRight(char[][] tab)
{
    for (int j = 0; j < 4; j++)//i permet de passer sur chaque ligne du tableau, et ainsi de trier toutes les lignes
    {
        int i =2*j+1; // i nous permet d'obtenir les indices des lignes sur les lesquelles on joue seulement (et non les lignes de délimitations des cases)
        //stockage des valeurs de chacune des cases de jeu de la première ligne, avec var1 celle la + à droite, et var4 celle la + à gauche
        char var1 = tab[i][7];
        char var2 = tab[i][5];
        char var3 = tab[i][3];
        char var4 = tab[i][1];

        if (var1 != ' ' && var1 == var2)//on a alors le même bonbon dans les 2cases les + à droite, et on est sûr de ne pas avoir de vide dans ces deux cases là
        {
            //fusionnage des bonbons, et on met le résultat de la fusion dans la case la plus à droite entre les deux cases évaluées
            if (var1 == '¤')
            {
                tab[i][7] = '@';
                tab[i][5] = ' ';
            }
            if (var1 == '@')
            {
                tab[i][7] = 'o';
                tab[i][5] = ' ';
            }
            if (var1 == 'o')
            {
                tab[i][7] = 'J';
                tab[i][5] = ' ';
            }

        }
        //idem maintenant pour le reste des cas possibles :
        if (var2 != ' ' && var3 == var2)
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
        if (var4 != ' ' && var3 == var4)
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
        if (var4 != ' ' && var2 == ' ' && var3 == ' ' && var1 == var4)
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
        if (var1 != ' ' && var2 == ' ' && var3 == var1)
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
        if ( var4 != ' ' && var1 == ' ' && var3 == ' ' && var2 == var4)
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

        if (var1 != ' ' && var1 == var2)//on a alors le même bonbon dans les 2cases les + à gauche, et on est sûr de ne pas avoir de vide dans ces deux cases là
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

        if (var2 != ' ' && var3 == var2)
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
        if (var4 != ' ' && var3 == var4)
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
        if (var4 != ' ' && var2 == ' ' && var3 == ' ' && var1 == var4)
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
        if (var1 != ' ' && var2 == ' ' && var3 == var1)
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
        if ( var4 != ' ' && var1 == ' ' && var3 == ' ' && var2 == var4)
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

        if (var1 != ' ' && var1 == var2)
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
        if (var2 != ' ' && var3 == var2)
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
        if (var4 != ' ' && var3 == var4)
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
        if (var4 != ' ' && var2 == ' ' && var3 == ' ' && var1 == var4)
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
        if (var1 != ' ' && var2 == ' ' && var3 == var1)
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
        if ( var4 != ' ' && var1 == ' ' && var3 == ' ' && var2 == var4)
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

        if (var1 != ' ' && var1 == var2)
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
        if (var2 != ' ' && var3 == var2)
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
        if (var4 != ' ' && var3 == var4)
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
        if (var4 != ' ' && var2 == ' ' && var3 == ' ' && var1 == var4)
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
        if (var1 != ' ' && var2 == ' ' && var3 == var1)
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
        if ( var4 != ' ' && var1 == ' ' && var3 == ' ' && var2 == var4)
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


//Ensuite, on s'occupe de décaller au max les bonbons vers la droite, vers la gauche, le haut ou le bas, selon la touche préssée par l'utilisateur, en comblant les blancs, mais en ne fusionnant rien du tout.
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


//La partie du code suivante permet d'appeler les fonctions créées selon la valeur de directionVoulue.

if (directionVoulue == 'F')
{
    FusionGoRight(plateauDeJeu);
    DecallerLesTreatsDroite(plateauDeJeu);
    PlacerBonbonsAleatoirement(plateauDeJeu);
    AfficherLeJeu(plateauDeJeu);
}
if (directionVoulue=='S')
{
    FusionGoLeft(plateauDeJeu);
    DecallerLesTreatsGauche(plateauDeJeu);
    PlacerBonbonsAleatoirement(plateauDeJeu);
    AfficherLeJeu(plateauDeJeu);
}
if (directionVoulue == 'E')
{
    FusionGoUp(plateauDeJeu);
    DecallerLesTreatsHaut(plateauDeJeu);
    PlacerBonbonsAleatoirement(plateauDeJeu);
    AfficherLeJeu(plateauDeJeu);
}
if (directionVoulue=='D')
{
    FusionGoDown(plateauDeJeu);
    DecallerLesTreatsBas(plateauDeJeu);
    PlacerBonbonsAleatoirement(plateauDeJeu);
    AfficherLeJeu(plateauDeJeu);
}


//---------------------------------------------------------------------------------------------------------------------------


//Concernant les autres tours :
int compteur=2 ;
while (compteur<=nbCoupsMax)
{
    int coupsRestants=nbCoupsMax-compteur;
    Console.Write("Il vous reste "+coupsRestants+" coups à jouer. Quelle direction souhaitez-vous à présent ?");
    directionVoulue = Convert.ToChar(Console.ReadLine()!);

    if (directionVoulue == 'F')
    {
        FusionGoRight(plateauDeJeu);
        DecallerLesTreatsDroite(plateauDeJeu);
        PlacerBonbonsAleatoirement(plateauDeJeu);
        AfficherLeJeu(plateauDeJeu);
    }
    if (directionVoulue=='S')
    {
        FusionGoLeft(plateauDeJeu);
        DecallerLesTreatsGauche(plateauDeJeu);
        PlacerBonbonsAleatoirement(plateauDeJeu);
        AfficherLeJeu(plateauDeJeu);
    }
    if (directionVoulue == 'E')
    {
        FusionGoUp(plateauDeJeu);
        DecallerLesTreatsHaut(plateauDeJeu);
        PlacerBonbonsAleatoirement(plateauDeJeu);
        AfficherLeJeu(plateauDeJeu);
    }

    if (directionVoulue=='D')
    {
        FusionGoDown(plateauDeJeu);
        DecallerLesTreatsBas(plateauDeJeu);
        PlacerBonbonsAleatoirement(plateauDeJeu);
        AfficherLeJeu(plateauDeJeu);
    }
    compteur+=1;
}


//---------------------------------------------------------------------------------------------------------------------------


