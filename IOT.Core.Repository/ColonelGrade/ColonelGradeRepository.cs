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

        public Model.ColonelGrade ft2(int id)
        {
            string sql = $"select  * from ColonelGrade where CGId={id} ";
            return DapperHelper.GetList<IOT.Core.Model.ColonelGrade>(sql).First();
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
            IOT.Core.Model.ColonelGrade ls = DapperHelper.GetList<IOT.Core.Model.ColonelGrade>($"select * from ColonelGrade  where CGId  ={Cid}").FirstOrDefault();
            if (ls.GradeStatus == 0)
            {
                ls.GradeStatus = 1;
            }
            else
            {
                ls.GradeStatus = 0;
            }
            string sql = $"update ColonelGrade set GradeStatus={ls.GradeStatus} where CGId  ={Cid} ";
            return DapperHelper.Execute(sql);
        }
    }
}
