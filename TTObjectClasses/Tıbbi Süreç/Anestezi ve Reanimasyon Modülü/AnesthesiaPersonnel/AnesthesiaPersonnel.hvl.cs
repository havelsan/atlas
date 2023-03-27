
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="AnesthesiaPersonnel")] 

    /// <summary>
    /// Anestezi Ekibi
    /// </summary>
    public  partial class AnesthesiaPersonnel : BaseAnesthesiaPersonnel
    {
        public class AnesthesiaPersonnelList : TTObjectCollection<AnesthesiaPersonnel> { }
                    
        public class ChildAnesthesiaPersonnelCollection : TTObject.TTChildObjectCollection<AnesthesiaPersonnel>
        {
            public ChildAnesthesiaPersonnelCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildAnesthesiaPersonnelCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetBySurgery_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public UserTitleEnum? Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Role
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAPERSONNEL"].AllPropertyDefs["ROLE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetBySurgery_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetBySurgery_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetBySurgery_Class() : base() { }
        }

        [Serializable] 

        public partial class GetByAnestesiaAndReanimation_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public UserTitleEnum? Title
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["TITLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["TITLE"].DataType;
                    return (UserTitleEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Role
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ROLE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAPERSONNEL"].AllPropertyDefs["ROLE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetByAnestesiaAndReanimation_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetByAnestesiaAndReanimation_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetByAnestesiaAndReanimation_Class() : base() { }
        }

        public static BindingList<AnesthesiaPersonnel.GetBySurgery_Class> GetBySurgery(Guid SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAPERSONNEL"].QueryDefs["GetBySurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<AnesthesiaPersonnel.GetBySurgery_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AnesthesiaPersonnel.GetBySurgery_Class> GetBySurgery(TTObjectContext objectContext, Guid SURGERY, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAPERSONNEL"].QueryDefs["GetBySurgery"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("SURGERY", SURGERY);

            return TTReportNqlObject.QueryObjects<AnesthesiaPersonnel.GetBySurgery_Class>(objectContext, queryDef, paramList, pi);
        }

        public static BindingList<AnesthesiaPersonnel.GetByAnestesiaAndReanimation_Class> GetByAnestesiaAndReanimation(Guid ANESTHESIAANDREANIMATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAPERSONNEL"].QueryDefs["GetByAnestesiaAndReanimation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ANESTHESIAANDREANIMATION", ANESTHESIAANDREANIMATION);

            return TTReportNqlObject.QueryObjects<AnesthesiaPersonnel.GetByAnestesiaAndReanimation_Class>(queryDef, paramList, pi);
        }

        public static BindingList<AnesthesiaPersonnel.GetByAnestesiaAndReanimation_Class> GetByAnestesiaAndReanimation(TTObjectContext objectContext, Guid ANESTHESIAANDREANIMATION, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["ANESTHESIAPERSONNEL"].QueryDefs["GetByAnestesiaAndReanimation"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("ANESTHESIAANDREANIMATION", ANESTHESIAANDREANIMATION);

            return TTReportNqlObject.QueryObjects<AnesthesiaPersonnel.GetByAnestesiaAndReanimation_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Görevi
    /// </summary>
        public string Role
        {
            get { return (string)this["ROLE"]; }
            set { this["ROLE"] = value; }
        }

    /// <summary>
    /// Anestezi Ekibi
    /// </summary>
        public AnesthesiaAndReanimation AnesthesiaAndReanimation
        {
            get { return (AnesthesiaAndReanimation)((ITTObject)this).GetParent("ANESTHESIAANDREANIMATION"); }
            set { this["ANESTHESIAANDREANIMATION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected AnesthesiaPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected AnesthesiaPersonnel(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected AnesthesiaPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected AnesthesiaPersonnel(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected AnesthesiaPersonnel(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "ANESTHESIAPERSONNEL", dataRow) { }
        protected AnesthesiaPersonnel(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "ANESTHESIAPERSONNEL", dataRow, isImported) { }
        public AnesthesiaPersonnel(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public AnesthesiaPersonnel(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public AnesthesiaPersonnel() : base() { }

    }
}