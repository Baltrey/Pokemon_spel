Player player = new();
Enemy enemy = new();
game game = new();

//använder array för att det är snabbare och att jag inte kommer lägga till mer i den efter skapelse
string[] choices = { "start(1)", "quit(2)" };
string[] choicesturn = { "attack(1)", "heal(2)", "buff(3)" };

tutorial();
while (true)
{
    Console.WriteLine("skriv respektiv siffra för att börja");
    Console.WriteLine(choices[0]);
    Console.WriteLine(choices[1]);
    string a = answer();
    if (a == "1")
    {
        while (gameactive(player, enemy, game))
        {
            Console.Clear();
            move(player, enemy, choicesturn);
            enemyattack(player, enemy);
            Console.ReadLine();
        }
    }
    if (a == "2")
    {
        return;
    }
    else
    {
        if (game.active)
        {
            Console.WriteLine("skriv ett nummer som jag har sagt");
        }
    }
}

static void move(Player player, Enemy enemy, string[] choicesturn)
{

    while (true)
    {
        Console.WriteLine(choicesturn[0]);
        Console.WriteLine(choicesturn[1]);
        Console.WriteLine(choicesturn[2]);
        string a = answer();
        if (a == "1")
        {
            attack(player, enemy);
            return;
        }
        if (a == "2")
        {
            heal(player);
            return;
        }
        if (a == "3")
        {
            buff(player);
            return;
        }
        else
        {
            Console.WriteLine("skriv ett alternativ som jag har sagt");

        }
    }
}
static bool gameactive(Player player, Enemy enemy, game game)
{
    if (enemy.hp <= 0)
    {
        Console.WriteLine("Du vann Grattis!!");
        game.active = false;
        enemy.hp = 100;
        player.hp = 100;
        return false;

    }
    if (player.hp <= 0)
    {
        Console.WriteLine("Du förlorade:(");
        game.active = false;
        enemy.hp = 100;
        player.hp = 100;
        return false;
    }
    return true;
}
static void tutorial()
{
    Console.WriteLine("Hej vill du ha en tutorial? y/n");
    while (true)
    {
        string a = answer();
        if (a == "Y" || a == "YES")
        {
            Console.WriteLine("okej så spelet kommer gå till att du får välja mellan 3 olika moves attack som gör skada, heal som ger tillbaka hälsa och buff som kommer göra din nästkommande attack starkare");
            Console.WriteLine("sen kommer motståndaren att slå dig och du kör tills någon har fått slut på hp");
            Console.ReadLine();
            Console.Clear();
            return;
        }
        if (a == "N" || a == "NO")
        {
            Console.Clear();
            return;
        }
        else
        {
            Console.WriteLine("skriv ett alternativ som jag har sagt");
        }
    }
}
static void attack(Player player, Enemy enemy)
{
    Random generator = new Random();
    player.attack += generator.Next(1, 11);
    enemy.hp -= player.attack;
    Console.WriteLine("Du slog för " + player.attack + " skada");
    Console.WriteLine("enemy har " + enemy.hp + "  hp kvar");
    player.attack = 0;

}
static void enemyattack(Player player, Enemy enemy)
{
    Random generator = new Random();
    enemy.attack = generator.Next(1, 15);
    Console.WriteLine("Du blev slagen för " + enemy.attack + " skada");
    player.hp -= enemy.attack;
    Console.WriteLine("Du har " + player.hp + "  hp kvar");

}
static void heal(Player player)
{
    Random generator = new Random();
    player.hp += generator.Next(1, 15);
    Console.WriteLine("Du har nu " + player.hp + " hp");
}
static void buff(Player player)
{
    Random generator = new Random();
    player.attack += generator.Next(1, 15);
}
static string answer()
{
    string answer = Console.ReadLine();
    string result = answer.ToUpper();
    return result;
}