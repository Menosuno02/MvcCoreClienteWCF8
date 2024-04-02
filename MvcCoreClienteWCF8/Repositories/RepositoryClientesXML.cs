﻿using MvcCoreClienteWCF8.Helpers;
using MvcCoreClienteWCF8.Models;
using System.Xml.Linq;

namespace MvcCoreClienteWCF8.Repositories
{
    public class RepositoryClientesXML
    {
        private HelperPathProvider helper;

        public RepositoryClientesXML(HelperPathProvider helper)
        {
            this.helper = helper;
        }

        public List<Cliente> GetClientes()
        {
            string path = this.helper.MapPath("ClientesID.xml",
                Folders.Documents);
            XDocument document = XDocument.Load(path);
            // from datos in document.Descendants("TAG")
            // where o select datos;
            var consulta = from datos in document.Descendants("CLIENTE")
                           select datos;
            // Extraemos los elementos XElement de la consulta
            List<Cliente> clientesList = new List<Cliente>();
            foreach (XElement tag in consulta)
            {
                Cliente cliente = new Cliente();
                // Podemos recuperar tanto atributos como datos de etiqueta
                // tag.Attributes("ATTRIBUTE").Value
                // tag.Element("ELEMENT").Value
                cliente.Nombre = tag.Element("NOMBRE").Value;
                cliente.Email = tag.Element("EMAIL").Value;
                cliente.Direccion = tag.Element("DIRECCION").Value;
                cliente.ImagenCliente = tag.Element("IMAGENCLIENTE").Value;
                cliente.IdCliente =
                    int.Parse(tag.Element("IDCLIENTE").Value);
                clientesList.Add(cliente);
            }
            return clientesList;
        }
    }
}
