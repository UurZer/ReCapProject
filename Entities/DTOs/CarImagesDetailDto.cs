using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.DTOs
{
    public class CarImagesDetailDto : IDto
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
        public string CarName { get; set; }
        public string ColorName { get; set; }
        public string ModelYear { get; set; }
        public decimal DailyPrice { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public bool Status { get; set; }
    }
}
