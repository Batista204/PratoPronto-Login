public class RouteConfig
{

    public static void RegisterRoutes(RouteCollection routes) 
    {
        routes.IgnoreRoute("{resource}.add/{*pathInfo}");

        routes.MapRoute (
            name: "Default",
            url: "{controller}/{action}/{id}",
            defaults: new { controller = "todo", action = "Index", id = UrlParameter.Optional}
        );
    }
}