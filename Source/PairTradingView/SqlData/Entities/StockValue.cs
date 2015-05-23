using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PairTradingView.SqlData.Entities
{
    public class StockValue
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        public DateTime DateTime { get; set; }
        public double Price { get; set; }
        public long Volume { get; set; }
    }
}
