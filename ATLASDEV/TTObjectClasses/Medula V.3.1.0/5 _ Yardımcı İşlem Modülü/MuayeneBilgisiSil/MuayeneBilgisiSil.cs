
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
    public  partial class MuayeneBilgisiSil : BaseMedulaAction
    {
        public partial class GetMuayeneBilgisiSilWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
        }

        protected override void PreInsert()
        {
#region PreInsert
            



            base.PreInsert();

#if MEDULA && MEDULATEST
            throw new TTException("Bu işlem sadece Gerçek Veritabanında yapılabilir.");
#endif






#endregion PreInsert
        }

        protected override void PreUpdate()
        {
#region PreUpdate
            



            base.PreUpdate();


#if MEDULA && MEDULATEST
            throw new TTException("Bu işlem sadece Gerçek Veritabanında yapılabilir.");
#endif





#endregion PreUpdate
        }

#region Methods
        protected override void OnConstruct()
        {

            base.OnConstruct();

            ITTObject iTTobject = (ITTObject)this;

            if (iTTobject.IsNew && iTTobject.IsImported == false)
                muayeneSilGirisDVO = new MuayeneSilGirisDVO(ObjectContext);
        }

        public override void PrepareExportableObjects()
        {
            base.PrepareExportableObjects();

            _exportableObjects.Add(muayeneSilGirisDVO);
            if (muayeneSilGirisDVO.muayeneSilCevapDVO != null)
                _exportableObjects.Add(muayeneSilGirisDVO.muayeneSilCevapDVO);
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