using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doosan.DAL;
using Doosan.Model;
using Moq;

namespace Doosan.Monitoring.Test
{
    public class EquipmentTestFixture
    {
        private readonly EquipmentRepository _equipmentRepository;

        public EquipmentTestFixture()
        {
            _equipmentRepository = new EquipmentRepository("housing");
        }

        public void Test001()
        {
            var list = _equipmentRepository.Equipment2();

            foreach (var item in list)
            {
                Console.WriteLine(item.GoodsCode);
            }
        }

        public void EquipmentsTest()
        {
            IList<Equipment> getAdminBoardListResult = new List<Equipment>
            {
                new Equipment{ GoodsCode = "1" },
                new Equipment{ GoodsCode = "2" }
            };

            Mock<IEquipmentRepository> mock = new Mock<IEquipmentRepository>();
            mock.Setup(m => m.Equipments()).Returns(getAdminBoardListResult);
            foreach (var item in mock.Object.Equipments())
            {
                Console.WriteLine(item.GoodsCode);
            }
        }
    }
}
