
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="RadioPharmaceuticalDefinition")] 

    /// <summary>
    /// Radyofarmasötik Malzeme Tanımlama
    /// </summary>
    public  partial class RadioPharmaceuticalDefinition : TerminologyManagerDef
    {
        public class RadioPharmaceuticalDefinitionList : TTObjectCollection<RadioPharmaceuticalDefinition> { }
                    
        public class ChildRadioPharmaceuticalDefinitionCollection : TTObject.TTChildObjectCollection<RadioPharmaceuticalDefinition>
        {
            public ChildRadioPharmaceuticalDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildRadioPharmaceuticalDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetRadioPharmaReportNQL_Class : TTReportNqlObject 
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOPHARMACEUTICALDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOPHARMACEUTICALDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string OriginalName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ORIGINALNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOPHARMACEUTICALDEFINITION"].AllPropertyDefs["ORIGINALNAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RADIOPHARMACEUTICALDEFINITION"].AllPropertyDefs["DESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetRadioPharmaReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRadioPharmaReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRadioPharmaReportNQL_Class() : base() { }
        }

        public static BindingList<RadioPharmaceuticalDefinition> GetRadioPharmaceuticalDByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOPHARMACEUTICALDEFINITION"].QueryDefs["GetRadioPharmaceuticalDByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<RadioPharmaceuticalDefinition>(queryDef, paramList);
        }

        public static BindingList<RadioPharmaceuticalDefinition.GetRadioPharmaReportNQL_Class> GetRadioPharmaReportNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOPHARMACEUTICALDEFINITION"].QueryDefs["GetRadioPharmaReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadioPharmaceuticalDefinition.GetRadioPharmaReportNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadioPharmaceuticalDefinition.GetRadioPharmaReportNQL_Class> GetRadioPharmaReportNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOPHARMACEUTICALDEFINITION"].QueryDefs["GetRadioPharmaReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<RadioPharmaceuticalDefinition.GetRadioPharmaReportNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<RadioPharmaceuticalDefinition> GetRadioPharmaceuricalDefs(TTObjectContext objectContext, string injectionSQL)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["RADIOPHARMACEUTICALDEFINITION"].QueryDefs["GetRadioPharmaceuricalDefs"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<RadioPharmaceuticalDefinition>(queryDef, paramList, injectionSQL);
        }

        public string Code
        {
            get { return (string)this["CODE"]; }
            set { this["CODE"] = value; }
        }

        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

        public string OriginalName
        {
            get { return (string)this["ORIGINALNAME"]; }
            set { this["ORIGINALNAME"] = value; }
        }

        public string Description
        {
            get { return (string)this["DESCRIPTION"]; }
            set { this["DESCRIPTION"] = value; }
        }

        virtual protected void CreateNuclearMedicinePharmGridsCollection()
        {
            _NuclearMedicinePharmGrids = new NuclearMedicineGridPharmDefinition.ChildNuclearMedicineGridPharmDefinitionCollection(this, new Guid("36d890dd-a7e3-4cb1-9c7d-e85b33b6db2a"));
            ((ITTChildObjectCollection)_NuclearMedicinePharmGrids).GetChildren();
        }

        protected NuclearMedicineGridPharmDefinition.ChildNuclearMedicineGridPharmDefinitionCollection _NuclearMedicinePharmGrids = null;
    /// <summary>
    /// Child collection for Radyofarmosötik Malzeme
    /// </summary>
        public NuclearMedicineGridPharmDefinition.ChildNuclearMedicineGridPharmDefinitionCollection NuclearMedicinePharmGrids
        {
            get
            {
                if (_NuclearMedicinePharmGrids == null)
                    CreateNuclearMedicinePharmGridsCollection();
                return _NuclearMedicinePharmGrids;
            }
        }

        protected RadioPharmaceuticalDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected RadioPharmaceuticalDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected RadioPharmaceuticalDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected RadioPharmaceuticalDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected RadioPharmaceuticalDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "RADIOPHARMACEUTICALDEFINITION", dataRow) { }
        protected RadioPharmaceuticalDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "RADIOPHARMACEUTICALDEFINITION", dataRow, isImported) { }
        public RadioPharmaceuticalDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public RadioPharmaceuticalDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public RadioPharmaceuticalDefinition() : base() { }

    }
}