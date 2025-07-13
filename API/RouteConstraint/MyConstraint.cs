public class MyConstraint : IRouteConstraint
{
    public bool Match(HttpContext? httpContext, IRouter? route, string routeKey, RouteValueDictionary values, RouteDirection routeDirection)
    {
        
        if (values.TryGetValue(routeKey, out var value) && value != null)
        {
            return int.TryParse(value.ToString(), out _);
        }

        return false;
    }
}
