
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
namespace TTObjectClasses
{
    public partial class ENABIZCreate700 : BaseScheduledTask
    {
        public override void TaskScript()
        {
            string logTxt = "ENABIZCreate700 Has Started : " + Common.RecTime();
            try
            {
                double startDay = Convert.ToDouble(SystemParameter.GetParameterValue("ENABIZ700STARTDAY", "1"));
                double endDay = Convert.ToDouble(SystemParameter.GetParameterValue("ENABIZ700ENDDAY", "0"));
                
                DateTime currentDate = Common.RecTime().Date;
                DateTime startDate = currentDate.AddDays(-1 * startDay);
                DateTime endDate = currentDate.AddDays(-1 * endDay);

                // Uygun SEP ler i�in 700 paketleri olu�turulur(yoksa) ve g�nderilir 
                BindingList<SubEpisodeProtocol.GetSEPSToCreateENabiz700_Class> outpatientSEPs = SubEpisodeProtocol.GetSEPSToCreateENabiz700(startDate, endDate);
                foreach (SubEpisodeProtocol.GetSEPSToCreateENabiz700_Class item in outpatientSEPs)
                {
                    TTObjectContext context = new TTObjectContext(false);
                    SubEpisodeProtocol sep = context.GetObject<SubEpisodeProtocol>(item.ObjectID.Value);
                    sep.SendNabiz700(false);  // 700 paketini olu�turur ve g�nderir
                    context.Dispose();
                }
                
                // A�a��daki gibi tek tek 700 paketi olu�turulup, bir seferde de g�nderilebilir.
                //TTObjectContext roContext = new TTObjectContext(true);
                //DateTime startDate = Common.RecTime().Date.AddDays(-1);
                //SendToENabiz sendToENabiz = new SendToENabiz();

                //// Uygun SEP ler i�in 700 paketlerini olu�tur
                //BindingList<SubEpisodeProtocol.GetSEPSToCreateENabiz700_Class> outpatientSEPs = SubEpisodeProtocol.GetSEPSToCreateENabiz700(roContext, startDate);
                //foreach (SubEpisodeProtocol.GetSEPSToCreateENabiz700_Class item in outpatientSEPs)
                //{
                //    TTObjectContext context = new TTObjectContext(false);
                //    SubEpisodeProtocol sep = context.GetObject<SubEpisodeProtocol>(item.ObjectID.Value);
                //    sendToENabiz.ControlAndCreatePackageToSendToENabiz(context, sep.SubEpisode, sep.ObjectID, sep.ObjectDef.Name, "700");
                //    context.Dispose();
                //}

                //sendToENabiz.ENABIZSend700(null);

                logTxt += " - Has Finished Succesfully : " + Common.RecTime();
            }
            catch (Exception ex)
            {
                logTxt += " - ERROR: " + ex.ToString() + ": " + Common.RecTime();
            }

            AddLog(logTxt);
        }
    }
}