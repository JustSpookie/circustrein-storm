using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circustrein
{
    public class wagon
    {
        List<dier> listdieren = new List<dier> ();



        /// <summary>
        /// Kijkt wat het gewicht van alle dieren bij elkaar zijn 
        /// </summary>
        /// <returns>Geeft het gewicht wat nu in de wagon zit terug</returns>
        public int animalweightcount()
        {
            int weight = 0;

            foreach(dier d in listdieren)
            {
                weight = weight + d.grootte;
            }

            return weight;
        }
        

        /// <summary>
        /// Controlleert of je een dier kan toevoegen
        /// Dit doet die door het gewicht te controleren
        /// En hij controlleert of alles goed is in verband met carnivoren
        /// </summary>
        /// <param name="dier">Het dier wat je wilt controleren</param>
        /// <returns>Returns een bool of het mogelijk is om het dier toe te voegen of niet</returns>
        public bool kan_toevoegen(dier dier)
        {
            bool kantoevoegen = true;

            if((dier.grootte + animalweightcount()) > 10) { kantoevoegen=false; }
            if(dier.carnivoorcheck(listdieren) == false) { kantoevoegen=false; }

            if(kantoevoegen == true)
            {
                listdieren.Add(dier);
            }

            return kantoevoegen;
        }

        
        /// <summary>
        /// Geeft een lijst van alle dieren in de wagon terug
        /// </summary>
        /// <returns>Geeft een lijst van alle dieren terug</returns>
        public List<dier> getdieren()
        {
            return listdieren;
        }

    }
}
