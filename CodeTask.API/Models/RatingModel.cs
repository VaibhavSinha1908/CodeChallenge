using System.Collections.Generic;

namespace CodeTask.API.Models
{
    public class OccupationRating
    {
        public string rating { get; set; }
        public string factor { get; set; }
    }

    public class RatingRoot
    {
        public List<OccupationRating> occupationRating { get; set; }
    }
}
