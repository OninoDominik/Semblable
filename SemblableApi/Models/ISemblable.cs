using SemblableApi.Models;
using System.Collections.Generic;

namespace SemblableApi.Models
{
    public interface ISemblable
    {
        string Nom { get; set; }
        AgeSemblable Age { get; }
        Armement Arme { get; set; }
        int Celerite { get; set; }
        int DepencePointdeSangduTour { get; set; }
        int Endurance { get; set; }
        int PdVMax { get; set; }
        int Physique { get; set; }
        int PointDeDegatActuel { get; set; }
        int Puissance { get; set; }
        int ReserveDeSang { get; set; }

        IList<Jet> CalculePossibiliteJetAttaque();
        IList<Jet> CalculePossibiliteJetDefense();
        void DepenserPointDeSang();
        int GetAnnulationDeDegat();
        int GetDepenceMaxdeSangParTour();
        int GetMalus();
        int GetNombreAttaque();
        int GetValeurDeDegat();
        double GetValeurInitiative();
        bool IsDepenceDeSangPossible();
        void SeSoigner();
    }
}