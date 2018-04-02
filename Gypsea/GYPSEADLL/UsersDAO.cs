using GYPSEADLL.Mapping;
using GYPSEADLL.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYPSEADLL
{
    public class UsersDAO
    {
        public UsersDAO(string connectionString)
        {
            _ConnectionString = connectionString;
        }
        private readonly string _ConnectionString; 

        public object UserMap { get; private set; }
        private LoggerD logger = new LoggerD();
        public List<UsersDO> ViewUsers()
        {
            List<UsersDO> allUsers = new List<UsersDO>();
            SqlConnection connection = null;
            SqlDataAdapter adapter = null;
            DataTable table = new DataTable();
            SqlCommand command = null;

            try
            {
                connection = new SqlConnection(_ConnectionString);
                command = new SqlCommand("VIEW_Users", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                allUsers = UsersMap2.DataTableToList(table);
            }
            catch (Exception ex)
            {
                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
                if  (adapter != null)
                {
                    adapter.Dispose();
                }
            }
            return allUsers;
        }
        public void AddUser(UsersDO user)
        {
            SqlConnection connection = null;
            SqlCommand createUserRowCommand = null;

            try
            {
                connection = new SqlConnection(_ConnectionString);
                connection.Open();
                createUserRowCommand = new SqlCommand("ADD_User", connection);
                createUserRowCommand.CommandType = CommandType.StoredProcedure;
                createUserRowCommand.Parameters.AddWithValue("UserName", user.UserName);
                createUserRowCommand.Parameters.AddWithValue("Password", user.Password);
                createUserRowCommand.Parameters.AddWithValue("LastName", user.LastName);
                createUserRowCommand.Parameters.AddWithValue("FirstName", user.FirstName);
                createUserRowCommand.Parameters.AddWithValue("Email", user.Email);
                createUserRowCommand.Parameters.AddWithValue("Address", user.Address);
                createUserRowCommand.Parameters.AddWithValue("City", user.City);
                createUserRowCommand.Parameters.AddWithValue("StateProvidence", user.StateProvidence);
                createUserRowCommand.Parameters.AddWithValue("PostalCode", user.PostalCode);
                createUserRowCommand.Parameters.AddWithValue("Country", user.Country);
                createUserRowCommand.Parameters.AddWithValue("RoleID", user.RoleID);
                createUserRowCommand.ExecuteNonQuery();



            }
            catch (Exception ex)
            {
                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
                
            }
        }
        public void UpdateUser(UsersDO user)
        {
            SqlConnection connection = null;
            SqlCommand updateUserRowCommand = null;

            try
            {
                connection = new SqlConnection(_ConnectionString);
                updateUserRowCommand = new SqlCommand("UPDATE_USER", connection);
                updateUserRowCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                updateUserRowCommand.Parameters.AddWithValue("@UserID", user.UserID);
                updateUserRowCommand.Parameters.AddWithValue("@UserName", user.UserName);
                updateUserRowCommand.Parameters.AddWithValue("@Password", user.Password);
                updateUserRowCommand.Parameters.AddWithValue("@LastName", user.LastName);
                updateUserRowCommand.Parameters.AddWithValue("@FirstName", user.FirstName);
                updateUserRowCommand.Parameters.AddWithValue("@Email", user.Email);
                updateUserRowCommand.Parameters.AddWithValue("@Address", user.Address);
                updateUserRowCommand.Parameters.AddWithValue("@City", user.City);
                updateUserRowCommand.Parameters.AddWithValue("@StateProvidence", user.StateProvidence);
                updateUserRowCommand.Parameters.AddWithValue("@PostalCode", user.PostalCode);
                updateUserRowCommand.Parameters.AddWithValue("@Country", user.Country);
                updateUserRowCommand.Parameters.AddWithValue("@RoleID", user.RoleID);
                updateUserRowCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        public void DeleteUser(Int64 UserID)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);
            SqlCommand deleteUserRowCommand = null;

            try
            {
                deleteUserRowCommand = new SqlCommand("DELETE_User", connection);
                deleteUserRowCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                deleteUserRowCommand.Parameters.AddWithValue("@UserID", UserID);
                deleteUserRowCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        public UsersDO ViewUserByID(Int64 UserID)
        {
            UsersDO user = new UsersDO();
            DataTable table = new DataTable();
            SqlConnection connection = null;
            SqlDataAdapter adapter = null;
            SqlCommand command = null;

            try
            {
                connection = new SqlConnection(_ConnectionString);
                command = new SqlCommand("VIEW_USER_BY_ID", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserID", UserID);
                connection.Open();
                adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                user = UsersMap2.DataTableToList(table).FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return user;

        }
        public UsersDO ViewByUserName(string userName)
        {
            UsersDO user = new UsersDO();
            SqlConnection connection = null;
            SqlDataAdapter adapter = null;
            DataTable table = new DataTable();
            SqlCommand command = null;

            try
            {
                connection = new SqlConnection(_ConnectionString);
                command = new SqlCommand("View_By_UserName", connection);
                command.CommandType = CommandType.StoredProcedure;
                
                connection.Open();
                command.Parameters.AddWithValue("@UserName", userName);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                user = UsersMap2.DataTableToList(table).FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            finally
            {
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return user;
        }
        
        
    }
}
