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
    
    public partial class Parts
    {
        public int ID { get; set; }
        public Nullable<decimal> Price { get; set; }
        public Nullable<System.DateTime> Pay_day { get; set; }
        public Nullable<int> Contract_id { get; set; }
    
        public virtual Contracts Contracts { get; set; }
    }
}