using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace BookExample.Models
{
    public class Products
    {
        [Key]
        [Display(Name = "BookId")]
        [Required(ErrorMessage = "Please enter BookId")]
        public int BookId { set; get; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "Please enter Book Name")]
        public string BookName { set; get; }

        [Display(Name = "BookRate")]
        [Required(ErrorMessage = "Please enter Book Rate")]
        public decimal BookRate { set; get; }

        [Display(Name = "Description")]
        [Required(ErrorMessage = "Please enter Description")]
        public string Description { set; get; }

        [Display(Name = "BookId")]
        [Required(ErrorMessage = "Please enter BookId")]
        public string CategoryName { set; get; }

        public static List<Products> GetAllProducts()
        {
            SqlConnection cn = new SqlConnection();
            cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";
            List<Products> list = new List<Products>();

            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ShowAllProducts";

                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    Products p = new Products();
                    p.BookId = (int)dr[0];
                    p.BookName = (string)dr[1];
                    p.BookRate = (decimal)dr[2];
                    p.Description = (string)dr[3];
                    p.CategoryName = (string)dr[4];

                    list.Add(p);
                }

                dr.Close();
                return list;


            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cn.Close();
            }
            return list;
        }
            internal static void UpdateProduct(int id,Products p)
            {
                SqlConnection cn = new SqlConnection();
                cn.ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=JKJuly2022;Integrated Security=True";
            
            try
            {
                cn.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = cn;
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "updateproduct";

                cmd.Parameters.AddWithValue("@BookId", p.BookId);
                cmd.Parameters.AddWithValue("@BookName", p.BookName);
                cmd.Parameters.AddWithValue("@BookRate", p.BookRate);
                cmd.Parameters.AddWithValue("@Description", p.Description);
                cmd.Parameters.AddWithValue("@CategoryName", p.CategoryName);



                 cmd.ExecuteNonQuery();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                cn.Close();
            }


        }




        
    }
}