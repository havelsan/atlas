
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FetusGrowingDefinition")] 

    public  partial class FetusGrowingDefinition : TTDefinitionSet
    {
        public class FetusGrowingDefinitionList : TTObjectCollection<FetusGrowingDefinition> { }
                    
        public class ChildFetusGrowingDefinitionCollection : TTObject.TTChildObjectCollection<FetusGrowingDefinition>
        {
            public ChildFetusGrowingDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFetusGrowingDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class FetusGrowingDefinitionNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public int? PregnancyWeek
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PREGNANCYWEEK"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FETUSGROWINGDEFINITION"].AllPropertyDefs["PREGNANCYWEEK"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? Length
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["LENGTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FETUSGROWINGDEFINITION"].AllPropertyDefs["LENGTH"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public double? Weight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["WEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FETUSGROWINGDEFINITION"].AllPropertyDefs["WEIGHT"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public int? BiparietalDiameter
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["BIPARIETALDIAMETER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FETUSGROWINGDEFINITION"].AllPropertyDefs["BIPARIETALDIAMETER"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? HeadCircumference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["HEADCIRCUMFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FETUSGROWINGDEFINITION"].AllPropertyDefs["HEADCIRCUMFERENCE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? AbdominalCircumference
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ABDOMINALCIRCUMFERENCE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FETUSGROWINGDEFINITION"].AllPropertyDefs["ABDOMINALCIRCUMFERENCE"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? FemurLength
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FEMURLENGTH"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["FETUSGROWINGDEFINITION"].AllPropertyDefs["FEMURLENGTH"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public FetusGrowingDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public FetusGrowingDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected FetusGrowingDefinitionNQL_Class() : base() { }
        }

    /// <summary>
    ///  Gebelik Haftasına Göre Fetus Gelişimi
    /// </summary>
        public static BindingList<FetusGrowingDefinition> GetFetusGrowingByWeekNQL(TTObjectContext objectContext, int PWEEK, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FETUSGROWINGDEFINITION"].QueryDefs["GetFetusGrowingByWeekNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("PWEEK", PWEEK);

            return ((ITTQuery)objectContext).QueryObjects<FetusGrowingDefinition>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<FetusGrowingDefinition.FetusGrowingDefinitionNQL_Class> FetusGrowingDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FETUSGROWINGDEFINITION"].QueryDefs["FetusGrowingDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FetusGrowingDefinition.FetusGrowingDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FetusGrowingDefinition.FetusGrowingDefinitionNQL_Class> FetusGrowingDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FETUSGROWINGDEFINITION"].QueryDefs["FetusGrowingDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<FetusGrowingDefinition.FetusGrowingDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Boy
    /// </summary>
        public int? Length
        {
            get { return (int?)this["LENGTH"]; }
            set { this["LENGTH"] = value; }
        }

    /// <summary>
    /// Kilo
    /// </summary>
        public double? Weight
        {
            get { return (double?)this["WEIGHT"]; }
            set { this["WEIGHT"] = value; }
        }

    /// <summary>
    /// Biparyetal Çap
    /// </summary>
        public int? BiparietalDiameter
        {
            get { return (int?)this["BIPARIETALDIAMETER"]; }
            set { this["BIPARIETALDIAMETER"] = value; }
        }

    /// <summary>
    /// Baş Çevresi
    /// </summary>
        public int? HeadCircumference
        {
            get { return (int?)this["HEADCIRCUMFERENCE"]; }
            set { this["HEADCIRCUMFERENCE"] = value; }
        }

    /// <summary>
    /// Karın Çevresi
    /// </summary>
        public int? AbdominalCircumference
        {
            get { return (int?)this["ABDOMINALCIRCUMFERENCE"]; }
            set { this["ABDOMINALCIRCUMFERENCE"] = value; }
        }

    /// <summary>
    /// Femur Uzunluğu
    /// </summary>
        public int? FemurLength
        {
            get { return (int?)this["FEMURLENGTH"]; }
            set { this["FEMURLENGTH"] = value; }
        }

    /// <summary>
    /// Gebelik Haftası
    /// </summary>
        public int? PregnancyWeek
        {
            get { return (int?)this["PREGNANCYWEEK"]; }
            set { this["PREGNANCYWEEK"] = value; }
        }

        protected FetusGrowingDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FetusGrowingDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FetusGrowingDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FetusGrowingDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FetusGrowingDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FETUSGROWINGDEFINITION", dataRow) { }
        protected FetusGrowingDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FETUSGROWINGDEFINITION", dataRow, isImported) { }
        public FetusGrowingDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FetusGrowingDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FetusGrowingDefinition() : base() { }

    }
}