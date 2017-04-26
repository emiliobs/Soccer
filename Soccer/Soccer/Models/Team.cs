using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer.Models
{
    public class Team
    {
        [PrimaryKey]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Logo { get; set; }
        public string Initials { get; set; }
        public int LeagueId { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.CascadeRead)]
        public List<User> Fans { get; set; }
        public string FullLogo
        {
            get
            {
                if (string.IsNullOrEmpty(Logo))
                {
                    return "avatar_shield.png";
                }

                //http://soccerbackend.azurewebsites.net{0}", Picture.Substring(1)
                return $"http://soccerbackend55.azurewebsites.net{Logo.Substring(1)}";
            }
        }

        public override int GetHashCode()
        {
            return TeamId;
        }
    }
}
