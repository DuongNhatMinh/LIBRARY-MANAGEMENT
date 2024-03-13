using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucSetFunctionForRole.xaml
    /// </summary>
    public partial class ucSetFunctionForRole : UserControl
    {
        RoleViewModel roleVM = new RoleViewModel();
        FunctionViewModel functionVM = new FunctionViewModel();
        RoleFunctionViewModel rolefunctionVM = new RoleFunctionViewModel();
        bool status;
        List<string> lstRole = new List<string>();
        List<string> lstAddFunction = new List<string>();
        List<string> lstDeleteFunction = new List<string>();
        ObservableCollection<RoleFunction> lstRoleFunction = new ObservableCollection<RoleFunction>();
        public ucSetFunctionForRole()
        {
            InitializeComponent();
            cbRole.Items.Clear();
            foreach (var item in roleVM.repoRole.Items)
            {
                if (item.Group == "librarian")
                {
                    cbRole.Items.Add(item.Name);
                }
            }
        }

        private void SetCheckBox(int op, string idrole)
        {
            if (op == 1)
            {
                foreach (var item in lstRoleFunction)
                {
                    Function functiontemp = functionVM.repoFunction.getbyid(item.IdFunction);
                    if (functiontemp.IdParent == null)
                    {
                        NameParent = new TreeViewItem()
                        {
                            Header = functiontemp.Name
                            
                        };
                        tvFunction.Items.Add(NameParent);
                        foreach (var item2 in functionVM.repoFunction.Items)
                        {
                            if (item2.Status == false)
                                continue;
                            ckbChild = new CheckBox();
                            if (item2.IdParent == functiontemp.Id)
                            {
                                if (rolefunctionVM.repoRoleFunction.check(item2.Id, idrole))
                                {
                                    status = true;
                                    ckbChild.Content = item2.Name;
                                    ckbChild.IsChecked = status;
                                    ckbChild.Checked += CkbChild_Checked;
                                    ckbChild.Unchecked += CkbChild_Unchecked;
                                    NameParent.Items.Add(ckbChild);
                                }
                                else
                                {
                                    status = false;
                                    ckbChild.Content = item2.Name;
                                    ckbChild.IsChecked = status;
                                    ckbChild.Checked += CkbChild_Checked;
                                    ckbChild.Unchecked += CkbChild_Unchecked;
                                    NameParent.Items.Add(ckbChild);
                                }
                            }
                        }
                    }
                    NameParent.IsExpanded = true;
                }
            }
            else
            {
                foreach (var item in functionVM.repoFunction.Items)
                {
                    if (item.IsAdmin == true)
                        continue;
                    status = false;
                    if (item.IdParent == null)
                    {
                        NameParent = new TreeViewItem();
                        NameParent.Header = item.Name;
                        tvFunction.Items.Add(NameParent);
                        foreach (var item2 in functionVM.repoFunction.Items)
                        {
                            if (item2.Status == false)
                                continue;
                            ckbChild = new CheckBox();
                            if (item2.IdParent == item.Id)
                            {
                                ckbChild.Content = item2.Name;
                                ckbChild.IsChecked = status;
                                ckbChild.Checked += CkbChild_Checked;
                                ckbChild.Unchecked += CkbChild_Unchecked;
                                NameParent.Items.Add(ckbChild);
                            }
                        }
                    }
                    NameParent.IsExpanded = true;
                }
            }
        }

        private bool isExist(string IdRole)
        {
            string temp = string.Empty;
            foreach (var item in rolefunctionVM.repoRoleFunction.Items)
            {
                if (item.IdRole == "R1")
                    continue;
                else if (temp != item.IdRole)
                {
                    temp = item.IdRole;
                    lstRole.Add(temp);
                }
            }

            foreach (var item in lstRole)
            {
                if (IdRole == item)
                    return true;
            }
            return false;
        }

        public void Init()
        {
            tvFunction.Items.Clear();
            NameParent.Visibility = Visibility.Hidden;
            Role roletemp = roleVM.repoRole.GetByName(cbRole.Items[cbRole.SelectedIndex].ToString());
            foreach (var item in rolefunctionVM.repoRoleFunction.Items)
            {
                Function functiontemp = functionVM.repoFunction.getbyid(item.IdFunction);

                if (item.IdRole == "R1")
                    continue;
                if (item.IdRole == roletemp.Id)
                {
                    lstRoleFunction.Add(item);
                }
            }
            if (isExist(roletemp.Id))
            {
                SetCheckBox(1, roletemp.Id);
            }
            else
            {
                SetCheckBox(2, roletemp.Id);
            }
        }

        private void CkbChild_Unchecked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            lstDeleteFunction.Add(checkBox.Content.ToString());
        }

        private void CkbChild_Checked(object sender, RoutedEventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            lstAddFunction.Add(checkBox.Content.ToString());
        }

        private void cbRole_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lstAddFunction = new List<string>();
            lstDeleteFunction = new List<string>();
            lstRole = new List<string>();
            lstRoleFunction = new ObservableCollection<RoleFunction>();
            Init();
        }

        private void FunctionParent(string idrole)
        {
            foreach(var item in functionVM.repoFunction.Items)
            {
                if (item.IdParent == "" && item.Id != "F1" && item.Id != "F7" && item.Id != "F12")
                {
                    if(!IsExist(idrole, item.Name))
                        lstAddFunction.Add(item.Name);
                }
            }
        }

        public bool IsExist(string roleid, string name)
        {
            Function function = functionVM.repoFunction.getbyname(name);
            foreach (var item2 in rolefunctionVM.repoRoleFunction.Items)
            {
                if (item2.IdRole == "R1")
                    continue;
                if (item2.IdRole == roleid)
                {
                    if(item2.IdFunction == function.Id)
                        return true;
                }
            }
            return false;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            Role role = roleVM.repoRole.GetByName(cbRole.Items[cbRole.SelectedIndex].ToString());
            FunctionParent(role.Id);
            if(lstAddFunction != null)
            {
                foreach (var item in lstAddFunction)
                {
                    Function function = functionVM.repoFunction.getbyname(item);
                    rolefunctionVM.Add(role.Id, function.Id);    
                }
                rolefunctionVM.flag = 0;
            }
            if(lstDeleteFunction != null)
            {
                foreach (var item in lstDeleteFunction)
                {
                    Function function = functionVM.repoFunction.getbyname(item);
                    RoleFunction rolefunction = rolefunctionVM.repoRoleFunction.GetByIdFunction(function.Id, role.Id);
                    if (rolefunction == null)
                        continue;
                    rolefunctionVM.Delete(rolefunction.Id);
                }
                rolefunctionVM.flag = 0;
            } 
        }
    }
}
