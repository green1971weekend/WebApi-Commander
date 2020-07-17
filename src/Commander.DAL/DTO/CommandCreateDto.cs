using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Commander.DAL.DTO
{
    /// <summary>
    /// Command data transfer object for creation.
    /// </summary>
    public class CommandCreateDto
    {
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
