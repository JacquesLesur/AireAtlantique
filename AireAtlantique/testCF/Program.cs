using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new DBtestContext())
            {
                db.Employes.Add(new Employe()
                {
                    Nom = "Jacques"
                  ,
                    ID = 5
                });

                db.SaveChanges();

            }
            

        }
    }
}
