using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucUserInfor.xaml
    /// </summary>
    public partial class ucUserInfor : UserControl
    {
        UserInfo userInfor = new UserInfo();
        UserRoleViewModel userroleVM = new UserRoleViewModel();
        RoleViewModel roleVM = new RoleViewModel();
        public ucUserInfor(object infor)
        {
            InitializeComponent();
            userInfor = infor as UserInfo;

            UserRole userrole = userroleVM.repoUserRole.GetByIdUser(userInfor.IdUser);
            if(userrole == null)
                tblRole.Text = string.Format("Role: null");
            Role role = roleVM.repoRole.GetByID(userrole.IdRole);
            tblName.Text = string.Format("Name: {0} {1}", userInfor.LName, userInfor.FName);
            tblPhone.Text = string.Format("Phone: {0}", userInfor.Phone);
            tblAddress.Text = string.Format("Address: {0}", userInfor.Address);
            tblRole.Text = string.Format("Role: {0}", role.Name);
        }
    }
}
