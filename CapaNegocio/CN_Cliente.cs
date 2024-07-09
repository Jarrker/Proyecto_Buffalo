using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Cliente
    {
        private CD_Cliente objcd = new CD_Cliente();

        public List<CE_Cliente> Listar()
        {
            return objcd.Listar();

        }
        public int Registrar(CE_Cliente obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (obj.DNI == "")
            {
                Mensaje += "Es necesario el DNI del cliente";
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre del cliente";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo del del cliente";
            }

            if (obj.Telefono == "")
            {
                Mensaje += "Es necesario el telefono del del cliente";
            }

            if (Mensaje != string.Empty)
            {
                return 0;
            }
            else
            {
                return objcd.Registrar(obj, out Mensaje);
            }
        }

        public bool Editar(CE_Cliente obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.DNI == "")
            {
                Mensaje += "Es necesario el Documento del cliente";
            }

            if (obj.NombreCompleto == "")
            {
                Mensaje += "Es necesario el nombre del cliente";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo del del cliente";
            }

            if (obj.Telefono == "")
            {
                Mensaje += "Es necesario el telefono del del cliente";
            }

            if (Mensaje != string.Empty)
            {
                return false;
            }
            else
            {
                return objcd.Editar(obj, out Mensaje);
            }
        }


        public bool Eliminar(CE_Cliente obj, out string Mensaje)
        {
            return objcd.Eliminar(obj, out Mensaje);
        }
    }
}
