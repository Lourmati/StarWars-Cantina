using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_GONLO
{
   public class Player
    {
        //Global variables
        private string _nom;
        private string _species;
        private string _gender;
        private int _credits;
        private int _pazaakgameswon;
        private int _pazaakgameslost;
        private int _dejarikgameswon;
        private int _dejarikgameslost;
        private Monster _powMonster;
        private Monster _attMonster;
        private Monster _defMonster;
        private Monster _movMonster;
        private Monster currMonster;
        private List<Monster> _listMonsters = new List<Monster>();

        private int points = 0;
        private int nbCards = 0;
        private bool stand = false;
        private int nbVictoire = 0;
        private int nbCarteUtiliseAi = 0;

        /// <summary>
        /// Default Player object constructor
        /// </summary>
        public Player()
        {
            
        }

        //Getter / Setter for player's name
        public string Name
        {
            get { return _nom; }
            set { _nom = value; }
        }

        //Getter / Setter for player's species
        public string Species
        {
            get { return _species; }
            set { _species = value; }
        }

        //Getter / Setter for player's gender
        public string Gender
        {
            get { return _gender; }
            set { _gender = value; }
        }

        //Getter / Setter for player's credits
        public int Credits
        {
            get { return _credits; }
            set { _credits = value; }
        }

        //Getter / Setter for player's Pazaak games won
        public int PazaakGamesWon
        {
            get { return _pazaakgameswon; }
            set { _pazaakgameswon = value; }
        }

        //Getter / Setter for player's Pazaak games lost
        public int PazaakGamesLost
        {
            get { return _pazaakgameslost; }
            set { _pazaakgameslost = value; }
        }

        //Getter / Setter for player's Dejarik games won
        public int DejarikGamesWon
        {
            get { return _dejarikgameswon; }
            set { _dejarikgameswon = value; }
        }

        //Getter / Setter for player's Dejarik games lost
        public int DejarikGamesLost
        {
            get { return _dejarikgameslost; }
            set { _dejarikgameslost = value; }
        }

        //Getter / Setter for player's Dejarik power monster
        public Monster PowMonster
        {
            get { return _powMonster; }
            set { _powMonster = value; }
        }

        //Getter / Setter for player's Dejarik monsters addAttackDice data
        public Monster AttMonster
        {
            get { return _attMonster; }
            set { _attMonster = value; }
        }

        //Getter / Setter for player's Dejarik monsters defend data
        public Monster DefMonster
        {
            get { return _defMonster; }
            set { _defMonster = value; }
        }

        //Getter / Setter for player's Dejarik monsters movement data
        public Monster MovMonster
        {
            get { return _movMonster; }
            set { _movMonster = value; }
        }

        //Getter / Setter for player's Dejarik current monsters
        public Monster CurrMonster
        {
            get { return currMonster; }
            set { currMonster = value; }
        }

        //Getter / Setter for player's Dejarik list of monsters
        public List<Monster> ListMonsters {
            get => _listMonsters;
            set => _listMonsters = value;
        }

        //Getter / Setter for player's Pazaak points
        public int Points {
            get => points;
            set => points = value;
        }

        //Getter / Setter for player's number of Pazaak cards on the board
        public int NbCards {
            get => nbCards;
            set => nbCards = value;
        }

        //Getter / Setter for player's state in the Pazaak game
        public bool Stand {
            get => stand;
            set => stand = value;
        }

        //Getter / Setter for player's number of rounds won in the Pazaak game
        public int NbVictoire {
            get => nbVictoire;
            set => nbVictoire = value;
        }

        //Getter / Setter for the AI's number of Pazaak cards in his deck
        public int NbCarteUtiliseAi {
            get => nbCarteUtiliseAi;
            set => nbCarteUtiliseAi = value;
        }
    }
}
