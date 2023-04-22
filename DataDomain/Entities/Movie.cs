﻿using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Test_API_Interest.DataDomain.Entities
{
    public class Movie
    {

        //[Key]
        public int MovieId { get; set; }
        public int GenreId { get; set; }
        public int PersonId { get; set; }
        public string Link { get; set; }
        //[Range(1,10)]
        private int RatingCheck;
        [Range(1, 10)]
        public int  Rating 
        {
            get; set;
            //get { return RatingCheck; }
            //set
            //{
            //    if (value > 10)
            //        throw new ArgumentException("Invalid value - Rating must be in the range 1-10");
            //    RatingCheck = value;
            //}
        }
        //[ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
        //[ForeignKey("GenreId")]
        public virtual Genre  Genre { get; set; }

    }
}
