using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Web;

namespace WCF_Proyecto_CineALL
{
      public class Service1 : IService1
      {

        /*===============================================================================*/
        /*                                COMESTIBLES                                    */
        /*===============================================================================*/
        public List<Comestibles> comestibles()
        {
            List<Comestibles> temporal = new List<Comestibles>();
            using (SqlConnection cn = new connection().getCn)
            {
                SqlCommand cmd = new SqlCommand("exec USP_LIST_COMESTIBLES", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Comestibles()
                    {
                        cod_Com = (string)dr[0],
                        descrip = (string)dr[1],
                        precio = (Double)dr[2],
                        stock_Actual = (int)dr[3],
                        id_Tipo = (int)dr[4],
                        id_proveedor = (int)dr[5],
                        estado = (string)dr[6],
                        rutaimg = (string)dr[7],
                        descripcionTipo = (string)dr[8],
                        descripcionProveedor = (string)dr[9]
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string AgregarCome(Comestibles reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new connection().getCn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_ADD_COMESTIBLES", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descrip", reg.descrip);
                    cmd.Parameters.AddWithValue("@precio", reg.precio);
                    cmd.Parameters.AddWithValue("@stock_Actual", reg.stock_Actual);
                    cmd.Parameters.AddWithValue("@id_Tipo", reg.id_Tipo);
                    cmd.Parameters.AddWithValue("@id_proveedor", reg.id_proveedor);
                    cmd.Parameters.AddWithValue("@estado", reg.estado);
                    cmd.Parameters.AddWithValue("@img", reg.rutaimg);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = i + " registro agregado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string ActualizarCome(Comestibles reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new connection().getCn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_UPDATE_COMESTIBLES", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cod_Com", reg.cod_Com);
                    cmd.Parameters.AddWithValue("@descrip", reg.descrip);
                    cmd.Parameters.AddWithValue("@precio", reg.precio);
                    cmd.Parameters.AddWithValue("@stock_Actual", reg.stock_Actual);
                    cmd.Parameters.AddWithValue("@id_Tipo", reg.id_Tipo);
                    cmd.Parameters.AddWithValue("@id_proveedor", reg.id_proveedor);
                    cmd.Parameters.AddWithValue("@estado", reg.estado);
                    cmd.Parameters.AddWithValue("@img", reg.rutaimg);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = i + " registro actualizado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string EliminarCome(Comestibles reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new connection().getCn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_DELETE_COMESTIBLES", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cod_Com", reg.cod_Com);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = i + " registro inhabilitado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }


        /*===============================================================================*/
        /*                               TIPO COMESTIBLES                                */
        /*===============================================================================*/
        public List<TipoComestible> tipocomestibles()
        {
            List<TipoComestible> temporal = new List<TipoComestible>();
            using (SqlConnection cn = new connection().getCn)
            {
                SqlCommand cmd = new SqlCommand("exec USP_LIST_TIPOCOMESTIBLE", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new TipoComestible()
                    {
                        id = (int)dr[0],
                        descrip = (string)dr[1],
                        estado = (string)dr[2],
                       
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string AgregarTipCome(TipoComestible reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new connection().getCn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_ADD_TIPOCOMESTIBLE", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", reg.descrip);
                    cmd.Parameters.AddWithValue("@estado", reg.estado);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = i + " registro agregado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string ActualizarTipCome(TipoComestible reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new connection().getCn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_UPDATE_TIPOCOMESTIBLE", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", reg.id);
                    cmd.Parameters.AddWithValue("@descripcion", reg.descrip);
                    cmd.Parameters.AddWithValue("@estado", reg.estado);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = i + " registro actualizado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string EliminarTipCome(TipoComestible reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new connection().getCn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_DELETE_TIPOCOMESTIBLE", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", reg.id);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = i + " registro inhabilitado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        
    }


        /*===============================================================================*/
        /*                                  PROVEEDOR                                    */
        /*===============================================================================*/
        public List<Proveedor> proveedor()
        {
            List<Proveedor> temporal = new List<Proveedor>();
            using (SqlConnection cn = new connection().getCn)
            {
                SqlCommand cmd = new SqlCommand("exec USP_LIST_PROVEEDOR", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temporal.Add(new Proveedor()
                    {
                        id = (int)dr[0],
                        nombre = (string)dr[1],
                        telefono = (string)dr[2],
                        direccion = (string)dr[3],
                        estado = (string)dr[4]
                      
                    });
                }
                dr.Close();
            }
            return temporal;
        }

        public string AgregarProve(Proveedor reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new connection().getCn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_ADD_PROVEEDOR", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", reg.nombre);
                    cmd.Parameters.AddWithValue("@telf", reg.telefono);
                    cmd.Parameters.AddWithValue("@direc", reg.direccion);
                    cmd.Parameters.AddWithValue("@estado", reg.estado);
                  
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = i + " registro agregado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string ActualizarProve(Proveedor reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new connection().getCn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_UPDATE_PROVEEDOR", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", reg.id);
                    cmd.Parameters.AddWithValue("@nombre", reg.nombre);
                    cmd.Parameters.AddWithValue("@telf", reg.telefono);
                    cmd.Parameters.AddWithValue("@direc", reg.direccion);
                    cmd.Parameters.AddWithValue("@estado", reg.estado);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = i + " registro actualizado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string EliminarProve(Proveedor reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new connection().getCn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_DELETE_PROVEEDOR", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@id", reg.id);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = i + " registro inhabilitado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }


        /*===============================================================================*/
        /*                              TIPO PELICULA                                    */
        /*===============================================================================*/
        public List<TipoPelicula> listTipoPelicula()
        {
            List<TipoPelicula> temp = new List<TipoPelicula>();

            using (SqlConnection cn = new connection().getCn)
            {
                SqlCommand cmd = new SqlCommand("USP_LIST_TIPOPELICULA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temp.Add(new TipoPelicula()
                    {
                        codigo = (int)dr[0],
                        descripcion = (string)dr[1],
                        estado = (string)dr[2],
                    });
                }
                dr.Close();
            }
            return temp;
        }

        public string addTipoPelicula(TipoPelicula reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new connection().getCn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_ADD_TIPOPELICULA", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@descripcion", reg.descripcion);
                    cmd.Parameters.AddWithValue("@estado", reg.estado);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = i + " registro agregado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string updateTipoPelicula(TipoPelicula reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new connection().getCn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_UPDATE_TIPOPELICULA", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo", reg.codigo);
                    cmd.Parameters.AddWithValue("@descripcion", reg.descripcion);
                    cmd.Parameters.AddWithValue("@estado", reg.estado);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = i + " registro actualizado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string deleteTipoPelicula(TipoPelicula reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new connection().getCn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_DELETE_TIPOPELICULA", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@codigo", reg.codigo);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = i + " registro eliminado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }


        /*===============================================================================*/
        /*                                   PELICULA                                    */
        /*===============================================================================*/
        public List<Peliculas> listPeliculas()
        {
            List<Peliculas> temp = new List<Peliculas>();
            using (SqlConnection cn = new connection().getCn)
            {
                SqlCommand cmd = new SqlCommand("USP_LIST_PELICULAS", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    temp.Add(new Peliculas()
                    {
                        codigo = (string)dr[0],
                        nombre = (string)dr[1],
                        idTipo = (int)dr[2],
                        fechaEstreno = (DateTime)dr[3],
                        fechaFinal = (DateTime)dr[4],
                        precio = (Double)dr[5],
                        entradas = (int)dr[6],
                        entradasRestantes = (int)dr[7],                     
                        estado = (string)dr[8],
                        rutaimg= (string)dr[9],
                        descripcionTipo = (string)dr[10]
                    });
                }
                dr.Close();
            }
            return temp;
        }
      
        public string addPelicula(Peliculas reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new connection().getCn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_ADD_PELICULAS", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@nombre", reg.nombre);
                    cmd.Parameters.AddWithValue("@tipo_peli", reg.idTipo);
                    cmd.Parameters.AddWithValue("@fecha_Estreno", reg.fechaEstreno);
                    cmd.Parameters.AddWithValue("@fecha_final", reg.fechaFinal);
                    cmd.Parameters.AddWithValue("@entradas", reg.entradas);
                    cmd.Parameters.AddWithValue("@entradasRestantes", reg.entradasRestantes);
                    cmd.Parameters.AddWithValue("@precio", reg.precio);
                    cmd.Parameters.AddWithValue("@estado", reg.estado);
                    cmd.Parameters.AddWithValue("@img", reg.rutaimg);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = i + " registro agregado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string updatePelicula(Peliculas reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new connection().getCn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_UPDATE_PELICULAS", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cod_peli", reg.codigo);
                    cmd.Parameters.AddWithValue("@nombre", reg.nombre);
                    cmd.Parameters.AddWithValue("@tipo_peli", reg.idTipo);
                    cmd.Parameters.AddWithValue("@fecha_Estreno", reg.fechaEstreno);
                    cmd.Parameters.AddWithValue("@fecha_final", reg.fechaFinal);
                    cmd.Parameters.AddWithValue("@entradas", reg.entradas);
                    cmd.Parameters.AddWithValue("@entradasRestantes", reg.entradasRestantes);
                    cmd.Parameters.AddWithValue("@precio", reg.precio);
                    cmd.Parameters.AddWithValue("@estado", reg.estado);
                    cmd.Parameters.AddWithValue("@img", reg.rutaimg);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = i + " registro actualizado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        public string deletePelicula(Peliculas reg)
        {
            string mensaje = "";
            using (SqlConnection cn = new connection().getCn)
            {
                try
                {
                    SqlCommand cmd = new SqlCommand("USP_DELETE_PELICULAS", cn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@cod_peli", reg.codigo);
                    cn.Open();
                    int i = cmd.ExecuteNonQuery();
                    mensaje = i + " registro eliminado";
                }
                catch (SqlException ex) { mensaje = ex.Message; }
                finally { cn.Close(); }
            }
            return mensaje;
        }

        /*===============================================================================*/
        /*                                TRANSACCION                                    */
        /*===============================================================================*/
        public string Transaccion(Boleta reg, IEnumerable<Carrito> carrito)
        {
            string mensaje = "";
            SqlConnection cn = new connection().getCn;
            cn.Open();
            SqlTransaction tr = cn.BeginTransaction(IsolationLevel.Serializable);
            try
            {
                //1.
                SqlCommand cmd = new SqlCommand("USP_ADD_BOLETA", cn, tr);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@cod_user", SqlDbType.Char, 15).Value = reg.codigoUsuario;
                cmd.Parameters.Add("@fecha_bol", SqlDbType.Date).Value = DateTime.Now;
                cmd.Parameters.Add("@prec_total", SqlDbType.Float).Value = reg.precioTotal;
                cmd.Parameters.Add("@codigo", SqlDbType.Char, 5).Direction = ParameterDirection.Output;
                object codigo = cmd.ExecuteNonQuery();

                //2.
                string n = (string)cmd.Parameters["@codigo"].Value;

                //3.
                foreach (Carrito element in carrito)
                {
                    cmd = new SqlCommand("USP_ADD_DETALLEBOLETA", cn, tr);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@cod_bol", SqlDbType.Char, 5).Value = n;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = element.cantidad;
                    cmd.Parameters.Add("@total", SqlDbType.Float).Value = element.precio; 
                    if(element.tipo == 1) cmd.Parameters.Add("@cod_peli", SqlDbType.Char, 5).Value = element.codigoProducto;
                    else cmd.Parameters.Add("@cod_Com", SqlDbType.Char, 5).Value = element.codigoProducto;

                    cmd.ExecuteNonQuery();
                }
                //4.Ejecutar el procedure usp_actualiza_unidades, leyendo cada registro de carrito
                foreach (Carrito element in carrito)
                {
                    cmd = new SqlCommand("USP_ACTUALIZA_PRODUCTOS", cn, tr);
                    cmd.CommandType = CommandType.StoredProcedure; 

                    cmd.Parameters.Add("@codigo", SqlDbType.Char, 5).Value = element.codigoProducto;
                    cmd.Parameters.Add("@tipo", SqlDbType.Int).Value = element.tipo;
                    cmd.Parameters.Add("@cantidad", SqlDbType.Int).Value = element.cantidad;

                    cmd.ExecuteNonQuery();
                }
                //si todo esta ok
                tr.Commit();
                mensaje = string.Format("Se ha registrado la Orden con numero {0}", n);
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                tr.Rollback();
            }
            finally { cn.Close(); }

            return mensaje;
        }

        /*===============================================================================*/
        /*                                   PELICULA                                    */
        /*===============================================================================*/

        public Usuario validarUsuario(string usu, string contraseña)
        {
            Usuario usuario = null;
            using (SqlConnection cn = new connection().getCn)
            {
                SqlCommand cmd = new SqlCommand("USP_LOGUIN", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@user", usu);
                cmd.Parameters.AddWithValue("@password", contraseña);
                //Usuario.GetSHA256(contraseña)
                cn.Open();

                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    usuario = new Usuario()
                    {
                        usuario = dr[0].ToString(),
                        nombre = dr[1].ToString(),
                        telefono = dr[2].ToString(),
                        direccion = dr[3].ToString(),
                        idTipo = Convert.ToInt32(dr[4]),
                        password = dr[5].ToString(),
                        estado = dr[6].ToString()
                    };
                }
                dr.Close(); cn.Close();
            }
            return usuario;
        }
        public void IniciarSesion(Usuario reg)
        {
            HttpContext.Current.Session["Usuario"] = reg.usuario;
            HttpContext.Current.Session.Timeout = 30;
        }
        public void CerrarSesion()
        {
            HttpContext.Current.Session["Usuario"] = null;
            HttpContext.Current.Session.Abandon();
        }
    }
}
