using API.EmployedFolder;

using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace API.CustomFormatters
{
    // Définition d'un formatter personnalisé qui produit une sortie texte au format CSV pour des objets Employee
    public class MyFormatters : TextOutputFormatter
    {
        public MyFormatters()
        {
            // Déclare les types MIME personnalisés que ce formatter peut gérer
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/x-myformat"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/myformat"));

            // Déclare les encodages pris en charge (facultatif mais recommandé)
            SupportedEncodings.Add(Encoding.UTF8);
            SupportedEncodings.Add(Encoding.Unicode);
        }

        // Surcharge appelée automatiquement par ASP.NET Core pour écrire le corps de la réponse
        public override async Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
            // Récupère la réponse HTTP à modifier
            HttpResponse response = context.HttpContext.Response;

            // StringBuilder pour construire la réponse CSV ligne par ligne
            StringBuilder buffer = new StringBuilder();

            // Si l'objet retourné est une collection d'employés
            if (context.Object is IEnumerable<Employee>)
            {
                // Pour chaque employé, on génère une ligne CSV
                foreach (Employee emp in (IEnumerable<Employee>)context.Object)
                {
                    EmpToCsv(buffer, emp);
                }
            }
            // Si l'objet retourné est un seul employé
            else if (context.Object is Employee)
            {
                // On génère une ligne CSV pour cet employé
                EmpToCsv(buffer, (Employee)context.Object);
            }

            // Écrit le contenu CSV généré dans la réponse HTTP
            await response.WriteAsync(buffer.ToString(), selectedEncoding);
        }

        // Méthode utilitaire privée qui convertit un Employee en ligne CSV
        private void EmpToCsv(StringBuilder buffer, Employee emp)
        {
            // Si c'est la première ligne (le buffer est vide), on ajoute l'en-tête CSV
            if (buffer.Length == 0)
            {
                buffer.AppendLine("Id,Firstname,Lastname");
            }

            // Ajoute une ligne CSV pour l'employé courant
            buffer.AppendLine($"{emp.Id},{emp.Firstname},{emp.Lastname}");
        }
    }
}
