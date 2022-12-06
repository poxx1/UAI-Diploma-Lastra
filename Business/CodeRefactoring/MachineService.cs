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
        User user = new User();
        UserService userService = new UserService();
        MachineRepository machineRepository = new MachineRepository();
        UserRepository userRepository = new UserRepository();
        public void AssingMachineToEmployee(Machines machine)
        {        
            machineRepository.Assing(machine);
            machineRepository.Approval(machine);

            MessageBox.Show($"La maquina se le asigno al empleado : {userRepository.GetAll().Where(x => x.Id == machine.Id_User).ToList().First().UserName}");
        }
        private int GetRepairerUserID()
        {
            Dictionary<int, int> DictUserID_HoursAssigned = MapUserToReapairHours(ListUserSortedByID(),new List<User_MachineModel>());

            //Ordeno para agarrar al que menos horas tiene
            return (from userID in DictUserID_HoursAssigned orderby userID.Value ascending select userID).First().Key;
        }
        private Dictionary<int, int> MapUserToReapairHours(List<User> usuariosReparadores,List<User_MachineModel> maquinas)
        {
            int contadorId = 0;
            int horasTotales = 0;
            int repeticiones = 0;

            Dictionary<int, int> dictUserToRepairHours = new Dictionary<int, int>();

            foreach (User user in usuariosReparadores)
            {
                if (user.Id != 55)
                {

                    foreach (User_MachineModel m in maquinas)
                    {
                        if (repeticiones == 0)
                        {
                            horasTotales += m.Time;
                            contadorId = user.Id;
                            repeticiones++;
                            continue;
                        }
                        if (repeticiones <= machineRepository.listMachinesToRepair().Count - 1)
                        {
                            if (contadorId == m.Id_user)
                            {
                                horasTotales += m.Time;
                            }
                            repeticiones++;
                        }
                        else
                        {
                            contadorId = user.Id;
                            horasTotales = 0;
                            repeticiones = 1;
                        }
                    }
                    dictUserToRepairHours.Add(contadorId, horasTotales);
                }
            }
            return dictUserToRepairHours;
        }
        private List<User> ListRepairUsers()
        {
            List<User> listRepairUsers = new List<User>();

            foreach (User user in userService.GetAll())
            {
                if (user.Tipo == 1)
                {
                    listRepairUsers.Add(user);
                }
            }
            return listRepairUsers;
        }
        private List<User> ListUserSortedByID()
        {
            List<User> listRepairUsers = ListRepairUsers();
            return (List<User>)listRepairUsers.OrderByDescending(x => x.Id);
        }
    }
}
