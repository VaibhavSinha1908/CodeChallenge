using System.Collections.Generic;

namespace CodeTask.API.Models
{
    public class OccupationList
    {
        public int id { get; set; }
        public string name { get; set; }
        public string rating { get; set; }
    }

    public class OccupationRoot
    {
        public List<OccupationList> occupationList { get; set; }
    }
}
