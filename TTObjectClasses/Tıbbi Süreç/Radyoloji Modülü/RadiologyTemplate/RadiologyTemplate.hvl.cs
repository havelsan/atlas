
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadiologyTemplate")] 

    public  partial class RadiologyTemplate : TTObject
    {
        public class RadiologyTemplateList : TTObjectCollection<RadiologyTemplate> { }
                    
        public class ChildRadiologyTemplateCollection : TTObject.TTChildObjectCollection<RadiologyTemplate>
        {
            public ChildRadiologyTemplateCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadiologyTemplateCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRadiologyTemplates_Class : TTReportNqlObject 
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

            public object Report
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEMPLATE"].AllPropertyDefs["REPORT"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object RadiographyTechnique
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RADIOGRAPHYTECHNIQUE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEMPLATE"].AllPropertyDefs["RADIOGRAPHYTECHNIQUE"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object Results
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RESULTS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEMPLATE"].AllPropertyDefs["RESULTS"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public object ComparisonInfo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPARISONINFO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEMPLATE"].AllPropertyDefs["COMPARISONINFO"].DataType;
                    return (object)dataType.ConvertValue(val);
                }
            }

            public string TemplateName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TEMPLATENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEMPLATE"].AllPropertyDefs["TEMPLATENAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsActive
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEMPLATE"].AllPropertyDefs["ISACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEMPLATE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public GetRadiologyTemplates_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRadiologyTemplates_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRadiologyTemplates_Class() : base() { }
        }

        public static BindingList<RadiologyTemplate> CheckRadiologyTemplates(TTObjectContext objectContext, Guid DOCTORID, Guid RADIOLOGYTESTDEFID)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEMPLATE"].QueryDefs["CheckRadiologyTemplates"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("DOCTORID", DOCTORID);
            paramList.Add("RADIOLOGYTESTDEFID", RADIOLOGYTESTDEFID);

            return ((ITTQuery)objectContext).QueryObjects<RadiologyTemplate>(queryDef, paramList);
        }

        public static BindingList<RadiologyTemplate.GetRadiologyTemplates_Class> GetRadiologyTemplates(PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEMPLATE"].QueryDefs["GetRadiologyTemplates"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTemplate.GetRadiologyTemplates_Class>(queryDef, paramList, pi);
        }

        public static BindingList<RadiologyTemplate.GetRadiologyTemplates_Class> GetRadiologyTemplates(TTObjectContext objectContext, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOLOGYTEMPLATE"].QueryDefs["GetRadiologyTemplates"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadiologyTemplate.GetRadiologyTemplates_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Rapor
    /// </summary>
        public object Report
        {
            get { return (object)this["REPORT"]; }
            set { this["REPORT"] = value; }
        }

    /// <summary>
    /// Çekim Tekniği
    /// </summary>
        public object RadiographyTechnique
        {
            get { return (object)this["RADIOGRAPHYTECHNIQUE"]; }
            set { this["RADIOGRAPHYTECHNIQUE"] = value; }
        }

    /// <summary>
    /// Bulgular
    /// </summary>
        public object Results
        {
            get { return (object)this["RESULTS"]; }
            set { this["RESULTS"] = value; }
        }

    /// <summary>
    /// Karşılaştırma Bilgisi
    /// </summary>
        public object ComparisonInfo
        {
            get { return (object)this["COMPARISONINFO"]; }
            set { this["COMPARISONINFO"] = value; }
        }

    /// <summary>
    /// Şablon Adı
    /// </summary>
        public string TemplateName
        {
            get { return (string)this["TEMPLATENAME"]; }
            set { this["TEMPLATENAME"] = value; }
        }

        public bool? IsActive
        {
            get { return (bool?)this["ISACTIVE"]; }
            set { this["ISACTIVE"] = value; }
        }

        public DateTime? CreationDate
        {
            get { return (DateTime?)this["CREATIONDATE"]; }
            set { this["CREATIONDATE"] = value; }
        }

        virtual protected void CreateRadiologyTempProceduresCollection()
        {
            _RadiologyTempProcedures = new RadiologyTempProcedures.ChildRadiologyTempProceduresCollection(this, new Guid("eec9da8b-fa89-4ec5-a616-3bf0e29556b8"));
            ((ITTChildObjectCollection)_RadiologyTempProcedures).GetChildren();
        }

        protected RadiologyTempProcedures.ChildRadiologyTempProceduresCollection _RadiologyTempProcedures = null;
        public RadiologyTempProcedures.ChildRadiologyTempProceduresCollection RadiologyTempProcedures
        {
            get
            {
                if (_RadiologyTempProcedures == null)
                    CreateRadiologyTempProceduresCollection();
                return _RadiologyTempProcedures;
            }
        }

        virtual protected void CreateRadiologyTempDoctorsCollection()
        {
            _RadiologyTempDoctors = new RadiologyTempDoctors.ChildRadiologyTempDoctorsCollection(this, new Guid("e0100710-e09e-4a7a-8fc7-ed16deee5b12"));
            ((ITTChildObjectCollection)_RadiologyTempDoctors).GetChildren();
        }

        protected RadiologyTempDoctors.ChildRadiologyTempDoctorsCollection _RadiologyTempDoctors = null;
        public RadiologyTempDoctors.ChildRadiologyTempDoctorsCollection RadiologyTempDoctors
        {
            get
            {
                if (_RadiologyTempDoctors == null)
                    CreateRadiologyTempDoctorsCollection();
                return _RadiologyTempDoctors;
            }
        }

        protected RadiologyTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadiologyTemplate(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadiologyTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadiologyTemplate(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadiologyTemplate(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOLOGYTEMPLATE", dataRow) { }
        protected RadiologyTemplate(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOLOGYTEMPLATE", dataRow, isImported) { }
        public RadiologyTemplate(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadiologyTemplate(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadiologyTemplate() : base() { }

    }
}