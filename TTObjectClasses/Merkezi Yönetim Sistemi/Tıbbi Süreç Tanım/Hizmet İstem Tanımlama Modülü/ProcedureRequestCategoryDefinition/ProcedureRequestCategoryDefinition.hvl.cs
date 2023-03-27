
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureRequestCategoryDefinition")] 

    /// <summary>
    /// Hizmet İstek Ekranları Kategorileri
    /// </summary>
    public  partial class ProcedureRequestCategoryDefinition : TTDefinitionSet
    {
        public class ProcedureRequestCategoryDefinitionList : TTObjectCollection<ProcedureRequestCategoryDefinition> { }
                    
        public class ChildProcedureRequestCategoryDefinitionCollection : TTObject.TTChildObjectCollection<ProcedureRequestCategoryDefinition>
        {
            public ChildProcedureRequestCategoryDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureRequestCategoryDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProcedureReqCategory_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public Guid? ObjectDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTDEFID"]);
                }
            }

            public Guid? CurrentStateDefID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["CURRENTSTATEDEFID"]);
                }
            }

            public Boolean? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    return (Boolean)Convert.ChangeType(val, typeof(Boolean)); 
                }
            }

            public DateTime? LastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LASTUPDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTCATEGORYDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string CategoryName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CATEGORYNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTCATEGORYDEFINITION"].AllPropertyDefs["CATEGORYNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTCATEGORYDEFINITION"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public bool? IsPassiveNow
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPASSIVENOW"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTCATEGORYDEFINITION"].AllPropertyDefs["ISPASSIVENOW"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonForPassive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONFORPASSIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTCATEGORYDEFINITION"].AllPropertyDefs["REASONFORPASSIVE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProcedureReqCategory_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcedureReqCategory_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcedureReqCategory_Class() : base() { }
        }

        public static BindingList<ProcedureRequestCategoryDefinition.GetProcedureReqCategory_Class> GetProcedureReqCategory(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTCATEGORYDEFINITION"].QueryDefs["GetProcedureReqCategory"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureRequestCategoryDefinition.GetProcedureReqCategory_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedureRequestCategoryDefinition.GetProcedureReqCategory_Class> GetProcedureReqCategory(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTCATEGORYDEFINITION"].QueryDefs["GetProcedureReqCategory"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureRequestCategoryDefinition.GetProcedureReqCategory_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Kodu
    /// </summary>
        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

    /// <summary>
    /// Kategory Adı
    /// </summary>
        public string CategoryName
        {
            get { return (string)this["CATEGORYNAME"]; }
            set { this["CATEGORYNAME"] = value; }
        }

    /// <summary>
    /// Kategorinin hangi sirada gorunecegini belirler
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

    /// <summary>
    /// Pasif Kategori
    /// </summary>
        public bool? IsPassiveNow
        {
            get { return (bool?)this["ISPASSIVENOW"]; }
            set { this["ISPASSIVENOW"] = value; }
        }

    /// <summary>
    /// Çalışmama Nedeni
    /// </summary>
        public string ReasonForPassive
        {
            get { return (string)this["REASONFORPASSIVE"]; }
            set { this["REASONFORPASSIVE"] = value; }
        }

        public ProcedureRequestFormDefinition ProcedureRequestForm
        {
            get { return (ProcedureRequestFormDefinition)((ITTObject)this).GetParent("PROCEDUREREQUESTFORM"); }
            set { this["PROCEDUREREQUESTFORM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateFormDetailCollection()
        {
            _FormDetail = new ProcedureRequestFormDetailDefinition.ChildProcedureRequestFormDetailDefinitionCollection(this, new Guid("e3f1ca3a-3066-4397-a58a-f1ab5ece8ee9"));
            ((ITTChildObjectCollection)_FormDetail).GetChildren();
        }

        protected ProcedureRequestFormDetailDefinition.ChildProcedureRequestFormDetailDefinitionCollection _FormDetail = null;
        public ProcedureRequestFormDetailDefinition.ChildProcedureRequestFormDetailDefinitionCollection FormDetail
        {
            get
            {
                if (_FormDetail == null)
                    CreateFormDetailCollection();
                return _FormDetail;
            }
        }

        protected ProcedureRequestCategoryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureRequestCategoryDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureRequestCategoryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureRequestCategoryDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureRequestCategoryDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDUREREQUESTCATEGORYDEFINITION", dataRow) { }
        protected ProcedureRequestCategoryDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDUREREQUESTCATEGORYDEFINITION", dataRow, isImported) { }
        public ProcedureRequestCategoryDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureRequestCategoryDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureRequestCategoryDefinition() : base() { }

    }
}