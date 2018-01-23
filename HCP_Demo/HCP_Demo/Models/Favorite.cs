using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HCP_Demo.Models
{
    /// <summary>
    /// Favorite data class
    /// </summary>
    public class Favorite
    {
        /// <summary>
        /// Favorite ID
        /// </summary>
        public int FavoriteID { get; set; }

        /// <summary>
        /// Product ID link.
        /// </summary>
        public int ProductID { get; set; }

        /// <summary>
        /// Customer ID link.
        /// </summary>
        public int CustomerID { get; set; }
        
        /// <summary>
        /// Instance of a customer.
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        /// Instance of a product.
        /// </summary>
        public Product Product { get; set; }
    }
}
