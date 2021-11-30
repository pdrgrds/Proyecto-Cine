using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WCF_Proyecto_CineALL
{
    [ServiceContract]
    public interface IService1
    {
        /*===============================================================================*/
        /*                                COMESTIBLES                                    */
        /*===============================================================================*/
        [OperationContract] List<Comestibles> comestibles();
        [OperationContract] string AgregarCome(Comestibles reg);
        [OperationContract] string ActualizarCome(Comestibles reg);
        [OperationContract] string EliminarCome(Comestibles reg);


        /*===============================================================================*/
        /*                               TIPO COMESTIBLES                                */
        /*===============================================================================*/
        [OperationContract] List<TipoComestible> tipocomestibles();
        [OperationContract] string AgregarTipCome(TipoComestible reg);
        [OperationContract] string ActualizarTipCome(TipoComestible reg);
        [OperationContract] string EliminarTipCome(TipoComestible reg);

      
       /*===============================================================================*/
       /*                                  PROVEEDOR                                    */
       /*===============================================================================*/
        [OperationContract] List<Proveedor> proveedor();
        [OperationContract] string AgregarProve(Proveedor reg);
        [OperationContract] string ActualizarProve(Proveedor reg);
        [OperationContract] string EliminarProve(Proveedor reg);


        /*===============================================================================*/
        /*                              TIPO PELICULA                                    */
        /*===============================================================================*/
        [OperationContract] List<TipoPelicula> listTipoPelicula();
        [OperationContract] string addTipoPelicula(TipoPelicula reg);
        [OperationContract] string updateTipoPelicula(TipoPelicula reg);
        [OperationContract] string deleteTipoPelicula(TipoPelicula reg);


        /*===============================================================================*/
        /*                                   PELICULA                                    */
        /*===============================================================================*/
        [OperationContract] List<Peliculas> listPeliculas();
        [OperationContract] string addPelicula(Peliculas reg);
        [OperationContract] string updatePelicula(Peliculas reg);
        [OperationContract] string deletePelicula(Peliculas reg);

        /*===============================================================================*/
        /*                                TRANSACCION                                    */
        /*===============================================================================*/
        [OperationContract] string Transaccion(Boleta reg, IEnumerable<Carrito> carrito);

        /*===============================================================================*/
        /*                                    USUARIO                                    */
        /*===============================================================================*/

        [OperationContract] Usuario validarUsuario(string usu, string contraseña);
        [OperationContract] void IniciarSesion(Usuario reg);
        [OperationContract] void CerrarSesion();
    }

}
