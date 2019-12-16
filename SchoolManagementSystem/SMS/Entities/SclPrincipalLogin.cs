using SMS.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SMS.DataSource.Entities
{
    public class SclPrincipalLogin
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [ForeignKey("PrincipalId")]
        public SclPrincipal PrincipalUser { get; set; }

        [Required]
        public int PrincipalId { get; set; }
    }
}
