using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using SQLite;
using System.IO;

namespace dbapplication
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            string dbPath = Path.Combine(
                System.Environment.GetFolderPath(
                    System.Environment.SpecialFolder.Personal), "mydatabase.db3");

            var db = new SQLiteConnection(dbPath);

            db.CreateTable<Stock>();
            if (db.Table<Stock>().Count() == 0)
            {
                var newStock = new Stock();

            }

        }
    }

    public class Stock
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int Id { get; set; }
        [MaxLength(8)]
        public string Symbol { get; set; }
    }
}