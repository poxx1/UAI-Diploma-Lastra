using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess;
using Models;

namespace Business
{
    public class MachinesService
    {
        public List<Machines> GetAll()
        {
            MachineRepository mr = new MachineRepository();
            return mr.listMachines();
        }
        public List<ColorModel> GetAllColors()
        {
            MachineRepository mr = new MachineRepository();
            List<ColorModel> colors = new List<ColorModel>();
            return colors = mr.listColors();
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

        public void AssingToEmployee(Machines machine)
        {
            MachineRepository mr = new MachineRepository();

            User u = new User(); //Pero los usuarios
            UserService us = new UserService();

            #region Algoritmo re Magico
            //1. Recorro la lista de usuarios.
            List<User> listaDeUsuariosReparadores = new List<User>();
            List<User_MachineModel> listadeMachines = new List<User_MachineModel>();
            listadeMachines = mr.listMachinesToRepair();

            foreach (User user in us.GetAll())
            {
                if (user.Tipo == 1)
                {
                    listaDeUsuariosReparadores.Add(user);
                }
            }

            //2. La ordeno
            listaDeUsuariosReparadores.OrderByDescending(x => x.Id);

            //3. Agarro a uno por uno
            int contadorId = 0;
            int horasTotales = 0;

            List<User> listaIDs = new List<User>();

            Dictionary<int, int> mapUsers = new Dictionary<int, int>();

            int cantidadDeMaquinas = listadeMachines.Count;
            int repeticiones = 0;

            foreach (User user in listaDeUsuariosReparadores)
            {
                if (user.Id != 55)
                {

                    foreach (User_MachineModel m in listadeMachines)
                    {
                        if (repeticiones == 0)
                        {
                            horasTotales += m.Time;
                            contadorId = user.Id;
                            repeticiones++;
                            continue;
                        }
                        if (repeticiones <= cantidadDeMaquinas-1)
                        {
                            if (contadorId == m.Id_user)
                            {
                                horasTotales += m.Time;
                            }
                            repeticiones++;
                        }
                        else
                        {
                            //mapUsers.Add(contadorId, horasTotales);
                            contadorId = user.Id;
                            horasTotales = 0;
                            repeticiones = 1;
                        }

                    }

                    mapUsers.Add(contadorId, horasTotales);
                }//Se supone que esta magia deberia funcionar
            }

                //4. Ordeno para agarrar al que menos horas tiene
                var dicSorteado = from entry in mapUsers orderby entry.Value ascending select entry;
            
            //5. Agarro al primero
            var elegido = dicSorteado.First();


            machine.Id_User = elegido.Key;
            //6. Le asigno la maquina
            mr.Assing(machine);

            mr.Approval(machine);
            #endregion

            UserRepository userRepository = new UserRepository();
            u = userRepository.GetAll().Where(x => x.Id == machine.Id_User).ToList().First();

            MessageBox.Show($"La maquina se le asigno al empleado : {u.Name}");

        }

        public static List<User_MachineModel> ListMachinesToRepair()
        {
            MachineRepository mr = new MachineRepository();
            return mr.listMachinesToRepair();
        }
    }
}
