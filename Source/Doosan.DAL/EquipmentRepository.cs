using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Doosan.Model;

namespace Doosan.DAL
{
    public class EquipmentRepository : DataConnection
    {
        public EquipmentRepository(string connectionString)
            : base(connectionString)
        {
        }

        public IList<Equipment> Equipments()
        {
            using (Connection)
            {
                return Connection.Query<Equipment>(sql: "dbo.GetAdminBoardList", commandType: CommandType.StoredProcedure) as IList<Equipment>;   
            }      
        }

        public Equipment Equipment(int seq)
        {
            using (Connection)
            {
                var param = new DynamicParameters();

                param.Add("@mappingBizCode", "04654");
                param.Add("@goodsCode", "");
                param.Add("@coopGoodsCode", "");
                //param.Add("@frDate", "20151201", DbType.String, ParameterDirection.Input, 8);
                //param.Add("@goodsCode", "20161231", DbType.String, ParameterDirection.Input, 8);
                //param.Add("@coopGoodsCode", "15000081", DbType.String, ParameterDirection.Input, 8);

                return Connection.Query<Equipment>("dbo.usp_Housing_Room_Mapping_List", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
            }
        }

        public IList<Equipment2> Equipment2()
        {
            IList<Equipment2> list = new List<Equipment2>();
            using (Connection)
            {
                var param = new DynamicParameters();

                param.Add("@mappingBizCode", "04654");
                param.Add("@goodsCode", "");
                param.Add("@coopGoodsCode", "");
                //param.Add("@frDate", "20151201", DbType.String, ParameterDirection.Input, 8);
                //param.Add("@goodsCode", "20161231", DbType.String, ParameterDirection.Input, 8);
                //param.Add("@coopGoodsCode", "15000081", DbType.String, ParameterDirection.Input, 8);

                Console.WriteLine(Connection.State);
                list = Connection.Query<Equipment2>("dbo.usp_Housing_Room_Mapping_List", param, commandType: CommandType.StoredProcedure) as IList<Equipment2> ?? new List<Equipment2>();
            }

            Console.WriteLine(Connection.State);

            return list;
        }
    }
}
