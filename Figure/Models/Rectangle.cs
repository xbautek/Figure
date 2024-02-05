using System.ComponentModel.DataAnnotations;

namespace Figure.Models
{
    public enum Measure
    {
        mm,
        cm,
        m
    }

    public class Rectangle
    {
        public int Id { get; set; }
        [Range(1, 1000000)]
        [Required]
        [Display(Name = "Bok A")]
        public int sideA { get; set; }
        [Range(1, 1000000)]
        [Required]
        [Display(Name = "Bok B")]
        public int sideB { get; set; }
        [Display(Name = "Jednostka miary A")]

        public Measure MeasureA { get; set; }
        [Display(Name = "Jednostka miary B")]

        public Measure MeasureB { get; set; }

        public decimal SideInMetersA
        {
            get
            {
                switch (MeasureA)
                {
                    case Measure.mm:
                        return (decimal)sideA / 1000;
                    case Measure.cm:
                        return (decimal)sideA / 100;
                    default:
                        return sideA;
                }
            }
        }

        public decimal SideInMetersB
        {
            get
            {
                switch (MeasureB)
                {
                    case Measure.mm:
                        return (decimal)sideB / 1000;
                    case Measure.cm:
                        return (decimal)sideB / 100;
                    default:
                        return sideB;
                }
            }
        }

        // Obliczanie pola powierzchni
        public decimal Field
        {
            get
            {
                return SideInMetersA * SideInMetersB;
            }
        }

        [Display(Name = "Data utworzenia")]
        public DateTime? Created { get; set; }
    }
}
