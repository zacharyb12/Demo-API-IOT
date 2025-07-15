// Cr�ation du g�n�rateur d'application Web avec les arguments de la ligne de commande -------------------------
using API.CustomFormatters;
using API.EmployedFolder;

var builder = WebApplication.CreateBuilder(args);



// Ajout des services au conteneur d'injection de d�pendances

builder.Services.AddSingleton<IContext>(m => new FakeContext());


// Ajoute le support des contr�leurs MVC � l'application
//builder.Services.AddControllers();

//builder.Services.AddControllers( options =>
//{
//    options.OutputFormatters.Add(new MyFormatters()); // Ajoute le formatter personnalis� pour g�rer les r�ponses au format CSV
//});

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true; // Respecte l'en-t�te Accept du navigateur pour d�terminer le format de r�ponse
    config.ReturnHttpNotAcceptable = true; // Retourne une erreur 406 si le format demand� n'est pas support�
}).AddXmlSerializerFormatters();

// Ajoute les services n�cessaires pour explorer les points de terminaison de l'API (OpenAPI/Swagger)
builder.Services.AddEndpointsApiExplorer();

// Ajoute et configure Swagger pour la documentation de l'API
builder.Services.AddSwaggerGen();

builder.Services.AddCors( options =>
{
    options.AddPolicy("CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin() // Autorise toutes les origines
               .AllowAnyMethod() // Autorise toutes les m�thodes HTTP (GET, POST, etc.)
               .AllowAnyHeader(); // Autorise tous les en-t�tes
    });
});


builder.Services.Configure<RouteOptions>(options =>
{
    options.ConstraintMap.Add("MyConstraint", typeof(MyConstraint));
});



// Construction de l'application � partir du builder configur� ------------------------------------------------
var app = builder.Build();




// Configuration du pipeline de traitement des requ�tes HTTP

// Si l'environnement est en d�veloppement, active Swagger et son interface utilisateur
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();      // G�n�re la documentation Swagger au format JSON
    app.UseSwaggerUI();    // Active l'interface utilisateur Swagger pour tester l'API
}

// Redirige automatiquement les requ�tes HTTP vers HTTPS
app.UseHttpsRedirection();


// Active la politique CORS d�finie pr�c�demment pour permettre les requ�tes cross-origin
app.UseCors("CorsPolicy");

// Active l'autorisation (v�rification des droits d'acc�s)
app.UseAuthorization();

// Mappe les contr�leurs aux routes d�finies dans l'application
app.MapControllers();


// D�marre l'application et commence � �couter les requ�tes HTTP ----------------------------------------------
app.Run(); 
