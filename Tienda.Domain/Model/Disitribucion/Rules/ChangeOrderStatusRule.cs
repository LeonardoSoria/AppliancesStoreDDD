using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Distribucion.Domain.Model.Disitribucion.Rules
{
    public class ChangeOrderStatusRule : IBusinessRule
    {
        private readonly EstadoOrdenEntrega oldStatus;
        private readonly EstadoOrdenEntrega newStatus;

        public ChangeOrderStatusRule(EstadoOrdenEntrega oldStatus, EstadoOrdenEntrega newStatus)
        {
            this.oldStatus = oldStatus;
            this.newStatus = newStatus;
        }

        public string Message => "No se puede cambiar del estado " + oldStatus.ToString() + 
            " al estado " + newStatus.ToString() ; 

        public bool IsBroken()
        {
            if(newStatus == EstadoOrdenEntrega.ListoParaEntrega && oldStatus != EstadoOrdenEntrega.Pendiente)
                return false;

            if (newStatus == EstadoOrdenEntrega.Anulado &&
                (oldStatus != EstadoOrdenEntrega.Pendiente || oldStatus != EstadoOrdenEntrega.ListoParaEntrega))
                return false;

            if (newStatus == EstadoOrdenEntrega.Pendiente && oldStatus != EstadoOrdenEntrega.ListoParaEntrega)
                return false;

            if (newStatus == EstadoOrdenEntrega.Finaliado && oldStatus != EstadoOrdenEntrega.ListoParaEntrega)
                return false;

            return true;
        }
    }
}
