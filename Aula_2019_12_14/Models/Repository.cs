using System;
namespace Aula_2019_12_14.Models
{
    public class Repository
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public bool Private { get; set; }
        public User Owner { get; set; }

        public Repository()
        {

        }
    }
}
