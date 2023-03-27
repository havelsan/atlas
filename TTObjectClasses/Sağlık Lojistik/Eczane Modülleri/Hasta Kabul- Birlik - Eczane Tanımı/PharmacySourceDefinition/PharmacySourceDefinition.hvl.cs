
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PharmacySourceDefinition")] 

    /// <summary>
    /// Hasta Kabul- Birlik - Eczane Tanımı
    /// </summary>
    public  partial class PharmacySourceDefinition : TTDefinitionSet
    {
        public class PharmacySourceDefinitionList : TTObjectCollection<PharmacySourceDefinition> { }
                    
        public class ChildPharmacySourceDefinitionCollection : TTObject.TTChildObjectCollection<PharmacySourceDefinition>
        {
            public ChildPharmacySourceDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPharmacySourceDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPharmacySourceDefinition_Class : TTReportNqlObject 
        {
            public PatientGroupEnum? PatientGroup
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTGROUP"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSOURCEDEFINITION"].AllPropertyDefs["PATIENTGROUP"].DataType;
                    return (PatientGroupEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public GetPharmacySourceDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPharmacySourceDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPharmacySourceDefinition_Class() : base() { }
        }

        public static BindingList<PharmacySourceDefinition> GetPharmacySourceDefinitionByPatientGroup(TTObjectContext objectContext, int PATIENTGROUP)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSOURCEDEFINITION"].QueryDefs["GetPharmacySourceDefinitionByPatientGroup"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PATIENTGROUP", PATIENTGROUP);

            return ((ITTQuery)objectContext).QueryObjects<PharmacySourceDefinition>(queryDef, paramList);
        }

        public static BindingList<PharmacySourceDefinition.GetPharmacySourceDefinition_Class> GetPharmacySourceDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSOURCEDEFINITION"].QueryDefs["GetPharmacySourceDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PharmacySourceDefinition.GetPharmacySourceDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PharmacySourceDefinition.GetPharmacySourceDefinition_Class> GetPharmacySourceDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHARMACYSOURCEDEFINITION"].QueryDefs["GetPharmacySourceDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PharmacySourceDefinition.GetPharmacySourceDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Hasta Grubu
    /// </summary>
        public PatientGroupEnum? PatientGroup
        {
            get { return (PatientGroupEnum?)(int?)this["PATIENTGROUP"]; }
            set { this["PATIENTGROUP"] = value; }
        }

    /// <summary>
    /// Bütün Birlikler için
    /// </summary>
        public bool? AllMilitaryUnit
        {
            get { return (bool?)this["ALLMILITARYUNIT"]; }
            set { this["ALLMILITARYUNIT"] = value; }
        }

        virtual protected void CreatePharmacySourceMilitaryUnitsCollection()
        {
            _PharmacySourceMilitaryUnits = new PharmacySourceMilitaryUnit.ChildPharmacySourceMilitaryUnitCollection(this, new Guid("4cf0f3f0-bbfe-4735-9f97-128be7a0d931"));
            ((ITTChildObjectCollection)_PharmacySourceMilitaryUnits).GetChildren();
        }

        protected PharmacySourceMilitaryUnit.ChildPharmacySourceMilitaryUnitCollection _PharmacySourceMilitaryUnits = null;
        public PharmacySourceMilitaryUnit.ChildPharmacySourceMilitaryUnitCollection PharmacySourceMilitaryUnits
        {
            get
            {
                if (_PharmacySourceMilitaryUnits == null)
                    CreatePharmacySourceMilitaryUnitsCollection();
                return _PharmacySourceMilitaryUnits;
            }
        }

        protected PharmacySourceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PharmacySourceDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PharmacySourceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PharmacySourceDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PharmacySourceDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHARMACYSOURCEDEFINITION", dataRow) { }
        protected PharmacySourceDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHARMACYSOURCEDEFINITION", dataRow, isImported) { }
        public PharmacySourceDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PharmacySourceDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PharmacySourceDefinition() : base() { }

    }
}