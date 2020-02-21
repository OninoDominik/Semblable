using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SemblableApi.Models
{
    public class Combat
    {
        /// <summary>
        /// constructeur
        /// </summary>
        /// <param name="Equipe1"></param>
        /// <param name="Equipe2"></param>
        public Combat(IList<Semblable> Equipe1, IList<Semblable> Equipe2)
        {
            EquipeA = Equipe1;
            EquipeB = Equipe2;
            A = EquipeA.First();
            B = EquipeB.First();


    }

        /// <summary>
        /// Methode qui trie par ordre d'initiative
        /// </summary>
        /// <param name="OrdreInitiative"></param>
        public List<Semblable> OrdoneListeInitiative()
        {
            OrdreInitiative.Sort(Semblable.CompareTo);
            return OrdreInitiative; 
        }

        public void CopierOrdreInitiative()
        {
            OrdreInitiativePermanent = OrdoneListeInitiative();
        }

        Random rand = new Random();
        public IList<Semblable> EquipeA;
        public IList<Semblable> EquipeB;
        public Semblable A ;
        public Semblable B ;
        public List<Semblable> OrdreInitiative = new List<Semblable>();
        public List<Semblable> OrdreInitiativePermanent = new List<Semblable>();


        public ResultatShifumi ComparerShifumi(Jet A, Jet B)
        {
            switch (A)
            {
                case Jet.Pierre:
                    if (B == Jet.Pierre)
                    { return ResultatShifumi.Egalite; }
                    else if (B == Jet.Feuille || B == Jet.Bombe)
                    { return ResultatShifumi.Defaite; }
                    else
                    { return ResultatShifumi.Victoire; }
                    break;
                case Jet.Ciseaux:
                    if (B == Jet.Ciseaux)
                    { return ResultatShifumi.Egalite; }
                    else if (B == Jet.Pierre)
                    { return ResultatShifumi.Defaite; }
                    else
                    { return ResultatShifumi.Victoire; }
                    break;
                case Jet.Feuille:
                    if (B == Jet.Feuille)
                    { return ResultatShifumi.Egalite; }
                    else if (B == Jet.Ciseaux || B == Jet.Bombe)
                    { return ResultatShifumi.Defaite; }
                    else
                    { return ResultatShifumi.Victoire; }
                    break;
                case Jet.Bombe:
                    if (B == Jet.Bombe)
                    { return ResultatShifumi.Egalite; }
                    else if (B == Jet.Ciseaux )
                    { return ResultatShifumi.Defaite; }
                    else
                    { return ResultatShifumi.Victoire; }
                    break;
                 default:
                    return ResultatShifumi.Egalite;
                    break;
            }
        }
        public void InfligeDegat(Semblable A, Semblable B) 
        {
            int ValeurDegat = (A.GetValeurDeDegat() - B.GetAnnulationDeDegat()) > 0 ? (A.GetValeurDeDegat() - B.GetAnnulationDeDegat()) : 0;
            B.PointDeDegatActuel += ValeurDegat;
        }

        public void Attaque(Semblable A, Semblable B)
        {
            
            Jet ChoixDeA;
            Jet ChoixDeB;
            if (A.CalculePossibiliteJetAttaque().Count() == 3)
            {
                ChoixDeA = A.CalculePossibiliteJetAttaque()[rand.Next(0, 3)];
            }
            else
            {
                ChoixDeA = A.CalculePossibiliteJetAttaque()[rand.Next(0, 4)];
            }

            if (B.CalculePossibiliteJetDefense().Count() == 3)
            {
                ChoixDeB = A.CalculePossibiliteJetDefense()[rand.Next(0, 3)];
            }
            else
            {
                ChoixDeB = A.CalculePossibiliteJetDefense()[rand.Next(0, 4)];
            }

            if (ResultatShifumi.Victoire == ComparerShifumi(ChoixDeA,ChoixDeB) || (ResultatShifumi.Egalite == ComparerShifumi(ChoixDeA, ChoixDeB) && (A.Physique > B.Physique)))
            {
                InfligeDegat(A, B);
            }
        }
        public void CalculOrdreinitiative()
        {
            foreach (Semblable Joueur in EquipeA)
            {
                OrdreInitiative.Add(Joueur);
            }
            foreach (Semblable Joueur in EquipeB)
            {
                OrdreInitiative.Add(Joueur);
            }
            OrdoneListeInitiative();
        }
        public double faireXfois(int X)
         {
            double PourcentageVictoireDeA = 0;
            for(int i =0; i< X; i++)
            {
                if (Commencer() == A)
                {
                    PourcentageVictoireDeA++;
                }
            }
            return PourcentageVictoireDeA / X * 100;
        }
        public Semblable Commencer()
        {
            Semblable A = EquipeA.First();
            Semblable B = EquipeB.First();
            A.PointDeDegatActuel = 0;
            B.PointDeDegatActuel = 0;
            A.ReserveDeSang = 13;
            B.ReserveDeSang = 13;


            while (A.PointDeDegatActuel<=A.PdVMax && B.PointDeDegatActuel <= B.PdVMax)
            {
                CalculOrdreinitiative();
                while (OrdreInitiative.Count>1)
                {
                    Semblable SemblableActif = OrdreInitiative.First();
                    Agir(A, B, SemblableActif);
                    OrdreInitiative.Remove(SemblableActif);
                }
               
            }
            if (A.PointDeDegatActuel <= A.PdVMax)
            {
                Console.WriteLine(A.Nom + " à survecu");
                return A;
            }
            if (B.PointDeDegatActuel <= B.PdVMax)
            {
                Console.WriteLine(B.Nom + " à survecu");
                return B;
            }
            Semblable Erreur = new Semblable("Erreur", AgeSemblable.Archaique, 1, Armement.CorpsaCorps, 4, 4, 4);
            Console.WriteLine(B.Nom + " à survecu");
            return Erreur;

        }

        public void Agir(Semblable A, Semblable B, Semblable SemblableActif)
        {
            if (SemblableActif == A)
            {
                Action(A, B);
            }
            else if (SemblableActif == B)
            {
                Action(B, A);
            }
        }

        public void Action(Semblable A,Semblable B)
        {
            if (A.Celerite >= 4 && A.IsDepenceDeSangPossible())
            {
                A.DepenserPointDeSang();
                Attaque(A, B);
            }
            Attaque(A, B);
            while (A.IsDepenceDeSangPossible())
            {
                A.SeSoigner();
            }
            A.DepencePointdeSangduTour = 0;
         }

        //public void LancerCombat ()
        //{
        //    OrdreInitiative.First()
        //}

    }
}