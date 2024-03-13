using System.Collections.ObjectModel;
using System.Xml;

namespace Minh_C5_Assignment
{
    class ServerNameViewModel
    {
        public ServerName serverName = new ServerName();
        public ObservableCollection<ServerName> lstServer = new ObservableCollection<ServerName>();

        public ObservableCollection<ServerName> getList()
        {
            string xPath = "/Servers/Server";
            string Name = string.Empty;
            string catalog = string.Empty;
            string status = string.Empty;
            DataProvider.Instance.pathData = "data/ServerNames.xml";
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            XmlNodeList lstNode = DataProvider.Instance.getDsNode(xPath);
            foreach (XmlNode node in lstNode)
            {
                Name = node.Attributes["Name"].Value;
                catalog = node.Attributes["Catalog"].Value;
                status = node.Attributes["Status"].Value;
                if (status == "True")
                    serverName = new ServerName(Name, catalog, true);
                else
                    serverName = new ServerName(Name, catalog, false);
                lstServer.Add(serverName);
            }
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
            return lstServer;
        }

        public int getLast()
        {
            if (lstServer.Count == 0)
                return -1;
            return lstServer.Count;
        }

        public bool Compare(string name)
        {
            for (int i = 0; i < lstServer.Count; i++)
            {
                if (lstServer[i].Name == name)
                {
                    return true;
                }
            }
            return false;
        }

        public void Create(string name)
        {
            DataProvider.Instance.pathData = "data/ServerNames.xml";
            var newNode = DataProvider.Instance.createNode("Server");
            var attr1 = DataProvider.Instance.createAttr("Name");
            attr1.Value = name;  
            newNode.Attributes.Append(attr1);
            //newNode.InnerText = string.Empty;
            DataProvider.Instance.Open(); // Mở tài liệu Xml
            DataProvider.Instance.AppendNode(DataProvider.Instance.nodeRoot, newNode);
            DataProvider.Instance.Close(); // Đóng tài liệu Xml
        }
    }
}
