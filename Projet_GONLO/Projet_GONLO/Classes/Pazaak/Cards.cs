using Projet_GONLO.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace Projet_GONLO
{
    class Cards
    {
        //Global variables
        private static Image[] TabPlusCards = new Image[6];
        private Image[] TabMinusCards = new Image[6];
        private Image[] TabPlusMinusCards = new Image[6];
        private Image[] TabNormalCards = new Image[10];

        /// <summary>
        /// Default Cards constructor
        /// </summary>
        public Cards()
        {
            RemplirTableauCartes();
        }

        /// <summary>
        /// This method fills the Image arrays with their proper cards
        /// </summary>
        private void RemplirTableauCartes()
        {
            for (int i = 0; i < TabPlusCards.Length; i++)
            {
                TabPlusCards[i] = (Image)Properties.Resources.ResourceManager.GetObject("Carte" + "Plus" + (i+1));
            }
            for (int i = 0; i < TabMinusCards.Length; i++)
            {
                TabMinusCards[i] = (Image)Properties.Resources.ResourceManager.GetObject("Carte" + "Minus" + (i + 1));
            }
            for (int i = 0; i < TabPlusMinusCards.Length; i++)
            {
                TabPlusMinusCards[i] = (Image)Properties.Resources.ResourceManager.GetObject("Carte" + "PlusMinus" + (i + 1));
            }
            for (int i = 0; i < TabNormalCards.Length; i++)
            {
                TabNormalCards[i] = (Image)Properties.Resources.ResourceManager.GetObject("Carte" + (i + 1));
            }
        }

        /// <summary>
        /// This Getter method returns a plus card image
        /// </summary>
        /// <param name="num"></param>
        /// <returns> Image TabPlusCards[num] </returns>
        public Image getCartePlus(int num)
        {
            return TabPlusCards[num-1];
        }

        /// <summary>
        /// This Getter method returns a minus card image
        /// </summary>
        /// <param name="num"></param>
        /// <returns> Image TabMinusCards[num] </returns>
        public Image getCarteMinus(int num)
        {
            return TabMinusCards[num - 1];
        }

        /// <summary>
        /// This Getter method returns a plus/minus card image
        /// </summary>
        /// <param name="num"></param>
        /// <returns> Image TabPlusMinusCards[num] </returns>
        public Image getCartePlusMinus(int num)
        {
            return TabPlusMinusCards[num - 1];
        }

        /// <summary>
        /// This Getter method returns a normal card image
        /// </summary>
        /// <param name="num"></param>
        /// <returns> Image TabNor</returns>
        public Image getCarteNormal(int num)
        {
            return TabNormalCards[num - 1];
        }

    }
}
