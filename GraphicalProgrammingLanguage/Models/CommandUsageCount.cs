using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GraphicalProgrammingLanguage.Models
{
    [Table("Table")]
    public partial class CommandUsageCount
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "text")]
        public string CommandName { get; set; }
        public int UsageCount { get; set; }
    }
}
