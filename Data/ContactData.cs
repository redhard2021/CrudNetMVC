using CRUDCORE.Models;
using System.Data.SqlClient;
using System.Data;

namespace CRUDCORE.Datos
{
    public class ContactData
    {

        public List<ContactModel> GetList()
        {
            List<ContactModel> list = new List<ContactModel>();

            Connection cn = new Connection();

            using (SqlConnection conexion = new SqlConnection(cn.ChainSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {

                        list.Add(new ContactModel()
                        {
                            IdContact = Convert.ToInt32(dr["IdContacto"]),
                            Name = dr["Nombre"].ToString(),
                            Telephone = dr["Telefono"].ToString(),
                            Mail = dr["Correo"].ToString()
                        });
                    }
                }
            }

            return list;
        }

        public ContactModel Obtain(int idContacto)
        {
            ContactModel contacto = new ContactModel();

            Connection cn = new Connection();

            using (SqlConnection conexion = new SqlConnection(cn.ChainSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_Obtener", conexion);
                cmd.Parameters.AddWithValue("IdContacto", idContacto);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        contacto.IdContact = Convert.ToInt32(dr["IdContacto"]);
                        contacto.Name = dr["Nombre"].ToString();
                        contacto.Telephone = dr["Telefono"].ToString();
                        contacto.Mail = dr["Correo"].ToString();
                    }
                }
            }

            return contacto;
        }

        public bool Save(ContactModel contacto)
        {
            bool response;

            try
            {
                Connection cn = new Connection();

                using (SqlConnection conexion = new SqlConnection(cn.ChainSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Guardar", conexion);
                    cmd.Parameters.AddWithValue("Nombre", contacto.Name);
                    cmd.Parameters.AddWithValue("Telefono", contacto.Telephone);
                    cmd.Parameters.AddWithValue("Correo", contacto.Mail);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                response = true;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                response = false;
            }

            return response;
        }

        public bool Edit(ContactModel contacto)
        {
            bool response;

            try
            {
                Connection cn = new Connection();

                using (SqlConnection conexion = new SqlConnection(cn.ChainSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Editar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", contacto.IdContact);
                    cmd.Parameters.AddWithValue("Nombre", contacto.Name);
                    cmd.Parameters.AddWithValue("Telefono", contacto.Telephone);
                    cmd.Parameters.AddWithValue("Correo", contacto.Mail);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                response = true;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                response = false;
            }

            return response;
        }

        public bool Eliminar(int IdContacto)
        {
            bool response;

            try
            {
                Connection cn = new Connection();

                using (SqlConnection conexion = new SqlConnection(cn.ChainSQL()))
                {
                    conexion.Open();
                    SqlCommand cmd = new SqlCommand("sp_Eliminar", conexion);
                    cmd.Parameters.AddWithValue("IdContacto", IdContacto);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                response = true;
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                response = false;
            }

            return response;
        }

    }
}
