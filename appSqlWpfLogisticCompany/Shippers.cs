//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace appSqlWpfLogisticCompany
{
    using System;
    using System.Collections.Generic;
    
    public partial class Shippers
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shippers()
        {
            this.Requests = new HashSet<Requests>();
        }
    
        public int Code_Shipper { get; set; }
        public string Name_Company { get; set; }
        public string Name_Responsible { get; set; }
        public string Surname_Responsible { get; set; }
        public string Midname_Responsible { get; set; }
        public string Number_Responsible { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Requests> Requests { get; set; }
    }
}