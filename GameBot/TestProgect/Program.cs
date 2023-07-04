
using Controllers.Controllers;
using DBServises.Servises;
using GameEngine.GameModels;
using GameEngine.GameModels.CharDescription;
using GameEngine.MiniGames;
using Microsoft.EntityFrameworkCore;
using Telegram.Bot.Types;


//using (ApplicationContext db = new ApplicationContext())
//{
//    db.Users.Add(new GeneralLibrary.BaseModels.User() { 
//        ChatId = 1, Name = $"User#{12}", ScenarioId = 1, Department = "2", ClanId = 2,
//        Clan = new GeneralLibrary.BaseModels.Clan() { Id = 0, Name = "" },
//        Role = new GeneralLibrary.BaseModels.Role() { Id = 0, Name = "", Type = GeneralLibrary.BaseModels.TypeRole.User}
//    });
//    db.SaveChanges();
//}
//DBController dB = new DBController(new ApplicationContext());
//GameController game = new GameController(dB);
//Console.WriteLine(game.GetUser(1));
/*
using (ApplicationContext db = new ApplicationContext())
{
    Hero hero = new Hero();
    Inventory inventory = new Inventory(hero);
    inventory.Items.Add(new Armor { Name ="343", ModStatus = new Status()});
    inventory.Items.Add(new Armor { Name = "344343", ModStatus = new Status() });
    // добавляем их в бд
    db.Inventories.Add(inventory);
    db.SaveChanges();
}
using (ApplicationContext db = new ApplicationContext())
{
    // получаем объекты из бд и выводим на консоль
    var inventories = db.Inventories.ToList();
    Console.WriteLine("Users list:");
    foreach (var u in inventories)
    {
        Console.WriteLine($"{u.Id}.");
    }
}
*/
//Random r = new Random();
//for (int i = 0; i < 10; i++)
//{
//    if (r.Next(0, 3) == 3) Console.WriteLine("gggg");
//}
//Console.WriteLine("end");

//HotOrCold hotOrCold = new HotOrCold();
//hotOrCold.Start();
//Console.WriteLine(hotOrCold.GameDescription);
//while (hotOrCold.IsWorked)
//{
//    Console.WriteLine("Загадайте число");
//    var gues = Convert.ToInt32(Console.ReadLine());
//    Console.WriteLine(hotOrCold.Guess(gues));
//}

CalculationGame calculationGame = new CalculationGame();
Console.WriteLine(calculationGame.GameDescription);
calculationGame.Start(6);
while (calculationGame.IsWorked)
{
    var e = calculationGame.GetNext();
    Console.WriteLine(e.example);
    foreach (var v in e.variants)
        Console.WriteLine(v);
    Console.Write("Введите ваш ответ: ");
    var a = Convert.ToDouble(Console.ReadLine());
    calculationGame.WriteAnswer(a);
}
Console.WriteLine(calculationGame.ShowStatistics());

