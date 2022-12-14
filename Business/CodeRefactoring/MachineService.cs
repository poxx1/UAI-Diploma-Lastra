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
            MachineRepository mr = new MachineRepository();
            return mr.listMachines();
        }
        public List<ColorModel> GetAllColors()
        {
            MachineRepository mr = new MachineRepository();
            return mr.listColors();
        }
        public bool CheckIfExist(Machines machine)
        {
            MachineRepository mr = new MachineRepository();
            return mr.CheckIfExist(machine);
            //return mr.SaveMachine(machine); WTF
        }
        public void Save(Machines machine)
        {
            MachineRepository mr = new MachineRepository();
            mr.SaveMachine(machine);
            //return mr.SaveMachine(machine); WTF
        }
        public void Review(Machines machine)
        {
            MachineRepository mr = new MachineRepository();
            mr.Review(machine);
        }
        public void Approval(Machines machine)
        {
            MachineRepository mr = new MachineRepository();
            mr.Approval(machine);
        }
    }
}
