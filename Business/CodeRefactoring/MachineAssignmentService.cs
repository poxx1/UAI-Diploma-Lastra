using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DataAccess;
using Models;

namespace Business.CodeRefactoring
{
    public class MachineAssignmentService
    {
        UserService userService = new UserService();
        MachineRepositoryV2 machineRepository = new MachineRepositoryV2();
        UserRepository userRepository = new UserRepository();

        public void AssingMachineToEmployee(Machines machine)
        {
            machine.Id_User = CalculateAndGetRepairerUserID();

            machineRepository.AssingMachineToEmployee(machine);
            machineRepository.ApproveMachine(machine);

            MessageBox.Show($"La maquina se le asigno al empleado : {userRepository.GetAll().Where(x => x.Id == machine.Id_User).ToList().First().UserName}");
        }
        private int CalculateAndGetRepairerUserID()
        {
            Dictionary<int, int> DictUserID_HoursAssigned = MapUserToReapairHours(sortListRepairUserByID(), ListMachinesToRepair());
            return (from userID in DictUserID_HoursAssigned orderby userID.Value ascending select userID).First().Key;
        }
        private Dictionary<int, int> MapUserToReapairHours(List<User> usuariosReparadores, List<User_MachineModel> listMachinesToRepair)
        {
            int contadorId = 0;
            int horasTotales = 0;
            int iteraciones = 0; //Valdria usar I?

            Dictionary<int, int> dictUserToRepairHours = new Dictionary<int, int>();

            foreach (User user in usuariosReparadores)
            {
                //if (user.Id != 55)
                //{
                foreach (User_MachineModel m in listMachinesToRepair)
                {
                    if (iteraciones == 0)
                    {
                        horasTotales += m.Time;
                        contadorId = user.Id;
                        iteraciones++;
                        continue;
                    }
                    if (iteraciones <= machineRepository.listMachinesToRepair().Count - 1)
                    {
                        if (contadorId == m.Id_user)
                        {
                            horasTotales += m.Time;
                        }
                        iteraciones++;
                    }
                    else
                    {
                        contadorId = user.Id;
                        horasTotales = 0;
                        iteraciones = 1;
                    }
                }
                dictUserToRepairHours.Add(contadorId, horasTotales);
                //}
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
        private List<User> sortListRepairUserByID()
        {
            List<User> listRepairUsers = ListRepairUsers();
            return (List<User>)listRepairUsers.OrderByDescending(x => x.Id);
        }
        private List<User_MachineModel> ListMachinesToRepair()
        {
            return machineRepository.listMachinesToRepair();
        }
    }
}
