
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="FavoriteDiagnosis")] 

    public  partial class FavoriteDiagnosis : TTObject
    {
        public class FavoriteDiagnosisList : TTObjectCollection<FavoriteDiagnosis> { }
                    
        public class ChildFavoriteDiagnosisCollection : TTObject.TTChildObjectCollection<FavoriteDiagnosis>
        {
            public ChildFavoriteDiagnosisCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildFavoriteDiagnosisCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class CountFavoriteDiagnosis_Class : TTReportNqlObject 
        {
            public Object Nqlcolumn
            {
                get
                {
                    return Globals.FromDBValue(_dataRow["NQLCOLUMN"]);
                }
            }

            public CountFavoriteDiagnosis_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public CountFavoriteDiagnosis_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected CountFavoriteDiagnosis_Class() : base() { }
        }

        public static BindingList<FavoriteDiagnosis> GetFavoriteDiagnosis(TTObjectContext objectContext, string USER, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FAVORITEDIAGNOSIS"].QueryDefs["GetFavoriteDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);

            return ((ITTQuery)objectContext).QueryObjects<FavoriteDiagnosis>(queryDef, paramList, injectionSQL);
        }

        public static BindingList<FavoriteDiagnosis.CountFavoriteDiagnosis_Class> CountFavoriteDiagnosis(string USER, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FAVORITEDIAGNOSIS"].QueryDefs["CountFavoriteDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<FavoriteDiagnosis.CountFavoriteDiagnosis_Class>(queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FavoriteDiagnosis.CountFavoriteDiagnosis_Class> CountFavoriteDiagnosis(TTObjectContext objectContext, string USER, string injectionSQL = null, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FAVORITEDIAGNOSIS"].QueryDefs["CountFavoriteDiagnosis"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);

            return TTReportNqlObject.QueryObjects<FavoriteDiagnosis.CountFavoriteDiagnosis_Class>(objectContext, queryDef, paramList, injectionSQL, pi);
        }

        public static BindingList<FavoriteDiagnosis> GetFavoriteDiagnosisByUserAndDiagnose(TTObjectContext objectContext, string USER, string DIAGNOSE, string injectionSQL = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["FAVORITEDIAGNOSIS"].QueryDefs["GetFavoriteDiagnosisByUserAndDiagnose"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("USER", USER);
            paramList.Add("DIAGNOSE", DIAGNOSE);

            return ((ITTQuery)objectContext).QueryObjects<FavoriteDiagnosis>(queryDef, paramList, injectionSQL);
        }

        public int? Order
        {
            get { return (int?)this["ORDER"]; }
            set { this["ORDER"] = value; }
        }

    /// <summary>
    /// Tanı
    /// </summary>
        public DiagnosisDefinition Diagnose
        {
            get { return (DiagnosisDefinition)((ITTObject)this).GetParent("DIAGNOSE"); }
            set { this["DIAGNOSE"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

    /// <summary>
    /// Kullanıcı
    /// </summary>
        public ResUser User
        {
            get { return (ResUser)((ITTObject)this).GetParent("USER"); }
            set { this["USER"] = (value==null ? null : (Guid?)value.ObjectID); }
        }

        protected FavoriteDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected FavoriteDiagnosis(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected FavoriteDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected FavoriteDiagnosis(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected FavoriteDiagnosis(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "FAVORITEDIAGNOSIS", dataRow) { }
        protected FavoriteDiagnosis(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "FAVORITEDIAGNOSIS", dataRow, isImported) { }
        public FavoriteDiagnosis(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public FavoriteDiagnosis(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public FavoriteDiagnosis() : base() { }

    }
}