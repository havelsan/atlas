
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBSTravelExpense")] 

    /// <summary>
    /// Yolluk
    /// </summary>
    public  partial class MBSTravelExpense : TTObject
    {
        public class MBSTravelExpenseList : TTObjectCollection<MBSTravelExpense> { }
                    
        public class ChildMBSTravelExpenseCollection : TTObject.TTChildObjectCollection<MBSTravelExpense>
        {
            public ChildMBSTravelExpenseCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBSTravelExpenseCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Net Tutar
    /// </summary>
        public double? NetIncome
        {
            get { return (double?)this["NETINCOME"]; }
            set { this["NETINCOME"] = value; }
        }

    /// <summary>
    /// Tutar
    /// </summary>
        public double? Total
        {
            get { return (double?)this["TOTAL"]; }
            set { this["TOTAL"] = value; }
        }

        virtual protected void CreateTravelsCollection()
        {
            _Travels = new MBSTravel.ChildMBSTravelCollection(this, new Guid("0683d924-e27e-43fb-a345-f3a2ddfac9af"));
            ((ITTChildObjectCollection)_Travels).GetChildren();
        }

        protected MBSTravel.ChildMBSTravelCollection _Travels = null;
        public MBSTravel.ChildMBSTravelCollection Travels
        {
            get
            {
                if (_Travels == null)
                    CreateTravelsCollection();
                return _Travels;
            }
        }

        protected MBSTravelExpense(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBSTravelExpense(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBSTravelExpense(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBSTravelExpense(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBSTravelExpense(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBSTRAVELEXPENSE", dataRow) { }
        protected MBSTravelExpense(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBSTRAVELEXPENSE", dataRow, isImported) { }
        public MBSTravelExpense(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBSTravelExpense(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBSTravelExpense() : base() { }

    }
}