namespace FunScience.Web.Areas.Admin.Views.Home
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using Microsoft.AspNetCore.Mvc.ViewFeatures;
    using System;

    public static class AdminNavPages
    {
        public static string ActivePageKey => "ActivePage";

        public static string Index => "All Employees";

        public static string School => "Add School";

        public static string ListOfSchools = "List of Schools";
        
        public static string Register = "Register";

        public static string CreatePlay = "Create Play";

        public static string Plays = "Plays";

        public static string CreateSchedule = "CreateSchedule";

        public static string IndexNavClass(ViewContext viewContext) => PageNavClass(viewContext, Index);

        public static string SchoolNavClass(ViewContext viewContext) => PageNavClass(viewContext, School);

        public static string SchoolsNavClass(ViewContext viewContext) => PageNavClass(viewContext, ListOfSchools);
        
        public static string RegisterNavClass(ViewContext viewContext) => PageNavClass(viewContext, Register);

        public static string CreatePlayNavClass(ViewContext viewContext) => PageNavClass(viewContext, CreatePlay);

        public static string CreateScheduleNavClass(ViewContext viewContext) => PageNavClass(viewContext, CreateSchedule);

        public static string PlaysNavClass(ViewContext viewContext) => PageNavClass(viewContext, Plays);

        public static string PageNavClass(ViewContext viewContext, string page)
        {
            var activePage = viewContext.ViewData["ActivePage"] as string;
            return string.Equals(activePage, page, StringComparison.OrdinalIgnoreCase) ? "active" : null;
        }

        public static void AddActivePage(this ViewDataDictionary viewData, string activePage) => viewData[ActivePageKey] = activePage;
    }
}
