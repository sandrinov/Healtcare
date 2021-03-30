using System;
using System.ComponentModel.DataAnnotations;

namespace AppointmentsManagerShared
{
    public class Call
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Provider { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
    }
}
