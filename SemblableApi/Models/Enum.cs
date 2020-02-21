using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SemblableApi.Models
{
    /// <summary>
    /// Enum des possibilites du shifumi
    /// Pierre,Feuille,Ciseaux + Bombe
    /// </summary>
    public enum Jet
    {
        /// <summary>
        /// Si le semblable choisit pierre
        /// </summary>
        Pierre,
        /// <summary>
        /// Si le semblable choisit Ciseaux
        /// </summary>
        Ciseaux,
        /// <summary>
        /// Si le semblable choisit Feuille
        /// </summary>
        Feuille,
        /// <summary>
        /// Si le semblable choisit Bombe
        /// </summary>
        Bombe
    }
    /// <summary>
    /// Enum des possibilites d'age du Semblable 
    /// NN +Archa
    /// </summary>
    public enum AgeSemblable
    {
        /// <summary>
        /// créer NN
        /// </summary>
        NouveauxNe,
        /// <summary>
        /// créer Archa
        /// </summary>
        Archaique
    }

    /// <summary>
    /// Enum des possibilites d'armement  
    /// Poing, Epée
    /// </summary>
    public enum Armement
    {
        /// <summary>
        /// CaC
        /// </summary>
        CorpsaCorps,
        /// <summary>
        /// Melee
        /// </summary>
        Melee
    }
    /// <summary>
    /// resultat d'un jet
    /// </summary>
    public enum ResultatShifumi
    {
        /// <summary>
        /// Egalité
        /// </summary>
        Egalite,
        /// <summary>
        /// Victoire de A
        /// </summary>
        Victoire,
        /// <summary>
        /// defaite de A
        /// </summary>
        Defaite
    }
}