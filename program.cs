System.Func<bool> CreateToggle()
{
    bool a = false;
    return () =>
    {
        return a = !a;
    };
}

List<string> toggleButtons = new List<string> { "StartGame", "Shop", "Quit" };
Dictionary<string, System.Func<bool>> toggleEvents = new Dictionary<string, Func<bool>>();

var i = 0;
foreach (var btns in toggleButtons)
    toggleEvents.Add(btns, CreateToggle());

Console.WriteLine("Toggle [StartGame] => " + toggleEvents["StartGame"]());
Console.WriteLine("Toggle [StartGame] => " + toggleEvents["StartGame"]());
Console.WriteLine("Toggle [StartGame] => " + toggleEvents["StartGame"]());
Console.WriteLine("Toggle [Shop] => " + toggleEvents["Shop"]());
Console.WriteLine("Toggle [StartGame] => " + toggleEvents["StartGame"]());
Console.WriteLine("Toggle [Shop] => " + toggleEvents["Shop"]());
Console.WriteLine("Toggle [Quit] => " + toggleEvents["Quit"]());
Console.WriteLine("Toggle [Quit] => " + toggleEvents["Quit"]());
Console.WriteLine("Toggle [Quit] => " + toggleEvents["Quit"]());
Console.WriteLine("Toggle [StartGame] => " + toggleEvents["StartGame"]());

/* out put sample
Toggle [StartGame] => True
Toggle [StartGame] => False
Toggle [StartGame] => True
Toggle [Shop] => True
Toggle [StartGame] => False
Toggle [Shop] => False
Toggle [Quit] => True
Toggle [Quit] => False
Toggle [Quit] => True
Toggle [StartGame] => True
 */
