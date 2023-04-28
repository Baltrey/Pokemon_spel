
Enemy enemy = new();
Player player = new();

string[] choices = { "start(1)", "quit(2)" };
string[] choicesturn = { "attack(1)", "heal(2)", "buff(3)" };


while (true)
{
    Console.WriteLine("skriv respektiv siffra för att börja");
    Console.WriteLine(choices[0]);
    Console.WriteLine(choices[1]);
    if (answer() == "1")
    {
        start();
        while (true)
        {

            move();
        }
    }
    if (answer() == "2")
    {
        return;
    }
    else
    {
        Console.WriteLine("skriv ett nummer som jag har sagt");
    }
}
void start()
{
    enemy.hp = 100;
    player.hp = 100;

}
void move()
{

    while (true)
    {
        Console.WriteLine(choicesturn[0]);
        Console.WriteLine(choicesturn[1]);
        Console.WriteLine(choicesturn[2]);
        if (answer() == "1")
        {
            attack();
            return;
        }
        if (answer() == "2")
        {
            heal();
            return;
        }
        if (answer() == "3")
        {
            buff();
            return;
        }
        else
        {
            Console.WriteLine("skriv ett alternativ som jag har sagt");
        }
    }
}
void isalive()
{

}
void attack()
{
    Random generator = new Random();
    player.attack += generator.Next(1, 11);
    enemy.hp -= player.attack;
    player.attack = 0;

}
void heal()
{
    Random generator = new Random();
    player.hp += generator.Next(1, 11);
}
void buff()
{
    Random generator = new Random();
    player.attack += generator.Next(1, 6);
}
static string answer()
{
    string answer = Console.ReadLine();
    return answer;

}
