
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
    /// Doktor Ara
    /// </summary>
    public  partial class DoktorAra : BaseMedulaDefinitionAction
    {
        public partial class GetDoktorAraWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
        }

        protected void PreTransition_Successfully2Completed()
        {
            // From State : Successfully   To State : Completed
#region PreTransition_Successfully2Completed
            
            
            
            if (doktorAraGirisDVO.doktorAraCevapDVO.doktorlar.Count > 0)
            {
                TTObjectContext readonlyObjectContext = new TTObjectContext(true);
                foreach (DoktorListDVO doktorListDVO in doktorAraGirisDVO.doktorAraCevapDVO.doktorlar)
                {
                    if (string.IsNullOrEmpty(doktorListDVO.drTescilNo) == false)
                    {
                        IList doktorlar = readonlyObjectContext.QueryObjects(typeof(Doktor).Name, "DRTESCILNO ='" + doktorListDVO.drTescilNo.Trim() + "'");
                        Doktor doktor = null;
                        if (doktorlar.Count <= 0)
                        {
                            doktor = (Doktor)ObjectContext.CreateObject(typeof(Doktor).Name);
                        }
                        else if (doktorlar.Count == 1)
                        {
                            Doktor readOnlyDoktor = (Doktor)doktorlar[0];
                            doktor = (Doktor)ObjectContext.GetObject(readOnlyDoktor.ObjectID, readOnlyDoktor.ObjectDef);
                        }

                        if (doktor != null)
                        {
                            if (string.IsNullOrEmpty(doktorListDVO.drAdi) == false)
                                doktor.drAdi = doktorListDVO.drAdi.Trim();
                            if (string.IsNullOrEmpty(doktorListDVO.drDiplomaNo) == false)
                                doktor.drDiplomaNo = doktorListDVO.drDiplomaNo.Trim();
                            if (string.IsNullOrEmpty(doktorListDVO.drSoyadi) == false)
                                doktor.drSoyadi = doktorListDVO.drSoyadi.Trim();
                            if (string.IsNullOrEmpty(doktorListDVO.drTescilNo) == false)
                                doktor.drTescilNo = doktorListDVO.drTescilNo.Trim();
                        SpecialityDefinition brans = SpecialityDefinition.GetBrans(doktorAraGirisDVO.drBransKodu);
                            doktor.Brans = brans;
                            doktor.SaglikTesisi = SaglikTesisi.GetSaglikTesisi(doktorAraGirisDVO.saglikTesisiKodu.Value);
                            doktor.IsActive = true;
                            doktor.LastUpdate = TTObjectDefManager.ServerTime;
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
                doktorAraGirisDVO = new DoktorAraGirisDVO(ObjectContext);
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(DoktorAra).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == DoktorAra.States.Successfully && toState == DoktorAra.States.Completed)
                PreTransition_Successfully2Completed();
        }

    }
}