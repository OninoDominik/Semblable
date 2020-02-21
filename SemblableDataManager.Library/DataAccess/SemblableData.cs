using SemblableDataManager.Library.Internal.DataAccess;
using SemblableDataManager.Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemblableDataManager.Library.DataAccess
{
    public class SemblableData
    {
        public List<SemblableModel> GetSemblableById(int Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            var p = new { Id = Id };

           var output = sql.LoadData<SemblableModel,dynamic>("dbo.spSemblableLookUp", p, "DefaultConnection");

           return output;
        }
    }
}
