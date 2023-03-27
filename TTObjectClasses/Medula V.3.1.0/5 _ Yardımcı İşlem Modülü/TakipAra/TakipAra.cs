
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
    /// Takip Ara
    /// </summary>
    public  partial class TakipAra : BaseMedulaAction
    {
        public partial class GetTakipAraWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();

            ITTObject iTTobject = (ITTObject)this;

            if (iTTobject.IsNew && iTTobject.IsImported == false)
                takipAraGirisDVO = new TakipAraGirisDVO(ObjectContext);
        }

        public override void PrepareExportableObjects()
        {
            base.PrepareExportableObjects();

            _exportableObjects.Add(takipAraGirisDVO);
            if (takipAraGirisDVO.takipAraCevapDVO != null)
            {
                _exportableObjects.Add(takipAraGirisDVO.takipAraCevapDVO);
                if (takipAraGirisDVO.takipAraCevapDVO.takipler.Count > 0)
                    foreach (TakipDVO takipDVO in takipAraGirisDVO.takipAraCevapDVO.takipler)
                        _exportableObjects.Add(takipDVO);
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

    }
}