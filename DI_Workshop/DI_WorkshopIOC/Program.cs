using DI_WorkshopIOC;
using DI_WorkshopIOC.DI;
using DI_WorkshopIOC.Renderers;
using Microsoft.Extensions.DependencyInjection;


// global dependancy inversion/injection
// IoC Container - inversion of control container (framework, който ни позволява глобално да дефинираме нашите депендансита!)


//IRenderer renderer = new ConsoleRenderer();
//Canvas canvas = new Canvas(renderer);


IRenderer renderer = DIProvider.GetServiceProvider().GetRequiredService<IRenderer>();
Canvas canvas = DIProvider.GetServiceProvider() .GetRequiredService<Canvas>();

canvas.Draw();