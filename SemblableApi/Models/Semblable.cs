
using SemblableApi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Tracing;

namespace SemblableApi.Models
{
    /// <summary>
    /// Classe de gestion d'un semblable
    /// </summary>
    public class Semblable : ISemblable, IComparable<Semblable>
    {

        /// <summary>
        /// Constructeur de Semblable
        /// </summary>
        /// <param name="Age"></param>
        /// <param name="Physique"></param>
        /// <param name="Arme"></param>
        /// <param name="Puissance"></param>
        /// <param name="Celerite"></param>
        /// <param name="Endurance"></param>
        public Semblable(string Nom, AgeSemblable Age, int Physique, Armement Arme, int Puissance, int Celerite, int Endurance)
        {
            this.Nom = Nom;
            this._Physique = Physique;
            this._Age = Age;
            this._Arme = Arme;

            this._Puissance = Puissance;
            this._Celerite = Celerite;
            this._Endurance = Endurance;

            this.PdVMax = 8 + Endurance;
        }

        public Semblable(string Nom, int AgeId, int Physique, int ArmeId, int Puissance, int Celerite, int Endurance)
        {
            this.Nom = Nom;
            this._Physique = Physique;
            this.AgeId = AgeId;
            this.ArmeId = ArmeId;

            this._Puissance = Puissance;
            this._Celerite = Celerite;
            this._Endurance = Endurance;

            this.PdVMax = 8 + Endurance;
        }


        public string log;
        /// <summary>
        /// methode pour cast l'enum en int
        /// </summary>
        [Required]
        public virtual int AgeId
        {
            get
            {
                return (int)this.Age;
            }
            set
            {
                Age = (AgeSemblable)value;
            }
        }
        /// <summary>
        /// Propriete Enumeration pour age du Semblable
        /// <see cref="AgeSemblable"/>
        /// </summary>
        [EnumDataType(typeof(AgeSemblable))]


        public AgeSemblable Age
        {

            get
            {
                return _Age;
            }

            set
            { 
              _Age = value;
            }
        }
        /// <summary>
        /// methode pour cast l'enum en int
        /// </summary>
        [Required]
        public virtual int ArmeId
        {
            get
            {
                return (int)this.Arme;
            }
            set
            {
                Arme = (Armement)value;
            }
        }
        /// <summary>
        /// Propriete Enumeration pour l'armement du Semblable
        /// <see cref="Armement"/>
        /// </summary>
        [EnumDataType(typeof(Armement))]
        public Armement Arme
        {

            get
            {
                return _Arme;
            }

            set
            {
                _Arme = value;
            }
        }
        /// <summary>
        /// Element nom
        /// </summary>
        private String _Nom = "SemblableLambda";
        /// <summary>
        /// Propriete Nom
        /// </summary>
        public string Nom
        {
            get { return _Nom; }
            set { _Nom = value; }
        }
        /// <summary>
        /// Element fait parti de l'equipe A
        /// </summary>
        private bool _EquipeA = true;
        /// <summary>
        /// Element fait parti de l'equipe A si true sinon EquipeB
        /// </summary>
        public bool EquipeA
        {
            get { return _EquipeA; }
            set { _EquipeA = value; }
        }

        /// <summary>
        /// Bolleen qui indique si le semblable est en torpeur
        /// </summary>
        public bool torpeur = false;


        /// <summary>
        /// Element Physique
        /// </summary>
        private int _Physique = 3;
        /// <summary>
        /// Propriete score de Physique
        /// </summary>
        public int Physique
        {
            get { return _Physique; }
            set { _Physique = value; }
        }

        /// <summary>
        /// Element point de vie maximum avant'a la torpeur
        /// </summary>
        private int _PdVMax = 8;
        /// <summary>
        /// Propriete point de vie maximum avant'a la torpeur
        /// </summary>
        public int PdVMax
        {
            get { return _PdVMax; }
            set { _PdVMax = value; }
        }

