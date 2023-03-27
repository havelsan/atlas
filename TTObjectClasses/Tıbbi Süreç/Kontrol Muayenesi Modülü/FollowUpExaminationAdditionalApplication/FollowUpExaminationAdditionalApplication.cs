
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
    /// Kontrol Muayenesi Ek Uygulamalar Sekmesi
    /// </summary>
    public partial class FollowUpExaminationAdditionalApplication : BaseAdditionalApplication
    {
        #region Methods
        //        public override void Cancel()
        //        {
        //            if(this.CurrentStateDefID != FollowUpExaminationAdditionalApplication.States.Cancelled)
        //            {
        //                base.Cancel();
        //                this.CurrentStateDefID = FollowUpExaminationAdditionalApplication.States.Cancelled;
        //            }
        //        }

        //public override string GetDVOAyniFarkliKesi()
        //{
        //    return AyniFarkliKesi?.ayniFarkliKesiKodu;
        //}
             
        public override string GetDVOEuroscore()
        {
            return MedulaEuroScore;
        }

        #endregion Methods

    }
}