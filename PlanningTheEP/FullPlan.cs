//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PlanningTheEP
{
    using System;
    using System.Collections.Generic;
    
    public partial class FullPlan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public FullPlan()
        {
            this.FullAndFirst = new HashSet<FullAndFirst>();
        }
    
        public long Id_Plan { get; set; }
        public string NamePlan { get; set; }
        public long Id_Type { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<FullAndFirst> FullAndFirst { get; set; }
        public virtual Type Type { get; set; }
    }
}
