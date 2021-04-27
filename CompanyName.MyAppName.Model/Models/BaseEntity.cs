using System.ComponentModel.DataAnnotations;

namespace CompanyName.MyAppName.Model.Models
{
    /// <summary>
    /// The base entity for application entities.
    /// </summary>
    public class BaseEntity 
    {
        /// <summary>
        /// Gets or sets the row version.
        /// </summary>
        /// <value>
        /// The row version.
        /// </value>
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
