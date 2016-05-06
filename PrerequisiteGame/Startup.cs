using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PrerequisiteGame.Startup))]
namespace PrerequisiteGame
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
