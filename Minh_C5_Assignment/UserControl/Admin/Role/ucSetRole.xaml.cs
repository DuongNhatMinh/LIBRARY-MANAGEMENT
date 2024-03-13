using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for SetRole.xaml
    /// </summary>
    public partial class ucSetRole : UserControl
    {
        RoleViewModel roleVM = new RoleViewModel();
        UserViewModel userVM = new UserViewModel();
        UserInforViewModel userinfoVM = new UserInforViewModel();
        UserRoleViewModel userroleVM = new UserRoleViewModel();

        UserRoleDTO userdto = new UserRoleDTO();
        WindowMessege Windown { get; set; }
        public ucSetRole(object user, object windown)
        {
            userdto = user as UserRoleDTO;
            Windown = windown as WindowMessege;

            InitializeComponent();
            User usertemp = userVM.repoUser.GetByID(userdto.Id);
            UserInfo userinfo = userinfoVM.repoUserInfo.GetByID(usertemp.Id);
            UserRole userrole = userroleVM.repoUserRole.GetByIdUser(usertemp.Id);
            tblUserName.Text = string.Format("UserName: {0}", usertemp.Username);
            tblPassword.Text = string.Format("Password: {0}", usertemp.Password);
            tblName.Text = string.Format("Name: {0} {1}", userinfo.LName, userinfo.FName);
            tblAddress.Text = string.Format("Address: {0}", userinfo.Address);
            tblPhone.Text = string.Format("Phone: {0}", userinfo.Phone);
            cbRole.Items.Clear();
            foreach (var item in roleVM.repoRole.Items)
            {
                if (item.Group == "librarian")
                {
                    cbRole.Items.Add(item.Name);
                }
            }
            if (userrole == null)
            {
                return;
            }
            Role role = roleVM.repoRole.GetByID(userrole.IdRole);
            tblRole.Text = string.Format("Role: {0}", role.Name);
        }

        private void btnSwitch_Click(object sender, RoutedEventArgs e)
        {
            Role role = roleVM.repoRole.GetByName(cbRole.Items[cbRole.SelectedIndex].ToString());
            User user = userVM.repoUser.GetByID(userdto.Id);
            UserRole userrole = userroleVM.repoUserRole.GetByIdUser(user.Id);
            if (userrole == null)
                userroleVM.Add(user.Id, role.Id);
            else
                userroleVM.Edit(userrole.Id, user.Id, role.Id);
            Windown.Shutdown();
        }
    }
}
