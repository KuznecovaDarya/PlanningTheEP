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
    
    public partial class Schedule
    {
        public long Id_Schedule { get; set; }
        public long Id_Grade { get; set; }
        public long Id_Day { get; set; }
        public long Id_Subject { get; set; }
    
        public virtual Day Day { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual Subject Subject { get; set; }
    }
}