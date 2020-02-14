using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Movie.Models
{
    public class GenresType
    {
  
        public int GenresTypeId { get; set; }
        public string GenreName { get; set; }
    }
}

/*
 
     Sql("SET IDENTITY_INSERT GenresType ON");
            Sql("INSERT INTO GenresType(GenId, GenreName) VALUES (1, 'Comedy')");
            Sql("INSERT INTO GenresType(GenId, GenreName) VALUES (2, 'Action')");
            Sql("INSERT INTO GenresType(GenId, GenreName) VALUES (3, 'Cartoon')");
            Sql("INSERT INTO GenreType(GenId, GenreName) VALUES (4, 'Detective')");
            Sql("INSERT INTO GenresType(GenId, GenreName) VALUES (5, 'Horror')");
            Sql("SET IDENTITY_INSERT GenresType OFF");


     Sql("Set IDENTITY_INSERT Movies ON");
            Sql("INSERT INTO Movies(Id, Name, ReleaseDate, DateAdded, NumberInStock) VALUES (1, 'Hangover', 'Friday, November 6, 2009', 'Wednesday, February 5, 2019', 5 )");
            Sql("INSERT INTO Movies(Id, Name, ReleaseDate, DateAdded, NumberInStock) VALUES (2, 'Phineas and Ferb', 'Friday, November 6, 2010', 'Wednesday, February 5, 2019', 10 )");
            Sql("INSERT INTO Movies(Id, Name, ReleaseDate, DateAdded, NumberInStock) VALUES (3, 'Kim Possible', 'Monday, November 6, 2009', 'Wednesday, February 5, 2019', 12 )");
            Sql("INSERT INTO Movies(Id, Name, ReleaseDate, DateAdded, NumberInStock) VALUES (4, 'Fast 9', 'Friday, November 6, 2019', 'Wednesday, February 5, 2019', 4 )");
            Sql("INSERT INTO Movies(Id, Name, ReleaseDate, DateAdded, NumberInStock) VALUES (5, 'Friends', 'Friday, November 6, 1999', 'Wednesday, February 5, 2019', 1 )");
            Sql("Set IDENTITY_INSERT Movies OFF");
     */
