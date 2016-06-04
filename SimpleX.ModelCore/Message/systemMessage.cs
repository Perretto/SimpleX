using SimpleX.Model;
using SimpleX.ModelCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleX.ModelCore.Message
{
    public class systemMessage
    {
        private systemMessageService serviceSystemMessage;

        public systemMessage()
        {
            serviceSystemMessage = new systemMessageService();
        }

        public void Dispose()
        {
            serviceSystemMessage.Dispose();
        }

        public string BuscarSystemMessageByExternalNumber(string number)
        {
            SimpleX.Model.systemMessageCore systemMessage = new SimpleX.Model.systemMessageCore();
            systemMessage.externalNumber = number;
            string description = "";
            List<systemMessageCore> lstsystemMessage = serviceSystemMessage.Filtrar(systemMessage);

            if (lstsystemMessage.Count > 0)
            {
                description = lstsystemMessage[0].description;
            }

            return description;
        }
    }
}
