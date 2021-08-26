using FullTextSearch.Entity;
using FullTextSearch.Interface;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FullTextSearch.Repository
{
    public class ExemplarDAL : IExemplarDAL
    {
        string connectionString = @"Data Source=LUCAS\SQLEXPRESS;Initial Catalog=livraria;Integrated Security=True;";
        //Server=LUCAS\\SQLEXPRESS;Database=LivrariaTeste;Trusted_Connection=True;MultipleActiveResultSets=true

        public IEnumerable<Exemplar> GetAllExemplar()
        {
            List<Exemplar> lstexemplar = new List<Exemplar>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT registro_sistema, titulo, sub_titulo, assunto, quantidade, ano, edicao, isbn, issn from tbExemplar", con);
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Exemplar exemplar = new Exemplar();
                    exemplar.RegistroSistema = Convert.ToInt32(rdr["registro_sistema"]);
                    exemplar.Titulo = rdr["titulo"].ToString();
                    exemplar.SubTitulo = rdr["sub_titulo"].ToString();
                    exemplar.Assunto = rdr["assunto"].ToString();
                    exemplar.Quantidade = Convert.ToInt32(rdr["quantidade"]);
                    exemplar.Ano = rdr["ano"].ToString();
                    exemplar.Edicao = rdr["edicao"].ToString();
                    exemplar.Isbn = rdr["isbn"].ToString();
                    exemplar.Issn = rdr["issn"].ToString();

                    lstexemplar.Add(exemplar);
                }
                con.Close();
            }
            return lstexemplar;
        }

        public IEnumerable<Exemplar> busca(string busca)
        {
            List<Exemplar> lstexemplar = new List<Exemplar>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT registro_sistema, titulo, sub_titulo, assunto, fk_autor, quantidade, ano, edicao, isbn, issn from tbExemplar LEFT JOIN tbAutor on id=fk_autor WHERE assunto LIKE '%' + @busca + '%'", con);
                cmd.Parameters.Add("@busca", SqlDbType.VarChar);
                cmd.Parameters["@busca"].Value = busca;
                cmd.CommandType = CommandType.Text;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Exemplar exemplar = new Exemplar();
                    exemplar.RegistroSistema = Convert.ToInt32(rdr["registro_sistema"]);
                    exemplar.Titulo = rdr["titulo"].ToString();
                    exemplar.SubTitulo = rdr["sub_titulo"].ToString();
                    exemplar.Assunto = rdr["assunto"].ToString();
                    exemplar.Quantidade = Convert.ToInt32(rdr["quantidade"]);
                    exemplar.Ano = rdr["ano"].ToString();
                    exemplar.Edicao = rdr["edicao"].ToString();
                    exemplar.Isbn = rdr["isbn"].ToString();
                    exemplar.Issn = rdr["issn"].ToString();

                    lstexemplar.Add(exemplar);
                }
                con.Close();
            }
            return lstexemplar;
        }
    }
}

