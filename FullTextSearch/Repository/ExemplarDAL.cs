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
                SqlCommand cmd = new SqlCommand("SELECT registro_sistema, titulo, sub_titulo, assunto, mat.material as Material, aut.nome as Autor, quantidade, ano, edicao, edit.nome as Editora, isbn, issn from tbExemplar " +
                    "LEFT JOIN tbAutor aut on aut.id=fk_autor " +
                    "LEFT JOIN tbEditor edit on edit.id=fk_editor " +
                    "LEFT JOIN tbTipo_Material mat on mat.id=fk_tipomaterial " +
                    "WHERE assunto LIKE '%' + @busca + '%' OR titulo LIKE '%' + @busca + '%' OR sub_titulo LIKE '%' + @busca + '%'" +
                    " OR ano LIKE '%' + @busca + '%' OR aut.nome LIKE '%' + @busca + '%' OR edit.nome LIKE '%' + @busca + '%'", con);
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
                    exemplar.AutorNome = rdr["Autor"].ToString();
                    exemplar.EditoraNome = rdr["Editora"].ToString();
                    exemplar.Material = rdr["Material"].ToString();
                    

                    lstexemplar.Add(exemplar);
                }
                con.Close();
            }
            return lstexemplar;
        }

        public IEnumerable<Exemplar> FTS(string busca)
        {
            List<Exemplar> lstexemplar = new List<Exemplar>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT registro_sistema, titulo, sub_titulo, assunto, mat.material as Material, aut.nome as Autor, quantidade, ano, edicao, edit.nome as Editora, isbn, issn from tbExemplar " +
                    "LEFT JOIN tbEditor edit on tbExemplar.fk_editor = edit.id " +
                    "LEFT JOIN tbAutor aut on tbExemplar.fk_autor = aut.id " +
                    "LEFT JOIN tbTipo_Material mat on tbExemplar.fk_tipomaterial = mat.id " +
                    $"WHERE CONTAINS((edit.*), '${busca}' ) or CONTAINS((tbExemplar.*), '${busca}' ) " +
                    $"or contains((aut.*), '${busca}' )", con);
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
                    exemplar.AutorNome = rdr["Autor"].ToString();
                    exemplar.EditoraNome = rdr["Editora"].ToString();
                    exemplar.Material = rdr["Material"].ToString();


                    lstexemplar.Add(exemplar);
                }
                con.Close();
            }
            return lstexemplar;
        }
    }
}

