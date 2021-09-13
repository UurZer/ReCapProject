using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReCapProject.Integration.Tests.APIs.Car
{
    public partial class IntegrationTests
    {
        private static readonly string _baseUrl = "https://localhost:blabla/api/";

        public static class Users
        {
            private static readonly string _usersControllerUrl = string.Concat(_baseUrl, "users");

            public static readonly string GetAll = _usersControllerUrl;

            public static readonly string Get = string.Concat(_usersControllerUrl, "/{userId}");

            public static readonly string Delete = string.Concat(_usersControllerUrl, "/{userId}");
        }
    }
}
