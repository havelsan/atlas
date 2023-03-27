
using System;
using System.Xml;
using System.Data;
using System.Text;
using System.Drawing;
using System.Reflection;
using System.Collections;
using System.Linq;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

using TTUtils;
using TTObjectClasses;
using TTDataDictionary;
using TTCoreDefinitions;
using TTConnectionManager;
using TTInstanceManagement;
using TTDefinitionManagement;
using TTStorageManager.Security;

using TTStorageManager;
using System.Runtime.Versioning;
using static TTObjectClasses.UTSServis;

namespace TTObjectClasses
{
    public partial class UtsServisMessageDefinition : TerminologyManagerDef
    {
        public partial class GetUtsServisMessageDefinitionList_Class : TTReportNqlObject
        {
        }

        #region Methods
        public static string GetUTSErrorMessageInternal(string code, string[] parameters)
        {
            TTObjectContext context = new TTObjectContext(true);
            BindingList<UtsServisMessageDefinition.GetUtsServisMessageDefinitionList_Class> messageList = UtsServisMessageDefinition.GetUtsServisMessageDefinitionList("CODE=" + code);
            if(messageList.Count > 0)
            {
                string message = messageList[0].Message;
                if (parameters.Length > 0)
                    return string.Format(message, parameters);
                else
                    return message;

            }
            return string.Empty;
        }

        public static string GetUTSErrorMessage(Mesaj errorMessage)
        {
            string message = string.Empty;
            List<string> parameters = new List<string>();
            foreach(object obj in errorMessage.MPA)
                parameters.Add(obj.ToString());
            
            message = GetUTSErrorMessageInternal(errorMessage.KOD, parameters.ToArray());
            return message;
        }

        #endregion Methods
    }
}