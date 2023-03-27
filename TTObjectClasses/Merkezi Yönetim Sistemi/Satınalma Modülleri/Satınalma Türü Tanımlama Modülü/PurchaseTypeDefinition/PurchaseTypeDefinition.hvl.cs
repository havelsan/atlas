
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PurchaseTypeDefinition")] 

    public  partial class PurchaseTypeDefinition : TerminologyManagerDef
    {
        public class PurchaseTypeDefinitionList : TTObjectCollection<PurchaseTypeDefinition> { }
                    
        public class ChildPurchaseTypeDefinitionCollection : TTObject.TTChildObjectCollection<PurchaseTypeDefinition>
        {
            public ChildPurchaseTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPurchaseTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PurchaseTypeDefFormNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string PurchaseTypeName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASETYPENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASETYPEDEFINITION"].AllPropertyDefs["PURCHASETYPENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PurchaseMainTypeEnum? PurchaseMainType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PURCHASEMAINTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASETYPEDEFINITION"].AllPropertyDefs["PURCHASEMAINTYPE"].DataType;
                    return (PurchaseMainTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? NeedsAnnouncement
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEEDSANNOUNCEMENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASETYPEDEFINITION"].AllPropertyDefs["NEEDSANNOUNCEMENT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? NeedsSufficiency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEEDSSUFFICIENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASETYPEDEFINITION"].AllPropertyDefs["NEEDSSUFFICIENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? FirmInvite
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FIRMINVITE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PURCHASETYPEDEFINITION"].AllPropertyDefs["FIRMINVITE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public PurchaseTypeDefFormNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PurchaseTypeDefFormNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PurchaseTypeDefFormNQL_Class() : base() { }
        }

        public static BindingList<PurchaseTypeDefinition.PurchaseTypeDefFormNQL_Class> PurchaseTypeDefFormNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASETYPEDEFINITION"].QueryDefs["PurchaseTypeDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PurchaseTypeDefinition.PurchaseTypeDefFormNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PurchaseTypeDefinition.PurchaseTypeDefFormNQL_Class> PurchaseTypeDefFormNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASETYPEDEFINITION"].QueryDefs["PurchaseTypeDefFormNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PurchaseTypeDefinition.PurchaseTypeDefFormNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PurchaseTypeDefinition> GetPurchaseTypeDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PURCHASETYPEDEFINITION"].QueryDefs["GetPurchaseTypeDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PurchaseTypeDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// İlan İhaleden Geçmesi Zorunludur
    /// </summary>
        public bool? NeedsAnnouncement
        {
            get { return (bool?)this["NEEDSANNOUNCEMENT"]; }
            set { this["NEEDSANNOUNCEMENT"] = value; }
        }

    /// <summary>
    /// Alım Türü
    /// </summary>
        public string PurchaseTypeName
        {
            get { return (string)this["PURCHASETYPENAME"]; }
            set { this["PURCHASETYPENAME"] = value; }
        }

    /// <summary>
    /// Firma Davet Edilir
    /// </summary>
        public bool? FirmInvite
        {
            get { return (bool?)this["FIRMINVITE"]; }
            set { this["FIRMINVITE"] = value; }
        }

    /// <summary>
    /// Satınalma Şekli
    /// </summary>
        public PurchaseMainTypeEnum? PurchaseMainType
        {
            get { return (PurchaseMainTypeEnum?)(int?)this["PURCHASEMAINTYPE"]; }
            set { this["PURCHASEMAINTYPE"] = value; }
        }

    /// <summary>
    /// Yeterlilikten Geçmesi Zorunludur
    /// </summary>
        public bool? NeedsSufficiency
        {
            get { return (bool?)this["NEEDSSUFFICIENCY"]; }
            set { this["NEEDSSUFFICIENCY"] = value; }
        }

        public string PurchaseTypeName_Shadow
        {
            get { return (string)this["PURCHASETYPENAME_SHADOW"]; }
        }

        virtual protected void CreateFirmDocumentsCollection()
        {
            _FirmDocuments = new FirmDocument.ChildFirmDocumentCollection(this, new Guid("2c328cc1-ce89-4de8-b8c2-c081b5369427"));
            ((ITTChildObjectCollection)_FirmDocuments).GetChildren();
        }

        protected FirmDocument.ChildFirmDocumentCollection _FirmDocuments = null;
        public FirmDocument.ChildFirmDocumentCollection FirmDocuments
        {
            get
            {
                if (_FirmDocuments == null)
                    CreateFirmDocumentsCollection();
                return _FirmDocuments;
            }
        }

        protected PurchaseTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PurchaseTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PurchaseTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PurchaseTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PurchaseTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PURCHASETYPEDEFINITION", dataRow) { }
        protected PurchaseTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PURCHASETYPEDEFINITION", dataRow, isImported) { }
        public PurchaseTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PurchaseTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PurchaseTypeDefinition() : base() { }

    }
}