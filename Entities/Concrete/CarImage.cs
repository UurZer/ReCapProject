using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.Concrete
{
    public class CarImage:IEntity
    {
        public CarImage()
        {
            Date = DateTime.Now;
        }
        public int Id { get; set; }
        public int CarId { get; set; }
        public string ImagePath { get; set; }
        public DateTime? Date { get; set; }
        public bool Default { get; set; }
    }
}
