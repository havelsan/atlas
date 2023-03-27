
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="HyperbaricOxygenTreatmentDefinition")] 

    /// <summary>
    /// Hiperbarik Oksijen Tedavi Tanımlama
    /// </summary>
    public  partial class HyperbaricOxygenTreatmentDefinition : ProcedureDefinition
    {
        public class HyperbaricOxygenTreatmentDefinitionList : TTObjectCollection<HyperbaricOxygenTreatmentDefinition> { }
                    
        public class ChildHyperbaricOxygenTreatmentDefinitionCollection : TTObject.TTChildObjectCollection<HyperbaricOxygenTreatmentDefinition>
        {
            public ChildHyperbaricOxygenTreatmentDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildHyperbaricOxygenTreatmentDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetHyperbaricOxygenTreatmentDefinition_Class : TTReportNqlObject 
        {
            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTDEFINITION"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Qref
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["QREF"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTDEFINITION"].AllPropertyDefs["QREF"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EnglishName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ENGLISHNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTDEFINITION"].AllPropertyDefs["ENGLISHNAME"].DataType;
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

            public GetHyperbaricOxygenTreatmentDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetHyperbaricOxygenTreatmentDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetHyperbaricOxygenTreatmentDefinition_Class() : base() { }
        }

        public static BindingList<HyperbaricOxygenTreatmentDefinition> GetHyperbaricOxygenTreatDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTDEFINITION"].QueryDefs["GetHyperbaricOxygenTreatDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<HyperbaricOxygenTreatmentDefinition>(queryDef, paramList);
        }

        public static BindingList<HyperbaricOxygenTreatmentDefinition.GetHyperbaricOxygenTreatmentDefinition_Class> GetHyperbaricOxygenTreatmentDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTDEFINITION"].QueryDefs["GetHyperbaricOxygenTreatmentDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HyperbaricOxygenTreatmentDefinition.GetHyperbaricOxygenTreatmentDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<HyperbaricOxygenTreatmentDefinition.GetHyperbaricOxygenTreatmentDefinition_Class> GetHyperbaricOxygenTreatmentDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["HYPERBARICOXYGENTREATMENTDEFINITION"].QueryDefs["GetHyperbaricOxygenTreatmentDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<HyperbaricOxygenTreatmentDefinition.GetHyperbaricOxygenTreatmentDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        virtual protected void CreateHyperbaricTreatmentEquipmentsCollection()
        {
            _HyperbaricTreatmentEquipments = new HyperbaricTreatmentEquipment.ChildHyperbaricTreatmentEquipmentCollection(this, new Guid("99e905fd-a5c6-44f4-87fb-ae1b3f11e916"));
            ((ITTChildObjectCollection)_HyperbaricTreatmentEquipments).GetChildren();
        }

        protected HyperbaricTreatmentEquipment.ChildHyperbaricTreatmentEquipmentCollection _HyperbaricTreatmentEquipments = null;
        public HyperbaricTreatmentEquipment.ChildHyperbaricTreatmentEquipmentCollection HyperbaricTreatmentEquipments
        {
            get
            {
                if (_HyperbaricTreatmentEquipments == null)
                    CreateHyperbaricTreatmentEquipmentsCollection();
                return _HyperbaricTreatmentEquipments;
            }
        }

        virtual protected void CreateTreatmentUnitsCollection()
        {
            _TreatmentUnits = new HyperbaricOxygenTreatmentUnitGrid.ChildHyperbaricOxygenTreatmentUnitGridCollection(this, new Guid("f9c87b6b-42c3-49c2-acb3-9902723983f5"));
            ((ITTChildObjectCollection)_TreatmentUnits).GetChildren();
        }

        protected HyperbaricOxygenTreatmentUnitGrid.ChildHyperbaricOxygenTreatmentUnitGridCollection _TreatmentUnits = null;
    /// <summary>
    /// Child collection for Tanı Tedavi Üniteleri
    /// </summary>
        public HyperbaricOxygenTreatmentUnitGrid.ChildHyperbaricOxygenTreatmentUnitGridCollection TreatmentUnits
        {
            get
            {
                if (_TreatmentUnits == null)
                    CreateTreatmentUnitsCollection();
                return _TreatmentUnits;
            }
        }

        protected HyperbaricOxygenTreatmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected HyperbaricOxygenTreatmentDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected HyperbaricOxygenTreatmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected HyperbaricOxygenTreatmentDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected HyperbaricOxygenTreatmentDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "HYPERBARICOXYGENTREATMENTDEFINITION", dataRow) { }
        protected HyperbaricOxygenTreatmentDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "HYPERBARICOXYGENTREATMENTDEFINITION", dataRow, isImported) { }
        protected HyperbaricOxygenTreatmentDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public HyperbaricOxygenTreatmentDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public HyperbaricOxygenTreatmentDefinition() : base() { }

    }
}