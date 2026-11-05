using System;
using System.Web;
using System.Web.Routing;

namespace WebAppPoliMusicV3
{
    public class Global : HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            RouteTable.Routes.MapPageRoute("Song", "Song", "~/Song.aspx");
            RouteTable.Routes.MapPageRoute("Logout", "Logout", "~/Logout.aspx");
        }
    }
}
