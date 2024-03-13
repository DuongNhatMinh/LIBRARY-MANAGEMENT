namespace Minh_C5_Assignment
{
    class UnitofWork
    {
        public RepositoryReader reader;
        public RepositoryBookISBN bookISBN;
        public RepositoryAdult adult;
        public RepositoryChild child;
        public RepositoryBookTitle bookTitle;
        public RepositoryAuthor author;
        public RepositoryCategory category;
        public RepositoryParameter parameter;
        public RepositoryBook book;
        public RepositoryProvince province;
        public RepositoryUser user;
        public RepositoryRole role;
        public RepositoryFunction function;
        public RepositoryUserRole userrole;
        public RepositoryRoleFunction rolefunction;
        public RepositoryUserInfor userinfor;
        public RepositoryPublisher publisher;
        public RepositoryLoan loan;
        public RepositoryLoanDetail loandetail;
        public RepositoryLoanHistory loanhistory;
        public RepositoryLoanDetailHistory loandetailhistory;
        public RepositoryTranslator translator;
        public RepositoryBookStatus bookstatus;
        public RepositoryPenaltyReason penaltyreason;

        public RepositoryReader GetRepositoryReader
        {
            get
            {
                if (this.reader == null)
                    this.reader = new RepositoryReader();
                return reader;
            }
        }

        public RepositoryBookISBN GetRepositoryBookISBN
        {
            get
            {
                if (this.bookISBN == null)
                    this.bookISBN = new RepositoryBookISBN();
                return bookISBN;
            }
        }

        public RepositoryAdult GetRepositoryAdult
        {
            get
            {
                if (this.adult == null)
                    this.adult = new RepositoryAdult();
                return adult;
            }
        }

        public RepositoryChild GetRepositoryChild
        {
            get
            {
                if (this.child == null)
                    this.child = new RepositoryChild();
                return child;
            }
        }

        public RepositoryBookTitle GetRepositoryBookTitle
        {
            get
            {
                if (this.bookTitle == null)
                    this.bookTitle = new RepositoryBookTitle();
                return bookTitle;
            }
        }

        public RepositoryAuthor GetRepositoryAuthor
        {
            get
            {
                if (this.author == null)
                    this.author = new RepositoryAuthor();
                return author;
            }
        }

        public RepositoryCategory GetRepositoryCategory
        {
            get
            {
                if (this.category == null)
                    this.category = new RepositoryCategory();
                return category;
            }
        }

        public RepositoryParameter GetRepositoryParameter
        {
            get
            {
                if (this.parameter == null)
                    this.parameter = new RepositoryParameter();
                return parameter;
            }
        }

        public RepositoryBook GetRepositoryBook
        {
            get
            {
                if (this.book == null)
                    this.book = new RepositoryBook();
                return book;
            }
        }

        public RepositoryProvince GetRepositoryProvince
        {
            get
            {
                if (this.province == null)
                    this.province = new RepositoryProvince();
                return province;
            }
        }
        public RepositoryUser GetRepositoryUser
        {
            get
            {
                if (this.user == null)
                    this.user = new RepositoryUser();
                return user;
            }
        }
        public RepositoryRole GetRepositoryRole
        {
            get
            {
                if (this.role == null)
                    this.role = new RepositoryRole();
                return role;
            }
        }
        public RepositoryFunction GetRepositoryFunction
        {
            get
            {
                if (this.function == null)
                    this.function = new RepositoryFunction();
                return function;
            }
        }
        public RepositoryUserRole GetRepositoryUserRole
        {
            get
            {
                if (this.userrole == null)
                    this.userrole = new RepositoryUserRole();
                return userrole;
            }
        }
        public RepositoryRoleFunction GetRepositoryRoleFunction
        {
            get
            {
                if (this.rolefunction == null)
                    this.rolefunction = new RepositoryRoleFunction();
                return rolefunction;
            }
        }
        public RepositoryUserInfor GetRepositoryUserInfor
        {
            get
            {
                if (this.userinfor == null)
                    this.userinfor = new RepositoryUserInfor();
                return userinfor;
            }
        }

        public RepositoryPublisher GetRepositoryPublisher
        {
            get
            {
                if (this.publisher == null)
                    this.publisher = new RepositoryPublisher();
                return publisher;
            }
        }

        public RepositoryLoan GetRepositoryLoan
        {
            get
            {
                if (this.loan == null)
                    this.loan = new RepositoryLoan();
                return loan;
            }
        }

        public RepositoryLoanDetail GetRepositoryLoanDetail
        {
            get
            {
                if (this.loandetail == null)
                    this.loandetail = new RepositoryLoanDetail();
                return loandetail;
            }
        }

        public RepositoryLoanHistory GetRepositoryLoanHistory
        {
            get
            {
                if (this.loanhistory == null)
                    this.loanhistory = new RepositoryLoanHistory();
                return loanhistory;
            }
        }

        public RepositoryLoanDetailHistory GetRepositoryLoanDetailHistory
        {
            get
            {
                if (this.loandetailhistory == null)
                    this.loandetailhistory = new RepositoryLoanDetailHistory();
                return loandetailhistory;
            }
        }

        public RepositoryTranslator GetRepositoryTranslator
        {
            get
            {
                if (this.translator == null)
                    this.translator = new RepositoryTranslator();
                return translator;
            }
        }

        public RepositoryBookStatus GetRepositoryBookStatus
        {
            get
            {
                if (this.bookstatus == null)
                    this.bookstatus = new RepositoryBookStatus();
                return bookstatus;
            }
        }

        public RepositoryPenaltyReason GetRepositoryPenaltyReason
        {
            get
            {
                if (this.penaltyreason == null)
                    this.penaltyreason = new RepositoryPenaltyReason();
                return penaltyreason;
            }
        }
    }
}
