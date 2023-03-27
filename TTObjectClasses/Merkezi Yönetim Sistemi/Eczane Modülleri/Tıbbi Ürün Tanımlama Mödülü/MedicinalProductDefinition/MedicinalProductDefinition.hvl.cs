
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MedicinalProductDefinition")] 

    /// <summary>
    /// Tıbbi Ürün Tanımı
    /// </summary>
    public  partial class MedicinalProductDefinition : DrugDefinition
    {
        public class MedicinalProductDefinitionList : TTObjectCollection<MedicinalProductDefinition> { }
                    
        public class ChildMedicinalProductDefinitionCollection : TTObject.TTChildObjectCollection<MedicinalProductDefinition>
        {
            public ChildMedicinalProductDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMedicinalProductDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetMedicinalProductDefinition_Class : TTReportNqlObject 
        {
            public string Barcode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BARCODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICINALPRODUCTDEFINITION"].AllPropertyDefs["BARCODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Code
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICINALPRODUCTDEFINITION"].AllPropertyDefs["CODE"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICINALPRODUCTDEFINITION"].AllPropertyDefs["NAME"].DataType;
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
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICINALPRODUCTDEFINITION"].AllPropertyDefs["ORIGINALNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public PrescriptionTypeEnum? PrescriptionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRESCRIPTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MEDICINALPRODUCTDEFINITION"].AllPropertyDefs["PRESCRIPTIONTYPE"].DataType;
                    return (PrescriptionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string NATOStockNO
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NATOSTOCKNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARD"].AllPropertyDefs["NATOSTOCKNO"].DataType;
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

            public GetMedicinalProductDefinition_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetMedicinalProductDefinition_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetMedicinalProductDefinition_Class() : base() { }
        }

        public static BindingList<MedicinalProductDefinition.GetMedicinalProductDefinition_Class> GetMedicinalProductDefinition(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICINALPRODUCTDEFINITION"].QueryDefs["GetMedicinalProductDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicinalProductDefinition.GetMedicinalProductDefinition_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<MedicinalProductDefinition.GetMedicinalProductDefinition_Class> GetMedicinalProductDefinition(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["MEDICINALPRODUCTDEFINITION"].QueryDefs["GetMedicinalProductDefinition"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<MedicinalProductDefinition.GetMedicinalProductDefinition_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        protected MedicinalProductDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MedicinalProductDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MedicinalProductDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MedicinalProductDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MedicinalProductDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MEDICINALPRODUCTDEFINITION", dataRow) { }
        protected MedicinalProductDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MEDICINALPRODUCTDEFINITION", dataRow, isImported) { }
        public MedicinalProductDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MedicinalProductDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MedicinalProductDefinition() : base() { }

    }
}