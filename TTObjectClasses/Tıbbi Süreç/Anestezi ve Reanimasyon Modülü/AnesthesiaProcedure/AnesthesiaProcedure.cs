
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
    /// Anestezi Konsültasyonunda Anestezi Şekli ve Tekniği
    /// </summary>
    public partial class AnesthesiaProcedure : BaseAnesthesiaProcedure
    {
        #region Methods
        
        public override string GetDVOAciklama(AccountTransaction accTrx)
        {
            if (AnaesthesiaAndReanimation != null && AnaesthesiaAndReanimation.AnesthesiaReport != null)
            {
                string anesthesiaReport = Common.GetTextOfRTFString(AnaesthesiaAndReanimation.AnesthesiaReport.ToString());
                if (anesthesiaReport.Length > 254)
                    return anesthesiaReport.Substring(0, 254);

                return anesthesiaReport;
            }

            return null;
        }

        public override string GetDVOEuroscore()
        {
            return ((int)MedulaEuroScoreEnum.Empty).ToString();
        }
               
        public override void SetPerformedDate()
        {

            // Hizmet oluşturulurken Henüz Anestezi tarihleri girilmemiş olabilir o zaman Ameliyatın tarihleri baz alınır
            if (AnaesthesiaAndReanimation.AnesthesiaStartDateTime != null && AnaesthesiaAndReanimation.AnesthesiaStartDateTime < CreationDate)
                CreationDate = AnaesthesiaAndReanimation.AnesthesiaStartDateTime;
            else if(AnaesthesiaAndReanimation.MainSurgery.SurgeryStartTime != null && AnaesthesiaAndReanimation.MainSurgery.SurgeryStartTime < CreationDate)
                CreationDate = AnaesthesiaAndReanimation.MainSurgery.SurgeryStartTime;

            if (AnaesthesiaAndReanimation.AnesthesiaEndDateTime != null)
                PerformedDate = AnaesthesiaAndReanimation.AnesthesiaEndDateTime;
            else if(AnaesthesiaAndReanimation.MainSurgery.SurgeryEndTime != null)
                PerformedDate = AnaesthesiaAndReanimation.MainSurgery.SurgeryEndTime;




        }


        #endregion Methods

    }
}