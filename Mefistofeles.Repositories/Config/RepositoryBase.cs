using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mefistofeles.Repositories.Config
{
    public class RepositoryBase
    {
        public SqlConnection connection { get; set; }

        private static SqlConnection _connection;

        protected RepositoryBase()
        {
            connection = GetConnection();
        }

        public SqlConnection GetConnection()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection("Data Source=.;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True;Database=MefistoDB");
            }

            return _connection;
        }
    }
}
