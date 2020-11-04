using System;
using System.Collections.Generic;
using System.Text;
using Tienda.SharedKernel.Core;

namespace Tienda.Soporte.Domain.Model.Soporte.Rules
{
    public class ChangeOrderServiceStatusRule : IBusinessRule
    {
        private readonly ServiceOrderStatus oldStatus;
        private readonly ServiceOrderStatus newStatus;

        public ChangeOrderServiceStatusRule(ServiceOrderStatus oldStatus, ServiceOrderStatus newStatus)
        {
            this.oldStatus = oldStatus;
            this.newStatus = newStatus;
        }

        public string Message => "No se puede cambiar del estado " + oldStatus.ToString() +
            " al estado " + newStatus.ToString();

        public bool IsBroken()
        {
            if (newStatus == ServiceOrderStatus.Inactive && oldStatus != ServiceOrderStatus.Inactive)
                return false;
            return true;
        }
    }
}
