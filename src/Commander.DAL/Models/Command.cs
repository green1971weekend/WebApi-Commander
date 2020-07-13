using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Commander.DAL.Models
{
    /// <summary>
    /// Command model.
    /// </summary>
    public class Command
    {
        [Key] // There is no need to put this annotation here, because the system already knows about that it's primary key.
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        /// <summary>
        /// Description of the command.
        /// </summary>
        public string Description { get; set; }

        [Required]
        /// <summary>
        /// Full title of command.
        /// </summary>
        public string Line { get; set; }

        [Required]
        /// <summary>
        /// Platform in which the command runs.
        /// </summary>
        public string Platform { get; set; }
    }
}
