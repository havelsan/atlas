
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
    /// Hasta Kabul İptal
    /// </summary>
    public  partial class HastaKabulIptal : BaseMedulaAction
    {
        public partial class GetHastaKabulIptalWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();

            ITTObject iTTobject = (ITTObject)this;

            if (iTTobject.IsNew && iTTobject.IsImported == false)
                takipSilGirisDVO = new TakipSilGirisDVO(ObjectContext);
        }


        public override void PrepareExportableObjects()
        {
            base.PrepareExportableObjects();

            _exportableObjects.Add(takipSilGirisDVO);
            if (takipSilGirisDVO.takipSilCevapDVO != null)
                _exportableObjects.Add(takipSilGirisDVO.takipSilCevapDVO);
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