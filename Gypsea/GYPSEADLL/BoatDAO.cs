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
    public class BoatDAO
    {
        public BoatDAO(string connectionString)
        {
            _ConnectionString = connectionString;
        }
        private readonly string _ConnectionString;  
        private LoggerD logger = new LoggerD();
        public List<BoatDO> ViewSailboats()
        {

            List<BoatDO> allSailboats = new List<BoatDO>();
            SqlConnection connection = null;
            SqlDataAdapter adapter = null;
            DataTable table = new DataTable();
            SqlCommand command = null;

            try
            {
                connection = new SqlConnection(_ConnectionString);
                command = new SqlCommand("VIEW_SAILBOATS", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                allSailboats = BoatMap2.DataTableToList(table);
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
                if (adapter != null)
                {
                    adapter.Dispose();
                }
            }
            return allSailboats;
        }
        public void AddSailboats(BoatDO boat)
        {
            SqlConnection connection = null;
            SqlCommand createBoatRowCommand = null;

            try
            {
                connection = new SqlConnection(_ConnectionString);
                connection.Open();
                createBoatRowCommand = new SqlCommand("ADD_SAILBOAT", connection);
                createBoatRowCommand.CommandType = CommandType.StoredProcedure;
                
                createBoatRowCommand.Parameters.AddWithValue("@YearofBoat", boat.YearofBoat);
                createBoatRowCommand.Parameters.AddWithValue("@BoatType", boat.BoatType);
                createBoatRowCommand.Parameters.AddWithValue("@Length", boat.Length);
                createBoatRowCommand.Parameters.AddWithValue("@Model", boat.Model);
                createBoatRowCommand.Parameters.AddWithValue("@CostperDay", boat.CostperDay);
                createBoatRowCommand.ExecuteNonQuery();

                
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
        public void UpdateSailboats(BoatDO boat)
        {
            SqlConnection connection = null;
            SqlCommand updateBoatRowCommand = null;

            try
            {

                connection = new SqlConnection(_ConnectionString);
                updateBoatRowCommand = new SqlCommand("UPDATE_SAILBOAT", connection);
                updateBoatRowCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                updateBoatRowCommand.Parameters.AddWithValue("@BoatID", boat.BoatID);
                updateBoatRowCommand.Parameters.AddWithValue("@YearofBoat", boat.YearofBoat);
                updateBoatRowCommand.Parameters.AddWithValue("@BoatType", boat.BoatType);
                updateBoatRowCommand.Parameters.AddWithValue("@Length", boat.Length);
                updateBoatRowCommand.Parameters.AddWithValue("@Model", boat.Model);
                updateBoatRowCommand.Parameters.AddWithValue("@CostperDay", boat.CostperDay);
                updateBoatRowCommand.ExecuteNonQuery();
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
        public void DeleteSailboats(Int64 BoatID)
        {
            SqlConnection connection = new SqlConnection(_ConnectionString);
            SqlCommand deleteBoatRowCommand = null;

            try
            {
                deleteBoatRowCommand = new SqlCommand("DELETE_SAILBOAT", connection);
                deleteBoatRowCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                deleteBoatRowCommand.Parameters.AddWithValue("@BoatID", BoatID);
                deleteBoatRowCommand.ExecuteNonQuery();
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
        public BoatDO ViewBoatByID(Int64 BoatID)
        {
            BoatDO boat = new BoatDO();
            SqlConnection connection = null;
            SqlDataAdapter adapter = null;
            DataTable table = new DataTable();
            SqlCommand command = null;
            try
            {
                connection = new SqlConnection(_ConnectionString);
                command = new SqlCommand("VIEW_BOAT_BY_ID", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.AddWithValue("@BoatID", BoatID);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                boat = BoatMap2.DataTableToList(table).FirstOrDefault();
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
            return boat;
        }
    }
}
