using Models.language;
using System;
using System.Collections.Generic;

namespace Models
{
    public class User
    {
        public User()
        {
            _Permissions = new List<Component>();
        }

        private List<Component> _Permissions;

        public Int32 Id { get; set; }
        public String Dni { get; set; }
        public String Name { get; set; }
        public String LastName { get; set; }
        public String UserName { get; set; }
        public String Password { get; set; }
        public String Email { get; set; }
        public Language Language { get; set; }
        public String Phone { get; set; }
        public String Adress { get; set; }
        public int Tries { get; set; }
        public bool isBlocked { get; set; }
        public Int32 Tipo {get; set;}
        public List<Component> Permissions
        {
            get
            {
                return _Permissions;
            }
        }
    }
}