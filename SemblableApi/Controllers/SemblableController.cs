using SemblableApi.Models;
using SemblableDataManager.Library.DataAccess;
using SemblableDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Tracing;
using System.Web.Mvc;

namespace SemblableApi.Controllers
{
    [System.Web.Http.RoutePrefix("api/Semblable")]
    public class SemblableController : ApiController
    {
        //public object SemblableData { get; private set; }

        /// <summary>
        /// A appeller pour recevoir la liste de tout les semblables en BDD
        /// </summary>
        /// <returns> la liste de tout les semblables en BDD</returns>
        // GET: api/Semblable/5


        public List<SemblableModel> GetById(int id)
        {
            HttpConfiguration ttt = new HttpConfiguration();
            string t = "GetAnnulationDeDegat";
            ttt.Services.GetTraceWriter().Info(Request, "SemblableController", "GetAnnulationDeDegat");

            SemblableData data = new SemblableData();
            return data.GetSemblableById(id);
             
        }

         //GET: api/Semblable
        public string Get()
        {
            int x = 1;
            Semblable Gabrielle = new Semblable("Gabrielle", AgeSemblable.Archaique, 13, Armement.Melee, 4, 0, 0);
            Semblable Astra = new Semblable("Astra", AgeSemblable.NouveauxNe, 13, Armement.Melee, 4, 4, 4);
            List<Semblable> Gab = new List<Semblable>();
            Gab.Add(Gabrielle);
            List<Semblable> Opel = new List<Semblable>();
            Opel.Add(Astra);
            Combat fight = new Combat(Gab, Opel);
            fight.faireXfois(x);

            return Gabrielle.log;
        }

        // POST: api/Semblable
        public void Post([FromBody]Semblable value)
        {
        }

        // PUT: api/Semblable/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Semblable/5
        public void Delete(int id)
        {
        }
    }
}
