using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TriathlonWPF
{
    internal class TeamDaten
    {
        public string _id;
        public string _teamName;
        public float _schwimmZeit;
        public float _radZeit;
        public float _laufZeit;
        public float _gesamtZeit;
        public int _platz;


        public TeamDaten()
        {

        }
        public TeamDaten(string id, string teamName,int platz, float schwimmZeit, float radZeit, float laufZeit, float gesamtZeit)
        {
            _id= id;
            _teamName= teamName;
            _platz= platz; 
            _schwimmZeit= schwimmZeit;
            _radZeit= radZeit;  
            _laufZeit= laufZeit;
            _gesamtZeit= gesamtZeit;
        }



        public string TeamName
        {
            get { return _teamName; }
            set { this._teamName = value; }
        }
        public int Platz
        {
            get { return _platz; }
            set { this._platz = value; }
        }
      public float GesamtZeit
        {
            get { return _gesamtZeit; }
            set { _gesamtZeit = value; }
        }

        public string ID
        {
            get { return _id; }
            set { this._id = value; }
        }

        public List<TeamDaten> SortByTitleUsingLinq(List<TeamDaten> originalList)
        {
            return originalList.OrderBy(x => x._platz).ToList();
        }
    }
}