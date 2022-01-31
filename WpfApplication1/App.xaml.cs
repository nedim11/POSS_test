using System;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Data.Entity.Migrations.Infrastructure;
using System.Windows;
using WpfApplication1.DAL;
using WpfApplication1.ViewModel;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            var window = new MainWindow
            {
                DataContext = new ProdajaViewModel()
            };

            ApplyDatabaseMigrations();

            window.ShowDialog();
        }

        public static void ApplyDatabaseMigrations()
        {
            DbMigrationsConfiguration dbMgConfig = new DBinitializer()
            {
                ContextType = typeof(POSSectorDBContext)
            };
            using (var databaseContext = new POSSectorDBContext())
            {
                try
                {
                    var db = databaseContext.Database;
                    var migrationConfiguration = dbMgConfig;
                    migrationConfiguration.TargetDatabase = new DbConnectionInfo(db.Connection.ConnectionString, "System.Data.SqlClient");
                    var migrator = new DbMigrator(migrationConfiguration);
                    migrator.Update();
                }
                catch (AutomaticDataLossException adle)
                {
                    dbMgConfig.AutomaticMigrationDataLossAllowed = true;
                    var mg = new DbMigrator(dbMgConfig);
                    var scriptor = new MigratorScriptingDecorator(mg);
                    string script = scriptor.ScriptUpdate(null, null);
                    throw new Exception(adle.Message + " : " + script);
                }
            }
        }

    }
}
