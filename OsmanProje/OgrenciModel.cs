using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OsmanProje
{
   public class OgrenciModel
    {
       
            public int Id { get; set; }
            public string Ad { get; set; }
            

            public string FullName
            {
                get
                {
                    return $"{Ad}";
                }
            }
        }
}
