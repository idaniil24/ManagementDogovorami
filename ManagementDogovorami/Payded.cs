//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ManagementDogovorami
{
    using System;
    using System.Collections.Generic;
    
    public partial class Payded
    {
        public int ID { get; set; }
        public Nullable<decimal> Sum { get; set; }
        public int Contract_id { get; set; }
        public Nullable<System.DateTime> Pay_date { get; set; }
    
        public virtual Contracts Contracts { get; set; }
    }
}
