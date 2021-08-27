using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace ADONetDemo
{
    class Program
    {
       static  SqlConnection con;
       static  SqlCommand com;
        static void Main(string[] args)
        {
            byte ch;
            Console.WriteLine("1. Insert");
            Console.WriteLine("2. Update");
            Console.WriteLine("3. Delete");
            Console.WriteLine("4. Search");

            Console.WriteLine("5. List of Students");
            Console.WriteLine("Enter Your choice");
            ch = Byte.Parse(Console.ReadLine());
            switch(ch)
            {
                case 1:
                    {
                        InsertStudent();
                        break;
                    }
                case 2:
                    {
                        UpdateStudent();
                        break;
                    }
                case 3:
                    {
                        DeleteStudent();
                        break;
                    }
                case 4:
                    {
                        GetStudentDetails();
                        break;
                    }
                case 5:
                    {
                        GetStudents();
                        break;
                    }
            }
        }
        static void InsertStudent()
        {
            con = GetConnection();
            com = new SqlCommand("Insert into Student values (6,'Meenu' , 'B002', 90)", con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        static void UpdateStudent()
        {
            con = GetConnection();
            com = new SqlCommand("Update Student set batchcode='B010'", con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();

        }
        static void DeleteStudent()
        {
            con = GetConnection();
            com = new SqlCommand("Delete Student", con);
            con.Open();
            com.ExecuteNonQuery();
            con.Close();
        }
        static void GetStudentDetails()
        {
            con = GetConnection();
            com = new SqlCommand("Select * from Student where id =4", con);
            con.Open();
            SqlDataReader read = com.ExecuteReader();
            if (read.HasRows)
            {
                read.Read();
                Console.WriteLine(read[0] + " " + read[1] + " " + read[2] + " " + read[3]); ;

            }
            else
                Console.WriteLine("No Record with this ID");
            read.Close();
            con.Close();
             
        }
        static void GetStudents()
        {
            con = GetConnection();
            com = new SqlCommand("Select * fro Studen", con);
            con.Open();

            SqlDataReader read = com.ExecuteReader();
            if (read.HasRows)
            {
                while (read.Read())
                {
                    Console.WriteLine(read[0] + " " + read[1] + " " + read[2] + " " + read[3]); ;
                }
            }
            else
                Console.WriteLine("No Records");
            read.Close();
            con.Close();
        }
        static SqlConnection GetConnection()
        {
            con = new SqlConnection(@"data source=admivm\SQLEXPRESS;initial catalog=PracticeDb;user id=sa;password=pass@123");
            return con;
        }
    }
}
