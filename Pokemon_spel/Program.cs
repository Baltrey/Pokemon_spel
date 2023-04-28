﻿
Enemy enemy = new();
Player player = new();

string[] choices = { "start(1)", "quit(2)" };
string[] choicesturn = { "attack(1)", "heal(2)", "buff(3)" };

bool active = true;

while (true)
{
    active = true;
    Console.WriteLine("skriv respektiv siffra för att börja");
    Console.WriteLine(choices[0]);
    Console.WriteLine(choices[1]);
    if (answer() == "1")
    {
        start();
        while (gameactive())
        {
            Console.Clear();
            move();
            enemyattack();
            Console.ReadLine();
        }
    }
    if (answer() == "2")
    {
        return;
    }
    else
    {
        if (active)
        {
            Console.WriteLine("skriv ett nummer som jag har sagt");
        }
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
bool gameactive()
{
    if (enemy.hp <= 0)
    {
        Console.WriteLine("Du vann Grattis!!");
        active = false;
        return false;

    }
    if (player.hp <= 0)
    {
        Console.WriteLine("Du förlorade:(");
        active = false;
        return false;
    }
    return true;
}
void attack()
{
    Random generator = new Random();
    player.attack += generator.Next(1, 11);
    enemy.hp -= player.attack;
    Console.WriteLine("Du slog för " + player.attack + " skada");
    Console.WriteLine("enemy har " + enemy.hp + "  hp kvar");
    player.attack = 0;

}
void enemyattack()
{
    Random generator = new Random();
    enemy.attack = generator.Next(1, 15);
    Console.WriteLine("Du blev slagen för " + enemy.attack + " skada");
    player.hp -= enemy.attack;
    Console.WriteLine("Du har " + player.hp + "  hp kvar");

}
void heal()
{
    Random generator = new Random();
    player.hp += generator.Next(1, 11);
    Console.WriteLine("Du har nu " + player.hp + " hp");
}
void buff()
{
    Random generator = new Random();
    player.attack += generator.Next(1, 6);
}
string answer()
{
    if (active)
    {
        string answer = Console.ReadLine();
        return answer;
    }
    else
    {
        string answer = "0";
        return answer;
    }
}
