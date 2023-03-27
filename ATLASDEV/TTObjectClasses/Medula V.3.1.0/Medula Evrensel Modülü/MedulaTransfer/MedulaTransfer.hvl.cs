
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedulaTransfer")] 

    /// <summary>
    /// Medulaya Aktar
    /// </summary>
    public  partial class MedulaTransfer : TTObject
    {
        public class MedulaTransferList : TTObjectCollection<MedulaTransfer> { }
                    
        public class ChildMedulaTransferCollection : TTObject.TTChildObjectCollection<MedulaTransfer>
        {
            public ChildMedulaTransferCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedulaTransferCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedulaTransfersForXXXXXXTransferRQ_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? TransferDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSFERDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATRANSFER"].AllPropertyDefs["TRANSFERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string TemplateFileName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEMPLATEFILENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATRANSFER"].AllPropertyDefs["TEMPLATEFILENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? Transferdate1
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TRANSFERDATE1"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDULATRANSFER"].AllPropertyDefs["TRANSFERDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Object Totalcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["TOTALCOUNT"]);
                }
            }

            public Object Successfullcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["SUCCESSFULLCOUNT"]);
                }
            }

            public Object Unsuccessfullcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["UNSUCCESSFULLCOUNT"]);
                }
            }

            public Object Cancelledcount
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["CANCELLEDCOUNT"]);
                }
            }

            public GetMedulaTransfersForXXXXXXTransferRQ_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedulaTransfersForXXXXXXTransferRQ_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedulaTransfersForXXXXXXTransferRQ_Class() : base() { }
        }

        public static class States
        {
            public static Guid Completed { get { return new Guid("17ac84b8-d03d-4627-b290-3d24af330b9a"); } }
            public static Guid New { get { return new Guid("9807d071-b64d-4028-9f20-52892d213d79"); } }
            public static Guid PreparedFile { get { return new Guid("8751a210-a96f-4116-ba6c-4b06850e6450"); } }
            public static Guid ImportedFile { get { return new Guid("a2c44e2c-cd1a-45f1-85e9-76447cdb6d84"); } }
        }

        public static BindingList<MedulaTransfer> GetMedulaTransfersForXXXXXXTransfer(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATRANSFER"].QueryDefs["GetMedulaTransfersForXXXXXXTransfer"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<MedulaTransfer>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<MedulaTransfer.GetMedulaTransfersForXXXXXXTransferRQ_Class> GetMedulaTransfersForXXXXXXTransferRQ(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATRANSFER"].QueryDefs["GetMedulaTransfersForXXXXXXTransferRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaTransfer.GetMedulaTransfersForXXXXXXTransferRQ_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedulaTransfer.GetMedulaTransfersForXXXXXXTransferRQ_Class> GetMedulaTransfersForXXXXXXTransferRQ(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDULATRANSFER"].QueryDefs["GetMedulaTransfersForXXXXXXTransferRQ"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedulaTransfer.GetMedulaTransfersForXXXXXXTransferRQ_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Aktarma Tarihi ve Saati
    /// </summary>
        public DateTime? TransferDate
        {
            get { return (DateTime?)this["TRANSFERDATE"]; }
            set { this["TRANSFERDATE"] = value; }
        }

    /// <summary>
    /// Şablon Dosya Adı
    /// </summary>
        public string TemplateFileName
        {
            get { return (string)this["TEMPLATEFILENAME"]; }
            set { this["TEMPLATEFILENAME"] = value; }
        }

        public int? HealthFacilityID
        {
            get { return (int?)this["HEALTHFACILITYID"]; }
            set { this["HEALTHFACILITYID"] = value; }
        }

        virtual protected void CreateBaseMedulaActionsCollection()
        {
            _BaseMedulaActions = new BaseMedulaAction.ChildBaseMedulaActionCollection(this, new Guid("e783873c-4d6f-4357-b77e-94141510c625"));
            ((ITTChildObjectCollection)_BaseMedulaActions).GetChildren();
        }

        protected BaseMedulaAction.ChildBaseMedulaActionCollection _BaseMedulaActions = null;
        public BaseMedulaAction.ChildBaseMedulaActionCollection BaseMedulaActions
        {
            get
            {
                if (_BaseMedulaActions == null)
                    CreateBaseMedulaActionsCollection();
                return _BaseMedulaActions;
            }
        }

        protected MedulaTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedulaTransfer(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedulaTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedulaTransfer(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedulaTransfer(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDULATRANSFER", dataRow) { }
        protected MedulaTransfer(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDULATRANSFER", dataRow, isImported) { }
        public MedulaTransfer(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedulaTransfer(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedulaTransfer() : base() { }

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