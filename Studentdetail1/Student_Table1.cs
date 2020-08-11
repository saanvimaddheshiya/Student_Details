namespace Studentdetail1
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Student_Table1
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string First_Name { get; set; }

        [StringLength(50)]
        public string Last_Name { get; set; }

        [StringLength(50)]
        public string Class { get; set; }

        [Required]
        [StringLength(50)]
        public string Subject { get; set; }

        public int? Marks { get; set; }
    }
}
