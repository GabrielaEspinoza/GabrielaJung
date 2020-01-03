using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EjemploDeObserver.Interfaces;

namespace EjemploDeObserver.Clases
{
    /// <summary>
    /// Clase que se encarga de implementar la interfaz sujeto para registar un 
    /// observador, eliminar y notificar lo que ha pasado, cambio.
    /// </summary>
    public class Sujeto:ISujeto
    {
        /// <summary>
        /// Constructor de clase
        /// </summary>
        public Sujeto()
        {
            this.Observador = new List<object>();

        }
        
        /// <summary>
        /// Se encarga de contener los registros.
        /// </summary>
        private List<object> observador;

        public List<object> Observador
        {
            get { return observador; }
            set { observador = value; }
        }

        /// <summary>
        /// Método encargado de notificar al subscripto que ha sucedido
        /// un evento que requiere atención
        /// </summary>
        public void Notificar()
        {
            
            //Recorrec las observaciones notificadas
            foreach (IObservador observador in this.observador)
            {
                // Indicaciones a cada uno de los subscriptores la actualización del estado.
                observador.UpdateState(this);
            }
        }

        /// <summary>
        /// Método encargado de agregar para que el subscriptor le pueda notificar
        /// los eventos.
        /// </summary>
        /// <param name="observador"></param>
        public void RegistarObservador(IObservador observador)
        {
            // Agregar los subscriptores a la lista.
            this.Observador.Add (observador);
        }

        /// <summary>
        /// Método encargado de eliminar un observador para que no se notifique
        /// ningun evento.
        /// </summary>
        /// <param name="observador"></param>
        public void QuitarObservador(IObservador observador)
        {
            // Elimina el subscriptor de la lista del publicador.
            this.Observador.Remove (observador);
        }
    }
}
