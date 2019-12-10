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
        [MaxLength(20)]
        public string Grade { get; set; }

        [Required]
        [MaxLength(20)]
        public string Section { get; set; }

        [ForeignKey("ClasssTeacherId")]
        [Required]
        [MaxLength(20)]
        public Teacher ParentTeacher { get; set; }

        public int ClasssTeacherId { get; set; }
    }
}