        /// <summary>
        /// Element points de degats actuels accumulés par le semblable si elle depase le PpVMax torpeur
        /// </summary>
        private int _PointDeDegatActuel = 0;
        /// <summary>
        /// Propriete points de degats actuels accumulés par le semblable  si elle depase le PpVMax torpeur
        /// </summary>
        public int PointDeDegatActuel
        {
            get { return _PointDeDegatActuel; }
            set { _PointDeDegatActuel = value; }
        }

        /// <summary>
        /// Element Enumeration pour age du Semblable
        /// <see cref="AgeSemblable"/>
        /// </summary>
        private AgeSemblable _Age = AgeSemblable.NouveauxNe;



        /// <summary>
        /// Element Enumeration pour l'armement du Semblable
        /// <see cref="Armement"/>
        /// </summary>
        private Armement _Arme = Armement.CorpsaCorps;



        /// <summary>
        /// Element niveau de la Discipline Puissance
        /// </summary>
        private int _Puissance = 0;
        /// <summary>
        /// Propriete niveau de la Discipline Puissance
        /// </summary>
        public int Puissance
        {
            get { return _Puissance; }
            set { _Puissance = value; }
        }

        /// <summary>
        /// Element niveau de la Discipline Celerite
        /// </summary>
        private int _Celerite = 0;
        /// <summary>
        /// Propiete niveau de la Discipline Celerite
        /// </summary>
        public int Celerite
        {
            get { return _Celerite; }
            set { _Celerite = value; }
        }

        /// <summary>
        /// Element niveau de la Discipline Endurance 
        /// </summary>
        private int _Endurance = 0;
        /// <summary>
        /// Propriete niveau de la Discipline Endurance 
        /// </summary>
        public int Endurance
        {
            get { return _Endurance; }
            set { _Endurance = value; }
        }
        /// <summary>
        /// Element Reserve de Sang Encore disponible minimum 3 pour pas gerer les frenesies
        /// </summary>
        private int _ReserveDeSang = 13;
        /// <summary>
        /// Propriete Reserve de Sang Encore disponible minimum 3 pour pas gerer les frenesies
        /// </summary>
        public int ReserveDeSang
        {
            get { return _ReserveDeSang; }
            set { _ReserveDeSang = value; }
        }

        /// <summary>
        /// Element nombre de point de sang deja depensé dans le tour par le semblable
        /// </summary>
        private int _DepencePointdeSangduTour = 0;
        /// <summary>
        /// Propriete nombre de point de sang deja depensé dans le tour par le semblable
        /// </summary>
        public int DepencePointdeSangduTour
        {
            get { return _DepencePointdeSangduTour; }
            set { _DepencePointdeSangduTour = value; }
        }

        /// <summary>
        /// methode pour savoir combien de pds un semblabe peut depenser  nn =1 , Archa=2
        /// </summary>
        /// <returns> nombre de pds max en un tour</returns>
        public int GetDepenceMaxdeSangParTour()
        {
            log += "GetDepenceMaxdeSangParTour " + this.Nom;
            if (Age == AgeSemblable.Archaique)
            {
                log += " 2 \n";
                return 2;
            }
            log += "1 \n";
            return 1;
        }

        /// <summary>
        /// nbr attaque
        /// </summary>
        /// <returns>nbr attaque / tour</returns>
        public int GetNombreAttaque()
        {
            Console.Write("GetNombreAttaque" + this.Nom);
            if (IsDepenceDeSangPossible() && Celerite >= 4)
            {
                Console.WriteLine("2");
                return 2;
            }
            Console.WriteLine("1");
            return 1;
        }
        /// <summary>
        /// fda
        /// </summary>
        /// <returns>coche en moins</returns>
        public int GetAnnulationDeDegat()
        {




            if (Endurance >= 3)
            {
                Console.WriteLine("1");
                return 1;
            }
            Console.WriteLine("0");
            return 0;
        }

