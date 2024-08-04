using ExploreMars.Interfaces;
using Microsoft.Extensions.DependencyInjection;

// DI
var serviceProvider = new ServiceCollection()
    .AddTransient<IPosition, Position>()
    .AddTransient<IRover, Rover>()
    .BuildServiceProvider();

// App start
var rover = serviceProvider.GetService<IRover>();
rover!.Drive("LMLMLMLMM");
Console.WriteLine(rover!.GetPositionInfo());