using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Doosan.Model;

namespace Doosan.DAL
{
    public interface IEquipmentRepository
    {
        IList<Equipment> Equipments();

        Equipment Equipment(int seq);

        void Add();

        void Edid();
    }
}
