using System;
using Newtonsoft.Json;

namespace Aula_2019_12_14.Models
{
    public class User
    {
        //"login": "mojombo",
        //"id": 1,
        //"node_id": "MDQ6VXNlcjE=",
        //"avatar_url": "https://avatars0.githubusercontent.com/u/1?v=4",
        //"gravatar_id": "",
        //"url": "https://api.github.com/users/mojombo",

        public string Login { get; set; }
        public int Id { get; set; }

        [JsonProperty("avatar_url")]
        public string AvatarUrl { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }

        public User()
        {

        }
    }
}
