
using DBServises.Servises;
using GameEngine.GameModels;
using GameEngine.GameModels.CharDescription;


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
