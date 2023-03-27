
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="ComplaintAndSuggestion")] 

    public  partial class ComplaintAndSuggestion : TTObject
    {
        public class ComplaintAndSuggestionList : TTObjectCollection<ComplaintAndSuggestion> { }
                    
        public class ChildComplaintAndSuggestionCollection : TTObject.TTChildObjectCollection<ComplaintAndSuggestion>
        {
            public ChildComplaintAndSuggestionCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildComplaintAndSuggestionCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetComplaintAndSuggestion_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string Desciption
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["DESCIPTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPLAINTANDSUGGESTION"].AllPropertyDefs["DESCIPTION"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string EMail
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["EMAIL"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPLAINTANDSUGGESTION"].AllPropertyDefs["EMAIL"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public ComplationAndSuggestionTypeEnum? ComplationOrSuggestion
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["COMPLATIONORSUGGESTION"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPLAINTANDSUGGESTION"].AllPropertyDefs["COMPLATIONORSUGGESTION"].DataType;
                    return (ComplationAndSuggestionTypeEnum?)(int)dataType.ConvertValue(val);
                }
            }

            public bool? IsRead
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ISREAD"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPLAINTANDSUGGESTION"].AllPropertyDefs["ISREAD"].DataType;
                    return (bool?)dataType.ConvertValue(val);
                }
            }

            public string Name
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["NAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPLAINTANDSUGGESTION"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Surname
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["SURNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPLAINTANDSUGGESTION"].AllPropertyDefs["SURNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string MobilePhone
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MOBILEPHONE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["COMPLAINTANDSUGGESTION"].AllPropertyDefs["MOBILEPHONE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetComplaintAndSuggestion_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetComplaintAndSuggestion_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetComplaintAndSuggestion_Class() : base() { }
        }

        public static BindingList<ComplaintAndSuggestion.GetComplaintAndSuggestion_Class> GetComplaintAndSuggestion(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMPLAINTANDSUGGESTION"].QueryDefs["GetComplaintAndSuggestion"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ComplaintAndSuggestion.GetComplaintAndSuggestion_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<ComplaintAndSuggestion.GetComplaintAndSuggestion_Class> GetComplaintAndSuggestion(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["COMPLAINTANDSUGGESTION"].QueryDefs["GetComplaintAndSuggestion"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<ComplaintAndSuggestion.GetComplaintAndSuggestion_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public ComplationAndSuggestionTypeEnum? ComplationOrSuggestion
        {
            get { return (ComplationAndSuggestionTypeEnum?)(int?)this["COMPLATIONORSUGGESTION"]; }
            set { this["COMPLATIONORSUGGESTION"] = value; }
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
    /// Soyadı
    /// </summary>
        public string Surname
        {
            get { return (string)this["SURNAME"]; }
            set { this["SURNAME"] = value; }
        }

    /// <summary>
    /// Email
    /// </summary>
        public string EMail
        {
            get { return (string)this["EMAIL"]; }
            set { this["EMAIL"] = value; }
        }

    /// <summary>
    /// Hastanın 'Cep Telefonu' Bilgisini Taşıyan Alandır
    /// </summary>
        public string MobilePhone
        {
            get { return (string)this["MOBILEPHONE"]; }
            set { this["MOBILEPHONE"] = value; }
        }

    /// <summary>
    /// Görüş
    /// </summary>
        public string Desciption
        {
            get { return (string)this["DESCIPTION"]; }
            set { this["DESCIPTION"] = value; }
        }

        public bool? IsRead
        {
            get { return (bool?)this["ISREAD"]; }
            set { this["ISREAD"] = value; }
        }

        protected ComplaintAndSuggestion(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected ComplaintAndSuggestion(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected ComplaintAndSuggestion(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected ComplaintAndSuggestion(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected ComplaintAndSuggestion(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "COMPLAINTANDSUGGESTION", dataRow) { }
        protected ComplaintAndSuggestion(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "COMPLAINTANDSUGGESTION", dataRow, isImported) { }
        public ComplaintAndSuggestion(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public ComplaintAndSuggestion(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public ComplaintAndSuggestion() : base() { }

    }
}