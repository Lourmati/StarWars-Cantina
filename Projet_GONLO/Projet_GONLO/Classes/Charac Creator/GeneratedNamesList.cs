using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_GONLO
{
    class GeneratedNamesList
    {
        //Global Random
        private Random rand = new Random();

        //Lists of names for all species 
        public List<string> listNameMandalorian = new List<string>();
        public List<string> listNameZabrak = new List<string>();
        public List<string> listNameSPB = new List<string>();
        public List<string> listNameTwilek = new List<string>();
        public List<string> listNameCathar = new List<string>();
        public List<string> listNameHuman = new List<string>();

        /// <summary>
        /// This method adds Mandalorian names in the List<string> listNameMandalorian
        /// </summary>
        /// <returns> List<string> listNameMandalorian </returns>
        private List<string> FillListNameMand()
        {
            //Male Mandalorian names
            listNameMandalorian.Add("Par Wruuc");
            listNameMandalorian.Add("Drick Wrarkard");
            listNameMandalorian.Add("Pad Zahl");
            listNameMandalorian.Add("Juk Daxagg");
            listNameMandalorian.Add("Lliyiod Tunch");
            listNameMandalorian.Add("Xideank Drachorr");
            listNameMandalorian.Add("Iopoe Fyrs");
            listNameMandalorian.Add("Anno Rasuard");
            listNameMandalorian.Add("Rhiidebeenx Krungh");
            listNameMandalorian.Add("Kroesulu Zulgai");
            listNameMandalorian.Add("Xean Guas");
            listNameMandalorian.Add("Murk Strunygg");
            listNameMandalorian.Add("Throng Wit");
            listNameMandalorian.Add("Grej Walgoc");
            listNameMandalorian.Add("Kriikruk Blill");
            listNameMandalorian.Add("Gokku Stretod");
            listNameMandalorian.Add("Rasoegg Kuun");
            listNameMandalorian.Add("Njoraild Paurvun");
            listNameMandalorian.Add("Orosan Qugg");
            listNameMandalorian.Add("Vraidavoe Foobbest");

            //Female Mandalorian names
            listNameMandalorian.Add("Fi Tros");
            listNameMandalorian.Add("Va Ikkatt");
            listNameMandalorian.Add("Sham Wran");
            listNameMandalorian.Add("Shialk Blaso");
            listNameMandalorian.Add("Aodesh Troord");
            listNameMandalorian.Add("Haymnalk Ulyll");
            listNameMandalorian.Add("Kaytai Sywr");
            listNameMandalorian.Add("Bonnoo Cyyos");
            listNameMandalorian.Add("Ikaiba Veg");
            listNameMandalorian.Add("Risilo Dreli");
            listNameMandalorian.Add("Khin Suwr");
            listNameMandalorian.Add("Zha Wapmyt");
            listNameMandalorian.Add("Rilk Skegg");
            listNameMandalorian.Add("Bi Ydu");
            listNameMandalorian.Add("Phobbial Blunch");
            listNameMandalorian.Add("Huskish Qaurhout");
            listNameMandalorian.Add("Uyias Cral");
            listNameMandalorian.Add("Nemsaith Tarvhic");
            listNameMandalorian.Add("Aviddes Nud");
            listNameMandalorian.Add("Bhekkiggath Dakko");

            return listNameMandalorian;
        }

        /// <summary>
        /// This Getter method returns a Mandalorian name depending on the gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns> string name </returns>
        public string getListNameMand(string gender)
        {
            FillListNameMand();
            string name;
            if (gender == "M")
            {
                int listIndex = rand.Next(0, 20);
                name = listNameMandalorian.ElementAt(listIndex);
            }
            else
            {
                int listIndex = rand.Next(21, 40);
                name = listNameMandalorian.ElementAt(listIndex);
            }
            return name;
        }



        /// <summary>
        /// This method adds Zabrak names in the List<string> listNameZabrak
        /// </summary>
        /// <returns> List<string> listNameZabrak </returns>
        private List<string> FillListNameZab()
        {
            //Male Zabrak names
            listNameZabrak.Add("Kradroo");
            listNameZabrak.Add("Vratropa");
            listNameZabrak.Add("Vukraru");
            listNameZabrak.Add("Kuprar");
            listNameZabrak.Add("Reprura");
            listNameZabrak.Add("Aekror");
            listNameZabrak.Add("Vrutas");
            listNameZabrak.Add("Stavrag");
            listNameZabrak.Add("Storga");
            listNameZabrak.Add("Drasuu");
            listNameZabrak.Add("Retae");
            listNameZabrak.Add("Povue");
            listNameZabrak.Add("Sogrok");
            listNameZabrak.Add("Mosa");
            listNameZabrak.Add("Duvao");
            listNameZabrak.Add("Audo");
            listNameZabrak.Add("Gexam");
            listNameZabrak.Add("Grebromu");
            listNameZabrak.Add("Kagoma");
            listNameZabrak.Add("Peta");

            //Female Zabrak names
            listNameZabrak.Add("Stomati");
            listNameZabrak.Add("Buqa");
            listNameZabrak.Add("Ausake");
            listNameZabrak.Add("Gedrio");
            listNameZabrak.Add("Nokrido");
            listNameZabrak.Add("Blunes");
            listNameZabrak.Add("Oovreda");
            listNameZabrak.Add("Xokrose");
            listNameZabrak.Add("Kugei");
            listNameZabrak.Add("Reme");
            listNameZabrak.Add("Blavax");
            listNameZabrak.Add("Gumok");
            listNameZabrak.Add("Gedama");
            listNameZabrak.Add("Lokrao");
            listNameZabrak.Add("Eaveku");
            listNameZabrak.Add("Aosri");
            listNameZabrak.Add("Hage");
            listNameZabrak.Add("Aosrou");
            listNameZabrak.Add("Eesaxo");
            listNameZabrak.Add("Qado");

            return listNameZabrak;
        }

        /// <summary>
        /// This Getter method returns a Zabrak name depending on the gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns> string name </returns>
        public string getListNameZab(string gender)
        {
            FillListNameZab();
            string name;
            if (gender == "M")
            {
                int listIndex = rand.Next(0, 20);
                name = listNameZabrak.ElementAt(listIndex);
            }
            else
            {
                int listIndex = rand.Next(21, 40);
                name = listNameZabrak.ElementAt(listIndex);
            }
            return name;
        }



        /// <summary>
        /// This method adds Sith Pureblood names in the List<string> listNameSPB
        /// </summary>
        /// <returns> List<string> listNameSPB </returns>
        private List<string> FillListNameSPB()
        {
            //Male Sith Pureblood names
            listNameSPB.Add("Krâmshan");
            listNameSPB.Add("Yuhshat");
            listNameSPB.Add("Sralos");
            listNameSPB.Add("Rhilzos");
            listNameSPB.Add("Kaidhis");
            listNameSPB.Add("Zroshwû");
            listNameSPB.Add("Hotsais");
            listNameSPB.Add("Dona");
            listNameSPB.Add("Tishdû");
            listNameSPB.Add("Rhûrji");
            listNameSPB.Add("Nikwum");
            listNameSPB.Add("Nuykaits");
            listNameSPB.Add("Lajliw");
            listNameSPB.Add("Chotûsh");
            listNameSPB.Add("Whâdkuz");
            listNameSPB.Add("Ûlowyi");
            listNameSPB.Add("Wrushow");
            listNameSPB.Add("Hiljûm");
            listNameSPB.Add("Tsoikâ");
            listNameSPB.Add("Wrojim");

            //Female Sith Pureblood names
            listNameSPB.Add("Zarua");
            listNameSPB.Add("Ekheniu");
            listNameSPB.Add("Wiqul");
            listNameSPB.Add("Eqoleath");
            listNameSPB.Add("Dhulua");
            listNameSPB.Add("Ruglea");
            listNameSPB.Add("Xukeath");
            listNameSPB.Add("Ixikam");
            listNameSPB.Add("Zhigriux");
            listNameSPB.Add("Namrualyr");
            listNameSPB.Add("Isopuasy");
            listNameSPB.Add("Bhahi");
            listNameSPB.Add("Awexviash");
            listNameSPB.Add("Ipleqaeth");
            listNameSPB.Add("Gheaxduatiur");
            listNameSPB.Add("Vrokwa");
            listNameSPB.Add("Udragbe");
            listNameSPB.Add("Uwraqias");
            listNameSPB.Add("Komla");
            listNameSPB.Add("Uxuhia");

            return listNameSPB;
        }

        /// <summary>
        /// This Getter method returns a Sith Pureblood name depending on the gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns> string name </returns>
        public string getListNameSPB(string gender)
        {
            FillListNameSPB();
            string name;
            if (gender == "M")
            {
                int listIndex = rand.Next(0, 20);
                name = listNameSPB.ElementAt(listIndex);
            }
            else
            {
                int listIndex = rand.Next(21, 40);
                name = listNameSPB.ElementAt(listIndex);
            }
            return name;
        }



        /// <summary>
        /// This method adds Twilek names in the List<string> listNameTwilek
        /// </summary>
        /// <returns> List<string> listNameTwilek </returns>
        private List<string> FillListNameTwilek()
        {
            //Male Twilek names
            listNameTwilek.Add("Bumbacri");
            listNameTwilek.Add("Audopfaru");
            listNameTwilek.Add("Hekkile");
            listNameTwilek.Add("Uumibcidus");
            listNameTwilek.Add("Criswajif");
            listNameTwilek.Add("Hig'fowim");
            listNameTwilek.Add("Ajobzacru");
            listNameTwilek.Add("Aulewnabik");
            listNameTwilek.Add("Okumhahag");
            listNameTwilek.Add("Gitzuci");
            listNameTwilek.Add("Iciwdogiq");
            listNameTwilek.Add("Aubihhisew");
            listNameTwilek.Add("Aeluh'haja");
            listNameTwilek.Add("Gat'cenu");
            listNameTwilek.Add("Gegbacis");
            listNameTwilek.Add("Omamhuse");
            listNameTwilek.Add("Aerebtukal");
            listNameTwilek.Add("Ekozfela");
            listNameTwilek.Add("Ietitnaro");
            listNameTwilek.Add("Oosritlace");

            //Female Twilek names
            listNameTwilek.Add("Ipastabu");
            listNameTwilek.Add("Esagtupi");
            listNameTwilek.Add("Aawummedo");
            listNameTwilek.Add("Oeyodsomo");
            listNameTwilek.Add("Iopor'niwul");
            listNameTwilek.Add("Ianer'bine");
            listNameTwilek.Add("Ojippifof");
            listNameTwilek.Add("Ubomvetah");
            listNameTwilek.Add("Cumbira");
            listNameTwilek.Add("Azuzcoda");
            listNameTwilek.Add("Ocobhemon");
            listNameTwilek.Add("Iatudlove");
            listNameTwilek.Add("Uhit'hiwiy");
            listNameTwilek.Add("Augip'rutir");
            listNameTwilek.Add("Obitpikum");
            listNameTwilek.Add("Omiwlacri");
            listNameTwilek.Add("Alumhakem");
            listNameTwilek.Add("Ifulcoje");
            listNameTwilek.Add("Uayuwbome");
            listNameTwilek.Add("Yarwafug");

            return listNameTwilek;
        }

        /// <summary>
        /// This Getter method returns a Twilek name depending on the gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns> string name </returns>
        public string getListNameTwilek(string gender)
        {
            FillListNameTwilek();
            string name;
            if (gender == "M")
            {
                int listIndex = rand.Next(0, 20);
                name = listNameTwilek.ElementAt(listIndex);
            }
            else
            {
                int listIndex = rand.Next(21, 40);
                name = listNameTwilek.ElementAt(listIndex);
            }
            return name;
        }



        /// <summary>
        /// This method adds Cathar names in the List<string> listNameCathar
        /// </summary>
        /// <returns> List<string> listNameCathar </returns>
        private List<string> FillListNameCathar()
        {
            //Male Cathar names
            listNameCathar.Add("Cronu Jhido");
            listNameCathar.Add("Musu Tamol");
            listNameCathar.Add("Cido Korgor");
            listNameCathar.Add("Criso Lhudul");
            listNameCathar.Add("Harby Josa");
            listNameCathar.Add("Ixihr Mun");
            listNameCathar.Add("Si Nhi");
            listNameCathar.Add("Ty Sit");
            listNameCathar.Add("Ric Kuk");
            listNameCathar.Add("Nurr No");
            listNameCathar.Add("Crundi Kirgon");
            listNameCathar.Add("Horam Tudir");
            listNameCathar.Add("Tirbo Mhoshuk");
            listNameCathar.Add("Suda Torgor");
            listNameCathar.Add("Ruso Phalon");
            listNameCathar.Add("Usi Phu");
            listNameCathar.Add("Ixi Rul");
            listNameCathar.Add("Akhun La");
            listNameCathar.Add("Asy So");
            listNameCathar.Add("Isam Lhu");

            //Female Cathar names
            listNameCathar.Add("Jalvyn Khamu");
            listNameCathar.Add("Mimoz Pozun");
            listNameCathar.Add("Churoxi Tado");
            listNameCathar.Add("Calyr Runam");
            listNameCathar.Add("Manihr Lusal");
            listNameCathar.Add("Choryn Mar");
            listNameCathar.Add("Cuwusha Pot");
            listNameCathar.Add("Monish Ko");
            listNameCathar.Add("Sothiza Mu");
            listNameCathar.Add("Jusuhi Lum");
            listNameCathar.Add("Covazy Lurgo");
            listNameCathar.Add("Nirisa Jazik");
            listNameCathar.Add("Ralvohy Sashun");
            listNameCathar.Add("Rovyr Nhosu");
            listNameCathar.Add("Mimuna Sorgik");
            listNameCathar.Add("Daliny Jo");
            listNameCathar.Add("Naryz Mhag");
            listNameCathar.Add("Sulvisy Lus");
            listNameCathar.Add("Siluxa Ril");
            listNameCathar.Add("Sovos Par");

            return listNameCathar;
        }

        /// <summary>
        /// This Getter method returns a Cathar name depending on the gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns> string name </returns>
        public string getListNameCathar(string gender)
        {
            FillListNameCathar();
            string name;
            if (gender == "M")
            {
                int listIndex = rand.Next(0, 20);
                name = listNameCathar.ElementAt(listIndex);
            }
            else
            {
                int listIndex = rand.Next(21, 40);
                name = listNameCathar.ElementAt(listIndex);
            }
            return name;
        }



        /// <summary>
        /// This method adds Human names in the List<string> listNameHuman
        /// </summary>
        /// <returns> List<string> listNameHuman </returns>
        private List<string> FillListNameHum()
        {
            //Male Human names
            listNameHuman.Add("Jetraf Hyndbal");
            listNameHuman.Add("Khatann Freeappl");
            listNameHuman.Add("Remalex Sarsib");
            listNameHuman.Add("Jespeyt Smaher");
            listNameHuman.Add("Alaade Edgegedn");
            listNameHuman.Add("Jamagar Sevhum");
            listNameHuman.Add("Dillash Whijohn");
            listNameHuman.Add("Logakyl Searud");
            listNameHuman.Add("Mavandy Oxefent");
            listNameHuman.Add("Jonabarr Braedd");
            listNameHuman.Add("Trolond Stacri");
            listNameHuman.Add("Nasgid Denlcrib");
            listNameHuman.Add("Antoosc Spibond");
            listNameHuman.Add("Omartodd Daviyar");
            listNameHuman.Add("Philjea Meacruff");
            listNameHuman.Add("Guicurt Angmabr");
            listNameHuman.Add("Jakelev Fulpix");
            listNameHuman.Add("Andrbra Druisa");
            listNameHuman.Add("Irvitoby Colcoz");
            listNameHuman.Add("Markev Hurpic");

            //Female Human names
            listNameHuman.Add("Brekour Beckmake");
            listNameHuman.Add("Fioale Dauwal");
            listNameHuman.Add("Jayvivi Domefair");
            listNameHuman.Add("Jacalex Coasher");
            listNameHuman.Add("Briyvon Ralpil");
            listNameHuman.Add("Jeweesth Cockpet");
            listNameHuman.Add("Keylnor Rickrail");
            listNameHuman.Add("Makjos Sadpop");
            listNameHuman.Add("Taneric Chancha");
            listNameHuman.Add("Fabfra Passta");
            listNameHuman.Add("Joreliz Hallevat");
            listNameHuman.Add("Lauanne Talbpay");
            listNameHuman.Add("Ciemar Whilang");
            listNameHuman.Add("Jewpris Rickrou");
            listNameHuman.Add("Heatjayd Dalebee");
            listNameHuman.Add("Leahkas Holldurn");
            listNameHuman.Add("Daryas Bealsirm");
            listNameHuman.Add("Valana Cruhab");
            listNameHuman.Add("Lyndali Turrawl");
            listNameHuman.Add("Julizoe Decktrap");

            return listNameHuman;
        }

        /// <summary>
        /// This Getter method returns a Human name depending on the gender
        /// </summary>
        /// <param name="gender"></param>
        /// <returns> string name </returns>
        public string getListNameHum(string gender)
        {
            FillListNameHum();
            string name;
            if (gender == "M")
            {
                int listIndex = rand.Next(0, 20);
                name = listNameHuman.ElementAt(listIndex);
            }
            else
            {
                int listIndex = rand.Next(21, 40);
                name = listNameHuman.ElementAt(listIndex);
            }
            return name;
        }
    }
}
