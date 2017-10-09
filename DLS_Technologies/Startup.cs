using Microsoft.Owin;
using Owin;
using Hangfire;
using DLS_Technologies.Utilities;

[assembly: OwinStartupAttribute(typeof(DLS_Technologies.Startup))]
namespace DLS_Technologies
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            GlobalConfiguration.Configuration
                .UseSqlServerStorage("DefaultConnection");

            //app.UseHangfireDashboard();
            //app.UseHangfireServer();

            //BackgroundJob.Enqueue(() => HangFireJobs.HangFireTest());
            //RecurringJob.AddOrUpdate("SiteVisitJob", () => HangFireJobs.CheckMonthlySiteVisitDates(), Cron.Minutely);

            ConfigureAuth(app);
        }
    }
}
