using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValeanDariaLab7.Models
{
    public class Shop
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public required string ShopName { get; set; }
        public required string Adress { get; set; }
        public string ShopDetails
        {
            get
            {
                return ShopName + ""+Adress;} }
        [OneToMany]
        public required List<ShopList> ShopLists { get; set; }

    }
}
