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
    
    public partial class Users_Photo
    {
        public int Code_Photo { get; set; }
        public int Code_User { get; set; }
        public string Path_Photo { get; set; }
        public byte[] Photo_User { get; set; }
        public Nullable<bool> Current_Photo { get; set; }
    
        public virtual Users Users { get; set; }
    }
}
