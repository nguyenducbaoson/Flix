//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PhimBo
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhimBo()
        {
            this.CTTapPhims = new HashSet<CTTapPhim>();
        }
    
        public string ID { get; set; }
        public string Name { get; set; }
        public Nullable<int> IDCategory { get; set; }
        public Nullable<int> Year { get; set; }
        public string Images { get; set; }
        public Nullable<int> Viewed { get; set; }
        public Nullable<int> Country { get; set; }
        public string Trailer { get; set; }
        public Nullable<int> Rate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTTapPhim> CTTapPhims { get; set; }
    }
}
