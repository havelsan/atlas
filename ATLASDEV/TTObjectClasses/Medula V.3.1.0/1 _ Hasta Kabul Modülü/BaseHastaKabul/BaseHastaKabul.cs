
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
    /// Hasta Kabul
    /// </summary>
    public  abstract  partial class BaseHastaKabul : BaseMedulaAction
    {
        public partial class HASTAKABULReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class TAKIPNUMARASIALINMISHASTALARReportQuery_Class : TTReportNqlObject 
        {
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();

            ITTObject iTTobject = (ITTObject)this;

            if (iTTobject.IsNew && iTTobject.IsImported == false)
                provizyonGirisDVO = new ProvizyonGirisDVO(ObjectContext);
        }


        public override void PrepareExportableObjects()
        {
            base.PrepareExportableObjects();

            _exportableObjects.Add(provizyonGirisDVO);
            if (provizyonGirisDVO.provizyonCevapDVO != null)
                _exportableObjects.Add(provizyonGirisDVO.provizyonCevapDVO);
            if (provizyonGirisDVO.provizyonCevapDVO != null && provizyonGirisDVO.provizyonCevapDVO.hastaBilgileri != null)
                _exportableObjects.Add(provizyonGirisDVO.provizyonCevapDVO.hastaBilgileri);
        }

        public override bool IsExportable
        {
            get
            {
                #if MEDULA && MEDULATEST
                return false;
                #else
                return true;
                #endif
            }
        }
        
#endregion Methods

    }
}