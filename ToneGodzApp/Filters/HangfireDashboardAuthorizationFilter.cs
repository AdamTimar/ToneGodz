using Hangfire.Dashboard;

namespace ToneGodzApp.Filters
{
    public class HangfireDashboardAuthorizationFilter : IDashboardAuthorizationFilter
    {
        public bool Authorize(DashboardContext context)
        {
            // Check if the user is authenticated
            var user = context.GetHttpContext().User;

            if (!user.Identity.IsAuthenticated)
            {
                return false; // Deny access if the user is not authenticated
            }

            // You can restrict access based on roles or claims
            return user.IsInRole("Admin");  // Only users in "Admin" role are authorized
        }
    }
}