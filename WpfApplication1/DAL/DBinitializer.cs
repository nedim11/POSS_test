using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApplication1.Model;

namespace WpfApplication1.DAL
{
    class DBinitializer : DbMigrationsConfiguration<WpfApplication1.POSSectorDBContext>
    {
        public DBinitializer()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }
        protected override void Seed(POSSectorDBContext context)
        {

            IList<Operators> ops = new List<Operators>();

            ops.Add(new Operators()
            {
                Name = "Jasminka Mlinar",
                ArticlesLst = new List<Articles>
                {
                    new Articles() { ArticleNumber = null, Order = 1, Name = "Williams", SubCategory_Id = 1, BarCode = null, Code = null, FreeModifiers = 1, Image = null, Price = 45632.00, ReturnFee = 0, Deleted = false, Tag = true}
                }
            });

            ops.Add(new Operators()
            {
                Name = "Mujanović Raša",
                ArticlesLst = new List<Articles>
                {
                    new Articles() { ArticleNumber = null, Order = 1, Name = "Crassane", SubCategory_Id = 1, BarCode = null, Code = null, FreeModifiers = 1, Image = null, Price = 14356.50, ReturnFee = 0, Deleted = false, Tag = true }
                }
            });

            ops.Add(new Operators()
            {
                Name = "Nataša Andrašek",
                ArticlesLst = new List<Articles>
                {
                    new Articles() { ArticleNumber = null, Order = 1, Name = "Hardenpont", SubCategory_Id = 1, BarCode = null, Code = null, FreeModifiers = 1, Image = null, Price = 8389.50, ReturnFee = 0, Deleted = false, Tag = true }
                }
            });

            ops.Add(
           new Operators()
           {
               Name = "S. Maksić - MAX",
               ArticlesLst = new List<Articles>
                {
                    new Articles() { ArticleNumber = null, Order = 1, Name = "Morettini", SubCategory_Id = 1, BarCode = null, Code = null, FreeModifiers = 1, Image = null, Price = 7611.50, ReturnFee = 0, Deleted = false, Tag = true }
                }
           });


           
            IList<Categories> cats = new List<Categories>();

            cats.Add(new Categories() { Order = 1, Name = "Voce", Printer = "Printer 1", Storage_Id = 1, Deleted = false });

            IList<SubCategories> subCats = new List<SubCategories>();

            subCats.Add(new SubCategories() { Order = 1, Name = "Kruske", Printer = "Printer 1", Storage_Id = 1, Category_Id = 1, Deleted = false, Tag = 123 });





            foreach (Operators op in ops)
                context.Operators.AddOrUpdate(op);
            base.Seed(context);

            foreach (Categories cat in cats)
                context.Categories.AddOrUpdate(cat);
            base.Seed(context);

            foreach (SubCategories subCat in subCats)
                context.SubCategories.AddOrUpdate(subCat);
            base.Seed(context);

        
            context.SaveChanges();
        }
    }
}
