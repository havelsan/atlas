
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ReferToUpperLevel")] 

    /// <summary>
    /// Üst Kademeye Sevk
    /// </summary>
    public  partial class ReferToUpperLevel : CMRAction
    {
        public class ReferToUpperLevelList : TTObjectCollection<ReferToUpperLevel> { }
                    
        public class ChildReferToUpperLevelCollection : TTObject.TTChildObjectCollection<ReferToUpperLevel>
        {
            public ChildReferToUpperLevelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildReferToUpperLevelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class RULReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Faname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FANAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stockcardclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mark
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MARK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Model
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MODEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SerialNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["SERIALNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Sendermilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDERMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CheckDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECKDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["CHECKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BreakDown
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BREAKDOWN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["BREAKDOWN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public RULReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RULReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RULReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class RULDetailReportNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Faname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FANAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mark
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MARK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Model
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MODEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SerialNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["SERIALNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Sendermilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDERMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CheckDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECKDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["CHECKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BreakDown
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BREAKDOWN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["BREAKDOWN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RUL_ITEMEQUIPMENT"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Itemamount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RUL_ITEMEQUIPMENT"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public RULDetailReportNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RULDetailReportNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RULDetailReportNQL_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRULDetailsByObjectIDQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RUL_ITEMEQUIPMENT"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RUL_ITEMEQUIPMENT"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public bool? IsChanged
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISCHANGED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RUL_ITEMEQUIPMENT"].AllPropertyDefs["ISCHANGED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsDamaged
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISDAMAGED"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RUL_ITEMEQUIPMENT"].AllPropertyDefs["ISDAMAGED"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsMissing
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISMISSING"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RUL_ITEMEQUIPMENT"].AllPropertyDefs["ISMISSING"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public bool? IsNormal
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISNORMAL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RUL_ITEMEQUIPMENT"].AllPropertyDefs["ISNORMAL"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Comments
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMMENTS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RUL_ITEMEQUIPMENT"].AllPropertyDefs["COMMENTS"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetRULDetailsByObjectIDQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRULDetailsByObjectIDQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRULDetailsByObjectIDQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetReferToUpperLevelByObjectIDQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Faname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FANAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stockcardclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mark
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MARK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Model
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MODEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SerialNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["SERIALNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public DateTime? ArrivalDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARRIVALDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["ARRIVALDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Sendermilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDERMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CheckDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECKDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["CHECKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ReferTypeEnum? ReferType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REFERTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["REFERTYPE"].DataType;
                    return (ReferTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string BreakDown
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BREAKDOWN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["BREAKDOWN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetReferToUpperLevelByObjectIDQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetReferToUpperLevelByObjectIDQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetReferToUpperLevelByObjectIDQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class RUL_HEKReportQuery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Faname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FANAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
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

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Stockcardclass
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STOCKCARDCLASS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["STOCKCARDCLASS"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Mark
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MARK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MARK"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Model
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MODEL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["MODEL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string SerialNumber
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SERIALNUMBER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FIXEDASSETMATERIALDEFINITION"].AllPropertyDefs["SERIALNUMBER"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public int? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["AMOUNT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public string Sendermilitaryunit
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SENDERMILITARYUNIT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["MILITARYUNIT"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? RequestDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["REQUESTDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public DateTime? CheckDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CHECKDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["CHECKDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string RequestNo
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["REQUESTNO"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["REQUESTNO"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string BreakDown
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BREAKDOWN"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["BREAKDOWN"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string HEKDescription
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEKDESCRIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["HEKDESCRIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public DateTime? ArrivalDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ARRIVALDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["ARRIVALDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public double? TotalWorkLoadPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TOTALWORKLOADPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["TOTALWORKLOADPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? MaterialPrice
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MATERIALPRICE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].AllPropertyDefs["MATERIALPRICE"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public RUL_HEKReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public RUL_HEKReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected RUL_HEKReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class HEKReportToItemEquipmentsReportQuery_Class : TTReportNqlObject 
        {
            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RUL_ITEMEQUIPMENT"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Itemamount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMAMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RUL_ITEMEQUIPMENT"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public Guid? DistributionType
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["DISTRIBUTIONTYPE"]);
                }
            }

            public HEKReportToItemEquipmentsReportQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public HEKReportToItemEquipmentsReportQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected HEKReportToItemEquipmentsReportQuery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetRULDetailsByRequestNoQuery_Class : TTReportNqlObject 
        {
            public string ItemName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ITEMNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RUL_ITEMEQUIPMENT"].AllPropertyDefs["ITEMNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public long? Amount
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["AMOUNT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RUL_ITEMEQUIPMENT"].AllPropertyDefs["AMOUNT"].DataType;
                    return (long?)dataType.ConvertValue(val);
                }
            }

            public string DistributionType
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DISTRIBUTIONTYPE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["DISTRIBUTIONTYPEDEFINITION"].AllPropertyDefs["DISTRIBUTIONTYPE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetRULDetailsByRequestNoQuery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetRULDetailsByRequestNoQuery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetRULDetailsByRequestNoQuery_Class() : base() { }
        }

        new public static class States
        {
    /// <summary>
    /// Geçici Kabul
    /// </summary>
            public static Guid TemporaryAdmission { get { return new Guid("5c9675aa-78fb-42b4-80fc-0512dbbf1f72"); } }
            public static Guid InOrderProgress { get { return new Guid("0796a2e0-15ee-4557-bf30-2e1a56e558aa"); } }
    /// <summary>
    /// Kurum Yetkilisi Onayına
    /// </summary>
            public static Guid ConsultantApproval { get { return new Guid("403e2d5c-a0f1-4411-89d8-86f0c27fc34f"); } }
    /// <summary>
    /// İlk Muayene Kayıt
    /// </summary>
            public static Guid FirstExaminationRegistry { get { return new Guid("0a94b1fb-12d3-45f7-867c-3de3a8246ee4"); } }
    /// <summary>
    /// Onay
    /// </summary>
            public static Guid AccountantApproval { get { return new Guid("57a4b757-db9e-49a7-8525-3102688b2146"); } }
    /// <summary>
    /// İptal Edildi
    /// </summary>
            public static Guid Cancelled { get { return new Guid("5a1e0f5c-d1f6-455c-ab5f-7d1e253c9c7f"); } }
    /// <summary>
    /// Tamalandı
    /// </summary>
            public static Guid Completed { get { return new Guid("6e0f7502-cd8f-41b6-8885-4089e5b85d59"); } }
            public static Guid TeamRequest { get { return new Guid("5e81af29-3ec3-4cf8-8a32-bc52f8fd5b3c"); } }
    /// <summary>
    /// Geçici Kabul Kayıt
    /// </summary>
            public static Guid TemporaryAdmissionRegistry { get { return new Guid("a2f5d8cc-ccbc-475e-94fe-f01800f8e869"); } }
    /// <summary>
    /// Kayıt
    /// </summary>
            public static Guid Registry { get { return new Guid("bea9f5a1-9789-42c6-8e7b-f28d47156dfe"); } }
    /// <summary>
    /// İlk Muayene
    /// </summary>
            public static Guid FirstExamination { get { return new Guid("a72d6b84-fb5f-419f-88d1-d2209daf3038"); } }
    /// <summary>
    /// Üst Kademeye Sevk İşlemi Sonuç
    /// </summary>
            public static Guid UpperLevelCompleted { get { return new Guid("027b2d9e-d3d5-412a-a524-8d8258a7b856"); } }
    /// <summary>
    /// Belge Bekleme
    /// </summary>
            public static Guid DocumentWaiting { get { return new Guid("2138dcfe-7f6d-4df8-ba42-d817db954190"); } }
    /// <summary>
    /// Üst Kademe XXXXXX Onayı
    /// </summary>
            public static Guid UpperLevelCommander { get { return new Guid("84a32d15-b922-4c45-a892-d46be681f210"); } }
    /// <summary>
    /// Kayıt
    /// </summary>
            public static Guid UpperLevelRegistry { get { return new Guid("8ddf335b-e4e1-4f14-b279-3f9ae45d10f5"); } }
    /// <summary>
    /// Teknik Müdür Onay
    /// </summary>
            public static Guid TechnicalDirectorApproval { get { return new Guid("babeddcf-7b91-4723-b461-a3519020919d"); } }
    /// <summary>
    /// Kalibrasyon Gecici Kabul ve İlk Muayene
    /// </summary>
            public static Guid CalibrationExamination { get { return new Guid("430b2022-52e8-4bdb-bcde-c704c93b53a5"); } }
        }

        public static BindingList<ReferToUpperLevel.RULReportNQL_Class> RULReportNQL(string REQUESTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].QueryDefs["RULReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTNO", REQUESTNO);

            return TTReportNqlObject.QueryObjects<ReferToUpperLevel.RULReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReferToUpperLevel.RULReportNQL_Class> RULReportNQL(TTObjectContext objectContext, string REQUESTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].QueryDefs["RULReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTNO", REQUESTNO);

            return TTReportNqlObject.QueryObjects<ReferToUpperLevel.RULReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReferToUpperLevel.RULDetailReportNQL_Class> RULDetailReportNQL(string REQUESTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].QueryDefs["RULDetailReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTNO", REQUESTNO);

            return TTReportNqlObject.QueryObjects<ReferToUpperLevel.RULDetailReportNQL_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReferToUpperLevel.RULDetailReportNQL_Class> RULDetailReportNQL(TTObjectContext objectContext, string REQUESTNO, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].QueryDefs["RULDetailReportNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("REQUESTNO", REQUESTNO);

            return TTReportNqlObject.QueryObjects<ReferToUpperLevel.RULDetailReportNQL_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReferToUpperLevel.GetRULDetailsByObjectIDQuery_Class> GetRULDetailsByObjectIDQuery(string RULOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].QueryDefs["GetRULDetailsByObjectIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RULOBJECTID", RULOBJECTID);

            return TTReportNqlObject.QueryObjects<ReferToUpperLevel.GetRULDetailsByObjectIDQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReferToUpperLevel.GetRULDetailsByObjectIDQuery_Class> GetRULDetailsByObjectIDQuery(TTObjectContext objectContext, string RULOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].QueryDefs["GetRULDetailsByObjectIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RULOBJECTID", RULOBJECTID);

            return TTReportNqlObject.QueryObjects<ReferToUpperLevel.GetRULDetailsByObjectIDQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery_Class> GetReferToUpperLevelByObjectIDQuery(string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].QueryDefs["GetReferToUpperLevelByObjectIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery_Class> GetReferToUpperLevelByObjectIDQuery(TTObjectContext objectContext, string TTOBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].QueryDefs["GetReferToUpperLevelByObjectIDQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("TTOBJECTID", TTOBJECTID);

            return TTReportNqlObject.QueryObjects<ReferToUpperLevel.GetReferToUpperLevelByObjectIDQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReferToUpperLevel.RUL_HEKReportQuery_Class> RUL_HEKReportQuery(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].QueryDefs["RUL_HEKReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ReferToUpperLevel.RUL_HEKReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReferToUpperLevel.RUL_HEKReportQuery_Class> RUL_HEKReportQuery(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].QueryDefs["RUL_HEKReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ReferToUpperLevel.RUL_HEKReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReferToUpperLevel.HEKReportToItemEquipmentsReportQuery_Class> HEKReportToItemEquipmentsReportQuery(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].QueryDefs["HEKReportToItemEquipmentsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ReferToUpperLevel.HEKReportToItemEquipmentsReportQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReferToUpperLevel.HEKReportToItemEquipmentsReportQuery_Class> HEKReportToItemEquipmentsReportQuery(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].QueryDefs["HEKReportToItemEquipmentsReportQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ReferToUpperLevel.HEKReportToItemEquipmentsReportQuery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<ReferToUpperLevel.GetRULDetailsByRequestNoQuery_Class> GetRULDetailsByRequestNoQuery(Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].QueryDefs["GetRULDetailsByRequestNoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ReferToUpperLevel.GetRULDetailsByRequestNoQuery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<ReferToUpperLevel.GetRULDetailsByRequestNoQuery_Class> GetRULDetailsByRequestNoQuery(TTObjectContext objectContext, Guid OBJECTID, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["REFERTOUPPERLEVEL"].QueryDefs["GetRULDetailsByRequestNoQuery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("OBJECTID", OBJECTID);

            return TTReportNqlObject.QueryObjects<ReferToUpperLevel.GetRULDetailsByRequestNoQuery_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Arıza
    /// </summary>
        public string BreakDown
        {
            get { return (string)this["BREAKDOWN"]; }
            set { this["BREAKDOWN"] = value; }
        }

    /// <summary>
    /// Muayene Tarihi
    /// </summary>
        public DateTime? CheckDate
        {
            get { return (DateTime?)this["CHECKDATE"]; }
            set { this["CHECKDATE"] = value; }
        }

    /// <summary>
    /// Sevk Türü
    /// </summary>
        public ReferTypeEnum? ReferType
        {
            get { return (ReferTypeEnum?)(int?)this["REFERTYPE"]; }
            set { this["REFERTYPE"] = value; }
        }

    /// <summary>
    /// Bağlı Onarım İşlemi ObjectID'si
    /// </summary>
        public string RepairObjectID
        {
            get { return (string)this["REPAIROBJECTID"]; }
            set { this["REPAIROBJECTID"] = value; }
        }

    /// <summary>
    /// İstek Tarihi
    /// </summary>
        public DateTime? RequestDate
        {
            get { return (DateTime?)this["REQUESTDATE"]; }
            set { this["REQUESTDATE"] = value; }
        }

        public string PendingEquipmentsDocuments
        {
            get { return (string)this["PENDINGEQUIPMENTSDOCUMENTS"]; }
            set { this["PENDINGEQUIPMENTSDOCUMENTS"] = value; }
        }

    /// <summary>
    /// Miktar
    /// </summary>
        public int? Amount
        {
            get { return (int?)this["AMOUNT"]; }
            set { this["AMOUNT"] = value; }
        }

    /// <summary>
    /// İlk Muayene Sonuc
    /// </summary>
        public FirstExamResultEnum? FirstExamStatus
        {
            get { return (FirstExamResultEnum?)(int?)this["FIRSTEXAMSTATUS"]; }
            set { this["FIRSTEXAMSTATUS"] = value; }
        }

    /// <summary>
    /// Malzemenin Rapor Tarihindeki Değeri
    /// </summary>
        public double? MaterialPrice
        {
            get { return (double?)this["MATERIALPRICE"]; }
            set { this["MATERIALPRICE"] = value; }
        }

    /// <summary>
    /// İşcilik Maliyeti
    /// </summary>
        public double? TotalWorkLoadPrice
        {
            get { return (double?)this["TOTALWORKLOADPRICE"]; }
            set { this["TOTALWORKLOADPRICE"] = value; }
        }

    /// <summary>
    /// Hek Nedeni
    /// </summary>
        public string HEKDescription
        {
            get { return (string)this["HEKDESCRIPTION"]; }
            set { this["HEKDESCRIPTION"] = value; }
        }

    /// <summary>
    /// Malzeme Geliş Şekli
    /// </summary>
        public ArrivalTypeEnum? ArrivalType
        {
            get { return (ArrivalTypeEnum?)(int?)this["ARRIVALTYPE"]; }
            set { this["ARRIVALTYPE"] = value; }
        }

    /// <summary>
    /// Malzemenin Geliş Tarihi
    /// </summary>
        public DateTime? ArrivalDate
        {
            get { return (DateTime?)this["ARRIVALDATE"]; }
            set { this["ARRIVALDATE"] = value; }
        }

    /// <summary>
    /// Sipariş Durumu
    /// </summary>
        public OrderStatusEnum? OrderStatus
        {
            get { return (OrderStatusEnum?)(int?)this["ORDERSTATUS"]; }
            set { this["ORDERSTATUS"] = value; }
        }

        public MilitaryUnit ToMilitaryUnit
        {
            get { return (MilitaryUnit)((ITTObject)this).GetParent("TOMILITARYUNIT"); }
            set { this["TOMILITARYUNIT"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateCommisionMembersCollection()
        {
            _CommisionMembers = new ReferToUpperLevel_CommisionMember.ChildReferToUpperLevel_CommisionMemberCollection(this, new Guid("bf76cd2d-f2f7-4722-813f-55ddd7e122d2"));
            ((ITTChildObjectCollection)_CommisionMembers).GetChildren();
        }

        protected ReferToUpperLevel_CommisionMember.ChildReferToUpperLevel_CommisionMemberCollection _CommisionMembers = null;
        public ReferToUpperLevel_CommisionMember.ChildReferToUpperLevel_CommisionMemberCollection CommisionMembers
        {
            get
            {
                if (_CommisionMembers == null)
                    CreateCommisionMembersCollection();
                return _CommisionMembers;
            }
        }

        virtual protected void CreateRUL_ItemEquipmentsCollection()
        {
            _RUL_ItemEquipments = new RUL_ItemEquipment.ChildRUL_ItemEquipmentCollection(this, new Guid("e4db58b9-8fc5-4f9f-8771-de7ad2c14fea"));
            ((ITTChildObjectCollection)_RUL_ItemEquipments).GetChildren();
        }

        protected RUL_ItemEquipment.ChildRUL_ItemEquipmentCollection _RUL_ItemEquipments = null;
        public RUL_ItemEquipment.ChildRUL_ItemEquipmentCollection RUL_ItemEquipments
        {
            get
            {
                if (_RUL_ItemEquipments == null)
                    CreateRUL_ItemEquipmentsCollection();
                return _RUL_ItemEquipments;
            }
        }

        virtual protected void CreateRULHekCommisionMembersCollection()
        {
            _RULHekCommisionMembers = new RULHekCommisionMember.ChildRULHekCommisionMemberCollection(this, new Guid("31dc7e2c-dbaa-4fa7-a5bd-0c7a28af3a57"));
            ((ITTChildObjectCollection)_RULHekCommisionMembers).GetChildren();
        }

        protected RULHekCommisionMember.ChildRULHekCommisionMemberCollection _RULHekCommisionMembers = null;
        public RULHekCommisionMember.ChildRULHekCommisionMemberCollection RULHekCommisionMembers
        {
            get
            {
                if (_RULHekCommisionMembers == null)
                    CreateRULHekCommisionMembersCollection();
                return _RULHekCommisionMembers;
            }
        }

        virtual protected void CreateRULHEKReasonsCollection()
        {
            _RULHEKReasons = new RULHEKReason.ChildRULHEKReasonCollection(this, new Guid("0bb3cc7d-03f4-4f8d-aab9-c15f62c557b9"));
            ((ITTChildObjectCollection)_RULHEKReasons).GetChildren();
        }

        protected RULHEKReason.ChildRULHEKReasonCollection _RULHEKReasons = null;
        public RULHEKReason.ChildRULHEKReasonCollection RULHEKReasons
        {
            get
            {
                if (_RULHEKReasons == null)
                    CreateRULHEKReasonsCollection();
                return _RULHEKReasons;
            }
        }

        virtual protected void CreateNeededMaterialsCollection()
        {
            _NeededMaterials = new NeededMaterials.ChildNeededMaterialsCollection(this, new Guid("88d690b7-b346-4468-83f8-994939e9f664"));
            ((ITTChildObjectCollection)_NeededMaterials).GetChildren();
        }

        protected NeededMaterials.ChildNeededMaterialsCollection _NeededMaterials = null;
        public NeededMaterials.ChildNeededMaterialsCollection NeededMaterials
        {
            get
            {
                if (_NeededMaterials == null)
                    CreateNeededMaterialsCollection();
                return _NeededMaterials;
            }
        }

        protected ReferToUpperLevel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ReferToUpperLevel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ReferToUpperLevel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ReferToUpperLevel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ReferToUpperLevel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "REFERTOUPPERLEVEL", dataRow) { }
        protected ReferToUpperLevel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "REFERTOUPPERLEVEL", dataRow, isImported) { }
        public ReferToUpperLevel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ReferToUpperLevel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ReferToUpperLevel() : base() { }

        override protected void RunPreTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePreScript(transDef))
                base.RunPreTransition(transDef.BaseTransDef);
            this.PreTransition(transDef);
        }
        override protected void RunPostTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBasePostScript(transDef))
                base.RunPostTransition(transDef.BaseTransDef);
            this.PostTransition(transDef);
        }
        override protected void RunUndoTransition(TTObjectStateTransitionDef transDef)
        {
            if (MustCallBaseUndoScript(transDef))
                base.RunUndoTransition(transDef.BaseTransDef);
            this.UndoTransition(transDef);
        }
    }
}