# PlayerManagerMVC

## UML Class Diagram

<<<<<<< HEAD
``` markdown
mermaid classDiagram class Player { +Name: string +Score: int +ToString(): string +CompareTo(Player): int }
=======
```
classDiagram
>>>>>>> 849ac1b97601488b11623d6c56276ef749f1e48b
class PlayerView {
    +ShowMenu()
    +DisplayPlayers(IEnumerable~Player~)
    +GetNewPlayerInfo(): (string, int)
    +GetSortOrder(): PlayerOrder
    +GetMinimumScore(): int
    +WaitForKey()
    +DisplayGoodbye()
    +DisplayError(string)
}

class PlayerController {
    -playerList: List~Player~
    -view: PlayerView
    -compareByName: IComparer~Player~
    -compareByNameReverse: IComparer~Player~
    +Start()
    -InsertPlayer()
    -ListPlayers()
    -ListPlayersWithScoreGreaterThan()
    -SortPlayerList()
    -LoadPlayersFromFile(string)
}

class CompareByName {
    -ord: bool
    +Compare(Player, Player): int
}

enum PlayerOrder {
    ByScore
    ByName
    ByNameReverse
}

PlayerController --> PlayerView
PlayerController --> Player
<<<<<<< HEAD
PlayerController --> CompareByName
CompareByName ..|> IComparer
Player ..|> IComparable

```
=======
```
>>>>>>> 849ac1b97601488b11623d6c56276ef749f1e48b
