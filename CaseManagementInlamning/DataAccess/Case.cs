//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace CaseManagementInlamning.DataAccess
{
    using System;
    using System.Collections.Generic;
    
    public partial class Case
    {
        public int CaseId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerPhone { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedAt { get; set; }
        public string Status { get; set; }
    }
}
