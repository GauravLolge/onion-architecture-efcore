namespace CompanyName.MyAppName.Core.Entities
{

    /// <summary>
    /// Provides various members of user entity.
    /// </summary>
    /// <seealso cref="CompanyName.MyAppName.Core.Entities.BaseEntity" />
    public class User : BaseEntity
    {

        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }


        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name { get; set; }

    }
}
