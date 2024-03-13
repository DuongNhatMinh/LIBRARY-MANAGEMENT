using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Minh_C5_Assignment
{
    /// <summary>
    /// Interaction logic for ucSearchReader.xaml
    /// </summary>
    public partial class ucSearchReader : UserControl, INotifyPropertyChanged
    {
        private int Selected = 0;
        int length = 0;
        private PaginationViewModel<Reader> _PaginationVM;
        ReaderViewModel readerVM = new ReaderViewModel();
        AdultViewModel adultVM = new AdultViewModel();
        ChildViewModel childVM = new ChildViewModel();
        ParameterViewModel parameterVM = new ParameterViewModel();
        List<Reader> ChildReaders = new List<Reader>();
        List<Child> childs = new List<Child>();
        Utility ult = new Utility();
        private string _find;

        public string Find
        {
            get { return _find; }
            set
            {
                _find = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ucSearchReader()
        {
            InitializeComponent();
            _PaginationVM = new PaginationViewModel<Reader>(readerVM.repoReader.Items);
            DataContext = _PaginationVM;
            _PaginationVM.SelectedButton = pagination.btnOne;
        }

        private void btnDetail_Click(object sender, RoutedEventArgs e)
        {
            ChildReaders = new List<Reader>();
            childs = new List<Child>();
            var item = (sender as Button).DataContext as Reader;
            if (item.ReaderType == true)
            {
                Adult adult = adultVM.repoAdult.GetByIdReader(item.Id);
                ult.CheckChildQuantity(adult, readerVM.repoReader.Items, childVM.repoChild.Items, ChildReaders, childs);
                WindowMessege window = new WindowMessege();
                window.grid.Children.Add(new ucAdultInfor(item, adult, ChildReaders));
                window.ShowDialog();
            }
            else
            {
                Child child = childVM.repoChild.GetByReaderID(item.Id);
                Adult adult = adultVM.repoAdult.GetByIdReader(child.IdAdult);
                Reader adultReader = readerVM.repoReader.GetById(adult.IdReader);
                WindowMessege window = new WindowMessege();
                window.grid.Children.Add(new ucChildInfor(adultReader, adult, item, child));
                window.ShowDialog();
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            var item = (sender as Button).DataContext as Reader;
            if (item.Status == false)
            {
                readerVM.UnLock(item, dtgReader.SelectedIndex);
                if (readerVM.check == 1)
                    return;
                readerVM.repoReader.Items[dtgReader.SelectedIndex].Status = true;
                _PaginationVM.GotoFirstPage(readerVM.repoReader.Items);
            }
            else
            {
                readerVM.Lock(item, dtgReader.SelectedIndex);
                readerVM.repoReader.Items[dtgReader.SelectedIndex].Status = false;
                _PaginationVM.GotoFirstPage(readerVM.repoReader.Items);
            }
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            WindowMessege mess = new WindowMessege();
            mess.grid.Children.Add(new ucAddReader());
            mess.Show();
        }

        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtSearch.Text == string.Empty)
            {
                _PaginationVM.GotoFirstPage(readerVM.repoReader.Items);
                return;
            }
            _PaginationVM.LstItem.Clear();

            foreach (var item in readerVM.repoReader.Items)
            {
                if (item.Id.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.FName.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.LName.ToLower().Contains(txtSearch.Text.ToLower()))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.boF.ToString("dd/MM/yyyy").Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.CreatedAt.ToString("dd/MM/yyyy").Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
                else if (item.ModifiedAt.ToString("dd/MM/yyyy").Contains(txtSearch.Text))
                {
                    _PaginationVM.LstItem.Add(item);
                }
            }
        }
    }
}
