namespace Minh_C5_Assignment
{
    class tSQL
    {
        public static string tSQLreader = "SELECT * FROM Reader";
        public static string tSQLbookISBN = "SELECT * FROM BookISBN";
        public static string tSQLbookTitle = "SELECT * FROM BookTitle";
        public static string tSQLadult = "SELECT * FROM Adult";
        public static string tSQLchild = "SELECT * FROM Child";
        public static string tSQLAuthor = "SELECT * FROM Author";
        public static string tSQLCategory = "SELECT * FROM Category";
        public static string tSQLParameter = "SELECT * FROM Parameter";
        public static string tSQLBook = "SELECT * FROM Book";
        public static string tSQLProvince = "SELECT * FROM Province";
        public static string tSQLUser = "SELECT * FROM [User]";
        public static string tSQLRole = "SELECT * FROM Role";
        public static string tSQLFunction = "SELECT * FROM [Function]";
        public static string tSQLUserRole = "SELECT * FROM UserRole";
        public static string tSQLRoleFunction = "SELECT * FROM RoleFunction";
        public static string tSQLUserInfor = "SELECT * FROM UserInfo";

        public static string InsertReader = $"INSERT INTO Reader VALUES(@{"Id"}, @{"LName"}, @{"FName"}, @{"BoF"}, @{"ReaderType"}, @{"Status"}, @{"CreatedAt"}, @{"ModifiedAt"})";
        public static string InsertAdult = $"INSERT INTO Adult VALUES(@{"IdReader"}, @{"Identify"}, @{"Address"}, @{"City"}, @{"Phone"}, @{"ExpireDate"}, @{"Status"}, @{"CreatedAt"}, @{"ModifiedAt"})";
        public static string InsertChild = $"INSERT INTO Child VALUES(@{"IdReader"}, @{"IdAdult"}, @{"Status"}, @{"CreatedAt"}, @{"ModifiedAt"})";
        public static string InsertBookTitle = $"INSERT INTO BookTitle VALUES(@{"Id"}, @{"IdCategory"}, @{"Name"}, @{"IdAuthor"}, @{"Summary"})";
        public static string InsertBookISBN = $"INSERT INTO BookISBN VALUES(@{"ISBN"}, @{"IdBookTitle"}, @{"IdAuthor"}, @{"PublishDate"}, @{"Language"}, @{"Status"})";
        public static string InsertBook = $"INSERT INTO Book VALUES(@{"Id"}, @{"ISBN"}, @{"Status"},  @{"CreatedAt"}, @{"ModifiedAt"})";
        public static string InsertUser = $"INSERT INTO [User] VALUES(@{"Id"}, @{"Username"}, @{"Password"}, @{"Status"},  @{"CreatedAt"}, @{"ModifiedAt"})";
        public static string InsertUserInfor = $"INSERT INTO UserInfo VALUES(@{"IdUser"}, @{"LName"}, @{"FName"}, @{"Phone"}, @{"Address"})";
        public static string InsertFunction = $"INSERT INTO [Function] VALUES(@{"Id"}, @{"Name"}, @{"Description"}, @{"IdParent"}, @{"UrlImage"}, @{"Status"})";
        public static string InsertRole = $"INSERT INTO Role VALUES(@{"Id"}, @{"Name"}, @{"Group"}, @{"Status"})";
        public static string InsertUserRole = $"INSERT INTO UserRole VALUES(@{"Id"}, @{"IdUser"}, @{"IdRole"})";
        public static string InsertRoleFunction = $"INSERT INTO RoleFunction VALUES(@{"Id"}, @{"IdRole"}, @{"IdFunction"})";

        public static string UpdateReader(int status, string id)
        {
            return $"UPDATE Reader SET Status = {status} WHERE Id = '{id}'";
        }
        public static string UpdateChild(int status, string idReader)
        {
            return $"UPDATE Child SET Status = {status} WHERE IdReader = '{idReader}'";
        }
        public static string UpdateAdult(int status, string idReader)
        {
            return $"UPDATE Adult SET Status = {status} WHERE IdReader = '{idReader}'";
        }

        public static string UpdateBookISBN(int status, string ISBN)
        {
            return $"UPDATE BookISBN SET Status = {status} WHERE ISBN = '{ISBN}'";
        }

        public static string UpdateUser(int status, string id)
        {
            return $"UPDATE [User] SET Status = {status} WHERE Id = '{id}'";
        }

        public static string UpdateFunction(int status, string id)
        {
            return $"UPDATE [Function] SET Status = {status} WHERE Id = '{id}'";
        }

        public static string UpdateParamenter(int status, string id)
        {
            return $"UPDATE [Parameter] SET Status = {status} WHERE Id = '{id}'";
        }

        public static string UpdateAuthor(int status, string id)
        {
            return $"UPDATE [Author] SET Status = {status} WHERE Id = '{id}'";
        }

        public static string UpdateTranslator(int status, string id)
        {
            return $"UPDATE [Translator] SET Status = {status} WHERE Id = '{id}'";
        }

        public static string UpdateCategory(int status, string id)
        {
            return $"UPDATE [Category] SET Status = {status} WHERE Id = '{id}'";
        }

        public static string UpdatePenalty(int status, string id)
        {
            return $"UPDATE PenaltyReason SET Status = {status} WHERE Id = '{id}'";
        }

        public static string UpdateStatusBook(int status, string isbn)
        {
            return $"update Book set Status = {status} where ISBN = '{isbn}'";
        }

        public static string UpdateStatusBookId(int status, int id)
        {
            return $"update Book set Status = {status} where Id = '{id}'";
        }

        public static string UpdateIdStatusBookId(string idstatus, int id)
        {
            return $"update Book set IdBookStatus = '{idstatus}' where Id = '{id}'";
        }

        public static string UpdatePriceBook(decimal price, string isbn)
        {
            return $"update Book set PriceCurrent = {price} where ISBN = '{isbn}'";
        }

        public static string EditUserRole(string idrole, string id)
        {
            return $"UPDATE UserRole SET IdRole = '{idrole}' WHERE Id = '{id}'";
        }

        public static string EditUser(string username, string password, string id)
        {
            return $"UPDATE [User] SET Username = '{username}', Password = '{password}' WHERE Id = '{id}'";
        }

        public static string EditUserInfo(string lname, string fname, string address, string phone, string id)
        {
            return $"UPDATE UserInfo SET LName = '{lname}', FName = '{fname}', Phone = '{phone}', [Address] = '{address}' WHERE IdUser = '{id}'";
        }

        public static string Editfunction(string name, string description, string idparent, string urlimage, string id)
        {
            if(idparent == null)
                return $"UPDATE [Function] SET Name = '{name}', Description = '{description}', IdParent = null, UrlImage = '{urlimage}' WHERE Id = '{id}'";
            else
                return $"UPDATE [Function] SET Name = '{name}', Description = '{description}', IdParent = '{idparent}', UrlImage = '{urlimage}' WHERE Id = '{id}'";
        }

        public static string DeleteRoleFunction(string id)
        {
            return $"DELETE FROM [RoleFunction] WHERE Id = '{id}'";
        }
    }
}

