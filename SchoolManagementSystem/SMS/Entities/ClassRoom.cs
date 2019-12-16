using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMS.Entities
{
    public class ClassRoom
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Grade { get; set; }

        [Required]
        public string Section { get; set; }

        [ForeignKey("ClasssTeacherId")]
        public Teacher ClassTeacher { get; set; }

        [Required]
        public int ClasssTeacherId { get; set; }
    }
}
