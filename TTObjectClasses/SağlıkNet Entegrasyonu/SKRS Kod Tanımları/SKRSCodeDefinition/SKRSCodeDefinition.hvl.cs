
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="SKRSCodeDefinition")] 

    public  partial class SKRSCodeDefinition : TerminologyManagerDef
    {
        public class SKRSCodeDefinitionList : TTObjectCollection<SKRSCodeDefinition> { }
                    
        public class ChildSKRSCodeDefinitionCollection : TTObject.TTChildObjectCollection<SKRSCodeDefinition>
        {
            public ChildSKRSCodeDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildSKRSCodeDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetSKRSCodeDefinitionList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string SistemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SISTEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCODEDEFINITION"].AllPropertyDefs["SISTEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCODEDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SKRSCODEDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public GetSKRSCodeDefinitionList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetSKRSCodeDefinitionList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetSKRSCodeDefinitionList_Class() : base() { }
        }

        public static BindingList<SKRSCodeDefinition.GetSKRSCodeDefinitionList_Class> GetSKRSCodeDefinitionList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSCODEDEFINITION"].QueryDefs["GetSKRSCodeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSCodeDefinition.GetSKRSCodeDefinitionList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSCodeDefinition.GetSKRSCodeDefinitionList_Class> GetSKRSCodeDefinitionList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSCODEDEFINITION"].QueryDefs["GetSKRSCodeDefinitionList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<SKRSCodeDefinition.GetSKRSCodeDefinitionList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<SKRSCodeDefinition> GetSKRSDefinitions(TTObjectContext objectContext, Guid SYSTEMCODE, int CODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["SKRSCODEDEFINITION"].QueryDefs["GetSKRSDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SYSTEMCODE", SYSTEMCODE);
            paramList.Add("CODE", CODE);

            return ((ITTQuery)objectContext).QueryObjects<SKRSCodeDefinition>(queryDef, paramList);
        }

        public Guid? SystemCode
        {
            get { return (Guid?)this["SYSTEMCODE"]; }
            set { this["SYSTEMCODE"] = value; }
        }

        public string SistemName
        {
            get { return (string)this["SISTEMNAME"]; }
            set { this["SISTEMNAME"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public int? Code
        {
            get { return (int?)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        virtual protected void CreateSaglikNetProtokol_PTCollection()
        {
            _SaglikNetProtokol_PT = new SaglikNetProtokol.ChildSaglikNetProtokolCollection(this, new Guid("5c1439ee-78c8-4e23-80cd-d03aba5b6b06"));
            ((ITTChildObjectCollection)_SaglikNetProtokol_PT).GetChildren();
        }

        protected SaglikNetProtokol.ChildSaglikNetProtokolCollection _SaglikNetProtokol_PT = null;
        public SaglikNetProtokol.ChildSaglikNetProtokolCollection SaglikNetProtokol_PT
        {
            get
            {
                if (_SaglikNetProtokol_PT == null)
                    CreateSaglikNetProtokol_PTCollection();
                return _SaglikNetProtokol_PT;
            }
        }

        virtual protected void CreateSaglikNetProtokol_HTCollection()
        {
            _SaglikNetProtokol_HT = new SaglikNetProtokol.ChildSaglikNetProtokolCollection(this, new Guid("7d93c3cc-7f34-4fd1-bf3e-deddad433167"));
            ((ITTChildObjectCollection)_SaglikNetProtokol_HT).GetChildren();
        }

        protected SaglikNetProtokol.ChildSaglikNetProtokolCollection _SaglikNetProtokol_HT = null;
        public SaglikNetProtokol.ChildSaglikNetProtokolCollection SaglikNetProtokol_HT
        {
            get
            {
                if (_SaglikNetProtokol_HT == null)
                    CreateSaglikNetProtokol_HTCollection();
                return _SaglikNetProtokol_HT;
            }
        }

        virtual protected void CreateSaglikNetProtokol_KKCollection()
        {
            _SaglikNetProtokol_KK = new SaglikNetProtokol.ChildSaglikNetProtokolCollection(this, new Guid("29f8fc50-49df-4bea-ae52-5365f32d9a3b"));
            ((ITTChildObjectCollection)_SaglikNetProtokol_KK).GetChildren();
        }

        protected SaglikNetProtokol.ChildSaglikNetProtokolCollection _SaglikNetProtokol_KK = null;
        public SaglikNetProtokol.ChildSaglikNetProtokolCollection SaglikNetProtokol_KK
        {
            get
            {
                if (_SaglikNetProtokol_KK == null)
                    CreateSaglikNetProtokol_KKCollection();
                return _SaglikNetProtokol_KK;
            }
        }

        virtual protected void CreateResSectionCollection()
        {
            _ResSection = new ResSection.ChildResSectionCollection(this, new Guid("deeff2f6-899e-485d-8cc7-79e6b647d805"));
            ((ITTChildObjectCollection)_ResSection).GetChildren();
        }

        protected ResSection.ChildResSectionCollection _ResSection = null;
        public ResSection.ChildResSectionCollection ResSection
        {
            get
            {
                if (_ResSection == null)
                    CreateResSectionCollection();
                return _ResSection;
            }
        }

        protected SKRSCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected SKRSCodeDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected SKRSCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected SKRSCodeDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected SKRSCodeDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "SKRSCODEDEFINITION", dataRow) { }
        protected SKRSCodeDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "SKRSCODEDEFINITION", dataRow, isImported) { }
        public SKRSCodeDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public SKRSCodeDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public SKRSCodeDefinition() : base() { }

    }
}