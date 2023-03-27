
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="CashOfficeComputerUserDefinition")] 

    /// <summary>
    /// Sayman Mutemetliği / Vezne / Fatura Servisi Bilgisayar Kullanıcı Tanımı
    /// </summary>
    public  partial class CashOfficeComputerUserDefinition : TTDefinitionSet
    {
        public class CashOfficeComputerUserDefinitionList : TTObjectCollection<CashOfficeComputerUserDefinition> { }
                    
        public class ChildCashOfficeComputerUserDefinitionCollection : TTObject.TTChildObjectCollection<CashOfficeComputerUserDefinition>
        {
            public ChildCashOfficeComputerUserDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildCashOfficeComputerUserDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetCashOfficeComputerUserDefinitions_Class : TTReportNqlObject 
        {
            public string ComputerName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPUTERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECOMPUTERUSERDEFINITION"].AllPropertyDefs["COMPUTERNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Username
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["USERNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Cashofficename
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["CASHOFFICENAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICEDEFINITION"].AllPropertyDefs["NAME"].DataType;
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

            public GetCashOfficeComputerUserDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetCashOfficeComputerUserDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetCashOfficeComputerUserDefinitions_Class() : base() { }
        }

        public static BindingList<CashOfficeComputerUserDefinition.GetCashOfficeComputerUserDefinitions_Class> GetCashOfficeComputerUserDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECOMPUTERUSERDEFINITION"].QueryDefs["GetCashOfficeComputerUserDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CashOfficeComputerUserDefinition.GetCashOfficeComputerUserDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CashOfficeComputerUserDefinition.GetCashOfficeComputerUserDefinitions_Class> GetCashOfficeComputerUserDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECOMPUTERUSERDEFINITION"].QueryDefs["GetCashOfficeComputerUserDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<CashOfficeComputerUserDefinition.GetCashOfficeComputerUserDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<CashOfficeComputerUserDefinition> GetAll(TTObjectContext objectContext)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECOMPUTERUSERDEFINITION"].QueryDefs["GetAll"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return ((ITTQuery)objectContext).QueryObjects<CashOfficeComputerUserDefinition>(queryDef, paramList);
        }

        public static BindingList<CashOfficeComputerUserDefinition> GetByUserNameCompName(TTObjectContext objectContext, string PARAMUSERNAME, string PARAMCOMPNAME)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECOMPUTERUSERDEFINITION"].QueryDefs["GetByUserNameCompName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PARAMUSERNAME", PARAMUSERNAME);
            paramList.Add("PARAMCOMPNAME", PARAMCOMPNAME);

            return ((ITTQuery)objectContext).QueryObjects<CashOfficeComputerUserDefinition>(queryDef, paramList);
        }

        public static BindingList<CashOfficeComputerUserDefinition> GetByUserID(TTObjectContext objectContext, Guid RESUSER)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["CASHOFFICECOMPUTERUSERDEFINITION"].QueryDefs["GetByUserID"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("RESUSER", RESUSER);

            return ((ITTQuery)objectContext).QueryObjects<CashOfficeComputerUserDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Bilgisayar Adı
    /// </summary>
        public string ComputerName
        {
            get { return (string)this["COMPUTERNAME"]; }
            set { this["COMPUTERNAME"] = value; }
        }

    /// <summary>
    /// Vezne ile ilişki
    /// </summary>
        public CashOfficeDefinition CashOffice
        {
            get { return (CashOfficeDefinition)((ITTObject)this).GetParent("CASHOFFICE"); }
            set { this["CASHOFFICE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kullanıcı ile ilişki
    /// </summary>
        public ResUser ResUser
        {
            get { return (ResUser)((ITTObject)this).GetParent("RESUSER"); }
            set { this["RESUSER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected CashOfficeComputerUserDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected CashOfficeComputerUserDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected CashOfficeComputerUserDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected CashOfficeComputerUserDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected CashOfficeComputerUserDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "CASHOFFICECOMPUTERUSERDEFINITION", dataRow) { }
        protected CashOfficeComputerUserDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "CASHOFFICECOMPUTERUSERDEFINITION", dataRow, isImported) { }
        protected CashOfficeComputerUserDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public CashOfficeComputerUserDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public CashOfficeComputerUserDefinition() : base() { }

    }
}