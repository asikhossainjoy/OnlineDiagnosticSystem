//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DatabaseLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class LabAppointTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public LabAppointTable()
        {
            this.PatientTestDetailTables = new HashSet<PatientTestDetailTable>();
        }
    
        public int LabAppointID { get; set; }
        public int LabTestID { get; set; }
        public int PatientID { get; set; }
        public int LabID { get; set; }
        public int LabTimeSlotID { get; set; }
        public System.DateTime AppointDate { get; set; }
        public bool IsFeeSubmit { get; set; }
        public bool IsComplete { get; set; }
        public string Description { get; set; }
        public string TransectionNo { get; set; }
    
        public virtual LabTable LabTable { get; set; }
        public virtual LabTestTable LabTestTable { get; set; }
        public virtual LabTimeSlotTable LabTimeSlotTable { get; set; }
        public virtual PatientTable PatientTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PatientTestDetailTable> PatientTestDetailTables { get; set; }
    }
}
