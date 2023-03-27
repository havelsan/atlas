
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
    public  partial class MuayeneGiris : BaseMedulaAction
    {
        public partial class MUAYENEBILGILERIReportQuery_Class : TTReportNqlObject 
        {
        }

        public partial class GetMuayeneGirisWillBeSentToMedulaRQ_Class : TTReportNqlObject 
        {
        }

        public partial class GetMuayeneGirisReportQuery_Class : TTReportNqlObject 
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

        protected void PreTransition_New2SentServer()
        {
            // From State : New   To State : SentServer
#region PreTransition_New2SentServer
            









            if (muayeneGirisDVO.referansNo.HasValue == false)
                throw new TTException(TTUtils.CultureService.GetText("M26543", "Muayene Giriş Referans Numarası girilmesi zorunludur. Referans Numarası girip yeniden deneyiniz."));

            if (muayeneGirisDVO.referansNo.HasValue && muayeneGirisDVO.referansNo.Value <= 0)
                throw new TTException(TTUtils.CultureService.GetText("M26544", "Muayene Giriş Referans Numarası sıfırdan büyük olmalıdır."));











#endregion PreTransition_New2SentServer
        }

#region Methods
        protected override void OnConstruct()
        {

            base.OnConstruct();

            ITTObject iTTobject = (ITTObject)this;

            if (iTTobject.IsNew && iTTobject.IsImported == false)
                muayeneGirisDVO = new MuayeneGirisDVO(ObjectContext);
        }

        public override void PrepareExportableObjects()
        {
            base.PrepareExportableObjects();

            _exportableObjects.Add(muayeneGirisDVO);
            if (muayeneGirisDVO.muayeneGirisCevapDVO != null)
                _exportableObjects.Add(muayeneGirisDVO.muayeneGirisCevapDVO);
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

        public string MuayeneDurumu
        {
            get
            {
                string retValue = string.Empty;

                if (muayeneGirisDVO != null && muayeneGirisDVO.muayeneGirisCevapDVO != null && (muayeneGirisDVO.muayeneGirisCevapDVO.sonucKodu.Equals("0000") || muayeneGirisDVO.muayeneGirisCevapDVO.sonucKodu.Equals("99")))
                {
                    retValue = TTUtils.CultureService.GetText("M26276", "Kaydedilmiş");
                    IList muayeneBilgisiSilList = MuayeneBilgisiSil.GetMuayeneBilgisiSilForMuayeneDurum(ObjectContext, muayeneGirisDVO.saglikTesisKodu.Value, muayeneGirisDVO.referansNo.Value);
                    foreach (MuayeneBilgisiSil muayeneBilgisiSil in muayeneBilgisiSilList)
                    {
                        if (muayeneBilgisiSil.muayeneSilGirisDVO != null && muayeneBilgisiSil.muayeneSilGirisDVO.muayeneSilCevapDVO != null && string.IsNullOrEmpty(muayeneBilgisiSil.muayeneSilGirisDVO.muayeneSilCevapDVO.sonucKodu) == false && (muayeneBilgisiSil.muayeneSilGirisDVO.muayeneSilCevapDVO.sonucKodu.Equals("0000") || muayeneBilgisiSil.muayeneSilGirisDVO.muayeneSilCevapDVO.sonucKodu.Equals("-")))
                        {
                            retValue = TTUtils.CultureService.GetText("M26277", "Kaydedilmiş daha sonra silinmiş");
                            break;
                        }
                    }
                }
                return retValue;
            }
        }

        public override string ToString()
        {
            string retValue = base.ToString();
            if (muayeneGirisDVO != null)
            {
                retValue = string.Empty;
                if (muayeneGirisDVO.tcKimlikNo.HasValue)
                    retValue += "T.C.Kimlik Nu.: " + muayeneGirisDVO.tcKimlikNo.Value;
                if (muayeneGirisDVO.muayeneTarihiDateTime.HasValue)
                    retValue += " Muayene Tarihi: " + muayeneGirisDVO.muayeneTarihiDateTime.Value.ToShortDateString();
                if (muayeneGirisDVO.referansNo.HasValue)
                    retValue += " Referans Nu.: " + muayeneGirisDVO.referansNo.Value;
            }

            return retValue;
        }
        
#endregion Methods

        protected void PreTransition(TTObjectStateTransitionDef transDef)
        {
            if (transDef.ObjectDef.CodeName != typeof(MuayeneGiris).Name)
                return;

            var fromState = transDef.FromStateDefID;
            var toState = transDef.ToStateDefID;

            if (fromState == MuayeneGiris.States.New && toState == MuayeneGiris.States.SentServer)
                PreTransition_New2SentServer();
        }

    }
}