using API.EmployedFolder;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.Text;

namespace API.CustomFormatters
{
    public class MyFormatters : TextOutputFormatter
    {
        public MyFormatters()
        {
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/x-myformat"));
            SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("text/myformat"));
        }

        public override Task WriteResponseBodyAsync(OutputFormatterWriteContext context, Encoding selectedEncoding)
        {
           HttpResponse response = context.HttpContext.Response;
            StringBuilder buffer = new StringBuilder();
            if ((context.Object is IEnumerable<Employee>)
                {
                    foreach (var item in (IEnumerable<Employee>)context.Object)
                    {
                       EmpToCsv(item, buffer);
                }
                {
                
            }
        }
    }
    {
    }
}
