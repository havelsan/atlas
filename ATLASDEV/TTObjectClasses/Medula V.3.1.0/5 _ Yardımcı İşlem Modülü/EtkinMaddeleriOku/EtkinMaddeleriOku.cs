
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
    public  partial class EtkinMaddeleriOku : BaseMedulaDefinitionAction
    {
        public partial class GetEtkinMaddeleriOkuWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
        }

        protected void PreTransition_Successfully2Completed()
        {
            // From State : Successfully   To State : Completed
#region PreTransition_Successfully2Completed
            


            if (etkinMaddeOkuGirisDVO.etkinMaddeOkuCevapDVO.etkinMaddeler.Count > 0)
            {
                TTObjectContext readonlyObjectContext = new TTObjectContext(true);
                foreach (EtkinMaddeDVO etkinMaddeDVO in etkinMaddeOkuGirisDVO.etkinMaddeOkuCevapDVO.etkinMaddeler)
                {
                    if (string.IsNullOrEmpty(etkinMaddeDVO.etkinMaddeKodu) == false)
                    {
                        IList etkinMaddeler = readonlyObjectContext.QueryObjects(typeof(EtkinMadde).Name, "ETKINMADDEKODU ='" + etkinMaddeDVO.etkinMaddeKodu + "'");
                        EtkinMadde etkinMadde = null;
                        if (etkinMaddeler.Count <= 0)
                        {
                            etkinMadde = (EtkinMadde)ObjectContext.CreateObject(typeof(EtkinMadde).Name);
                        }
                        else if (etkinMaddeler.Count == 1)
                        {
                            EtkinMadde readOnlyEtkinMadde = (EtkinMadde)etkinMaddeler[0];
                            etkinMadde = (EtkinMadde)ObjectContext.GetObject(readOnlyEtkinMadde.ObjectID, readOnlyEtkinMadde.ObjectDef);
                        }

                        if (etkinMadde != null)
                        {
                            if (string.IsNullOrEmpty(etkinMaddeDVO.etkinMaddeKodu) == false)
                                etkinMadde.etkinMaddeKodu = etkinMaddeDVO.etkinMaddeKodu.Trim();
                            if (string.IsNullOrEmpty(etkinMaddeDVO.etkinMaddeAdi) == false)
                                etkinMadde.etkinMaddeAdi = etkinMaddeDVO.etkinMaddeAdi.Trim();
                            if (string.IsNullOrEmpty(etkinMaddeDVO.icerikMiktari) == false)
                                etkinMadde.icerikMiktari = etkinMaddeDVO.icerikMiktari.Trim();
                            if (string.IsNullOrEmpty(etkinMaddeDVO.adetMiktar) == false)
                                etkinMadde.adetMiktar = etkinMaddeDVO.adetMiktar.Trim();
                            if (string.IsNullOrEmpty(etkinMaddeDVO.form) == false)
                                etkinMadde.form = etkinMaddeDVO.form.Trim();
                            etkinMadde.IsActive = true;
                            etkinMadde.LastUpdate = TTObjectDefManager.ServerTime;

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
                etkinMaddeOkuGirisDVO = new EtkinMaddeOkuGirisDVO(ObjectContext);
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(EtkinMaddeleriOku).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == EtkinMaddeleriOku.States.Successfully && toState == EtkinMaddeleriOku.States.Completed)
                PreTransition_Successfully2Completed();
        }

    }
}