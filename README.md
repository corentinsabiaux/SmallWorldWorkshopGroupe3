# Small world Workshop B1 Game

Voilà le projet de base pour le Workshop 2020. Ce projet unity contient l'implémentation du jeu de plateau Small  world, basé sur les règles décrite dans ce [pdf des règles](https://www.jeuxavolonte.asso.fr/regles/small_world.pdf).
 Le projet est réalisé avec Unity 2019.3.4f1.


## Systems de jeu (back)
vous trouverez ici la description des principale classes et leurs fonctionnalités

### GameManager 
La classe GameManager est un singleton il fait le lien entre les différente partie du jeu, il contiens les informations de la partie et c'est ici que sont géré les event.
*Patterns Singleton et Observable (façon c#)*
#### [propriétés](https://fr.wikipedia.org/wiki/Propri%C3%A9t%C3%A9_(informatique)) (attributs) :
 - une Liste de joueur ( List\<Player> )  : players
 - un Deck de races et de pouvoirs (Deck) : powerAndRaceDeck
- un Plateau de jeu (Board) : board
- une Phase Global de jeu (GamePhase) : gamePhase
- un numero de tour de jeu (int) : gameTurn
- un numero de joueur actif (int) : activePlayerNumber
- Le numero de la case selectioner (int) : selectedCase
- un chiffre selectionner (int) : selectedNumber
- une Liste de joueur redeployer (List\<int>) : playersToRedeploy

#### Callback (Event obeservable)
- un event quand le tour change ( OnNextTurn) : onNextTurnCallback
- un event quand les info change (OnUiChange) : onUiChangeCallBack
- un event quand la partie est terminer (OnEndGame) onEndGameCallback

#### Methode ( fonctions)
-   InitiGame() sert de constructeur 
-  RollTheDice() lance le dés et retourne une valeur comprise entre 0 et 3
- NextPlayer() passer au joueur suivant et géré les passage de tour
- refreshUis() methode qui *invoke* l'event  onUiChangeCallBack
- NextTurn methode qui *invoke* l'event onNextTurnCallback augmente le compteur de tour 
- EndOfGame methode qui *invoke* onEndGameCallback

#### Enum
- une Enum GamePhase 

### Player
La classe Player représente le joueur et toutes ces statistiques, cette classe et le point d'entré du *pattern State* qui permet de géré les différents action du joueur et état du jeu

#### [propriétés](https://fr.wikipedia.org/wiki/Propri%C3%A9t%C3%A9_(informatique)) (attributs) :
 - un numero de joueur (int)  : playerNumber 
 - un nombre de point de victoire (int) : victoryPoint 
 - une phase de tour de jeu (PlayerPhase type abstrait) : phase
 - une race active ( Race ) : actualRace
 - un pouvoir (Power) : actualPower
 - une race en déclin (Race) : decliningRace 
 - une liste de numero de case conquise ( List\<int>) : conquestedCase 
 - une liste de numero de case conquise de la race en declin ( List\<int>) : conquestedCaseDeclin 
 - un nombre de troupe disponible (int) : troopsNumber
 - un nombre de troupe a redeployer (int) : troopsToRedeploy 

#### Methode ( fonctions)
- Player(int) constructeur de la classe construit un joueur a partire d'un int de numéro de joueur
-   doAction(Action  act) la seul méthode de Player qui permet d'effectuer une action sur la phase actuelle du joueur la methode prend en paramètre une action 

### PlayerPhase
La classe PlayerPhase est une classe abstraite 

#### [propriétés](https://fr.wikipedia.org/wiki/Propri%C3%A9t%C3%A9_(informatique)) (attributs) :
 - un player  (Player) :  player;
- un nom de phase (string) : phaseName

#### Methode ( fonctions)
- abstract  bool  doAction() effectuer un action dans la phase
- Enter(Player  player) etat d'entré de la phase
- Exit() etat de sortie de la phase

### Les phase joueur
Les Player phase sont aux nombre de 8 et permette de créé tout les interaction entre le joueur et le jeu 
les phase prenne une action générique et exécute le fonction en rapport ce sont les différent états du patterns State
chaque PlayerPhase possédé des méthode différente lié au contexte de la phase de jeu

#### machine a états (State machine)
[![](https://mermaid.ink/img/eyJjb2RlIjoic3RhdGVEaWFncmFtXG5cdFsqXSAtLT4gU2VsZWN0UmFjZUFuZFBvd2VyUGhhc2UgOiBzdGFydCBhY3RpdmUgcGxheWVyXG5cdFNlbGVjdFJhY2VBbmRQb3dlclBoYXNlICAtLT4gRmlyc3RDb25xdWVzdFBoYXNlXG4gIEZpcnN0Q29ucXVlc3RQaGFzZSAtLT4gQ29ucXVlc3RQaGFzZSBcbiAgQ29ucXVlc3RQaGFzZSAtLT4gTGFzdENvbnF1ZXN0UGhhc2VcbiAgTGFzdENvbnF1ZXN0UGhhc2UgLS0-IEVuZE9mVHVyblBoYXNlXG4gIEVuZE9mVHVyblBoYXNlIC0tPiBTdGFydE9mVHVyblBoYXNlIFxuICBTdGFydE9mVHVyblBoYXNlIC0tPiBDb25xdWVzdFBoYXNlIDogY2xhc3NpYyB0dXJuXG4gIFN0YXJ0T2ZUdXJuUGhhc2UgLS0-IERlY2xpbmluZ1BoYXNlIFxuXG5EZWNsaW5pbmdQaGFzZSAtLT4gRW5kT2ZUdXJuUGhhc2VcblN0YXJ0T2ZUdXJuUGhhc2UgLS0-IFNlbGVjdFJhY2VBbmRQb3dlclBoYXNlIDogYWZ0ZXIgZGVjbGluXG5cbkVuZE9mVHVyblBoYXNlIC0tPiBbKl0gOiBsb29zQ29ucXVlc3QgcGxheWVyXG5bKl0gLS0-IEVuZE9mVHVyblBoYXNlICA6IGJhY2sgdG8gYWN0aXZlIHBsYXllclxuXHRbKl0gLS0-IExvb3NDb25xdWVzdGVkQ2FzZVBoYXNlIDogc2VsZWN0ZWQgbG9vcyBjb25xdWVzdCBwbGF5ZXJcbiAgTG9vc0NvbnF1ZXN0ZWRDYXNlUGhhc2UgLS0-IFsqXVxuXHRcdFx0XHRcdCIsIm1lcm1haWQiOnsidGhlbWUiOiJkZWZhdWx0In0sInVwZGF0ZUVkaXRvciI6ZmFsc2V9)](https://mermaid-js.github.io/mermaid-live-editor/#/edit/eyJjb2RlIjoic3RhdGVEaWFncmFtXG5cdFsqXSAtLT4gU2VsZWN0UmFjZUFuZFBvd2VyUGhhc2UgOiBzdGFydCBhY3RpdmUgcGxheWVyXG5cdFNlbGVjdFJhY2VBbmRQb3dlclBoYXNlICAtLT4gRmlyc3RDb25xdWVzdFBoYXNlXG4gIEZpcnN0Q29ucXVlc3RQaGFzZSAtLT4gQ29ucXVlc3RQaGFzZSBcbiAgQ29ucXVlc3RQaGFzZSAtLT4gTGFzdENvbnF1ZXN0UGhhc2VcbiAgTGFzdENvbnF1ZXN0UGhhc2UgLS0-IEVuZE9mVHVyblBoYXNlXG4gIEVuZE9mVHVyblBoYXNlIC0tPiBTdGFydE9mVHVyblBoYXNlIFxuICBTdGFydE9mVHVyblBoYXNlIC0tPiBDb25xdWVzdFBoYXNlIDogY2xhc3NpYyB0dXJuXG4gIFN0YXJ0T2ZUdXJuUGhhc2UgLS0-IERlY2xpbmluZ1BoYXNlIFxuXG5EZWNsaW5pbmdQaGFzZSAtLT4gRW5kT2ZUdXJuUGhhc2VcblN0YXJ0T2ZUdXJuUGhhc2UgLS0-IFNlbGVjdFJhY2VBbmRQb3dlclBoYXNlIDogYWZ0ZXIgZGVjbGluXG5cbkVuZE9mVHVyblBoYXNlIC0tPiBbKl0gOiBsb29zQ29ucXVlc3QgcGxheWVyXG5bKl0gLS0-IEVuZE9mVHVyblBoYXNlICA6IGJhY2sgdG8gYWN0aXZlIHBsYXllclxuXHRbKl0gLS0-IExvb3NDb25xdWVzdGVkQ2FzZVBoYXNlIDogc2VsZWN0ZWQgbG9vcyBjb25xdWVzdCBwbGF5ZXJcbiAgTG9vc0NvbnF1ZXN0ZWRDYXNlUGhhc2UgLS0-IFsqXVxuXHRcdFx0XHRcdCIsIm1lcm1haWQiOnsidGhlbWUiOiJkZWZhdWx0In0sInVwZGF0ZUVkaXRvciI6ZmFsc2V9)

#### Liste des phase
- ConquestPhase
- DecliningPhase
- EndOfTurnPhase
- FirstConquestPhase (B)
- LastConquestPhase
- LoosConquestedCasePhase
- SelectRaceAndPowerPhase (A)
- StartOfTurnPhase


### Action
La classe Player représente le joueur et toutes ces statistiques, cette classe et le point d'entré du *pattern State* qui permet de géré les différents action du joueur et état du jeu

#### [propriétés](https://fr.wikipedia.org/wiki/Propri%C3%A9t%C3%A9_(informatique)) (attributs) :
 - un type d'action (ActionType  )  : type
 -  un index (int) : index
 -  un numbre (int) : number

#### Enum
- l'enum ActionType qui permet de différencier les différente actions

#### Methode ( fonctions)
- Action(ActionType,int,int) constructeur de la classe construit une action a partir d'un type d'action d'un int index et d'un int number (optionnel)

### Board
La classe Board représente le plateau de jeu

#### [propriétés](https://fr.wikipedia.org/wiki/Propri%C3%A9t%C3%A9_(informatique)) (attributs) :
 - un Dictionaire représentant les case du tableau (Dictionary\<int,BoardCase>)  : boardCases

#### Methode ( fonctions)
- Board() le constructeur
- AddCase() pour réaliser une entré dans le dictionnaire


### BoardCases
La classe BoardCases représente une case du plateau 

#### [propriétés](https://fr.wikipedia.org/wiki/Propri%C3%A9t%C3%A9_(informatique)) (attributs) :
 -  L’avantage 1 de la case (CaseAdventage)  : adventage 
 - L’avantage 2 de la case (CaseAdventage)  : adventage2 
 - le type de la case (CaseType) : type
 - une liste de case adjacente (List\<int>) : adjacenteCaseKeys 
 - si la case est a un bord (bool) : bord
 - un nombre de troupe sur la case (int) : troopsNumber 
 - un nombre de peuple oublié (int) : forgottenTribe 
 - un nombre de campement (int) : cmaping
 - si la case possède une forteresse (bool) : haveFortresse 
 - si la case possède une antre de troll (bool) : haveTrollLair 
 - si la case possède un hero (bool) : haveHero 
 - si la case possède un dragon (bool) : haveDragon 
 - un type de race sur la case par defaut a "Nothing" (Race.RaceType) : raceType
- un numéro de joueur qui possède la case (int) : playerNumber
- une phase pour la race (Race.RacePhase) : racePhase 

#### Methode ( fonctions)
- BoardCases(CaseAdventage  , CaseAdventage  , CaseType  , List<int> , int  , bool  ) le constructeur

#### Enum
- l'enum CaseType qui liste les différentes  case 
  * Mountain
  * ForgottenTribe
  * Hills
  * Forest
  * Swamp
  * Fileds
  * water
  * Nothing
- l'enum CaseAdventage qui liste les différent avantage des case  
  * Mine
  * MagicSource
  * Cave
  * Nothing

 ### Deck
La classe Deck représente le paquet de race et de pouvoir 

#### [propriétés](https://fr.wikipedia.org/wiki/Propri%C3%A9t%C3%A9_(informatique)) (attributs) :
 - une liste de race (List\<Race>) : races 
 - une liste de pouvoir (List\<Power>) : powers 
 - une liste de 6 race (List\<Race>) : racesShortList 
 - une liste de  6 pouvoir  (List\<Race>) : powersShortList 

#### Methode ( fonctions)
- Deck ( ) le constructeur initialise les paquets 
- PickRaceAndPower(int  , out  Race  , out  Power)  permet de tirer une race et un pouvoirs et gère l'augmentation des prix 

#### Interface 
IListExtensions permet d'ajouter la méthode shuffle() aux List\<t>

### Race
La classe Race est une classe abstraite dont hérite toutes les race

#### [propriétés](https://fr.wikipedia.org/wiki/Propri%C3%A9t%C3%A9_(informatique)) (attributs) :
 -  le nom de la race  (string)  : name
 - la description de la race  (string)  : desc
 - la phase actuelle de la race (RacePhase) : phase
 - le type de la race ( RaceType) : type
 - le nombre de point de victoire qu'elle possède au moment ou elle est sélectionné (int) : victoryPointAtPick
 - le nombre de troupe que donne la race (int) : troopNumber
 - le nombre de troupe en jeu (int) : troopUsed (inutilisé dans le code)
 - le nombre de troupe max possible dans le jeu (int) : troopsMax 

#### Methode ( fonctions)
- race décrit un ensemble de methode abstraite qui sont utiliser contextuellement par rapport a l'action du joueur 
  * StartTurn(Player  p)
  * CanConquest(int  boardPos, Player  p)
  * ConquestCost(int  boardPos, ref  int  cost, Player  p)
  * Conquest(int  boardPos, Player  p)
  * VictoryPointGain(Player  p)
  *  EndTurn(Player  p)
  * LoosConquestedCase(int  boardPos, Player  p)
  * Declin(Player  p)


#### Enum
- l'enum RacePhase qui liste les différentes  phase 
  * Actual
  * Declin
  * Ancestral
 - l'enum RaceTypequi liste les différentes  race

### Power
La classe Power est une classe abstraite dont hérite tout les pouvoir 

#### [propriétés](https://fr.wikipedia.org/wiki/Propri%C3%A9t%C3%A9_(informatique)) (attributs) :
 -  le nom du pouvoir  (string)  : name
 - la description du pouvoir  (string)  : desc
 - le nombre de troupe que donne la race (int) : troopNumber
 
#### Methode ( fonctions)
- power décrit un ensemble de methode abstraite qui sont utiliser contextuellement par rapport a l'action du joueur 
  * StartTurn(Player  p)
  * CanConquest(int  boardPos, Player  p)
  * ConquestCost(int  boardPos, ref  int  cost, Player  p)
  * Conquest(int  boardPos, Player  p)
  * VictoryPointGain(Player  p)
  *  EndTurn(Player  p)
  * LoosConquestedCase(int  boardPos, Player  p)
  * Declin(Player  p)

## Interface (Ui/IHM)
La partie interface est la partie la plus propre a unity ici on utilisent vraiment les MonoBehaviour et le unityEngine
les interface du projet de base sont sommaire et n'on servie presque uniquement a tester et debugé 

### Plateau de jeu
Le plateau de jeu est modéliser en 3D et chacune des case possédé un script "BoardCaseScript"

##### BoardCaseScript :
ce  script permet de déclarer les case et donc de créé le plateau virtuellement a l’initialisation du programe chaque case va s'ajouter elle même a la l'instance de la classe Board dans le GameManager, chaque case est mapper a la main dans l'editeur.
ce script permet aussi de géré les event de clique sur les case, lors d'un clique doAction et exectuer sur le "player" actif
> doAction(new  Action(Action.ActionType.MapAction,CaseId,GameManager.Instance.selectedNumber)

### Les panels
Les autres interface implémenter sont des panels dans un canvas, elles affiche les differente informations du joueur et aussi gère les bouton et les "doAction" associer, la plus part des panels réagissent au differents Events du GameManager pour s'actualiser.
