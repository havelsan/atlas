
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="VerbalAndPerformanceTests")] 

    public  partial class VerbalAndPerformanceTests : BasePsychologyForm
    {
        public class VerbalAndPerformanceTestsList : TTObjectCollection<VerbalAndPerformanceTests> { }
                    
        public class ChildVerbalAndPerformanceTestsCollection : TTObject.TTChildObjectCollection<VerbalAndPerformanceTests>
        {
            public ChildVerbalAndPerformanceTestsCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildVerbalAndPerformanceTestsCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
        [Serializable] 

        public partial class VerbalAndPerformanceTestsFormList_Class : TTReportNqlObject 
        {
            public Guid? ObjectID
            {
                get
                {
                    return ConnectionManager.FromDBNullableGuid(_dataRow["OBJECTID"]);
                }
            }

            public DateTime? AddedDate
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDEDDATE"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["VERBALANDPERFORMANCETESTS"].AllPropertyDefs["ADDEDDATE"].DataType;
                    return (DateTime?)dataType.ConvertValue(val);
                }
            }

            public string Addeduser
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["ADDEDUSER"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public string Proceduredoctor
            {
                get
                {
                    object val = Globals.FromDBValue(_dataRow["PROCEDUREDOCTOR"]);
                    if (val == null)
                        return null;
                    TTDataType dataType = TTObjectDefManager.Instance.ObjectDefs["RESUSER"].AllPropertyDefs["NAME"].DataType;
                    return (string)dataType.ConvertValue(val);
                }
            }

            public VerbalAndPerformanceTestsFormList_Class(TTObjectContext objectContext, string objectDefName, DataRow row) : base(objectContext, objectDefName, row) { }
            public VerbalAndPerformanceTestsFormList_Class(SerializationInfo info, StreamingContext context) : base(info, context) { }
            protected VerbalAndPerformanceTestsFormList_Class() : base() { }
        }

        public static BindingList<VerbalAndPerformanceTests.VerbalAndPerformanceTestsFormList_Class> VerbalAndPerformanceTestsFormList(Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VERBALANDPERFORMANCETESTS"].QueryDefs["VerbalAndPerformanceTestsFormList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<VerbalAndPerformanceTests.VerbalAndPerformanceTestsFormList_Class>(queryDef, paramList, pi);
        }

        public static BindingList<VerbalAndPerformanceTests.VerbalAndPerformanceTestsFormList_Class> VerbalAndPerformanceTestsFormList(TTObjectContext objectContext, Guid EPISODE, PaginationInfo pi = null)
        {
            TTQueryDef queryDef = TTObjectDefManager.Instance.ObjectDefs["VERBALANDPERFORMANCETESTS"].QueryDefs["VerbalAndPerformanceTestsFormList"];
            Dictionary<string, object> paramList = new Dictionary<string, object>();
            paramList.Add("EPISODE", EPISODE);

            return TTReportNqlObject.QueryObjects<VerbalAndPerformanceTests.VerbalAndPerformanceTestsFormList_Class>(objectContext, queryDef, paramList, pi);
        }

    /// <summary>
    /// Genel Bilgi
    /// </summary>
        public double? GeneralInformation
        {
            get { return (double?)this["GENERALINFORMATION"]; }
            set { this["GENERALINFORMATION"] = value; }
        }

    /// <summary>
    /// Benzerlikler
    /// </summary>
        public double? Similarities
        {
            get { return (double?)this["SIMILARITIES"]; }
            set { this["SIMILARITIES"] = value; }
        }

    /// <summary>
    /// Aritmetik
    /// </summary>
        public double? Arithmetic
        {
            get { return (double?)this["ARITHMETIC"]; }
            set { this["ARITHMETIC"] = value; }
        }

    /// <summary>
    /// Sözcük Dağarcığı
    /// </summary>
        public double? Vocabulary
        {
            get { return (double?)this["VOCABULARY"]; }
            set { this["VOCABULARY"] = value; }
        }

    /// <summary>
    /// Yargılama
    /// </summary>
        public double? Trial
        {
            get { return (double?)this["TRIAL"]; }
            set { this["TRIAL"] = value; }
        }

    /// <summary>
    /// Sayı Dizisi
    /// </summary>
        public double? NumberSequence
        {
            get { return (double?)this["NUMBERSEQUENCE"]; }
            set { this["NUMBERSEQUENCE"] = value; }
        }

    /// <summary>
    /// Resim Tamamlama
    /// </summary>
        public double? ImageCompletion
        {
            get { return (double?)this["IMAGECOMPLETION"]; }
            set { this["IMAGECOMPLETION"] = value; }
        }

    /// <summary>
    /// Resim Düzenleme
    /// </summary>
        public double? ImageEditing
        {
            get { return (double?)this["IMAGEEDITING"]; }
            set { this["IMAGEEDITING"] = value; }
        }

    /// <summary>
    /// Küplerle Desen
    /// </summary>
        public double? PatternWithCubes
        {
            get { return (double?)this["PATTERNWITHCUBES"]; }
            set { this["PATTERNWITHCUBES"] = value; }
        }

    /// <summary>
    /// Parça Birleştirme
    /// </summary>
        public double? PieceAssembly
        {
            get { return (double?)this["PIECEASSEMBLY"]; }
            set { this["PIECEASSEMBLY"] = value; }
        }

    /// <summary>
    /// Şifre
    /// </summary>
        public double? Password
        {
            get { return (double?)this["PASSWORD"]; }
            set { this["PASSWORD"] = value; }
        }

    /// <summary>
    /// Labirentler
    /// </summary>
        public double? Mazes
        {
            get { return (double?)this["MAZES"]; }
            set { this["MAZES"] = value; }
        }

        protected VerbalAndPerformanceTests(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected VerbalAndPerformanceTests(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected VerbalAndPerformanceTests(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected VerbalAndPerformanceTests(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected VerbalAndPerformanceTests(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "VERBALANDPERFORMANCETESTS", dataRow) { }
        protected VerbalAndPerformanceTests(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "VERBALANDPERFORMANCETESTS", dataRow, isImported) { }
        public VerbalAndPerformanceTests(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public VerbalAndPerformanceTests(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public VerbalAndPerformanceTests() : base() { }

    }
}