// See https://aka.ms/new-console-template for more information
using System.Reflection;

var res = new Dictionary<string, string>();
var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
List<Assembly> allAssemblies = new List<Assembly>();

foreach (string dll in Directory.GetFiles(path, "*.dll"))
    allAssemblies.Add(Assembly.LoadFile(dll));
Console.WriteLine("Report");

allAssemblies.ForEach(assembly =>
{ 
    var totalNumber = 0;
    var types = assembly.GetTypes();
    foreach (var tp in types)
    {
        var numPerClass = tp.GetMethods(BindingFlags.Public | BindingFlags.Instance).Length;
        totalNumber += numPerClass;
    } 
    
    //res.Add(assembly.FullName, totalNumber.ToString());
    Console.WriteLine($"{assembly.FullName}: {totalNumber}");
});