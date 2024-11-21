using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDCORE.Datos
{
    public class EmpresaDatos
    {
        public List<EmpresaModel> Listar()
        {
            var oLista = new List<EmpresaModel>();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ListarEmpresas", conexion); // Procedimiento almacenado
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new EmpresaModel()
                        {
                            Cif = Convert.ToInt32(dr["Cif"]),
                            Nombre = dr["Nombre"].ToString(),
                            Telefono = dr["Telefono"].ToString(),
                            Localidad = dr["Localidad"].ToString(),
                            Provincia = dr["Provincia"].ToString(),
                            Direccion = dr["Direccion"].ToString()
                        });
                    }
                }
            }

            return oLista;
        }

        public EmpresaModel Obtener(int Cif)
        {
            var oEmpresa = new EmpresaModel();
            var cn = new Conexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_ObtenerEmpresa", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                // Asegúrate de agregar correctamente el parámetro con su valor
                cmd.Parameters.AddWithValue("@Cif", Cif);

                using (var dr = cmd.ExecuteReader())
                {
                    if (dr.Read()) // Debería devolver solo un registro
                    {
                        oEmpresa.Cif = Convert.ToInt32(dr["Cif"]);
                        oEmpresa.Nombre = dr["Nombre"].ToString();
                        oEmpresa.Telefono = dr["Telefono"].ToString();
                        oEmpresa.Localidad = dr["Localidad"].ToString();
                        oEmpresa.Provincia = dr["Provincia"].ToString();
                        oEmpresa.Direccion = dr["Direccion"].ToString();
                    }
                }
            }

            return oEmpresa;
        }


        public bool Guardar(EmpresaModel oEmpresa)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_GuardarEmpresa", conexion); // Procedimiento almacenado correcto
                    cmd.Parameters.AddWithValue("Cif", oEmpresa.Cif);
                    cmd.Parameters.AddWithValue("Nombre", oEmpresa.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oEmpresa.Telefono);
                    cmd.Parameters.AddWithValue("Localidad", oEmpresa.Localidad);
                    cmd.Parameters.AddWithValue("Provincia", oEmpresa.Provincia);
                    cmd.Parameters.AddWithValue("Direccion", oEmpresa.Direccion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }

            return rpta;
        }

        public bool Editar(EmpresaModel oEmpresa)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EditarEmpresa", conexion); // Procedimiento almacenado correcto
                    cmd.Parameters.AddWithValue("Cif", oEmpresa.Cif);
                    cmd.Parameters.AddWithValue("Nombre", oEmpresa.Nombre);
                    cmd.Parameters.AddWithValue("Telefono", oEmpresa.Telefono);
                    cmd.Parameters.AddWithValue("Localidad", oEmpresa.Localidad);
                    cmd.Parameters.AddWithValue("Provincia", oEmpresa.Provincia);
                    cmd.Parameters.AddWithValue("Direccion", oEmpresa.Direccion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }

        public bool Eliminar(string Cif)
        {
            bool rpta;

            try
            {
                var cn = new Conexion();

                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_EliminarEmpresa", conexion); // Procedimiento almacenado correcto
                    cmd.Parameters.AddWithValue("Cif", Cif);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
