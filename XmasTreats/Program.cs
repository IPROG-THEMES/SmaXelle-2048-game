// SmaXelle - JEU

//Création du plateauDeJeu :
//Création d'un tableau imbriqué de char qui s'appelle plateauDeJeu de 9 lignes et de ? colonnes
char [][] plateauDeJeu = new char [9][];

//Création des 9 colonnes pour chacune des 9 lignes 
for (int i = 0; i < 9; i++)//i se balade dans les lignes du plateauDeJeu
{
    plateauDeJeu[i]=new char[9];//dans chaque ligne, on y met 9 colonnes
}
//on a ainsi un plateau de jeu de 16 cases de jeu, et tout le reste des cases permettent de dessiner le cadrillage


// NOMBRE DE COUPS
//on demande au joueur le nombre de coups maximum autorisé

int nbCoupsMax;
Console.Write("Veuillez entrer le nombre de coups maximum : ");
nbCoupsMax = Convert.ToInt32(Console.ReadLine()!);

// demander : si chiffre pas un int, message erreur + recommencer
// LE FAIRE URGENT!!!!!!!!! 

// on affiche à nouveau le nombre de coups
Console.WriteLine($"Vous avez choisi {nbCoupsMax} coups.");


//Remplissage du plateauDeJeu :

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
System.Console.WriteLine("Vous jouerez ainsi sur le plateau de jeu suivant : ");
AfficherLeJeu(plateauDeJeu);

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
        while (tab[ligne][colonne]!=' '); // la boucle do-while continue tant que la case choisie c'est pas vide, peu importe le bonbon qu'elle comporte
        tab[ligne][colonne]='¤';// lorsque la boucle est finie, le premier bonbon est attribué à la case choisie
    }
}


PlacerBonbonsAleatoirement(plateauDeJeu);
AfficherLeJeu(plateauDeJeu);


//début d'un tour
char directionVoulue;

Console.Write("Quelle direction voulez vous ? ");
directionVoulue = Convert.ToChar(Console.ReadLine()!);

//création d'une fonction qui sera utile si l'utilisateur tape 'F' : les éléments vont vers la droite


//fonction qui permet de fusionner et de mettre les elements fusionnes sur la droite(pour toutes les lignes)
void FusionGoRight(char[][] tab)//fonction qui permet de fusionner et de mettre à droite
{
    for (int i = 0; i < 4; i++)//i permet de passer sur chaque ligne du tableau, et ainsi de trier toutes les lignes
    {
        if (directionVoulue=='F')//l'utilisateur veut donc aller à droite
        {
            //stockage des valeurs de chacune des cases de la première ligne, avec var1 celle la + à droite et var4 celle la + à gauche
            char var1=tab[i][7];
            char var2=tab[i][5];
            char var3=tab[i][3];
            char var4=tab[i][1];

            if (var1==var2 && var1!=' ')//on a alors le même bonbon dans les 2cases les + à droite, et on est sûr de ne pas avoir de vide dans ces deux cases là
            {
                //fusionnage des bonbons, et on met le résultat de la fusion dans la case la plus à droite entre les deux cases évaluées
                if (var1=='¤')
                {
                    tab[i][7]='@';
                    tab[i][5]=' ';
                }
                if (var1=='@')
                {
                    tab[i][7]='o';
                    tab[i][5]=' ';
                }
                if (var1=='o')
                {
                    tab[i][7]='J';
                    tab[i][5]=' ';
                }

            }
            //idem maintenant pour les deux cases du milieu, puis pour les deux cases les + à gauche
            if (var3==var2 && var2!=' ')
            {
                if (var2=='¤')
                {
                    tab[i][5]='@';
                    tab[i][3]=' ';
                }
                if (var2=='@')
                {
                    tab[i][5]='o';
                    tab[i][3]=' ';
                }
                if (var2=='o')
                {
                    tab[i][5]='J';
                    tab[i][3]=' ';
                }

            }
            if (var3==var4 && var4!=' ')
            {
                if (var3=='¤')
                {
                    tab[i][3]='@';
                    tab[i][1]=' ';
                }
                if (var3=='@')
                {
                    tab[i][3]='o';
                    tab[i][1]=' ';
                }
                if (var3=='o')
                {
                    tab[i][3]='J';
                    tab[i][1]=' ';
                }
            }
        }
    }
}
//*création de la meme chose : GoLeft, GoUp et GoDown*


//la partie du code suivante permet d'appeler une des fonctions parmi GoRight, GoLeft, GoUp et GoDown selon la valeir de directionVoulue
if (directionVoulue=='F')
{
    FusionGoRight(plateauDeJeu);
}
// if (directionVoulue=='S')
// {
//     GoLeft(plateauDeJeu);
// }
// if (directionVoulue=='E')
// {
//     GoUp(plateauDeJeu);
// }
// if (directionVoulue=='D')
// {
//     GoDown(plateauDeJeu);
// }


//ensuite, on s'occupe de décaller au max les bonbons vers la droite, en comblant les blans, mais en ne fusionnant rien  du tout
//dans ce but on va utiliser une fonction qui spl : DecallerLesTreatsDroite

void DecallerLesTreatsDroite (char[][] tab) //prend en argument le contenu des deux cases 
{
    for (int m = 0; m < 9; m++)//pour parcourir chacune des 9 lignes
    {
        for (int n = 0; n < 7; n++)//on le fait 7 fois cr cest le max pour tout decaller à droite
        {
            for (int i = 3; i > 0; i--) //i prend les valeurs 3 2 1 
            {
                int p=2*i+1;//p prend les valeurs 7 5 3

                char varD=tab[m][p];
                char varG=tab[m][p-2]; // p-2 prend les valeurs 5 3 1
                if (varD==' ')//si case de droite est vide
                {
                    if (varG!=' ')//si case de gacuhe non vide
                    {
                        //alors on décale varG dans varD
                        tab[m][p]=varG;
                        tab[m][p-2]=' ';
                    }
                }
            }
        }
    }
}

DecallerLesTreatsDroite(plateauDeJeu);
//on réécrit cette partie du code (qui a déjà été écritee auparavant, pour bel et bien écraser les bonbons sur le coté correspondant)
if (directionVoulue=='F')
{
    FusionGoRight(plateauDeJeu);
    DecallerLesTreatsDroite(plateauDeJeu);

}

// if (directionVoulue=='S')
// {
//     GoLeft(plateauDeJeu);
// }
// if (directionVoulue=='E')
// {
//     GoUp(plateauDeJeu);
// }
// if (directionVoulue=='D')
// {
//     GoDown(plateauDeJeu);
// }

AfficherLeJeu(plateauDeJeu);

/*mntn faire pour toutes les lignes à D
puis pour toutes les lignes à gauche
puis pour toutes les colonnes en haut
puis pour toutes les colonnes en bas*/

