using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class CN_Proveedor
    {
        private CD_Proveedor objcd = new CD_Proveedor();

        public List<CE_Proveedor> Listar()
        {
            return objcd.Listar();
        }
        public int Registrar(CE_Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el RUC del Proveedor";
            }

            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesario la razón social del Proveedor";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo del del Proveedor";
            }

            if (obj.Telefono == "")
            {
                Mensaje += "Es necesario el telefono del del Proveedor";
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

        public bool Editar(CE_Proveedor obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (obj.Documento == "")
            {
                Mensaje += "Es necesario el RUC del Proveedor";
            }

            if (obj.RazonSocial == "")
            {
                Mensaje += "Es necesario la razon social del Proveedor";
            }

            if (obj.Correo == "")
            {
                Mensaje += "Es necesario el correo del del Proveedor";
            }

            if (obj.Telefono == "")
            {
                Mensaje += "Es necesario el telefono del del Proveedor";
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


        public bool Eliminar(CE_Proveedor obj, out string Mensaje)
        {
            return objcd.Eliminar(obj, out Mensaje);

        }
    }
}
