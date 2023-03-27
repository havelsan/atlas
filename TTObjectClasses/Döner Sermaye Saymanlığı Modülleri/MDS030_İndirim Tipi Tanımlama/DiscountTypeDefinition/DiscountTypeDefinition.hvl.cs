
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="DiscountTypeDefinition")] 

    /// <summary>
    /// İndirim Tipi Tanımlama
    /// </summary>
    public  partial class DiscountTypeDefinition : TerminologyManagerDef
    {
        public class DiscountTypeDefinitionList : TTObjectCollection<DiscountTypeDefinition> { }
                    
        public class ChildDiscountTypeDefinitionCollection : TTObject.TTChildObjectCollection<DiscountTypeDefinition>
        {
            public ChildDiscountTypeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildDiscountTypeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetDiscountTypeDefinitions_Class : TTReportNqlObject 
        {
            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISCOUNTTYPEDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Description
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISCOUNTTYPEDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetDiscountTypeDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetDiscountTypeDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetDiscountTypeDefinitions_Class() : base() { }
        }

        public static BindingList<DiscountTypeDefinition.GetDiscountTypeDefinitions_Class> GetDiscountTypeDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISCOUNTTYPEDEFINITION"].QueryDefs["GetDiscountTypeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DiscountTypeDefinition.GetDiscountTypeDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiscountTypeDefinition.GetDiscountTypeDefinitions_Class> GetDiscountTypeDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISCOUNTTYPEDEFINITION"].QueryDefs["GetDiscountTypeDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<DiscountTypeDefinition.GetDiscountTypeDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<DiscountTypeDefinition> GetDiscountTypeDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["DISCOUNTTYPEDEFINITION"].QueryDefs["GetDiscountTypeDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<DiscountTypeDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Kod
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Açıklama Gölgesi
    /// </summary>
        public string Description_Shadow
        {
            get { return (string)this["DESCRIPTION_SHADOW"]; }
        }

    /// <summary>
    /// Açıklama
    /// </summary>
        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        virtual protected void CreateReceiptCollection()
        {
            _Receipt = new Receipt.ChildReceiptCollection(this, new Guid("0104be79-af38-4703-8d09-0da22b53a8c1"));
            ((ITTChildObjectCollection)_Receipt).GetChildren();
        }

        protected Receipt.ChildReceiptCollection _Receipt = null;
    /// <summary>
    /// Child collection for İndirim Tipleriyle ilişki
    /// </summary>
        public Receipt.ChildReceiptCollection Receipt
        {
            get
            {
                if (_Receipt == null)
                    CreateReceiptCollection();
                return _Receipt;
            }
        }

        virtual protected void CreateProcedureExceptionsCollection()
        {
            _ProcedureExceptions = new DiscountTypeProcedureExceptionDefinition.ChildDiscountTypeProcedureExceptionDefinitionCollection(this, new Guid("1dd6d84a-968c-409f-8f29-2e59f41422f2"));
            ((ITTChildObjectCollection)_ProcedureExceptions).GetChildren();
        }

        protected DiscountTypeProcedureExceptionDefinition.ChildDiscountTypeProcedureExceptionDefinitionCollection _ProcedureExceptions = null;
    /// <summary>
    /// Child collection for İndirim Tipi Tanımı ile ilişki
    /// </summary>
        public DiscountTypeProcedureExceptionDefinition.ChildDiscountTypeProcedureExceptionDefinitionCollection ProcedureExceptions
        {
            get
            {
                if (_ProcedureExceptions == null)
                    CreateProcedureExceptionsCollection();
                return _ProcedureExceptions;
            }
        }

        virtual protected void CreateMaterialGroupsCollection()
        {
            _MaterialGroups = new DiscountTypeMaterialGroupDefinition.ChildDiscountTypeMaterialGroupDefinitionCollection(this, new Guid("80f58755-433f-480a-b095-47fdd4dc01ec"));
            ((ITTChildObjectCollection)_MaterialGroups).GetChildren();
        }

        protected DiscountTypeMaterialGroupDefinition.ChildDiscountTypeMaterialGroupDefinitionCollection _MaterialGroups = null;
    /// <summary>
    /// Child collection for İndirim Tipi Tanımı ile ilişki
    /// </summary>
        public DiscountTypeMaterialGroupDefinition.ChildDiscountTypeMaterialGroupDefinitionCollection MaterialGroups
        {
            get
            {
                if (_MaterialGroups == null)
                    CreateMaterialGroupsCollection();
                return _MaterialGroups;
            }
        }

        virtual protected void CreatePayerInvoiceCollection()
        {
            _PayerInvoice = new PayerInvoice.ChildPayerInvoiceCollection(this, new Guid("f2f68568-a8ae-4c42-9d5a-7b75d2896227"));
            ((ITTChildObjectCollection)_PayerInvoice).GetChildren();
        }

        protected PayerInvoice.ChildPayerInvoiceCollection _PayerInvoice = null;
    /// <summary>
    /// Child collection for İndirim Tipi Tanımlarıyla İlişki
    /// </summary>
        public PayerInvoice.ChildPayerInvoiceCollection PayerInvoice
        {
            get
            {
                if (_PayerInvoice == null)
                    CreatePayerInvoiceCollection();
                return _PayerInvoice;
            }
        }

        virtual protected void CreateProcedureGroupsCollection()
        {
            _ProcedureGroups = new DiscountTypeProcedureGroupDefinition.ChildDiscountTypeProcedureGroupDefinitionCollection(this, new Guid("16b90737-52f3-42bb-95ae-b8efa905a1e7"));
            ((ITTChildObjectCollection)_ProcedureGroups).GetChildren();
        }

        protected DiscountTypeProcedureGroupDefinition.ChildDiscountTypeProcedureGroupDefinitionCollection _ProcedureGroups = null;
    /// <summary>
    /// Child collection for İndirim Tipi Tanımı ile ilişki
    /// </summary>
        public DiscountTypeProcedureGroupDefinition.ChildDiscountTypeProcedureGroupDefinitionCollection ProcedureGroups
        {
            get
            {
                if (_ProcedureGroups == null)
                    CreateProcedureGroupsCollection();
                return _ProcedureGroups;
            }
        }

        virtual protected void CreateMaterialExceptionsCollection()
        {
            _MaterialExceptions = new DiscountTypeMaterialExceptionDefinition.ChildDiscountTypeMaterialExceptionDefinitionCollection(this, new Guid("b8b16eaa-a790-4c12-a671-c212bcd7d349"));
            ((ITTChildObjectCollection)_MaterialExceptions).GetChildren();
        }

        protected DiscountTypeMaterialExceptionDefinition.ChildDiscountTypeMaterialExceptionDefinitionCollection _MaterialExceptions = null;
    /// <summary>
    /// Child collection for İndirim Tipi Tanımı ile ilişki
    /// </summary>
        public DiscountTypeMaterialExceptionDefinition.ChildDiscountTypeMaterialExceptionDefinitionCollection MaterialExceptions
        {
            get
            {
                if (_MaterialExceptions == null)
                    CreateMaterialExceptionsCollection();
                return _MaterialExceptions;
            }
        }

        protected DiscountTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected DiscountTypeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected DiscountTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected DiscountTypeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected DiscountTypeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "DISCOUNTTYPEDEFINITION", dataRow) { }
        protected DiscountTypeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "DISCOUNTTYPEDEFINITION", dataRow, isImported) { }
        protected DiscountTypeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public DiscountTypeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public DiscountTypeDefinition() : base() { }

    }
}