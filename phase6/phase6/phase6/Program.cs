using phase6.Services.Processor.QueryProcessor.InputHandler;
using phase6.Services.Processor.QueryProcessor.InputHandler.SearchStrategyImplemention;
using phase6.Services.Processor.QueryProcessor.InputHandler.SearchStrategyImplemention.Abstractions;
using phase6.Services.Processor.QueryProcessor.SearchStrategy;
using phase6.Services.Processor.QueryProcessor.SearchStrategy.Abstractions;
using phase6.Services.Processor.QueryProcessor.SearchStrategy.SearchStrategyFactory;
using phase6.Services.Processor.QueryProcessor.SearchStrategy.SearchStrategyFactory.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ISearchStrategyFactory,SearchStrategyFactory>();
builder.Services.AddTransient<ISearchQueryParser,SearchQueryParser>();
builder.Services.AddTransient<ISearchResultsFilter,SearchResultsFilter>();
builder.Services.AddTransient<InputSplitHandler,InputSplitHandler>();
builder.Services.AddTransient<IAtLeastOneInputStrategy, AtLeastOneAtLeastOneInputStrategy>();
builder.Services.AddTransient<IMustIncludeInputStrategy, MustIncludeInputStrategy>();
builder.Services.AddTransient
    <IMustNotContainInputStrategy, MustNotContainInputStrategy>();
builder.Services.AddTransient<SearchStrategy>(provider => new SearchStrategy(
    provider.GetRequiredService<SearchStrategyFactory>(),
    provider.GetRequiredService<SearchQueryParser>(),
    provider.GetRequiredService<SearchResultsFilter>(),
    provider.GetRequiredService<InputSplitHandler>()
));

builder.Services.AddControllers();
var app = builder.Build();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();