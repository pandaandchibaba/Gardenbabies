using IOT.Core.Common;
using IOT.Core.IRepository.ColonelGrade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOT.Core.Repository.ColonelGrade
{
    public class ColonelGradeRepository : IColonelGradeRepository
    {
        public int Edit(string id)
        {
            string sql = $"delete  from ColonelGrade where CGId in({id})";

            return DapperHelper.Execute(sql);
        }

        public List<Model.ColonelGrade> GetColonels()
        {
            string sql = "select  * from ColonelGrade";
            return DapperHelper.GetList<Model.ColonelGrade>(sql);
        }

        public int Upt(Model.ColonelGrade a)
        {
            string sql = $"UPDATE ColonelGrade set CGradeName ='{a.CGradeName}',GradeExperience='{a.GradeExperience}',FirstPY='{a.FirstPY}',AwardRatio='{a.AwardRatio}',GradeStatus='{a.GradeStatus}'  where CGId ={a.CGId}";
            return DapperHelper.Execute(sql);
        }

        public int UptState(int Cid)
        {
            throw new NotImplementedException();
        }
    }
}
