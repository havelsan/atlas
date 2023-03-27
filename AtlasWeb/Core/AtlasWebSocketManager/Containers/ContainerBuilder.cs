using Newtonsoft.Json;
using System;

namespace Core.AtlasWebSocketManager.Containers
{
    public class ContainerBuilder
    {
        private static I_AtlasWebSocketContainer GenerateBaseContainer(string receivedString, I_AtlasWebSocketContainer receivedContainer, Type classType)
        {
            try
            {
                receivedContainer = JsonConvert.DeserializeObject(receivedString, classType) as I_AtlasWebSocketContainer;
                if (receivedContainer.content == null)
                {
                    receivedContainer.dataProcessedSuccessfully = false;
                    receivedContainer.status = "Content is Null.";
                }
                else
                {
                    receivedContainer.dataProcessedSuccessfully = true;
                }
            }
            catch (ArgumentNullException e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                receivedContainer.dataProcessedSuccessfully = false;
                receivedContainer.status = "Input data are absent.";
            }
            catch (ArgumentException e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                receivedContainer.dataProcessedSuccessfully = false;
                receivedContainer.status = "Input data had an incorrect format.";
            }
            catch (InvalidOperationException e)
            {
                System.Diagnostics.Trace.WriteLine(e.Message);
                receivedContainer.dataProcessedSuccessfully = false;
                receivedContainer.status = "Data handling error on the server.";
            }

            return receivedContainer;
        }

        internal static I_AtlasWebSocketContainer CreateAtlasMessageContainer(string receivedString)
        {
            I_AtlasWebSocketContainer receivedContainer = new AtlasMessageContainer { dataProcessedSuccessfully = true };
            receivedContainer = GenerateBaseContainer(receivedString, receivedContainer, typeof(AtlasMessageContainer));

            return receivedContainer;
        }

        internal static I_AtlasWebSocketContainer CreateAtlasNotificationContainer(string receivedString)
        {
            I_AtlasWebSocketContainer receivedContainer = new AtlasNotificationContainer { dataProcessedSuccessfully = true };
            receivedContainer = GenerateBaseContainer(receivedString, receivedContainer, typeof(AtlasNotificationContainer));

            return receivedContainer;
        }
        internal static I_AtlasWebSocketContainer CreateAtlasActionContainer(string receivedString)
        {
            I_AtlasWebSocketContainer receivedContainer = new AtlasActionContainer { dataProcessedSuccessfully = true };
            receivedContainer = GenerateBaseContainer(receivedString, receivedContainer, typeof(AtlasActionContainer));

            return receivedContainer;
        }

    }
}
