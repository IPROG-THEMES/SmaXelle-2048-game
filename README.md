# SmaXelle

## Contexte

Le but de ce projet est de programmer en équipe un jeu similaire au jeu 2048 en C#, avec une approche procédurale. Le jeu se déroule sur un plateau de jeu, à l'aide de quatres touches de clavier, représentant les quatres directions de l'espace. L'utilisateur commence sur un plateau de jeu initialisé : seuls deux treats sont présents. Le jeu s'arrête lorsque toutes les cases du plateau de jeu sont occupées, lorsque le nombre de coups maximum, déterminé par l'utilisateur, est atteint, ou lorsque l'utilisateur le demande.

La principale contrainte technique a été l'utilisation du langage de programmation, qui devait être du C#, avec une approche procédurale.

## Choix techniques

Les choix concernant la modélisation des variables et fonctions sont les suivants :
- utilisation de la norme camelCase pour les variables et de la norme PascalCase pour
les fonctions ;
- utilisation d’un booléen pour savoir si le jeu est bloqué : façon de comparer et de
savoir si condition est remplie ;
- utilisation de tableaux imbriqués pour créer notre plateau de jeu. Ce choix s’explique
par l’intention de faciliter la compréhension dans l’équipe en s’appuyant sur nos
connaissances communes, ainsi que par l’intention de faciliter l’application des
autres démarches liées au plateau.

## Déroulé d'une partie de jeu

1. Au démarrage, le jeu affiche le plateau initial et demande au joueur de définir le nombre maximum de coups.
2. Le joueur entre le nombre de coups maximum.
3. Le jeu commence et le joueur peut déplacer les bonbons en utilisant les commandes E, D, F, et S.
4. Après chaque mouvement, le jeu demande si le joueur souhaite quitter ou continuer.

## L'équipe

L’équipe se compose de Esma Hebbar et de Axelle Agez, deux élèves-ingénieures de
Première Année à l’ENSC.

AGEZ Axelle : aagez@ensc.fr
HEBBAR Esma : ehebbar001@ensc.fr