        /// <summary>
        /// degats d'une attaque
        /// </summary>
        /// <returns>valeur de degats d'une attaque</returns>
        public int GetValeurDeDegat()
        {
            Console.Write("GetValeurDeDegat" + this.Nom);
            int degat = 1;
            if (Puissance >= 2)
            {
                degat += 1;
            }
            if (Puissance >= 4)
            {
                degat += 1;
            }
            if (Arme == Armement.Melee)
            {
                degat += 1;
            }
            Console.WriteLine(degat);
            return degat;
        }
        /// <summary>
        /// calcul le malus d'action suite au blessures
        /// </summary>
        /// <returns>le malus d'action suite au blessures</returns>
        public int GetMalus()
        {
            if (PointDeDegatActuel < 6 + Endurance)
            {
                return 0;
            }
            if (PointDeDegatActuel == 6 + Endurance)
            {
                if (Endurance < 2)
                {
                    return 1;
                }
                return 0;
            }
            if (PointDeDegatActuel == 7 + Endurance)
            {
                if (Endurance < 3)
                {
                    return 2;
                }
                return 0;
            }
            if (PointDeDegatActuel == 8 + Endurance)
            {
                if (Endurance < 4)
                {
                    return 3;
                }
                return 0;
            }
            return 99;
        }
        /// <summary>
        /// se soigner avec depense de pds
        /// </summary>
        public void SeSoigner()
        {
            if (IsDepenceDeSangPossible())
            {
                DepenserPointDeSang();
                PointDeDegatActuel--;
            }
        }
        /// <summary>
        /// calcul d'initiative avec un random en cas d'egalité sur els stats
        /// </summary>
        /// <returns> valeur d'initiative la plus grande commence</returns>
        public double GetValeurInitiative()
        {
            var rand = new Random();

            double ValeurInitiative = Arme == Armement.Melee ? 0.01 : 0.0;
            ValeurInitiative += Age == AgeSemblable.Archaique ? 0.1 : 0.0;
            ValeurInitiative += rand.NextDouble() * 0.01;
            ValeurInitiative += Celerite * 100 + Physique;

            return ValeurInitiative;
        }

        /// <summary>
        /// indique si le semblable peut depenser du sang
        /// </summary>
        /// <returns>bool </returns>
        public bool IsDepenceDeSangPossible()
        {
            if (GetDepenceMaxdeSangParTour() > DepencePointdeSangduTour && ReserveDeSang > 3)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// depense le sang 
        /// change les nbr de pdt sang utiliser dans le tour  
        /// diminue la reserve
        /// </summary>
        public void DepenserPointDeSang()
        {
            DepencePointdeSangduTour++;
            ReserveDeSang--;
        }

        /// <summary>
        /// Calcul list des possibilité sur un shifumi d'attaque 
        /// </summary>
        /// <returns>list des possibilité sur un shifumi attaque</returns>
        public IList<Jet> CalculePossibiliteJetAttaque()
        {
            IList<Jet> ListeAttaque = new List<Jet>();
            ListeAttaque.Add(Jet.Pierre);
            ListeAttaque.Add(Jet.Feuille);
            ListeAttaque.Add(Jet.Ciseaux);
            if (Puissance >= 3)
            {
                ListeAttaque.Add(Jet.Bombe);
            }
            return ListeAttaque;

        }
        /// <summary>
        ///  Calcul list des possibilité sur un shifumi de defence
        /// </summary>
        /// <returns>list des possibilité sur un shifumi de defence</returns>
        public IList<Jet> CalculePossibiliteJetDefense()
        {
            IList<Jet> ListeDefense = new List<Jet>();
            ListeDefense.Add(Jet.Pierre);
            ListeDefense.Add(Jet.Feuille);
            ListeDefense.Add(Jet.Ciseaux);
            if (Celerite >= 3)
            {
                ListeDefense.Add(Jet.Bombe);
            }
            return ListeDefense;

        }

        public static int CompareTo(Semblable SemblableA, Semblable SemblableB)
        {
            if (SemblableA.GetValeurInitiative() > SemblableB.GetValeurInitiative())
            {
                return -1;
            }
            return 1;
        }

        public int CompareTo(Semblable other)
        {
            if (this.GetValeurInitiative() > other.GetValeurInitiative())
            {
                return 1;
            }
            return -1;
        }
    }

}