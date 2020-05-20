using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrabajoNota1{
    class Main {
        public Cliente cliente = new Cliente();
        public Libro libro = new Libro();
        public Pedido pedido = new Pedido();
        public void RegistrarCliente() {
            cliente.nombre = "";
            cliente.rut = "";
            cliente.direccion = "";
            cliente.nombre = "";
        }
        public void RegistrarLibro(){
            libro.ID = 0;
            libro.titulo = "";
            libro.cantidad = 0;
        }
        public void AgregarLibro(){
            libro.ID = 0;
            libro.titulo = "";
            int sumarLibros = 0;
            libro.cantidad =+ sumarLibros;
        }
        public void AgregarPedido(){
            pedido.rut = "";
            pedido.id = 0;
            pedido.fechaS = "";
            pedido.fechaE = "";
            libro.cantidad =+ -1;
        }
    }
}