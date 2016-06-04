using SimpleX.Model;
using SimpleX.ModelCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleX.ModelCore.Message
{
    public class systemMessageCore
    {
        private systemMessageService serviceSystemMessage;

        public systemMessageCore()
        {
            serviceSystemMessage = new systemMessageService();
        }

        public void Dispose()
        {
            serviceSystemMessage.Dispose();
        }

        public string BuscarSystemMessageByExternalNumber(string number)
        {
            systemMessage systemMessage = new systemMessage();
            systemMessage.externalNumber = number;
            string description = "";
            List<systemMessage> lstsystemMessage = serviceSystemMessage.Filtrar(systemMessage);

            if (lstsystemMessage.Count > 0)
            {
                description = lstsystemMessage[0].description;
            }

            return description;
        }
    }
}
