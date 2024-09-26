using MiAppCrud.Services;
using MiAppCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiAppCrud.Controllers
{
    public class ProveedorController
    {
        private static List<Proveedor> proveedores = new List<Proveedor>();  // Simulación de una base de datos en memoria

        // Método para agregar o actualizar un proveedor
        public void AddOrUpdateProveedor(Proveedor proveedor)
        {
            var existingProveedor = proveedores.Find(p => p.Id == proveedor.Id);

            if (existingProveedor != null)
            {
                // Actualizamos el proveedor existente
                existingProveedor.Nombre = proveedor.Nombre;
                existingProveedor.Telefono = proveedor.Telefono;
            }
            else
            {
                // Asignamos un ID único si es un nuevo proveedor
                proveedor.Id = proveedores.Count + 1;
                proveedores.Add(proveedor);  // Agregamos el nuevo proveedor
            }
        }

        // Método para obtener todos los proveedores
        public List<Proveedor> GetAllProveedores()
        {
            return proveedores;
        }
    }

}
