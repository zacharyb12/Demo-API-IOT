// Création du générateur d'application Web avec les arguments de la ligne de commande -------------------------
using API.CustomFormatters;
using API.EmployedFolder;

var builder = WebApplication.CreateBuilder(args);



// Ajout des services au conteneur d'injection de dépendances

builder.Services.AddSingleton<IContext>(m => new FakeContext());


// Ajoute le support des contrôleurs MVC à l'application
//builder.Services.AddControllers();

//builder.Services.AddControllers( options =>
//{
//    options.OutputFormatters.Add(new MyFormatters()); // Ajoute le formatter personnalisé pour gérer les réponses au format CSV
//});

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true; // Respecte l'en-tête Accept du navigateur pour déterminer le format de réponse
    config.ReturnHttpNotAcceptable = true; // Retourne une erreur 406 si le format demandé n'est pas supporté
}).AddXmlSerializerFormatters();

// Ajoute les services nécessaires pour explorer les points de terminaison de l'API (OpenAPI/Swagger)
builder.Services.AddEndpointsApiExplorer();

// Ajoute et configure Swagger pour la documentation de l'API
builder.Services.AddSwaggerGen();

builder.Services.AddCors( options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin() // Autorise toutes les origines
               .AllowAnyMethod() // Autorise toutes les méthodes HTTP (GET, POST, etc.)
               .AllowAnyHeader(); // Autorise tous les en-têtes
    });
});


builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("MyConstraint", typeof(MyConstraint));
});



// Construction de l'application à partir du builder configuré ------------------------------------------------
var app = builder.Build();




// Configuration du pipeline de traitement des requêtes HTTP

// Si l'environnement est en développement, active Swagger et son interface utilisateur
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();      // Génère la documentation Swagger au format JSON
    app.UseSwaggerUI();    // Active l'interface utilisateur Swagger pour tester l'API
}

// Redirige automatiquement les requêtes HTTP vers HTTPS
app.UseHttpsRedirection();


// Active la politique CORS définie précédemment pour permettre les requêtes cross-origin
app.UseCors("CorsPolicy");

// Active l'autorisation (vérification des droits d'accès)
app.UseAuthorization();

// Mappe les contrôleurs aux routes définies dans l'application
app.MapControllers();


// Démarre l'application et commence à écouter les requêtes HTTP ----------------------------------------------
app.Run(); 
