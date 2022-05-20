using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopProject_1.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; } // имя фамилия покупателя

        public int GamePrice { get; set; }
        public int Password { get; set; }
      
       
    }
}

