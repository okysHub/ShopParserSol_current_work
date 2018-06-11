using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShopParser.Models
{
    public class ProductPriceHistory: ModelBase
    {
        private decimal _price;
        private DateTime? _updateDate;
        private int? productId;

        public decimal Price { get => _price; set => _price = value; }
        public DateTime? UpdateDate { get => _updateDate; set => _updateDate = value; }
        public int? ProductId { get => productId; set => productId = value; }
        public Product Product { get; set; }
    }
}