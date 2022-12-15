using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataAccess;
using Models;

namespace Business.CodeRefactoring
{
    public class MachineService
    {
        public List<Machines> GetAll()
        {
            MachineRepositoryV2 mr = new MachineRepositoryV2();
            return mr.listMachines();
        }
        public List<ColorModel> GetAllColors()
        {
            MachineRepository mr = new MachineRepository();
            return mr.listColors();
        }
        public bool CheckIfExist(Machines machine)
        {
            MachineRepositoryV2 mr = new MachineRepositoryV2();
            return mr.CheckIfExist(machine);
        }
        public void SaveMachine(Machines machine)
        {
            MachineRepositoryV2 mr = new MachineRepositoryV2();
            mr.SaveMachine(machine);
        }
        public void ReviewMachine(Machines machine)
        {
            MachineRepositoryV2 mr = new MachineRepositoryV2();
            mr.ReviewMachine(machine);
        }
        public void ApproveMachine(Machines machine)
        {
            MachineRepositoryV2 mr = new MachineRepositoryV2();
            mr.ApproveMachine(machine);
        }
    }
}
