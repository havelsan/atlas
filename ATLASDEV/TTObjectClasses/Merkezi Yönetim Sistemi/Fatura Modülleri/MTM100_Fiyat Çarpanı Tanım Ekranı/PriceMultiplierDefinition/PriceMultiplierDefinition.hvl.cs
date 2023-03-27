
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PriceMultiplierDefinition")] 

    /// <summary>
    /// Fiyat Çarpanı Tanım Ekranı
    /// </summary>
    public  partial class PriceMultiplierDefinition : TerminologyManagerDef
    {
        public class PriceMultiplierDefinitionList : TTObjectCollection<PriceMultiplierDefinition> { }
                    
        public class ChildPriceMultiplierDefinitionCollection : TTObject.TTChildObjectCollection<PriceMultiplierDefinition>
        {
            public ChildPriceMultiplierDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPriceMultiplierDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPriceMultiplierDefinitions_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICEMULTIPLIERDEFINITION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public double? OldMultiplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["OLDMULTIPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICEMULTIPLIERDEFINITION"].AllPropertyDefs["OLDMULTIPLIER"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? NewMultiplier
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NEWMULTIPLIER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PRICEMULTIPLIERDEFINITION"].AllPropertyDefs["NEWMULTIPLIER"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public GetPriceMultiplierDefinitions_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPriceMultiplierDefinitions_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPriceMultiplierDefinitions_Class() : base() { }
        }

        public static BindingList<PriceMultiplierDefinition.GetPriceMultiplierDefinitions_Class> GetPriceMultiplierDefinitions(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICEMULTIPLIERDEFINITION"].QueryDefs["GetPriceMultiplierDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PriceMultiplierDefinition.GetPriceMultiplierDefinitions_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PriceMultiplierDefinition.GetPriceMultiplierDefinitions_Class> GetPriceMultiplierDefinitions(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICEMULTIPLIERDEFINITION"].QueryDefs["GetPriceMultiplierDefinitions"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PriceMultiplierDefinition.GetPriceMultiplierDefinitions_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PriceMultiplierDefinition> GetPriceMultiplierDefByLastUpdateDate(TTObjectContext objectContext, DateTime STARTDATE, DateTime ENDDATE)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PRICEMULTIPLIERDEFINITION"].QueryDefs["GetPriceMultiplierDefByLastUpdateDate"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("STARTDATE", STARTDATE);
            paramList.Add("ENDDATE", ENDDATE);

            return ((ITTQuery)objectContext).QueryObjects<PriceMultiplierDefinition>(queryDef, paramList);
        }

    /// <summary>
    /// Adı
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Yeni Çarpan
    /// </summary>
        public double? NewMultiplier
        {
            get { return (double?)this["NEWMULTIPLIER"]; }
            set { this["NEWMULTIPLIER"] = value; }
        }

    /// <summary>
    /// Eski Çarpan
    /// </summary>
        public double? OldMultiplier
        {
            get { return (double?)this["OLDMULTIPLIER"]; }
            set { this["OLDMULTIPLIER"] = value; }
        }

        protected PriceMultiplierDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PriceMultiplierDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PriceMultiplierDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PriceMultiplierDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PriceMultiplierDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PRICEMULTIPLIERDEFINITION", dataRow) { }
        protected PriceMultiplierDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PRICEMULTIPLIERDEFINITION", dataRow, isImported) { }
        public PriceMultiplierDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PriceMultiplierDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PriceMultiplierDefinition() : base() { }

    }
}