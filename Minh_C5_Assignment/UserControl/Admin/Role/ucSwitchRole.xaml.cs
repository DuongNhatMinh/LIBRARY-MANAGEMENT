using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucSwitchRole.xaml
    /// </summary>
    public partial class ucSwitchRole : UserControl
    {
        RoleViewModel roleVM = new RoleViewModel();
        UserViewModel userVM = new UserViewModel();
        UserRoleViewModel userroleVM = new UserRoleViewModel();

        private PaginationViewModel<UserRoleDTO> _PaginationVM;

        public ucSwitchRole()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            roleVM = new RoleViewModel();
            userVM = new UserViewModel();
            userroleVM = new UserRoleViewModel();
            _PaginationVM = new PaginationViewModel<UserRoleDTO>(GetUserRoleDTO());
            DataContext = _PaginationVM;
            _PaginationVM.SelectedButton = pagination.btnOne;
        }

        private List<UserRoleDTO> GetUserRoleDTO()
        {
            List<UserRoleDTO> userRoleDTO = new List<UserRoleDTO>();

            foreach (var item in userVM.repoUser.Items)
            {
                UserRoleDTO userroledto = new UserRoleDTO();
                Role role = roleVM.repoRole.GetByName("admin");
                Role role2 = new Role();
                UserRole userrole = userroleVM.repoUserRole.GetByIdUser(item.Id);
                if (userrole == null)
                {
                    userroledto = new UserRoleDTO(item.Id, item.Username, item.Password, "null", item.Status, item.CreatedAt, item.ModifiedAt);
                }
                else
                {
                    role2 = roleVM.repoRole.GetByID(userrole.IdRole);
                    userroledto = new UserRoleDTO(item.Id, item.Username, item.Password, role2.Name, item.Status, item.CreatedAt, item.ModifiedAt);
                }
                if (userrole == null || userrole.IdRole != role.Id)
                {
                    userRoleDTO.Add(userroledto);
                }
            }
            return userRoleDTO;
        }

        private void btnSet_Click(object sender, RoutedEventArgs e)
        {
            var item = dtgUser.Items[dtgUser.SelectedIndex] as UserRoleDTO;
            WindowMessege window = new WindowMessege();
            ucSetRole ucsetRole = new ucSetRole(item, window);
            window.grid.Children.Add(ucsetRole);
            window.ShowDialog();
            Init();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowMessege mess = new WindowMessege();
            mess.grid.Children.Add(new ucAddRole());
            mess.Show();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                _PaginationVM.GotoFirstPage(GetUserRoleDTO());
                return;
            }
            _PaginationVM.LstItem.Clear();

            foreach (var item in GetUserRoleDTO())
            {
                if (item.Id.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.UserName.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.Password.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.CreatedAt.ToString("dd/MM/yyyy").Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.ModifitedAt.ToString("dd/MM/yyyy").Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.RoleName.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
            }
        }
    }
}
