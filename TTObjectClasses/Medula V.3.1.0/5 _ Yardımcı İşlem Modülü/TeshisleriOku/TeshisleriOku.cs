
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
    public  partial class TeshisleriOku : BaseMedulaDefinitionAction
    {
        public partial class GetTeshisleriOkuWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
        }

        protected void PreTransition_Successfully2Completed()
        {
            // From State : Successfully   To State : Completed
#region PreTransition_Successfully2Completed
            
            
             if (teshisOkuGirisDVO.teshisOkuCevapDVO.teshisler.Count > 0)
            {
                TTObjectContext readonlyObjectContext = new TTObjectContext(true);
                foreach (TeshisDVO teshisDVO in teshisOkuGirisDVO.teshisOkuCevapDVO.teshisler)
                {
                    if (teshisDVO.kodu.HasValue && teshisDVO.kodu.Value > 0)
                    {
                        IList teshisler = readonlyObjectContext.QueryObjects(typeof(Teshis).Name, "TESHISKODU =" + teshisDVO.kodu + "");
                        Teshis teshis = null;
                        if (teshisler.Count <= 0)
                        {
                            teshis = (Teshis)ObjectContext.CreateObject(typeof(Teshis).Name);
                        }
                        else if (teshisler.Count == 1)
                        {
                            Teshis readOnlyTeshis = (Teshis)teshisler[0];
                            teshis = (Teshis)ObjectContext.GetObject(readOnlyTeshis.ObjectID, readOnlyTeshis.ObjectDef);
                        }

                        if (teshis != null)
                        {
                            teshis.teshisKodu = teshisDVO.kodu;
                            if (string.IsNullOrEmpty(teshisDVO.adi) == false)
                                teshis.teshisAdi = teshisDVO.adi.Trim();
                            teshis.IsActive = true;
                            teshis.LastUpdate = TTObjectDefManager.ServerTime;

                        }
                    }
                }
                readonlyObjectContext.Dispose();
            }


#endregion PreTransition_Successfully2Completed
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();

            if (((ITTObject)this).IsNew)
                teshisOkuGirisDVO = new TeshisOkuGirisDVO(ObjectContext);
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(TeshisleriOku).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == TeshisleriOku.States.Successfully && toState == TeshisleriOku.States.Completed)
                PreTransition_Successfully2Completed();
        }

    }
}