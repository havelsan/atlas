
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="OrthesisProsthesisProcedure")] 

    public  partial class OrthesisProsthesisProcedure : BaseOrthesisProsthesisProcedure
    {
        public class OrthesisProsthesisProcedureList : TTObjectCollection<OrthesisProsthesisProcedure> { }
                    
        public class ChildOrthesisProsthesisProcedureCollection : TTObject.TTChildObjectCollection<OrthesisProsthesisProcedure>
        {
            public ChildOrthesisProsthesisProcedureCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildOrthesisProsthesisProcedureCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetOrthesisProsthesisProcedureByEpisode_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PricingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["PRICINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExtraDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTRADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SutRuleEngineStatus? SUTRuleStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTRULESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["SUTRULESTATUS"].DataType;
                    return (SutRuleEngineStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RightLeftEnum? RightLeftInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
                    return (RightLeftEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsPrintReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPRINTREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ISPRINTREPORT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsRequestReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISREQUESTREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ISREQUESTREPORT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public SideEnum? Side
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIDE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["SIDE"].DataType;
                    return (SideEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string DrAnesteziTescilNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRANESTEZITESCILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["DRANESTEZITESCILNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RaporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["RAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OrthesisPayRatio? PayRatio
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYRATIO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["PAYRATIO"].DataType;
                    return (OrthesisPayRatio?)(int)dataType.ConvertValue(val);
                }
            }

            public Currency? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["PRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetOrthesisProsthesisProcedureByEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOrthesisProsthesisProcedureByEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOrthesisProsthesisProcedureByEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOrthesisProsthesisProcedure_Class : TTReportNqlObject 
        {
            public Guid? Procedureid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREID"]);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Procedureamount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public SideEnum? Side
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIDE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["SIDE"].DataType;
                    return (SideEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Technicianname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIANNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetOrthesisProsthesisProcedure_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOrthesisProsthesisProcedure_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOrthesisProsthesisProcedure_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOrthesisProsthesisProcedureByAction_Class : TTReportNqlObject 
        {
            public Guid? Procedureid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREID"]);
                }
            }

            public long? Procedureamount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Proceduredefobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDEFOBJECTID"]);
                }
            }

            public SideEnum? Side
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIDE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["SIDE"].DataType;
                    return (SideEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public Guid? Technician
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["TECHNICIAN"]);
                }
            }

            public GetOrthesisProsthesisProcedureByAction_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOrthesisProsthesisProcedureByAction_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOrthesisProsthesisProcedureByAction_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOrthesisProsthesisProcedureBySubEpisode_Class : TTReportNqlObject 
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

            public long? ID
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ID"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ID"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public bool? Eligible
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ELIGIBLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ELIGIBLE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ReasonOfCancel
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REASONOFCANCEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["REASONOFCANCEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? WorkListDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WORKLISTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["WORKLISTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PricingDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICINGDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["PRICINGDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ActionDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ACTIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? Emergency
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMERGENCY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["EMERGENCY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? Active
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACTIVE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ACTIVE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["OLAPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? OlapLastUpdate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLAPLASTUPDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["OLAPLASTUPDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? AccountOperationDone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCOUNTOPERATIONDONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ACCOUNTOPERATIONDONE"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? AccTrxsMultipliedByAmount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ACCTRXSMULTIPLIEDBYAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ACCTRXSMULTIPLIEDBYAMOUNT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? PatientPay
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PATIENTPAY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["PATIENTPAY"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string ExtraDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EXTRADESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["EXTRADESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public SutRuleEngineStatus? SUTRuleStatus
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SUTRULESTATUS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["SUTRULESTATUS"].DataType;
                    return (SutRuleEngineStatus?)(int)dataType.ConvertValue(val);
                }
            }

            public double? DiscountPercent
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISCOUNTPERCENT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["DISCOUNTPERCENT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public DateTime? PerformedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PERFORMEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["PERFORMEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CreationDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CREATIONDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["CREATIONDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public bool? IsOldAction
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISOLDACTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ISOLDACTION"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string MedulaReportNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MEDULAREPORTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["MEDULAREPORTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RightLeftEnum? RightLeftInformation
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RIGHTLEFTINFORMATION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["RIGHTLEFTINFORMATION"].DataType;
                    return (RightLeftEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsPrintReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISPRINTREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ISPRINTREPORT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsRequestReport
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISREQUESTREPORT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["ISREQUESTREPORT"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public SideEnum? Side
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIDE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["SIDE"].DataType;
                    return (SideEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string DrAnesteziTescilNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DRANESTEZITESCILNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["DRANESTEZITESCILNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string RaporTakipNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["RAPORTAKIPNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["RAPORTAKIPNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public OrthesisPayRatio? PayRatio
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PAYRATIO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["PAYRATIO"].DataType;
                    return (OrthesisPayRatio?)(int)dataType.ConvertValue(val);
                }
            }

            public Currency? Price
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["PRICE"].DataType;
                    return (Currency?)dataType.ConvertValue(val);
                }
            }

            public GetOrthesisProsthesisProcedureBySubEpisode_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOrthesisProsthesisProcedureBySubEpisode_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOrthesisProsthesisProcedureBySubEpisode_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOldOrthesisProsthesisProcedure_Class : TTReportNqlObject 
        {
            public Guid? Episodeactionid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEACTIONID"]);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public Guid? RequesterUsr
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["REQUESTERUSR"]);
                }
            }

            public string Requesterunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTERUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESSECTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public String ObjectDefName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OBJECTDEFNAME"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public String Currentstate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTSTATE"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetOldOrthesisProsthesisProcedure_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOldOrthesisProsthesisProcedure_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOldOrthesisProsthesisProcedure_Class() : base() { }
        }

        [Serializable] 

        public partial class GetOrthesisProsthesisForWorkList_Class : TTReportNqlObject 
        {
            public Guid? Procid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCID"]);
                }
            }

            public Guid? Episodeactionid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["EPISODEACTIONID"]);
                }
            }

            public long? UniqueRefNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNIQUEREFNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["UNIQUEREFNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Hastaadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTAADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Hastasoyadi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HASTASOYADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PATIENT"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Procedureamount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string Procedurename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Procedurecode
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDURECODE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PROCEDUREDEFINITION"].AllPropertyDefs["CODE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public Guid? Proceduredefobjectid
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["PROCEDUREDEFOBJECTID"]);
                }
            }

            public SideEnum? Side
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIDE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].AllPropertyDefs["SIDE"].DataType;
                    return (SideEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Technician
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TECHNICIAN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? ProtocolNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROTOCOLNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISREQUEST"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISREQUEST"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Kabulno
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KABULNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SUBEPISODE"].AllPropertyDefs["PROTOCOLNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Kurum
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["KURUM"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PAYERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string sigortaliTuruAdi
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SIGORTALITURUADI"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["SIGORTALITURU"].AllPropertyDefs["SIGORTALITURUADI"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? BranchDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BRANCHDATE"]);
                    if (val == null)
                        return null;
                    return (DateTime)Convert.ChangeType(val, typeof(DateTime)); 
                }
            }

            public String Currentstate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CURRENTSTATE"]);
                    if (val == null)
                        return null;
                    return (String)Convert.ChangeType(val, typeof(String)); 
                }
            }

            public GetOrthesisProsthesisForWorkList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetOrthesisProsthesisForWorkList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetOrthesisProsthesisForWorkList_Class() : base() { }
        }

        new public static class States
        {
            public static Guid New { get { return new Guid("1c28a828-4470-46a5-af69-701b5322df1f"); } }
            public static Guid Completed { get { return new Guid("35536bbc-e567-46c8-be88-3bc9d65bfd5f"); } }
            public static Guid Cancelled { get { return new Guid("d16bf872-a7d1-476c-806d-92fd1852dccc"); } }
        }

        public static BindingList<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByEpisode_Class> GetOrthesisProsthesisProcedureByEpisode(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].QueryDefs["GetOrthesisProsthesisProcedureByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByEpisode_Class> GetOrthesisProsthesisProcedureByEpisode(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].QueryDefs["GetOrthesisProsthesisProcedureByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// O procedur u object ID ile get eder
    /// </summary>
        public static BindingList<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedure_Class> GetOrthesisProsthesisProcedure(string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].QueryDefs["GetOrthesisProsthesisProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedure_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// O procedur u object ID ile get eder
    /// </summary>
        public static BindingList<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedure_Class> GetOrthesisProsthesisProcedure(TTObjectContext objectContext, string OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].QueryDefs["GetOrthesisProsthesisProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedure_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// EpisodeAction a göre OrthesisProsthesisProcedure get eder
    /// </summary>
        public static BindingList<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class> GetOrthesisProsthesisProcedureByAction(string PARENTACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].QueryDefs["GetOrthesisProsthesisProcedureByAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTACTION", PARENTACTION);

            return TTReportNqlObject.QueryObjects<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class>(queryDef, paramList, pi);
        }

    /// <summary>
    /// EpisodeAction a göre OrthesisProsthesisProcedure get eder
    /// </summary>
        public static BindingList<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class> GetOrthesisProsthesisProcedureByAction(TTObjectContext objectContext, string PARENTACTION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].QueryDefs["GetOrthesisProsthesisProcedureByAction"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARENTACTION", PARENTACTION);

            return TTReportNqlObject.QueryObjects<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureByAction_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OrthesisProsthesisProcedure> GetOrthesisProthesisByEpisode(TTObjectContext objectContext, Guid EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].QueryDefs["GetOrthesisProthesisByEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<OrthesisProsthesisProcedure>(queryDef, paramList);
        }

        public static BindingList<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureBySubEpisode_Class> GetOrthesisProsthesisProcedureBySubEpisode(string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].QueryDefs["GetOrthesisProsthesisProcedureBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureBySubEpisode_Class>(queryDef, paramList, pi);
        }

        public static BindingList<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureBySubEpisode_Class> GetOrthesisProsthesisProcedureBySubEpisode(TTObjectContext objectContext, string SUBEPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].QueryDefs["GetOrthesisProsthesisProcedureBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);

            return TTReportNqlObject.QueryObjects<OrthesisProsthesisProcedure.GetOrthesisProsthesisProcedureBySubEpisode_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<OrthesisProsthesisProcedure> GetOrthesisProthesisBySubEpisode(TTObjectContext objectContext, Guid SUBEPISODE, string EPISODE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].QueryDefs["GetOrthesisProthesisBySubEpisode"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SUBEPISODE", SUBEPISODE);
            paramList.Add("EPISODE", EPISODE);

            return ((ITTQuery)objectContext).QueryObjects<OrthesisProsthesisProcedure>(queryDef, paramList);
        }

        public static BindingList<OrthesisProsthesisProcedure.GetOldOrthesisProsthesisProcedure_Class> GetOldOrthesisProsthesisProcedure(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].QueryDefs["GetOldOrthesisProsthesisProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OrthesisProsthesisProcedure.GetOldOrthesisProsthesisProcedure_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OrthesisProsthesisProcedure.GetOldOrthesisProsthesisProcedure_Class> GetOldOrthesisProsthesisProcedure(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].QueryDefs["GetOldOrthesisProsthesisProcedure"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OrthesisProsthesisProcedure.GetOldOrthesisProsthesisProcedure_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OrthesisProsthesisProcedure.GetOrthesisProsthesisForWorkList_Class> GetOrthesisProsthesisForWorkList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].QueryDefs["GetOrthesisProsthesisForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OrthesisProsthesisProcedure.GetOrthesisProsthesisForWorkList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<OrthesisProsthesisProcedure.GetOrthesisProsthesisForWorkList_Class> GetOrthesisProsthesisForWorkList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ORTHESISPROSTHESISPROCEDURE"].QueryDefs["GetOrthesisProsthesisForWorkList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<OrthesisProsthesisProcedure.GetOrthesisProsthesisForWorkList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Rapor Bas
    /// </summary>
        public bool? IsPrintReport
        {
            get { return (bool?)this["ISPRINTREPORT"]; }
            set { this["ISPRINTREPORT"] = value; }
        }

    /// <summary>
    /// Rapor İste
    /// </summary>
        public bool? IsRequestReport
        {
            get { return (bool?)this["ISREQUESTREPORT"]; }
            set { this["ISREQUESTREPORT"] = value; }
        }

    /// <summary>
    /// Taraf
    /// </summary>
        public SideEnum? Side
        {
            get { return (SideEnum?)(int?)this["SIDE"]; }
            set { this["SIDE"] = value; }
        }

    /// <summary>
    /// Dr Anestezi Tescil No
    /// </summary>
        public string DrAnesteziTescilNo
        {
            get { return (string)this["DRANESTEZITESCILNO"]; }
            set { this["DRANESTEZITESCILNO"] = value; }
        }

    /// <summary>
    /// Rapor Takip Numarası
    /// </summary>
        public string RaporTakipNo
        {
            get { return (string)this["RAPORTAKIPNO"]; }
            set { this["RAPORTAKIPNO"] = value; }
        }

        public OrthesisPayRatio? PayRatio
        {
            get { return (OrthesisPayRatio?)(int?)this["PAYRATIO"]; }
            set { this["PAYRATIO"] = value; }
        }

    /// <summary>
    /// Malzeme fiyatı
    /// </summary>
        public Currency? Price
        {
            get { return (Currency?)this["PRICE"]; }
            set { this["PRICE"] = value; }
        }

        public AyniFarkliKesi AyniFarkliKesi
        {
            get { return (AyniFarkliKesi)((ITTObject)this).GetParent("AYNIFARKLIKESI"); }
            set { this["AYNIFARKLIKESI"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OzelDurum OzelDurum
        {
            get { return (OzelDurum)((ITTObject)this).GetParent("OZELDURUM"); }
            set { this["OZELDURUM"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Teknisyen Nesnesini Taşıyan Alandır
    /// </summary>
        public ResUser Technician
        {
            get { return (ResUser)((ITTObject)this).GetParent("TECHNICIAN"); }
            set { this["TECHNICIAN"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public OrthesisProsthesisRequest OrthesisProsthesisRequest
        {
            get 
            {   
                if (EpisodeAction is OrthesisProsthesisRequest)
                    return (OrthesisProsthesisRequest)EpisodeAction; 
                return null;
            }            
            set { EpisodeAction = value; }
        }

    /// <summary>
    /// İşlem
    /// </summary>
        public OrtesisProsthesisDefinition OrtesisProsthesisDefinition
        {
            get 
            {   
                if (ProcedureObject is OrtesisProsthesisDefinition)
                    return (OrtesisProsthesisDefinition)ProcedureObject; 
                return null;
            }            
            set { ProcedureObject = value; }
        }

        virtual protected void CreateCokluOzelDurumCollection()
        {
            _CokluOzelDurum = new CokluOzelDurum.ChildCokluOzelDurumCollection(this, new Guid("ca8457a9-7e7c-481f-b30d-e519aae15e66"));
            ((ITTChildObjectCollection)_CokluOzelDurum).GetChildren();
        }

        protected CokluOzelDurum.ChildCokluOzelDurumCollection _CokluOzelDurum = null;
        public CokluOzelDurum.ChildCokluOzelDurumCollection CokluOzelDurum
        {
            get
            {
                if (_CokluOzelDurum == null)
                    CreateCokluOzelDurumCollection();
                return _CokluOzelDurum;
            }
        }

        protected OrthesisProsthesisProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected OrthesisProsthesisProcedure(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected OrthesisProsthesisProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected OrthesisProsthesisProcedure(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected OrthesisProsthesisProcedure(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ORTHESISPROSTHESISPROCEDURE", dataRow) { }
        protected OrthesisProsthesisProcedure(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ORTHESISPROSTHESISPROCEDURE", dataRow, isImported) { }
        public OrthesisProsthesisProcedure(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public OrthesisProsthesisProcedure(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public OrthesisProsthesisProcedure() : base() { }

    }
}