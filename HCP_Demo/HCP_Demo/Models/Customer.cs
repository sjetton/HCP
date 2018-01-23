using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HCP_Demo.Models
{
    /// <summary>
    /// Customer data class.
    /// </summary>
    public class Customer
    {
        /// <summary>
        ///  Customer ID.
        /// </summary>
        public int CustomerID { get; set; }

        /// <summary>
        /// Customers first name.
        /// </summary>
        [Required]
        [Column("FirstName")]
        [Display(Name = "First Name")]
        [StringLength(50)]
        public string FirstName { get; set; }

        /// <summary>
        /// Customers last name.
        /// </summary>
        [Required]
        [Column("LastName")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; }

        /// <summary>
        /// Customers street address.
        /// </summary>
        [Required]
        [Column("Address1")]
        [Display(Name = "Address")]
        public string Address1 { get; set; }

        /// <summary>
        /// Customers secondary street address.
        /// </summary>
        [Column("Address2")]
        [Display(Name = "Address Line 2")]
        public string Address2 { get; set; }

        /// <summary>
        /// Customers city.
        /// </summary>
        [Required]
        public string City { get; set; }

        /// <summary>
        /// Customers state.
        /// </summary>
        [Required]
        public string State { get; set; }

        /// <summary>
        /// Customers postal code.
        /// </summary>
        [Required]
        [Column("Zip")]
        [Display(Name = "Postal Code")]
        public int Zip { get; set; }

        // Creating a colletion of the Favorites class.
        public ICollection<Favorite> Favorites { get; set; }

    }
}