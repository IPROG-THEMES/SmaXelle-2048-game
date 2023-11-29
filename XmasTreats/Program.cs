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




//création du sous-programme AffichonsLeJeu qui nous permettra, lorsqu'il sera appelé, d'afficher la totalité du plateau de jeu
void AffichonsLeJeu(char[][] tab)
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
AffichonsLeJeu(plateauDeJeu);













//début d'un tour
//pour la ligne 1 !!!!!!!!!!!!!

//sq que l'utilisateur veuille aller à droite

char directionVoulue='F';//à enlever par la suite : travail réalisé par axl

if (directionVoulue=='F')
{
    //prise des valeurs de chacune des cases de la première ligne
    char var1=plateauDeJeu[1][7];
    char var2=plateauDeJeu[1][5];
    char var3=plateauDeJeu[1][3];
    char var4=plateauDeJeu[1][1];

    if (var1==var2 && var1!=' ')//on a allors le même bonbon dans les 2cases les + à droite, et on est sûr de ne pas avoir de vide
    {
        //fusionnage des bonbons, et on les met dans la case la plus à droite
        if (var1=='¤')
        {
            plateauDeJeu[1][7]='@';
        }
        if (var1=='@')
        {
            plateauDeJeu[1][7]='o';
        }
        if (var1=='o')
        {
            plateauDeJeu[1][7]='J';
        }

    }
    if (var3==var2 && var2!=' ')//on a allors le même bonbon dans les 2cases du milieu, et on est sûr de ne pas avoir de vide
    {
        //fusionnage des bonbons, et on les met dans la case la plus à droite entre les deux cases 
        if (var2=='¤')
        {
            plateauDeJeu[1][5]='@';
        }
        if (var2=='@')
        {
            plateauDeJeu[1][5]='o';
        }
        if (var2=='o')
        {
            plateauDeJeu[1][5]='J';
        }

    }
    if (var3==var4 && var4!=' ')//on a allors le même bonbon dans les 2cases les + à gauche, et on est sûr de ne pas avoir de vide
    {
        //fusionnage des bonbons, et on les met dans la case la plus à droite entre les deux cases 
        if (var3=='¤')
        {
            plateauDeJeu[1][3]='@';
        }
        if (var3=='@')
        {
            plateauDeJeu[1][3]='o';
        }
        if (var3=='o')
        {
            plateauDeJeu[1][3]='J';
        }

    }

}

//ensuite, on s'occupe de décaller au max les bonbons vers la droite, en comblant les blans, mais en ne fusionnant rien  du tout

//dans ce but on va utiliser une fonction qui spl 















