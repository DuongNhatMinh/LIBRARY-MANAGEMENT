//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Minh_C5_Assignment
{
    using System;
    using System.Collections.Generic;
    
    public partial class BookISBN
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BookISBN()
        {
            this.Books = new HashSet<Book>();
        }
    
        public string ISBN { get; set; }
        public string IdBookTitle { get; set; }
        public string IdAuthor { get; set; }
        public string OriginLanguage { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
    
        public virtual Author Author { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Book> Books { get; set; }
        public virtual BookTitle BookTitle { get; set; }
    }
}
