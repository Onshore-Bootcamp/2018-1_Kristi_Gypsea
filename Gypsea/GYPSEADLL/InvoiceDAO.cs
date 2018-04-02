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
    public class InvoiceDAO
    {
        // constructor for connection string
        public InvoiceDAO(string connectionString)
        {
            _ConnectionString = connectionString;
        }
        private readonly string _ConnectionString;
        private LoggerD logger = new LoggerD();

        public List<InvoiceDO> ViewInvoices()
        {
            //get list
            List<InvoiceDO> allInvoices = new List<InvoiceDO>();
            //defines variables 
            SqlConnection connection = null;
            SqlDataAdapter adapter = null;
            DataTable table = new DataTable();
            SqlCommand command = null;

            try
            {
                //obtains the connection to database
                connection = new SqlConnection(_ConnectionString);
                command = new SqlCommand("VIEW_INVOICE", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                allInvoices = InvoiceMap2.DataTableToList(table);
            }
            catch (Exception ex)
            {
                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            finally
            {
                //if not null close and dispose
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
            return allInvoices;
        }
        public InvoiceDO ViewInvoiceByID(Int64 InvoiceID)
        {
            //get list
            InvoiceDO invoice = new InvoiceDO();
            //defines variables
            SqlConnection connection = null;
            SqlDataAdapter adapter = null;
            DataTable table = new DataTable();
            SqlCommand command = null;

            try
            {
                //gets connection to database
                connection = new SqlConnection(_ConnectionString);
                command = new SqlCommand("VIEW_INVOICE_BY_ID", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.AddWithValue("@InvoiceID", InvoiceID);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                invoice = InvoiceMap2.DataTableToList(table).FirstOrDefault();
            }
            catch (Exception ex)
            {
                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            finally
            {
                //if not null close and dispose
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return invoice;
        }
        public void AddInvoice(InvoiceDO invoice)
        {
            //defines variables
            SqlConnection connection = null;
            SqlCommand createInvoiceRowCommand = null;

            try
            {
                //gets connection and then defines the parameters that will be entered
                connection = new SqlConnection(_ConnectionString);
                connection.Open();
                createInvoiceRowCommand = new SqlCommand("ADD_INVOICE", connection);
                createInvoiceRowCommand.CommandType = CommandType.StoredProcedure;
                createInvoiceRowCommand.Parameters.AddWithValue("LastName", invoice.LastName);
                createInvoiceRowCommand.Parameters.AddWithValue("FirstName", invoice.FirstName);
                createInvoiceRowCommand.Parameters.AddWithValue("Address", invoice.Address);
                createInvoiceRowCommand.Parameters.AddWithValue("City", invoice.City);
                createInvoiceRowCommand.Parameters.AddWithValue("StateProvidence", invoice.StateProvidence);
                createInvoiceRowCommand.Parameters.AddWithValue("Country", invoice.Country);
                createInvoiceRowCommand.Parameters.AddWithValue("PostalCode", invoice.PostalCode);
                createInvoiceRowCommand.Parameters.AddWithValue("DateChartered", invoice.DateChartered);
                createInvoiceRowCommand.Parameters.AddWithValue("DateReturned", invoice.DateReturned);
                createInvoiceRowCommand.Parameters.AddWithValue("CostperDay", invoice.CostperDay);
                createInvoiceRowCommand.Parameters.AddWithValue("AmountDue", invoice.AmountDue);
                createInvoiceRowCommand.Parameters.AddWithValue("BoatID", invoice.BoatID);
                createInvoiceRowCommand.Parameters.AddWithValue("UserID", invoice.UserID);
                createInvoiceRowCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            finally
            {
                //if null close and dispose
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        public void UpdateInvoice(InvoiceDO invoice)
        {
            //defines variables
            SqlConnection connection = null;
            SqlCommand updateInvoiceRowCommand = null;

            try
            {
                //gets connection then defines the parameters to be entered
                connection = new SqlConnection(_ConnectionString);
                updateInvoiceRowCommand = new SqlCommand("UPDATE_INVOICE", connection);
                updateInvoiceRowCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                updateInvoiceRowCommand.Parameters.AddWithValue("InvoiceID", invoice.InvoiceID);
                updateInvoiceRowCommand.Parameters.AddWithValue("LastName", invoice.LastName);
                updateInvoiceRowCommand.Parameters.AddWithValue("FirstName", invoice.FirstName);
                updateInvoiceRowCommand.Parameters.AddWithValue("Address", invoice.Address);
                updateInvoiceRowCommand.Parameters.AddWithValue("City", invoice.City);
                updateInvoiceRowCommand.Parameters.AddWithValue("StateProvidence", invoice.StateProvidence);
                updateInvoiceRowCommand.Parameters.AddWithValue("Country", invoice.Country);
                updateInvoiceRowCommand.Parameters.AddWithValue("PostalCode", invoice.PostalCode);
                updateInvoiceRowCommand.Parameters.AddWithValue("DateChartered", invoice.DateChartered);
                updateInvoiceRowCommand.Parameters.AddWithValue("DateReturned", invoice.DateReturned);
                updateInvoiceRowCommand.Parameters.AddWithValue("CostperDay", invoice.CostperDay);
                updateInvoiceRowCommand.Parameters.AddWithValue("AmountDue", invoice.AmountDue);
                updateInvoiceRowCommand.Parameters.AddWithValue("BoatID", invoice.BoatID);
                updateInvoiceRowCommand.Parameters.AddWithValue("UserID", invoice.UserID);
                updateInvoiceRowCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            finally
            {
                //if null close and dispose
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        public void DeleteInvoice(int InvoiceID)
        {
            // new connection and defines command variable
            SqlConnection connection = new SqlConnection(_ConnectionString);
            SqlCommand deleteInvoiceRowCommand = null;

            try
            {
                //gets connection and uses parameters of ID 
                deleteInvoiceRowCommand = new SqlCommand("DELETE_INVOICE", connection);
                deleteInvoiceRowCommand.CommandType = CommandType.StoredProcedure;
                connection.Open();
                deleteInvoiceRowCommand.Parameters.AddWithValue("@InvoiceID", InvoiceID);
                deleteInvoiceRowCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            finally
            {
                // if null close and dispose
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
        }
        public List<InvoiceDO> ViewInvoiceByUserID(long UserID)
        {
            // get list and define the variables
            List<InvoiceDO> allInvoices = new List<InvoiceDO>();
            SqlConnection connection = null;
            SqlDataAdapter adapter = null;
            DataTable table = new DataTable();
            SqlCommand command = null;
            try
            {
                //opens connectio and uses the parameter of ID
                connection = new SqlConnection(_ConnectionString);
                command = new SqlCommand("View_Invoice_By_UserID", connection);
                command.CommandType = CommandType.StoredProcedure;
                connection.Open();
                command.Parameters.AddWithValue("@UserID", UserID);
                adapter = new SqlDataAdapter(command);
                adapter.Fill(table);
                allInvoices = InvoiceMap2.DataTableToList(table);
            }
            catch (Exception ex)
            {
                logger.Log("Fatal", ex.Source, ex.TargetSite.ToString(), ex.Message, ex.StackTrace);
                throw ex;
            }
            finally
            {
                // if null close and dispose
                if (connection != null)
                {
                    connection.Close();
                    connection.Dispose();
                }
            }
            return allInvoices;
        }
    }
}
