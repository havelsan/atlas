
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSStudentAllowance")] 

    public  partial class MBSStudentAllowance : TTObject
    {
        public class MBSStudentAllowanceList : TTObjectCollection<MBSStudentAllowance> { }
                    
        public class ChildMBSStudentAllowanceCollection : TTObject.TTChildObjectCollection<MBSStudentAllowance>
        {
            public ChildMBSStudentAllowanceCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSStudentAllowanceCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Toplam kesinti
    /// </summary>
        public double? Reduction
        {
            get { return (double?)this["REDUCTION"]; }
            set { this["REDUCTION"] = value; }
        }

    /// <summary>
    /// Em.Kes.Devlet Katkısı
    /// </summary>
        public double? EMKESStudentContribution
        {
            get { return (double?)this["EMKESSTUDENTCONTRIBUTION"]; }
            set { this["EMKESSTUDENTCONTRIBUTION"] = value; }
        }

    /// <summary>
    /// Devlet katkısı
    /// </summary>
        public double? GovernmentContribution
        {
            get { return (double?)this["GOVERNMENTCONTRIBUTION"]; }
            set { this["GOVERNMENTCONTRIBUTION"] = value; }
        }

    /// <summary>
    /// Harçlık
    /// </summary>
        public double? Allowance
        {
            get { return (double?)this["ALLOWANCE"]; }
            set { this["ALLOWANCE"] = value; }
        }

    /// <summary>
    /// Genel toplam
    /// </summary>
        public double? Total
        {
            get { return (double?)this["TOTAL"]; }
            set { this["TOTAL"] = value; }
        }

    /// <summary>
    /// Net İta
    /// </summary>
        public double? NetIncome
        {
            get { return (double?)this["NETINCOME"]; }
            set { this["NETINCOME"] = value; }
        }

        protected MBSStudentAllowance(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSStudentAllowance(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSStudentAllowance(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSStudentAllowance(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSStudentAllowance(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSSTUDENTALLOWANCE", dataRow) { }
        protected MBSStudentAllowance(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSSTUDENTALLOWANCE", dataRow, isImported) { }
        public MBSStudentAllowance(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSStudentAllowance(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSStudentAllowance() : base() { }

    }
}