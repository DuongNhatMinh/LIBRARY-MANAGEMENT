using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Minh_C5_Assignment
{
    public class PaginationViewModel<T> : BaseViewModel
    {
        public ObservableCollection<T> LstItem { get; set; }
        public ObservableCollection<T> StorageItem { get; set; }
        private int _CurrentPage = 1;
        private int _MaxPage;

        private int _ItemPerPage = 10;
        private int _CurrentItems = 1;
        public int CurrentItems
        {
            get
            {
                return _CurrentItems;
            }
            set
            {
                _CurrentItems = value;
                OnPropertyChanged();
            }
        }
        private int _ToItems = 10;
        public int ToItems
        {
            get
            {
                return _ToItems;
            }
            set
            {
                _ToItems = value;
                OnPropertyChanged();
            }
        }
        private int _MaxItems;
        public int MaxItems
        {
            get
            {
                return _MaxItems;
            }
            set
            {
                _MaxItems = value;
                OnPropertyChanged();
            }
        }

        public Button SelectedButton { get; set; }

        private int _ContentButtonOne = 1;
        public int ContentButtonOne {
            get { return _ContentButtonOne; }
            set
            {
                _ContentButtonOne = value;
                OnPropertyChanged();
            }
        }

        private int _ContentButtonTwo = 2;
        public int ContentButtonTwo
        {
            get { return _ContentButtonTwo; }
            set
            {
                _ContentButtonTwo = value;
                OnPropertyChanged();
            }
        }

        private int _ContentButtonThree = 3;
        public int ContentButtonThree
        {
            get { return _ContentButtonThree; }
            set
            {
                _ContentButtonThree = value;
                OnPropertyChanged();
            }
        }

        private int _ContentButtonFour = 4;
        public int ContentButtonFour
        {
            get { return _ContentButtonFour; }
            set
            {
                _ContentButtonFour = value;
                OnPropertyChanged();
            }
        }

        private int _ContentButtonFive = 5;
        public int ContentButtonFive
        {
            get { return _ContentButtonFive; }
            set
            {
                _ContentButtonFive = value;
                OnPropertyChanged();
            }
        }

        private Visibility _VisibilityButtonOne = Visibility.Visible;
        public Visibility VisibilityButtonOne
        {
            get { return _VisibilityButtonOne; }
            set
            {
                _VisibilityButtonOne = value;
                OnPropertyChanged();
            }
        }

        private Visibility _VisibilityButtonTwo = Visibility.Visible;
        public Visibility VisibilityButtonTwo
        {
            get { return _VisibilityButtonTwo; }
            set
            {
                _VisibilityButtonTwo = value;
                OnPropertyChanged();
            }
        }

        private Visibility _VisibilityButtonThree = Visibility.Visible;
        public Visibility VisibilityButtonThree
        {
            get { return _VisibilityButtonThree; }
            set
            {
                _VisibilityButtonThree = value;
                OnPropertyChanged();
            }
        }

        private Visibility _VisibilityButtonFour = Visibility.Visible;
        public Visibility VisibilityButtonFour
        {
            get { return _VisibilityButtonFour; }
            set
            {
                _VisibilityButtonFour = value;
                OnPropertyChanged();
            }
        }

        private Visibility _VisibilityButtonFive = Visibility.Visible;
        public Visibility VisibilityButtonFive
        {
            get { return _VisibilityButtonFive; }
            set
            {
                _VisibilityButtonFive = value;
                OnPropertyChanged();
            }
        }

        private bool _IsEnabledButtonOne = false;
        public bool IsEnabledButtonOne
        {
            get { return _IsEnabledButtonOne; }
            set
            {
                _IsEnabledButtonOne = value;
                OnPropertyChanged();
            }
        }

        private bool _IsEnabledButtonTwo = true;
        public bool IsEnabledButtonTwo
        {
            get { return _IsEnabledButtonTwo; }
            set
            {
                _IsEnabledButtonTwo = value;
                OnPropertyChanged();
            }
        }

        private bool _IsEnabledButtonThree = true;
        public bool IsEnabledButtonThree
        {
            get { return _IsEnabledButtonThree; }
            set
            {
                _IsEnabledButtonThree = value;
                OnPropertyChanged();
            }
        }

        private bool _IsEnabledButtonFour = true;
        public bool IsEnabledButtonFour
        {
            get { return _IsEnabledButtonFour; }
            set
            {
                _IsEnabledButtonFour = value;
                OnPropertyChanged();
            }
        }

        private bool _IsEnabledButtonFive = true;
        public bool IsEnabledButtonFive
        {
            get { return _IsEnabledButtonFive; }
            set
            {
                _IsEnabledButtonFive = value;
                OnPropertyChanged();
            }
        }

        private bool _IsEnabledButtonNext = true;
        public bool IsEnabledButtonNext
        {
            get { return _IsEnabledButtonNext; }
            set
            {
                _IsEnabledButtonNext = value;
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> ChangedComboBoxCommand { get; private set; }
        public RelayCommand<object> ChangedPageCommand { get; private set; }

        private void SetVisibilityButton(bool isMax)
        {
            if(isMax)
            {
                if (ContentButtonOne > _MaxPage)
                    VisibilityButtonOne = Visibility.Collapsed;

                if (ContentButtonTwo > _MaxPage)
                    VisibilityButtonTwo = Visibility.Collapsed;

                if (ContentButtonThree > _MaxPage)
                    VisibilityButtonThree = Visibility.Collapsed;

                if (ContentButtonFour > _MaxPage)
                    VisibilityButtonFour = Visibility.Collapsed;

                if (ContentButtonFive > _MaxPage)
                    VisibilityButtonFive = Visibility.Collapsed;
            }
            else
            {
                if (ContentButtonOne <= 0)
                    VisibilityButtonOne = Visibility.Collapsed;

                if (ContentButtonTwo <= 0)
                    VisibilityButtonTwo = Visibility.Collapsed;

                if (ContentButtonThree <= 0)
                    VisibilityButtonThree = Visibility.Collapsed;

                if (ContentButtonFour <= 0)
                    VisibilityButtonFour = Visibility.Collapsed;

                if (ContentButtonFive <= 0)
                    VisibilityButtonFive = Visibility.Collapsed;
            }
        }

        private void IncreaseContent()
        {
            ContentButtonOne = int.Parse(ContentButtonOne.ToString()) + 1;
            ContentButtonTwo = int.Parse(ContentButtonTwo.ToString()) + 1;
            ContentButtonThree = int.Parse(ContentButtonThree.ToString()) + 1;
            ContentButtonFour = int.Parse(ContentButtonFour.ToString()) + 1;
            ContentButtonFive = int.Parse(ContentButtonFive.ToString()) + 1;
        }

        private void DecreaseContent()
        {
            ContentButtonOne = int.Parse(ContentButtonOne.ToString()) - 1;
            ContentButtonTwo = int.Parse(ContentButtonTwo.ToString()) - 1;
            ContentButtonThree = int.Parse(ContentButtonThree.ToString()) - 1;
            ContentButtonFour = int.Parse(ContentButtonFour.ToString()) - 1;
            ContentButtonFive = int.Parse(ContentButtonFive.ToString()) - 1;
        }

        private void SetDefaultContentButton()
        {
            ContentButtonOne = 1;
            ContentButtonTwo = 2;
            ContentButtonThree = 3;
            ContentButtonFour = 4;
            ContentButtonFive = 5;
        }

        private void SetEnabledButton()
        {
            if(ContentButtonFive == _CurrentPage)
            {
                IsEnabledButtonFive = false;
            }
            else if(ContentButtonFour == _CurrentPage)
            {
                IsEnabledButtonFour = false;
            }
            else if(ContentButtonThree == _CurrentPage)
            {
                IsEnabledButtonThree = false;
            }
            else if(ContentButtonTwo == _CurrentPage)
            {
                IsEnabledButtonTwo = false;
            }
            else if(ContentButtonOne == _CurrentPage)
            {
                IsEnabledButtonOne = false;
            }
        }

        public PaginationViewModel(List<T> lstItem)
        {
            StorageItem = new ObservableCollection<T>(lstItem);
            this.LstItem = new ObservableCollection<T>(lstItem.Take(_ItemPerPage));
            MaxItems = lstItem.Count;

            _MaxPage = (lstItem.Count / _ItemPerPage);
            if (lstItem.Count % _ItemPerPage != 0)
                _MaxPage++;

            ToItems = (CurrentItems - 1) + lstItem.Skip((_CurrentPage - 1) * _ItemPerPage).Take(_ItemPerPage).Count();

            if (_MaxPage == 1)
                IsEnabledButtonNext = false;
            SetVisibilityButton(true);
            ChangedPageCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    VisibilityButtonFive = VisibilityButtonFour = VisibilityButtonOne = VisibilityButtonThree = VisibilityButtonTwo = Visibility.Visible;
                    SetVisibilityButton(true);
                    IsEnabledButtonFive = IsEnabledButtonFour = IsEnabledButtonThree = IsEnabledButtonTwo = IsEnabledButtonOne = true;

                    string currentPage = string.Empty;
                    var button = p as Button;
                    if(button.Name == "btnPrevious")
                    {
                        currentPage = (--_CurrentPage).ToString();
                        SetEnabledButton();
                    }
                    else if(button.Name == "btnNext")
                    {
                        currentPage = (++_CurrentPage).ToString();
                        SetEnabledButton();
                    }
                    else
                    {
                        currentPage = button.Content.ToString();
                    }


                    if ((int.Parse(currentPage) > _MaxPage - 2 || int.Parse(currentPage) > _MaxPage - 1) && (ContentButtonFour.ToString() == (_MaxPage - 2).ToString() || ContentButtonFive.ToString() == (_MaxPage - 1).ToString()))
                    {
                        if(button.Name != "btnNext" && button.Name != "btnPrevious")
                        {
                            button.IsEnabled = false;
                        }
                    }
                    else if (button.Name == "btnFour" || button.Name == "btnFive" || IsEnabledButtonFour == false || IsEnabledButtonFive == false)
                    {
                        IncreaseContent();
                        if(button.Name == "btnFive" || IsEnabledButtonFive == false)
                        {
                            IncreaseContent();
                        }
                        SetVisibilityButton(true);

                        IsEnabledButtonFive = IsEnabledButtonFour = IsEnabledButtonTwo = IsEnabledButtonOne = true;

                        IsEnabledButtonThree = false;
                    }
                    else if(ContentButtonOne.ToString() == "1" || ContentButtonTwo.ToString() == "2") 
                    {
                        if (button.Name != "btnNext" && button.Name != "btnPrevious")
                        {
                            button.IsEnabled = false;
                        }
                    }

                    else if(button.Name == "btnOne" || button.Name == "btnTwo" || IsEnabledButtonOne == false || IsEnabledButtonTwo == false)
                    {
                        DecreaseContent();
                        if(button.Name == "btnOne" || IsEnabledButtonOne == false)
                            DecreaseContent();
                        SetVisibilityButton(false);
                        IsEnabledButtonFive = IsEnabledButtonFour = IsEnabledButtonTwo = IsEnabledButtonOne = true;
                        IsEnabledButtonThree = false;
                    }
                    else
                    {
                        if (button.Name != "btnNext" && button.Name != "btnPrevious")
                        {
                            button.IsEnabled = false;
                        }
                    }

                    SelectedButton = button;

                    _CurrentPage = int.Parse(currentPage);

                    CurrentItems = ((_CurrentPage - 1) * _ItemPerPage) + 1;
                    ToItems = (CurrentItems - 1) + StorageItem.Skip((_CurrentPage - 1) * _ItemPerPage).Take(_ItemPerPage).Count();

                    LstItem.Clear();

                    if(ToItems == MaxItems)
                    {
                        IsEnabledButtonNext = false;
                    }
                    else
                        IsEnabledButtonNext = true;

                    SetVisibilityButton(false);
                    SetVisibilityButton(true);

                    foreach (var item in StorageItem.Skip((_CurrentPage - 1) * _ItemPerPage).Take(_ItemPerPage))
                    {
                        LstItem.Add(item);
                    }
                }    
            );

            ChangedComboBoxCommand = new RelayCommand<object>(
                p => true,
                p =>
                {
                    var comboBox = p as ComboBox;
                    IsEnabledButtonFive = IsEnabledButtonFour = IsEnabledButtonThree = IsEnabledButtonTwo = true;
                    IsEnabledButtonOne = false;

                    _ItemPerPage = int.Parse((comboBox.SelectedItem as ComboBoxItem).Content.ToString());
                    _CurrentPage = 1;
                    CurrentItems = 1;
                    ToItems = (CurrentItems - 1) + StorageItem.Skip((_CurrentPage - 1) * _ItemPerPage).Take(_ItemPerPage).Count();
                    SetDefaultContentButton();

                    _MaxPage = (StorageItem.Count / _ItemPerPage);
                    if (StorageItem.Count % _ItemPerPage != 0)
                        _MaxPage++;
                    VisibilityButtonFive = VisibilityButtonFour = VisibilityButtonThree = VisibilityButtonTwo = VisibilityButtonOne = Visibility.Visible;
                    SetVisibilityButton(true);
                    if(VisibilityButtonFive == Visibility.Visible || VisibilityButtonFour == Visibility.Visible || VisibilityButtonThree == Visibility.Visible || VisibilityButtonTwo == Visibility.Visible || VisibilityButtonOne == Visibility.Visible)
                    {
                        IsEnabledButtonNext = true;
                    }
                    if (_MaxPage == 1)
                        IsEnabledButtonNext = false;
                    LstItem.Clear();
                    foreach (var item in StorageItem.Skip((_CurrentPage - 1) * _ItemPerPage).Take(_ItemPerPage))
                    {
                        LstItem.Add(item);
                    }
                }    
            );
        }

        public void GotoFirstPage(List<T> lstItem)
        {
            StorageItem = new ObservableCollection<T>(lstItem);

            SetDefaultContentButton();
            if (VisibilityButtonFive == Visibility.Visible || VisibilityButtonFour == Visibility.Visible || VisibilityButtonThree == Visibility.Visible || VisibilityButtonTwo == Visibility.Visible || VisibilityButtonOne == Visibility.Visible)
            {
                IsEnabledButtonNext = true;
            }
            IsEnabledButtonFive = IsEnabledButtonFour = IsEnabledButtonThree = IsEnabledButtonTwo = true;
            IsEnabledButtonOne = false;
            _CurrentPage = 1;
            CurrentItems = 1;
            
            ToItems = (CurrentItems - 1) + lstItem.Skip((_CurrentPage - 1) * _ItemPerPage).Take(_ItemPerPage).Count();

            LstItem.Clear();
            foreach (var item in lstItem.Skip((_CurrentPage - 1) * _ItemPerPage).Take(_ItemPerPage))
            {
                LstItem.Add(item);
            }
        }
    }
}
