using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class connection
    {
        string URL_CONNECT = "server=DESKTOP-O1047G9;database=Pelicula;integrated security=true";
        public SqlConnection getCn { get { return new SqlConnection(URL_CONNECT); } }
    }
}
