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
    
    public partial class CTTapPhim
    {
        public string ID { get; set; }
        public Nullable<int> TapPhim { get; set; }
        public string ID2 { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
    
        public virtual PhimBo PhimBo { get; set; }
    }
}