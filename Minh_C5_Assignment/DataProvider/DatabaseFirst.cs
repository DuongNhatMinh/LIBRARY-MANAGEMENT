namespace Minh_C5_Assignment
{
    public class DatabaseFirst
    {
        private static readonly object Instancelock = new object();
        public QuanLyThuVienEntities db;
        private static DatabaseFirst _Instance;
        public static DatabaseFirst Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (Instancelock)
                    {
                        if (_Instance == null)
                        {
                            _Instance = new DatabaseFirst();
                        }
                    }
                }
                return _Instance;
            }
            set
            {
                _Instance = value;
            }
        }

        private DatabaseFirst()
        {
            db = new QuanLyThuVienEntities();
            //db.Configuration.LazyLoadingEnabled = false;
        }
    }
}
