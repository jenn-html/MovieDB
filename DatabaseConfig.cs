using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Data.SqlClient;

namespace MovieDB
{
    internal static class DatabaseConfig
    {
        internal static string ConnectionString =>
            "Server=localhost;Database=MovieDB;Trusted_Connection=True;TrustServerCertificate=True;";

        internal static SqlConnection CreateConnection() => new SqlConnection(ConnectionString);
    }
}