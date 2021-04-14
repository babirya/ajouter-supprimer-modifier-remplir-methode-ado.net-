using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient; 

namespace devtech3
{
    class ado
    { 
            // lets make our  declaration here 
        public SqlConnection con = new SqlConnection();
        public SqlCommand cmd = new SqlCommand();
        public SqlDataReader rd;
        public DataTable dt = new DataTable(); 

        // now >>> precudure of connecte and deconncter 
        // 1
        public void connecter()
        {
            if(con.State==ConnectionState.Closed|| con.State==ConnectionState.Broken)
            {
                con.ConnectionString = @"Data Source=DESKTOP-3GHSQJ4\SQLEXPRESS;Initial Catalog=devtech;Integrated Security=True";
                con.Open();
            }
        } 

        //2  deconnecter 


        public void deconnecter()
        {
            if(con.State==ConnectionState.Open)
            {
                con.Close();
            }

        }


    }
}
