
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PrescriptionConsDocMatOut")] 

    public  partial class PrescriptionConsDocMatOut : ProductionConsumptionDocumentMaterialOut
    {
        public class PrescriptionConsDocMatOutList : TTObjectCollection<PrescriptionConsDocMatOut> { }
                    
        public class ChildPrescriptionConsDocMatOutCollection : TTObject.TTChildObjectCollection<PrescriptionConsDocMatOut>
        {
            public ChildPrescriptionConsDocMatOutCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPrescriptionConsDocMatOutCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PrescriptionConsumptionDocumentMaterialQuery_Class : TTReportNqlObject 
        {
            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSUMPTIONDETAIL"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string ActionDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSUMPTIONDETAIL"].AllPropertyDefs["ACTIONDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? ActionID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSUMPTIONDETAIL"].AllPropertyDefs["ACTIONID"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public Currency? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSUMPTIONDETAIL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public string DocktorFullName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DOCKTORFULLNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSUMPTIONDETAIL"].AllPropertyDefs["DOCKTORFULLNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PatienFullName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENFULLNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSUMPTIONDETAIL"].AllPropertyDefs["PATIENFULLNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string PrescriptionNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRESCRIPTIONNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSUMPTIONDETAIL"].AllPropertyDefs["PRESCRIPTIONNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public PrescriptionConsumptionDocumentMaterialQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PrescriptionConsumptionDocumentMaterialQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PrescriptionConsumptionDocumentMaterialQuery_Class() : base() { }
        }

        public static BindingList<PrescriptionConsDocMatOut.PrescriptionConsumptionDocumentMaterialQuery_Class> PrescriptionConsumptionDocumentMaterialQuery(Guid MATERIAL, Guid TERM, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSDOCMATOUT"].QueryDefs["PrescriptionConsumptionDocumentMaterialQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("TERM", TERM);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<PrescriptionConsDocMatOut.PrescriptionConsumptionDocumentMaterialQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<PrescriptionConsDocMatOut.PrescriptionConsumptionDocumentMaterialQuery_Class> PrescriptionConsumptionDocumentMaterialQuery(TTObjectContext objectContext, Guid MATERIAL, Guid TERM, Guid STORE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRESCRIPTIONCONSDOCMATOUT"].QueryDefs["PrescriptionConsumptionDocumentMaterialQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("MATERIAL", MATERIAL);
            paramList.Add("TERM", TERM);
            paramList.Add("STORE", STORE);

            return TTReportNqlObject.QueryObjects<PrescriptionConsDocMatOut.PrescriptionConsumptionDocumentMaterialQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Ana İşlem
    /// </summary>
        public PrescriptionConsumptionDocument PrescriptionConsumptionDoc
        {
            get 
            {   
                if (StockAction is PrescriptionConsumptionDocument)
                    return (PrescriptionConsumptionDocument)StockAction; 
                return null;
            }            
            set { StockAction = value; }
        }

        virtual protected void CreatePrescriptionConsumptionDetailsCollection()
        {
            _PrescriptionConsumptionDetails = new PrescriptionConsumptionDetail.ChildPrescriptionConsumptionDetailCollection(this, new Guid("36e528fe-7657-4890-99d0-361ddf91c79c"));
            ((ITTChildObjectCollection)_PrescriptionConsumptionDetails).GetChildren();
        }

        protected PrescriptionConsumptionDetail.ChildPrescriptionConsumptionDetailCollection _PrescriptionConsumptionDetails = null;
        public PrescriptionConsumptionDetail.ChildPrescriptionConsumptionDetailCollection PrescriptionConsumptionDetails
        {
            get
            {
                if (_PrescriptionConsumptionDetails == null)
                    CreatePrescriptionConsumptionDetailsCollection();
                return _PrescriptionConsumptionDetails;
            }
        }

        protected PrescriptionConsDocMatOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PrescriptionConsDocMatOut(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PrescriptionConsDocMatOut(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PrescriptionConsDocMatOut(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PrescriptionConsDocMatOut(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRESCRIPTIONCONSDOCMATOUT", dataRow) { }
        protected PrescriptionConsDocMatOut(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRESCRIPTIONCONSDOCMATOUT", dataRow, isImported) { }
        public PrescriptionConsDocMatOut(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PrescriptionConsDocMatOut(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PrescriptionConsDocMatOut() : base() { }

    }
}