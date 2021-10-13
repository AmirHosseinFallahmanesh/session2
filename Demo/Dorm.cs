using System.Collections.Generic;

namespace Demo
{
    public class Dorm
    {
        public int DormId { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public List<Student> Students { get; set; }
    }
}
