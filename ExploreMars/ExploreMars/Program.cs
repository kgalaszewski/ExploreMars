using ExploreMars.Enums;
using ExploreMars.Interfaces;
using Microsoft.Extensions.DependencyInjection;

// DI
var serviceProvider = new ServiceCollection()
    .AddTransient<IPosition, Position>()
    .AddTransient<IRover, Rover>()
    .BuildServiceProvider();

// App start
var rover = serviceProvider.GetService<IRover>();
rover!.Initialize(1, 2, Direction.West);
Console.WriteLine(rover!.GetPositionInfo());
rover!.Drive("LMMLMRMMLMMM");
Console.WriteLine(rover!.GetPositionInfo());