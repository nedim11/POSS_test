namespace WpfApplication1
{
    using System.Data;
    using System.Data.Entity;
    using System.Data.SqlClient;
    using WpfApplication1.Model;

    public class POSSectorDBContext : DbContext
    {

        public POSSectorDBContext() : base("name=POSSectorDB")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<POSSectorDBContext, WpfApplication1.DAL.DBinitializer>());
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<SubCategories> SubCategories { get; set; }
        public virtual DbSet<Articles> Articles { get; set; }
        public virtual DbSet<Operators> Operators { get; set; }


        public DataTable PopulateDataGrid()
        {
            DataTable dtOperatori = null;

            using (SqlConnection con = new SqlConnection(Database.Connection.ConnectionString))
            {
                string queryString = "select O.Name as Naziv, CAST(FORMAT(SUM(A.Price),'c','hr-HR') As VARCHAR(20)) as Iznos, Cast(Cast(SUM(A.Price)*100/(select SUM(Price) from Articles as ar inner join OperatorsArticles as op on ar.Id=op.Articles_Id) as decimal(18,2)) as varchar(5)) as Procenat from Operators as O inner join OperatorsArticles as OA on O.Id = OA.Operators_Id inner join Articles as A on A.Id = OA.Articles_Id group by O.Id, O.Name order by O.Id";

                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                dtOperatori = new DataTable("OperatoriSve");
                sda.Fill(dtOperatori);
                con.Close();
            }

            return dtOperatori;
        }

        public string PopulateLabel()
        {
            string ukupno = "";

            using (SqlConnection con = new SqlConnection(Database.Connection.ConnectionString))
            {
                string queryString = "select 'Ukupno: ' + CAST(FORMAT(SUM(A.Price),'c','hr-HR') As VARCHAR(20)) as ukupno  from OperatorsArticles as OA inner join Articles as A on A.Id = OA.Articles_Id";

                con.Open();
                SqlCommand cmd = new SqlCommand(queryString, con);
                ukupno = cmd.ExecuteScalar().ToString();
                con.Close();
            }

            return ukupno;
        }

    }
}