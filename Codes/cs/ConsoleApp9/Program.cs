// Представляет одну кость домино с двумя значениями

public class Tile
{
    //Первое значение кости
    public int FirstValue { get; private set; }
    
    //Второе значение кости
    public int SecondValue { get; private set; }
    
    // Является ли кость дублем 
    public bool IsDouble => ...;

    public Tile(int first, int second)
    {
        ...
    }

    // Проверяет, совместима ли кость с другим значением
    public bool CanConnect(int value) => ...;

    // Переворачивает кость, меняя значения местами
    public void Rotate() => ...;

    // Возвращает значение для соединения (если одно значение равно target, возвращает другое)
    public int GetConnectingValue(int target)
    {
        ...
    }
}

//  Колода костей домино
public class Deck
{
    List<Tile> _tiles;
    Random _random;

    public int TilesCount => ...;

    public Deck()
    {
        ...
    }

    // Создает полный набор из 28 костей домино
    void InitializeDeck()
    {
        ...
    }

    // Перемешивает колоду
    public void Shuffle()
    {
        ...
    }

    // Раздает указанное количество костей
    public List<Tile> DealTiles(int count)
    {
        ...
    }

    // Берет одну кость из колоды
    public Tile DrawTile()
    {
        ...
    }
}

// Игровая доска с выложенными костями

public class Board
{
    // Сыгранные кости (необходимо для визуализации стола)
    private List<Tile> _playedTiles;
    
    // Значение на левом конце цепочки
    public int LeftEnd { get; private set; }
    
    // Значение на правом конце цепочки
    public int RightEnd { get; private set; }
    
    public int TilesCount => ...;
    public bool IsEmpty => ...;

    public Board()
    {
        ...
    }

    // Добавляет первую кость на доску
    public void PlaceFirstTile(Tile tile)
    {
        ...
    }

    // Добавляет кость в левый конец цепочки
    public bool PlaceTileLeft(Tile tile)
    {
        ...
    }

    // Добавляет кость в правый конец цепочки
    public bool PlaceTileRight(Tile tile)
    {
        ...
    }

    // Возвращает все выложенные кости
    public IReadOnlyList<Tile> GetPlayedTiles() => ...;
}

//  Игрок в домино
public class Player
{
    // Кости на руках у игрока
    public List<Tile> Hand { get; private set; }
    
    public string Name { get; private set; }
    public int TilesCount => ...;

    public Player(string name)
    {
        ...
    }

    // Добавляет кость в руку игрока
    public void AddTile(Tile tile) => ...;

    // Удаляет кость из руки игрока
    public void RemoveTile(Tile tile) => ...;

    // Проверяет, может ли игрок сделать ход
    public bool CanMakeMove(int leftEnd, int rightEnd)
    {
        ...
    }

    // Находит подходящую кость для хода
    public Tile FindTileForMove(int leftEnd, int rightEnd, out bool placeOnLeft)
    {
        ...
    }
}

//  Основной класс игры в домино

public class Game
{
    public Deck Deck { get; private set; }
    public Board Board { get; private set; }
    public List<Player> Players { get; private set; }
    public int CurrentPlayerIndex { get; private set; }
    public bool GameStarted { get; private set; }

    public Game()
    {
        ...
    }

    // Добавляет игрока в игру
    public void AddPlayer(string name)
    {
        ...
    }

    // Начинает игру, раздавая кости
    public void StartGame(int tilesPerPlayer = 7)
    {
        ...
    }

    // Выполняет ход текущего игрока
    public bool MakeMove(Player player, Tile tile, bool placeOnLeft)
    {
        ...
    }

    // Проверяет, закончена ли игра
    public bool IsGameOver()
    {
        ...
    }

    // Определяет победителя
    public Player GetWinner()
    {
        ...
    }
}
