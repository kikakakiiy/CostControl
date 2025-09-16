using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CostControl.Models
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required, MaxLength(255)]
        public string ProjectName { get; set; }

        [MaxLength(50)]
        public string Type { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Budget { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Total { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Actual { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Forecast { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Overbudget { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Remaining { get; set; }

        [MaxLength(50)]
        public string Category { get; set; }

        [MaxLength(50)]
        public string Progress { get; set; }
    }
}
