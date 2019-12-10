using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMS.Entities
{
    public class Admin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [MaxLength(50)]
        public string UserName { get; set; }

        [MaxLength(50)]
        public string Password { get; set; }
        [Required]
        [MaxLength(20)]
        public string Gender { get; set; }

        [Required]
        [MaxLength(20)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(20)]
        public int ContactNumber { get; set; }
    }
}
