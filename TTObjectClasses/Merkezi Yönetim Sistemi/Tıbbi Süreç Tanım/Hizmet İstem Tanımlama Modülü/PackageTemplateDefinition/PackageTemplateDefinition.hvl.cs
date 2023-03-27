
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PackageTemplateDefinition")] 

    /// <summary>
    /// Paketi Hizmet İstem Template Tanımlama
    /// </summary>
    public  partial class PackageTemplateDefinition : TTDefinitionSet
    {
        public class PackageTemplateDefinitionList : TTObjectCollection<PackageTemplateDefinition> { }
                    
        public class ChildPackageTemplateDefinitionCollection : TTObject.TTChildObjectCollection<PackageTemplateDefinition>
        {
            public ChildPackageTemplateDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPackageTemplateDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPackageTemplate_Class : TTReportNqlObject 
        {
            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PACKAGETEMPLATEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public GetPackageTemplate_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPackageTemplate_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPackageTemplate_Class() : base() { }
        }

    /// <summary>
    /// Kişiye göre Paket Listesi
    /// </summary>
        public static BindingList<PackageTemplateDefinition> GetPackageTemplatesByUser(TTObjectContext objectContext, Guid OBJECTID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PACKAGETEMPLATEDEFINITION"].QueryDefs["GetPackageTemplatesByUser"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return ((ITTQuery)objectContext).QueryObjects<PackageTemplateDefinition>(queryDef, paramList);
        }

        public static BindingList<PackageTemplateDefinition.GetPackageTemplate_Class> GetPackageTemplate(Guid PACKAGEOWNERID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PACKAGETEMPLATEDEFINITION"].QueryDefs["GetPackageTemplate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PACKAGEOWNERID", PACKAGEOWNERID);

            return TTReportNqlObject.QueryObjects<PackageTemplateDefinition.GetPackageTemplate_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PackageTemplateDefinition.GetPackageTemplate_Class> GetPackageTemplate(TTObjectContext objectContext, Guid PACKAGEOWNERID, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PACKAGETEMPLATEDEFINITION"].QueryDefs["GetPackageTemplate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PACKAGEOWNERID", PACKAGEOWNERID);

            return TTReportNqlObject.QueryObjects<PackageTemplateDefinition.GetPackageTemplate_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
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
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string Name_Shadow
        {
            get { return (string)this["NAME_SHADOW"]; }
        }

    /// <summary>
    /// Paketi Oluşturan Kaynak Bilgisi
    /// </summary>
        public Resource PackageOwnerResource
        {
            get { return (Resource)((ITTObject)this).GetParent("PACKAGEOWNERRESOURCE"); }
            set { this["PACKAGEOWNERRESOURCE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreatePackageTemplateICDsCollection()
        {
            _PackageTemplateICDs = new PackageTemplateICDDetailDefinition.ChildPackageTemplateICDDetailDefinitionCollection(this, new Guid("5128b9c8-bd1d-4cef-969a-c797526bc182"));
            ((ITTChildObjectCollection)_PackageTemplateICDs).GetChildren();
        }

        protected PackageTemplateICDDetailDefinition.ChildPackageTemplateICDDetailDefinitionCollection _PackageTemplateICDs = null;
        public PackageTemplateICDDetailDefinition.ChildPackageTemplateICDDetailDefinitionCollection PackageTemplateICDs
        {
            get
            {
                if (_PackageTemplateICDs == null)
                    CreatePackageTemplateICDsCollection();
                return _PackageTemplateICDs;
            }
        }

        virtual protected void CreateProcedureRequestFormDetailDefinitionsCollection()
        {
            _ProcedureRequestFormDetailDefinitions = new PackageTemplateProcReqFormDetailDefinition.ChildPackageTemplateProcReqFormDetailDefinitionCollection(this, new Guid("e0a8284f-7ab0-48b3-a4b7-29f42f199d6e"));
            ((ITTChildObjectCollection)_ProcedureRequestFormDetailDefinitions).GetChildren();
        }

        protected PackageTemplateProcReqFormDetailDefinition.ChildPackageTemplateProcReqFormDetailDefinitionCollection _ProcedureRequestFormDetailDefinitions = null;
        public PackageTemplateProcReqFormDetailDefinition.ChildPackageTemplateProcReqFormDetailDefinitionCollection ProcedureRequestFormDetailDefinitions
        {
            get
            {
                if (_ProcedureRequestFormDetailDefinitions == null)
                    CreateProcedureRequestFormDetailDefinitionsCollection();
                return _ProcedureRequestFormDetailDefinitions;
            }
        }

        virtual protected void CreateProcedureDefinitionsCollection()
        {
            _ProcedureDefinitions = new PackageTemplateProcedureDefinition.ChildPackageTemplateProcedureDefinitionCollection(this, new Guid("752c603c-afb1-4585-8308-578d60d3a6e2"));
            ((ITTChildObjectCollection)_ProcedureDefinitions).GetChildren();
        }

        protected PackageTemplateProcedureDefinition.ChildPackageTemplateProcedureDefinitionCollection _ProcedureDefinitions = null;
        public PackageTemplateProcedureDefinition.ChildPackageTemplateProcedureDefinitionCollection ProcedureDefinitions
        {
            get
            {
                if (_ProcedureDefinitions == null)
                    CreateProcedureDefinitionsCollection();
                return _ProcedureDefinitions;
            }
        }

        virtual protected void CreateEtkinMaddesCollection()
        {
            _EtkinMaddes = new PackageTemplateEtkinMadDef.ChildPackageTemplateEtkinMadDefCollection(this, new Guid("e615aa7c-266c-46f5-a59a-35df64c5b9ea"));
            ((ITTChildObjectCollection)_EtkinMaddes).GetChildren();
        }

        protected PackageTemplateEtkinMadDef.ChildPackageTemplateEtkinMadDefCollection _EtkinMaddes = null;
        public PackageTemplateEtkinMadDef.ChildPackageTemplateEtkinMadDefCollection EtkinMaddes
        {
            get
            {
                if (_EtkinMaddes == null)
                    CreateEtkinMaddesCollection();
                return _EtkinMaddes;
            }
        }

        protected PackageTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PackageTemplateDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PackageTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PackageTemplateDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PackageTemplateDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PACKAGETEMPLATEDEFINITION", dataRow) { }
        protected PackageTemplateDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PACKAGETEMPLATEDEFINITION", dataRow, isImported) { }
        public PackageTemplateDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PackageTemplateDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PackageTemplateDefinition() : base() { }

    }
}