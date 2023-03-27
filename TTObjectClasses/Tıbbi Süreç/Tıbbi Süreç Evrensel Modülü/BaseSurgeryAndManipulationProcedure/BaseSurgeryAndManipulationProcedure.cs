
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
    /// <summary>
    /// Ana Ameliyat ve Maniplasyon
    /// </summary>
    public  partial class BaseSurgeryAndManipulationProcedure : SubActionProcedure
    {
    /// <summary>
    /// Medula için hesaplanan EuroScore bilgisi
    /// </summary>
        public string MedulaEuroScore
        {
            get
            {
                try
                {
#region MedulaEuroScore_GetScript                    
                    /*
                0: Yok (KVC değil ise ,diğer durumlarda 0 gönderilmelidir )
                1: Düşük risk (İşlem tutarı %10 azaltılır.)0-3 puan
                2: Orta risk (İşlem tutarının %100 ü ödenir.)4-6 puan, 
                3: Yüksek risk (İşlem tutarı %10 arttırılır.)7 ve üzeri puan
                 */
                  if(EuroScoreOfProcedure != null && EuroScoreOfProcedure.MedulaEuroScoreRisk.HasValue)
                        return ((int)EuroScoreOfProcedure.MedulaEuroScoreRisk.Value).ToString();

                    return ((int)MedulaEuroScoreEnum.Empty).ToString();  // EuroScore bilgisi yoksa 0 gönderilir
#endregion MedulaEuroScore_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "MedulaEuroScore") + " : " + ex.Message, ex);
                }
            }
        }

        public override bool GetProcedureDoctorFromMyEpisodeAction()
        {
            if (ProcedureDoctor == null)
                return true;
            else
                return false;
        }

    }
}