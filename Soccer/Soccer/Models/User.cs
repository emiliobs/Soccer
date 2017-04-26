using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer.Models
{
    public  class User
    {
        [PrimaryKey]
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }          
        public int UserTypeId { get; set; }
        public string Picture { get; set; }
        public string Email { get; set; }
        public string NickName { get; set; }
        public int FavoriteTeamId { get; set; }
        public int Points { get; set; }

        [ManyToOne]
        public Team FavoriteTeam { get; set; }

        [ManyToOne]
        public UserType UserType { get; set; }
        public string FullName
        {
            get
            {
                return $"{FirstName}{LastName}";
            }
        }

        public string FullPicture
        {
            get
            {
                if(string.IsNullOrEmpty(Picture))
                {
                    return "avatar_user.png";
                }

                return $"http://soccerbackend55.azurewebsites.net{Picture.Substring(1)}";
            }
        }

        //Qui devuelo la clave primaria del modelo:
        public override int GetHashCode()
        {
            return UserId;
        }
    }
}
