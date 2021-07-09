using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GraphicalProgrammingLanguage.Models
{
    /// <summary>
    /// The CommandUsageCount model is used to bind the entries from the database to the application.
    /// Table contains fieldsd for syntax examples which is intended to work as a reference guide for 
    /// users as well as being able to be copied and pasted quickly when tested.
    /// </summary>
    [Table("Table")]
    public partial class CommandUsageCount
    {
        [Key]
        public int Id { get; set; }
        [Column(TypeName = "varchar")]
        public string CommandName { get; set; }
        public string SyntaxExample { get; set; }
        public int UsageCount { get; set; }
    }
}
