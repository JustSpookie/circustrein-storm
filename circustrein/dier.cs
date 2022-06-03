using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circustrein
{
    public class dier
    {
        public int naam;
        public int grootte;
        public bool carnivoor;

        public dier(int Naam, int Grootte, bool Carnivoor)
        {
            naam = Naam;
            grootte = Grootte;
            carnivoor = Carnivoor;
        }

        /// <summary>
        /// Controlleert de lijst met dieren voor carnivoren
        /// En controlleert of dit dier erbij kan
        /// </summary>
        /// <param name="listdieren">Een lijst dieren die je wilt controleren</param>
        /// <returns>Geeft een bool terug die kijkt of het dier er wel of niet in kan</returns>
        public bool carnivoorcheck(List<dier> listdieren)
        {
            bool mogelijk = true;

            if (carnivoor == true)
            {
                foreach (dier dier1 in listdieren)
                {
                    if (grootte >= dier1.grootte)
                    {
                        mogelijk = false;
                    }
                }
            }
            foreach (dier dier2 in listdieren)
            {
                if ((dier2.carnivoor == true) && (dier2.grootte >= grootte))
                {
                    mogelijk = false;
                }
            }

            return mogelijk;
        }
    }
}
