
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SendSMSMaster")] 

    public  partial class SendSMSMaster : TTObject
    {
        public class SendSMSMasterList : TTObjectCollection<SendSMSMaster> { }
                    
        public class ChildSendSMSMasterCollection : TTObject.TTChildObjectCollection<SendSMSMaster>
        {
            public ChildSendSMSMasterCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSendSMSMasterCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        public static class States
        {
    /// <summary>
    /// Yeni
    /// </summary>
            public static Guid New { get { return new Guid("ed64154c-748a-4999-9323-89b1c6613df3"); } }
            public static Guid Started { get { return new Guid("be5973f9-25c2-4b7b-a79a-25868dc11229"); } }
            public static Guid Sent { get { return new Guid("151978e5-cfc9-4697-8f1a-4547a38012d0"); } }
    /// <summary>
    /// İptal
    /// </summary>
            public static Guid Cancelled { get { return new Guid("6b38e83c-fec4-4b35-bfbd-d830168e9247"); } }
        }

    /// <summary>
    /// SMS Türü
    /// </summary>
        public SMSTypeEnum? SMSType
        {
            get { return (SMSTypeEnum?)(int?)this["SMSTYPE"]; }
            set { this["SMSTYPE"] = value; }
        }

    /// <summary>
    /// Göndrilen Mesajın İçeriği
    /// </summary>
        public string MessageText
        {
            get { return (string)this["MESSAGETEXT"]; }
            set { this["MESSAGETEXT"] = value; }
        }

    /// <summary>
    /// Hastaya gönderilen SMS
    /// </summary>
        public bool? IsPatientSMS
        {
            get { return (bool?)this["ISPATIENTSMS"]; }
            set { this["ISPATIENTSMS"] = value; }
        }

    /// <summary>
    /// Gönderim İptal
    /// </summary>
        public bool? Cancelled
        {
            get { return (bool?)this["CANCELLED"]; }
            set { this["CANCELLED"] = value; }
        }

    /// <summary>
    /// SMS Gönderilen Kullanıcı
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateSendSMSDetailsCollection()
        {
            _SendSMSDetails = new SendSMSDetail.ChildSendSMSDetailCollection(this, new Guid("2a4a1181-8cb5-4d03-adeb-e49585a7b8cb"));
            ((ITTChildObjectCollection)_SendSMSDetails).GetChildren();
        }

        protected SendSMSDetail.ChildSendSMSDetailCollection _SendSMSDetails = null;
        public SendSMSDetail.ChildSendSMSDetailCollection SendSMSDetails
        {
            get
            {
                if (_SendSMSDetails == null)
                    CreateSendSMSDetailsCollection();
                return _SendSMSDetails;
            }
        }

        protected SendSMSMaster(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SendSMSMaster(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SendSMSMaster(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SendSMSMaster(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SendSMSMaster(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SENDSMSMASTER", dataRow) { }
        protected SendSMSMaster(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SENDSMSMASTER", dataRow, isImported) { }
        public SendSMSMaster(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SendSMSMaster(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SendSMSMaster() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}