using CapaEntidad;
using CapaDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Empleado
    {
        private CD_Empleado objcd_empleado = new CD_Empleado();

        public List<CE_Empleado> Listar()
        {
            return objcd_empleado.Listar();
        }

        public int Registrar(CE_Empleado obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del empleado";
            }

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del empleado";
            }

            if (obj.Clave == "")
            {
                Mensaje += "Es necesario la clave del empleado";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd_empleado.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(CE_Empleado obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el Documento del empleado";
            }

            if (obj.Nombre == "")
            {
                Mensaje += "Es necesario el nombre del empleado";
            }

            if (obj.Clave == "")
            {
                Mensaje += "Es necesario la clave del empleado";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd_empleado.Editar(obj, out Mensaje);
            }
        }

        public bool Eliminar(CE_Empleado obj, out string Mensaje)
        {
            return objcd_empleado.Eliminar(obj, out Mensaje);
        }
    }
}
