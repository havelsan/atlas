
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
    /// Demirbaş Tipi Değiştirme İşlemi Güncelleme
    /// </summary>
    public  partial class FixedAssetChangeUpdate : BaseDataCorrection, IWorkListBaseAction
    {
        protected void PreTransition_New2Completed()
        {
            // From State : New   To State : Completed
#region PreTransition_New2Completed
            
            
            int count = 0;
            foreach (FixedAssetChangeDetail fixedAssetChangeDetail in FixedAssetChangeDetails)
            {
                if (fixedAssetChangeDetail.DetailUpdate == true)
                    count++;
            }
            if (count > 1)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25276", "Birden fazla işlem seçemezsiniz"));
            }

            if (count == 0)
            {
                throw new TTException(TTUtils.CultureService.GetText("M25935", "Hiç işlem seçmediniz"));
            }


#endregion PreTransition_New2Completed
        }

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(FixedAssetChangeUpdate).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == FixedAssetChangeUpdate.States.New && toState == FixedAssetChangeUpdate.States.Completed)
                PreTransition_New2Completed();
        }

    }
}