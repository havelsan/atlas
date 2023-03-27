
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
    /// Sağlık Tesisi Ara
    /// </summary>
    public  partial class SaglikTesisiAra : BaseMedulaDefinitionAction
    {
        public partial class GetSaglikTesisiAraWillBeSentToMedulaReportQuery_Class : TTReportNqlObject 
        {
        }

        protected void PreTransition_Successfully2Completed()
        {
            // From State : Successfully   To State : Completed
#region PreTransition_Successfully2Completed
            

            if (saglikTesisiAraGirisDVO.saglikTesisiAraCevapDVO.tesisler.Count > 0)
            {
                TTObjectContext readonlyObjectContext = new TTObjectContext(true);
                foreach (SaglikTesisiListDVO saglikTesisiListDVO in saglikTesisiAraGirisDVO.saglikTesisiAraCevapDVO.tesisler)
                {
                    if (saglikTesisiListDVO.tesisKodu > 0)
                    {
                        IList saglikTesisleri = readonlyObjectContext.QueryObjects(typeof(SaglikTesisi).Name, "TESISKODU = " + saglikTesisiListDVO.tesisKodu);
                        SaglikTesisi saglikTesisi = null;
                        if (saglikTesisleri.Count == 1)
                        {
                            SaglikTesisi readOnlySaglikTesisi = (SaglikTesisi)saglikTesisleri[0];
                            saglikTesisi = (SaglikTesisi)ObjectContext.GetObject(readOnlySaglikTesisi.ObjectID, readOnlySaglikTesisi.ObjectDef);

                            if (string.IsNullOrEmpty(saglikTesisiListDVO.tesisSinifKodu) == false)
                                saglikTesisi.tesisSinifKodu = saglikTesisiListDVO.tesisSinifKodu;
                            if (string.IsNullOrEmpty(saglikTesisiListDVO.tesisTuru) == false)
                                saglikTesisi.tesisTuru = saglikTesisiListDVO.tesisTuru;
                            saglikTesisi.LastUpdate = TTObjectDefManager.ServerTime;
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
            if (((ITTObject)this).IsNew && ((ITTObject)this).IsImported == false)
                saglikTesisiAraGirisDVO = new SaglikTesisiAraGirisDVO(ObjectContext);
        }


        public override void PrepareExportableObjects()
        {
            base.PrepareExportableObjects();

            _exportableObjects.Add(saglikTesisiAraGirisDVO);
            if (saglikTesisiAraGirisDVO.saglikTesisiAraCevapDVO != null)
            {
                _exportableObjects.Add(saglikTesisiAraGirisDVO.saglikTesisiAraCevapDVO);
                if (saglikTesisiAraGirisDVO.saglikTesisiAraCevapDVO.tesisler.Count > 0)
                    foreach (SaglikTesisiListDVO saglikTesisiListDVO in saglikTesisiAraGirisDVO.saglikTesisiAraCevapDVO.tesisler)
                        _exportableObjects.Add(saglikTesisiListDVO);
            }
        }

        public override bool IsExportable
        {
            get
            {
                return true;
            }
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(SaglikTesisiAra).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == SaglikTesisiAra.States.Successfully && toState == SaglikTesisiAra.States.Completed)
                PreTransition_Successfully2Completed();
        }

    }
}