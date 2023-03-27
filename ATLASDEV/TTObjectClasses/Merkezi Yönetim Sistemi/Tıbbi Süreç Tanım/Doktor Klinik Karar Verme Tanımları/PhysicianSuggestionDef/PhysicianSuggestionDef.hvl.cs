
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="PhysicianSuggestionDef")] 

    /// <summary>
    /// Doktor Klinik Karar Verme Tanımları
    /// </summary>
    public  partial class PhysicianSuggestionDef : TerminologyManagerDef
    {
        public class PhysicianSuggestionDefList : TTObjectCollection<PhysicianSuggestionDef> { }
                    
        public class ChildPhysicianSuggestionDefCollection : TTObject.TTChildObjectCollection<PhysicianSuggestionDef>
        {
            public ChildPhysicianSuggestionDefCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildPhysicianSuggestionDefCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class GetPhysicianSuggestionDefList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public string GrupName
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["GRUPNAME"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANSUGGESTIONDEF"].AllPropertyDefs["GRUPNAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Message
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["MESSAGE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANSUGGESTIONDEF"].AllPropertyDefs["MESSAGE"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public GetPhysicianSuggestionDefList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public GetPhysicianSuggestionDefList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected GetPhysicianSuggestionDefList_Class() : base() { }
        }

        public static BindingList<PhysicianSuggestionDef.GetPhysicianSuggestionDefList_Class> GetPhysicianSuggestionDefList(string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANSUGGESTIONDEF"].QueryDefs["GetPhysicianSuggestionDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhysicianSuggestionDef.GetPhysicianSuggestionDefList_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PhysicianSuggestionDef.GetPhysicianSuggestionDefList_Class> GetPhysicianSuggestionDefList(TTObjectContext objectContext, string injectionSQL, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANSUGGESTIONDEF"].QueryDefs["GetPhysicianSuggestionDefList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();

            return TTReportNqlObject.QueryObjects<PhysicianSuggestionDef.GetPhysicianSuggestionDefList_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<PhysicianSuggestionDef> GetByGroupName(TTObjectContext objectContext, string GRUPNAME)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["PHYSICIANSUGGESTIONDEF"].QueryDefs["GetByGroupName"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("GRUPNAME", GRUPNAME);

            return ((ITTQuery)objectContext).QueryObjects<PhysicianSuggestionDef>(queryDef, paramList);
        }

        public string GrupName
        {
            get { return (string)this["GRUPNAME"]; }
            set { this["GRUPNAME"] = value; }
        }

        public string ButtonCaptions
        {
            get { return (string)this["BUTTONCAPTIONS"]; }
            set { this["BUTTONCAPTIONS"] = value; }
        }

        public string ReturnValues
        {
            get { return (string)this["RETURNVALUES"]; }
            set { this["RETURNVALUES"] = value; }
        }

        public string Message
        {
            get { return (string)this["MESSAGE"]; }
            set { this["MESSAGE"] = value; }
        }

        public string ReturnValueOfParent
        {
            get { return (string)this["RETURNVALUEOFPARENT"]; }
            set { this["RETURNVALUEOFPARENT"] = value; }
        }

        public PhysicianSuggestionDef ParentPhysicianSuggestionDef
        {
            get { return (PhysicianSuggestionDef)((ITTObject)this).GetParent("PARENTPHYSICIANSUGGESTIONDEF"); }
            set { this["PARENTPHYSICIANSUGGESTIONDEF"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Önerilen Hizmet
    /// </summary>
        public ProcedureDefinition ProcedureDefinition
        {
            get { return (ProcedureDefinition)((ITTObject)this).GetParent("PROCEDUREDEFINITION"); }
            set { this["PROCEDUREDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        public DiagnosisDefinition DiagnosisDefinition
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSISDEFINITION"); }
            set { this["DIAGNOSISDEFINITION"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        virtual protected void CreateChildPhysicianSuggestionDefsCollection()
        {
            _ChildPhysicianSuggestionDefs = new PhysicianSuggestionDef.ChildPhysicianSuggestionDefCollection(this, new Guid("9b136518-a955-4a1a-a9b4-e3280e418fe1"));
            ((ITTChildObjectCollection)_ChildPhysicianSuggestionDefs).GetChildren();
        }

        protected PhysicianSuggestionDef.ChildPhysicianSuggestionDefCollection _ChildPhysicianSuggestionDefs = null;
        public PhysicianSuggestionDef.ChildPhysicianSuggestionDefCollection ChildPhysicianSuggestionDefs
        {
            get
            {
                if (_ChildPhysicianSuggestionDefs == null)
                    CreateChildPhysicianSuggestionDefsCollection();
                return _ChildPhysicianSuggestionDefs;
            }
        }

        protected PhysicianSuggestionDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected PhysicianSuggestionDef(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected PhysicianSuggestionDef(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected PhysicianSuggestionDef(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected PhysicianSuggestionDef(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "PHYSICIANSUGGESTIONDEF", dataRow) { }
        protected PhysicianSuggestionDef(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "PHYSICIANSUGGESTIONDEF", dataRow, isImported) { }
        public PhysicianSuggestionDef(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public PhysicianSuggestionDef(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public PhysicianSuggestionDef() : base() { }

    }
}