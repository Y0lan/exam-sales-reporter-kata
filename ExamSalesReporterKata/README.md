# TODO un paragraphe sur les commentaires du code existant et de sa structure, les pb vus etc

# TODO un paragraphe sur comment il faudrait structurer le code et les entités utilisées

# TODO un paragraphe avec la stratégie de tests: qu'est ce que je veux tester, quels exemples, pourquoi etc..

Principaux problèmes :
- Le code est regroupé et est uniquement dans le main.
- Au lancement de l'application, pas d'erreur lorsque qu'aucun argument n'est renseigné sur la console.
- Le calcul du nombre de client ne fonnctionne pas.
- La lecture du fichier est en .csv mais la librairie utilisée pour la lecture n'est pas spécifique à ce type de fichier
- On arrive pas à se retrouver dans le code, ce qui rend la lecture et la compréhension du code assez compliqué. Les noms de variables ne sont pas représentatives et des variables sont déclarées en étant nulles. ex : "unknown", argument non reconnu par la console
- L'utilisation du C# qui est un langage objet alors le code est procédurale.
- Non utilisation de librairie et features scécifique au c# ne sont pas utilisés, et qu iaurais pu faciliter le développeur.

Début du refactoring :
- Analyse des best practice C#, n'ayant jamais fais de C#.
- Comprendre le but du programme.
- Le découper en plusieurs parties.
- Comprendre le fonctionnement de chaque partie et leurs rôles et mettre chaque role dans une fonction.
- Recherchez des librairies pour minimiser la taille du code.

Librairies :
- Une librairie pour parser les arguments en ligne de commande.
- Une librairie pour lire du CSV.
- Nunit pour les tests car Nunit permet d'utiliser Console.Write.
- ConsoleTable, pour afficher les données dans une table sans faire de l'algorithmie esoterique.

L'organisation du code :

	Pour y remédier, on a essayé de retranscrire le code dans une partie infrastructure et une autre, métier. 
Les principales fonctionnalités sont : pouvoir lire (parsing) les arguments de la console au lancement, pouvoir lire un fichier csv, afficher les résultats attendus en fonction de l'argument choisit (-p ou -r), les calcul des données du fichier grace à l'option report. Et, surtout l'utilisation de librairie propre au C# pour un code optimal.
Ainsi, les arguments sont :
- p : afficher le fichier sous forme de tableau
- r : report qui effectue différents calculs et affiche le résultat sous forme de tableau
- i + "path": une option que l'on a ajouté, qui permet la lecture du fichier à partir d'un emplacement quelconque.
  On a retiré le golden master puisque le code qui a été refactoré a suffisamment été dévéloppé pour le rendre inutile.

Le main a été remplacé par un fichier qu'on a nommé program.cs (convention de c#). Ce code va parser les commandes d'éxécution via CommandLineOptions (classe qui a été créee).


CommandLineOptions permet la gestion des options (-i, -p, -r, --help, --version) faisant parti du package cli. En fonction de l'option choisie, la CommandLine va appeler la classe DataPrinter qui va faire appel au fonction : DisplayRawData ou DisplayReport qui permettent l'affichage ou le rapport. Si l'utilisateur effectue une erreur de saisie lors du lancement de l'application, un message d'erreur va s'afficher et indiquer les options à écrire. Ainsi, CommandLineOptions fait partie de l'infrastructure.

Concernant le parsing du fichier csv, on est passé par la classe csvParser. 2 fonctions sont présentes :
- La fonction parseCSV qui va lire le fichier csv et faire appel à la fonction formatheaders.
- La fonction formatheaders va renvoyer le fichier csv reformaté avec une nomenclature spécifiée, les headers vont nommées et formatées sous ce format pour chaque colonne : "OrderId".
  Cette classe va donc lire le fichier et adapter les headers sous un bon format. Cette classe fait appel à une structure nommée CSV, qui déclare la structure du fichier csv : header + data.
  Le constructeur de la structure est relié à la classe SaleReport qui contiens tous les champs du fichier csv : "OrderId", "UserName", etc .. (Initialisation de getter et setter)


Le parsing étant fait à la main, on a décidé d'utiliser une librairie pour effectuer le parsing du fichier.
La classe DataPrinter permet l'affichage des données pour les fonctions print et report par quelques fonctions :
- La fonction displayRawData : répond à l'argument print "-p", affiche dans son intégralité le fichier csv sous forme de tableau sur la console. La table attendue sur la console est créée par ConsoleTable : une librairie qui formatte le tableau de la console avec l'indication des headers (préalablement renseignée).
- La fonction displayReport : répond à l'argument report "-r". Appelle la classe CsvReport qui va calculer : le nombre de ventes, le nombre de clients, etc.. Elle va récupérer les données du rapport et va retranscrire toujours à l'aide de la ConsoleTable le résultats des calculs sous forme de tableau. 




