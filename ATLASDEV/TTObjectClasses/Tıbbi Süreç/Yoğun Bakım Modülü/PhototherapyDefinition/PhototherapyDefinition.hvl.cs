
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PhototherapyDefinition")] 

    public  partial class PhototherapyDefinition : TTDefinitionSet
    {
        public class PhototherapyDefinitionList : TTObjectCollection<PhototherapyDefinition> { }
                    
        public class ChildPhototherapyDefinitionCollection : TTObject.TTChildObjectCollection<PhototherapyDefinition>
        {
            public ChildPhototherapyDefinitionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPhototherapyDefinitionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class PhototherapyDefinitionNQL_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public double? ComplicatedExcTrans
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLICATEDEXCTRANS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHOTOTHERAPYDEFINITION"].AllPropertyDefs["COMPLICATEDEXCTRANS"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? UncomplicatedExcTrans
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNCOMPLICATEDEXCTRANS"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHOTOTHERAPYDEFINITION"].AllPropertyDefs["UNCOMPLICATEDEXCTRANS"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? ComplicatedPhototherapy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLICATEDPHOTOTHERAPY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHOTOTHERAPYDEFINITION"].AllPropertyDefs["COMPLICATEDPHOTOTHERAPY"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public double? UncomplicatedPhototherapy
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["UNCOMPLICATEDPHOTOTHERAPY"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHOTOTHERAPYDEFINITION"].AllPropertyDefs["UNCOMPLICATEDPHOTOTHERAPY"].DataType;
                    return (double?)dataType.ConvertValue(val);
                }
            }

            public int? FinishTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["FINISHTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHOTOTHERAPYDEFINITION"].AllPropertyDefs["FINISHTIME"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? StartTime
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["STARTTIME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHOTOTHERAPYDEFINITION"].AllPropertyDefs["STARTTIME"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? MaxWeight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MAXWEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHOTOTHERAPYDEFINITION"].AllPropertyDefs["MAXWEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public int? MinWeight
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MINWEIGHT"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHOTOTHERAPYDEFINITION"].AllPropertyDefs["MINWEIGHT"].DataType;
                    return (int?)dataType.ConvertValue(val);
                }
            }

            public PhototherapyDefinitionNQL_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public PhototherapyDefinitionNQL_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected PhototherapyDefinitionNQL_Class() : base() { }
        }

        public static BindingList<PhototherapyDefinition.PhototherapyDefinitionNQL_Class> PhototherapyDefinitionNQL(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHOTOTHERAPYDEFINITION"].QueryDefs["PhototherapyDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhototherapyDefinition.PhototherapyDefinitionNQL_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PhototherapyDefinition.PhototherapyDefinitionNQL_Class> PhototherapyDefinitionNQL(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHOTOTHERAPYDEFINITION"].QueryDefs["PhototherapyDefinitionNQL"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhototherapyDefinition.PhototherapyDefinitionNQL_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

    /// <summary>
    /// Minimum Ağırlık
    /// </summary>
        public int? MinWeight
        {
            get { return (int?)this["MINWEIGHT"]; }
            set { this["MINWEIGHT"] = value; }
        }

    /// <summary>
    /// Maximum Ağırlık
    /// </summary>
        public int? MaxWeight
        {
            get { return (int?)this["MAXWEIGHT"]; }
            set { this["MAXWEIGHT"] = value; }
        }

    /// <summary>
    /// Başlangıç Saati
    /// </summary>
        public int? StartTime
        {
            get { return (int?)this["STARTTIME"]; }
            set { this["STARTTIME"] = value; }
        }

    /// <summary>
    /// Bitiş Saati
    /// </summary>
        public int? FinishTime
        {
            get { return (int?)this["FINISHTIME"]; }
            set { this["FINISHTIME"] = value; }
        }

    /// <summary>
    /// Komplikasyonsuz Fototerapi Sınırı
    /// </summary>
        public double? UncomplicatedPhototherapy
        {
            get { return (double?)this["UNCOMPLICATEDPHOTOTHERAPY"]; }
            set { this["UNCOMPLICATEDPHOTOTHERAPY"] = value; }
        }

    /// <summary>
    /// Komplikasyonlu Fototerapi Sınırı
    /// </summary>
        public double? ComplicatedPhototherapy
        {
            get { return (double?)this["COMPLICATEDPHOTOTHERAPY"]; }
            set { this["COMPLICATEDPHOTOTHERAPY"] = value; }
        }

    /// <summary>
    /// Komplikasyonsuz Kan Değişim Sınırı
    /// </summary>
        public double? UncomplicatedExcTrans
        {
            get { return (double?)this["UNCOMPLICATEDEXCTRANS"]; }
            set { this["UNCOMPLICATEDEXCTRANS"] = value; }
        }

    /// <summary>
    /// Komplikasyonlu Kan Değişim Sınırı
    /// </summary>
        public double? ComplicatedExcTrans
        {
            get { return (double?)this["COMPLICATEDEXCTRANS"]; }
            set { this["COMPLICATEDEXCTRANS"] = value; }
        }

        protected PhototherapyDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PhototherapyDefinition(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PhototherapyDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PhototherapyDefinition(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PhototherapyDefinition(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHOTOTHERAPYDEFINITION", dataRow) { }
        protected PhototherapyDefinition(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHOTOTHERAPYDEFINITION", dataRow, isImported) { }
        public PhototherapyDefinition(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PhototherapyDefinition(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PhototherapyDefinition() : base() { }

    }
}