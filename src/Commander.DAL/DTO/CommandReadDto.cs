namespace Commander.DAL.DTO
{
    /// <summary>
    /// Command data transfer object for reading.
    /// </summary>
    public class CommandReadDto
    {
        /// <summary>
        /// Identifier.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Description of the command.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Full title of command.
        /// </summary>
        public string Line { get; set; }

        /// <summary>
        /// Platform in which the command runs.
        /// </summary>
        public string Platform { get; set; }
    }
}
