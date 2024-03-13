using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Xml;

namespace Minh_C5_Assignment
{
    public class DataProvider
    {
        private static readonly object Instancelock = new object();

        private static DataProvider _Instance;
        public static DataProvider Instance
        {
            get
            {
                lock (Instancelock)
                {
                    if (_Instance == null)
                        _Instance = new DataProvider();
                }
                return _Instance;
            }
        }
        //string connStr = ConfigurationManager.ConnectionStrings["QLTV"].ConnectionString;
        public string connStr = string.Empty;
        public SqlConnection conn { get; set; }
        public SqlCommand cmd { get; set; }
        public SqlDataReader reader { get; set; }

        public string[] parameters { get; set; }
        public object[] values { get; set; }


        public string pathData { get; set; }
        static XmlDocument doc = null;
        public XmlNode nodeRoot = null;
        public bool connect;

        public void Connect()
        {
            try
            {
                if (conn == null)
                    conn = new SqlConnection(connStr);

                if (conn.State == ConnectionState.Open)
                {
                    //MessageBox.Show("Kết nối đang mở");
                }
                else
                {
                    conn.Open();
                    //MessageBox.Show("Ứng dụng đang kết nối tới " + conn.ConnectionString);
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
                connect = false;
                return;
            }
            connect = true;
        }

        public void Disconnect()
        {
            if (conn.State == ConnectionState.Closed)
            {
                //MessageBox.Show("Kết nối hiện tại đang đóng");
            }
            else
            {
                conn.Close();
                //MessageBox.Show("Tắt kết nối với HQT CSDL");
            }
        }

        //public SqlCommand GetParameters(CommandType cmdType, string tSQL)
        //{
        //    cmd = new SqlCommand(tSQL, conn);
        //    cmd.CommandType = cmdType;
        //    if (parameters != null && values != null)
        //    {
        //        int i = 0;
        //        foreach (var item in parameters)
        //        {
        //            cmd.Parameters.AddWithValue("@" + parameters[i], values[i]);
        //            i++;
        //        }
        //    }
        //    return cmd;
        //}

        public SqlCommand GetParameters(CommandType cmdType, string tSQL)
        {
            cmd = new SqlCommand(tSQL, conn);
            cmd.CommandType = cmdType;
            if (parameters != null && values != null)
            {
                int i = 0;
                foreach (var item in parameters)
                {
                    cmd.Parameters.AddWithValue("@" + parameters[i], values[i] ?? DBNull.Value);
                    i++;
                }
            }
            return cmd;
        }

        public object ExecuteScalar(CommandType cmdType, string tSQL)
        {
            object data = 0;
            try
            {
                Connect();
                cmd = new SqlCommand(tSQL, conn);
                cmd = GetParameters(cmdType, tSQL);
                data = cmd.ExecuteScalar();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error Generated. Details: " + ex.ToString());
            }
            finally
            {
                Disconnect();
            }
            return data;
        }

        public int ExcuteNonQuery(CommandType cmdType, string tSQL)
        {
            int nRow = -1;
            try
            {
                Connect();
                cmd = GetParameters(cmdType, tSQL);
                nRow = cmd.ExecuteNonQuery();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error Generated. Details: " + ex.ToString());
            }
            finally
            {
                Disconnect();
            }
            return nRow;
        }

        public SqlDataReader GetReader(CommandType cmdType, string tSQL)
        {
            try
            {
                Connect();
                cmd = GetParameters(cmdType, tSQL);
                reader = cmd.ExecuteReader();
                if (reader.HasRows)
                    return reader; // lấy 1 bảng  
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error Generated Details: " + ex.ToString());
            }
            return null;
        }

        public void Open()
        {
            if (doc == null)
                doc = new XmlDocument();
            doc.Load(pathData);
            nodeRoot = doc.DocumentElement;
        }

        public void Close()
        {
            if (doc != null)
                doc.Save(pathData);
        }

        public XmlNodeList getDsNode(string xpath)
        {
            return nodeRoot.SelectNodes(xpath);
        }

        public XmlNode createNode(string tagName)
        {
            XmlNode node = doc.CreateElement(tagName);
            return node;
        }

        public XmlAttribute createAttr(string name)
        {
            XmlAttribute attr = doc.CreateAttribute(name);
            return attr;
        }

        // Thêm 1 nút con tại vị trí cuối trong nút gốc (nút cha)
        public void AppendNode(XmlNode node, XmlNode newNode)
        {
            node.AppendChild(newNode);
        }

        public void getLanguage()
        {

        }
    }
}
