
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ProcedureRequestFormDefinition")] 

    /// <summary>
    /// Hizmet İstek Ekranları Tanımı
    /// </summary>
    public  partial class ProcedureRequestFormDefinition : TTDefinitionSet
    {
        public class ProcedureRequestFormDefinitionList : TTObjectCollection<ProcedureRequestFormDefinition> { }
                    
        public class ChildProcedureRequestFormDefinitionCollection : TTObject.TTChildObjectCollection<ProcedureRequestFormDefinition>
        {
            public ChildProcedureRequestFormDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildProcedureRequestFormDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetProcedureRequestForm_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? OrderNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORDERNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTFORMDEFINITION"].AllPropertyDefs["ORDERNO"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTFORMDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTFORMDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetProcedureRequestForm_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetProcedureRequestForm_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetProcedureRequestForm_Class() : base() { }
        }

        public static BindingList<ProcedureRequestFormDefinition.GetProcedureRequestForm_Class> GetProcedureRequestForm(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTFORMDEFINITION"].QueryDefs["GetProcedureRequestForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureRequestFormDefinition.GetProcedureRequestForm_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedureRequestFormDefinition.GetProcedureRequestForm_Class> GetProcedureRequestForm(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTFORMDEFINITION"].QueryDefs["GetProcedureRequestForm"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ProcedureRequestFormDefinition.GetProcedureRequestForm_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ProcedureRequestFormDefinition> GetForms(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREREQUESTFORMDEFINITION"].QueryDefs["GetForms"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<ProcedureRequestFormDefinition>(queryDef, paramList, injectionSQL);
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
    /// Formun Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Katologun hangi sirada gorulecegini belirler.
    /// </summary>
        public int? OrderNo
        {
            get { return (int?)this["ORDERNO"]; }
            set { this["ORDERNO"] = value; }
        }

        public ResObservationUnit ObservationUnit
        {
            get { return (ResObservationUnit)((ITTObject)this).GetParent("OBSERVATIONUNIT"); }
            set { this["OBSERVATIONUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateRequestUnitsOfProcedureFormCollection()
        {
            _RequestUnitsOfProcedureForm = new RequestUnitOfProcedureForm.ChildRequestUnitOfProcedureFormCollection(this, new Guid("02e55fb7-706f-4424-a319-057a924ee456"));
            ((ITTChildObjectCollection)_RequestUnitsOfProcedureForm).GetChildren();
        }

        protected RequestUnitOfProcedureForm.ChildRequestUnitOfProcedureFormCollection _RequestUnitsOfProcedureForm = null;
    /// <summary>
    /// Child collection for Tetkik İstem Formu Yetkili Birimleri
    /// </summary>
        public RequestUnitOfProcedureForm.ChildRequestUnitOfProcedureFormCollection RequestUnitsOfProcedureForm
        {
            get
            {
                if (_RequestUnitsOfProcedureForm == null)
                    CreateRequestUnitsOfProcedureFormCollection();
                return _RequestUnitsOfProcedureForm;
            }
        }

        virtual protected void CreateFormCategoryCollection()
        {
            _FormCategory = new ProcedureRequestCategoryDefinition.ChildProcedureRequestCategoryDefinitionCollection(this, new Guid("e0d07d41-fec7-4787-a28e-26ba80425231"));
            ((ITTChildObjectCollection)_FormCategory).GetChildren();
        }

        protected ProcedureRequestCategoryDefinition.ChildProcedureRequestCategoryDefinitionCollection _FormCategory = null;
        public ProcedureRequestCategoryDefinition.ChildProcedureRequestCategoryDefinitionCollection FormCategory
        {
            get
            {
                if (_FormCategory == null)
                    CreateFormCategoryCollection();
                return _FormCategory;
            }
        }

        protected ProcedureRequestFormDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ProcedureRequestFormDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ProcedureRequestFormDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ProcedureRequestFormDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ProcedureRequestFormDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PROCEDUREREQUESTFORMDEFINITION", dataRow) { }
        protected ProcedureRequestFormDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PROCEDUREREQUESTFORMDEFINITION", dataRow, isImported) { }
        public ProcedureRequestFormDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ProcedureRequestFormDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ProcedureRequestFormDefinition() : base() { }

    }
}