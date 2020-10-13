using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_GONLO
{
    /// <summary>
    /// Class tile, necessary for the Dejarik Board Game
    /// </summary>
    public class Tile
    {
        //List of movement 
        private List<Tile> listMovement = new List<Tile>();

        //List of all the tiles of the game (25 tiles)
        private static List<Tile> listTiles = new List<Tile>();

        /// <summary>
        /// Initialize the list of tiles
        /// </summary>
        public static void CreateTiles()
        {
            for (int i = 0; i < 26; i++)
            {
                listTiles.Add(new Tile(i));
            }
            CreateGraphTiles();
        }

        /// <summary>
        /// Associate available positions (movement) for each tile
        /// </summary>
        private static void CreateGraphTiles()
        {
            AssociateMovement(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13);
            AssociateMovement(2, 1, 3, 13, 15);
            AssociateMovement(3, 1, 2, 4, 16);
            AssociateMovement(4, 1, 3, 5, 17);
            AssociateMovement(5, 1, 4, 6, 18);
            AssociateMovement(6, 1, 5, 7, 19);
            AssociateMovement(7, 1, 6, 8, 20);
            AssociateMovement(8, 1, 7, 9, 21);
            AssociateMovement(9, 1, 8, 10, 22);
            AssociateMovement(10, 1, 9, 11, 23);
            AssociateMovement(11, 1, 10, 12, 24);
            AssociateMovement(12, 1, 11, 13, 25);
            AssociateMovement(13, 1, 2, 12, 14);
            AssociateMovement(14, 13, 15, 25);
            AssociateMovement(15, 2, 14, 16);
            AssociateMovement(16, 3, 15, 17);
            AssociateMovement(17, 4, 16, 18);
            AssociateMovement(18, 5, 17, 19);
            AssociateMovement(19, 6, 18, 20);
            AssociateMovement(20, 7, 19, 21);
            AssociateMovement(21, 8, 20, 22);
            AssociateMovement(22, 9, 21, 23);
            AssociateMovement(23, 10, 22, 24);
            AssociateMovement(24, 11, 23, 25);
            AssociateMovement(25, 12, 14, 24);
        }

        /// <summary>
        /// Add available positions to the list movement of the tile
        /// </summary>
        /// <param name="myTile"></param>
        /// <param name="tab"></param>
        private static void AssociateMovement(int myTile, params int[] tab)
        {
            foreach (int position in tab)
            {
                listTiles[myTile].listMovement.Add(listTiles[position]);
            }
        }

        /// <summary>
        /// Number getter and setter
        /// </summary>
        public int Number
        {
            get;
            set;
        }

        /// <summary>
        /// Tile Constructor
        /// </summary>
        /// <param name="number"></param>
        public Tile(int number)
        {
            Number = number;
        }

        /// <summary>
        /// Getter of list tiles
        /// </summary>
        public static List<Tile> ListTiles
        {
            get
            {
                return listTiles;
            }
        }

        /// <summary>
        /// Getter of list movement
        /// </summary>
        public List<Tile> ListMovement
        {
            get
            {
                return listMovement;
            }
        }

    }
}
