using SMS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMS.DataSource.Entities
{
    public class AdminLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey("AdminId")]
        public Admin AdminUser { get; set; }

        [Required]
        public int AdminId { get; set; }
    }
}
