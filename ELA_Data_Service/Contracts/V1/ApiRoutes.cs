using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ELA_Data_Service.Contracts.V1
{
    public static class ApiRoutes
    {
        public const string Root = "api";

        public const string Version = "v1";

        public const string Base = Root + "/" + Version;

        public static class TasksRoutes
        {
            public const string RandomTasks = Base + "/RandomTasks/{amount}";

            public const string Tasks = Base + "/TasksRoutes/{id}";
        }

        public static class UsersRoutes
        {
            public const string UserPoints = Base + "/Users/Points/{userId}";
        }
    }
}
