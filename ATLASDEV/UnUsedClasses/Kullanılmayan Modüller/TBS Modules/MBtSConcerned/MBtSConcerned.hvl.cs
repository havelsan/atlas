
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
    [Serializable, TTStorageManager.Attributes.ObjectDefAttribute(Name="MBtSConcerned")] 

    /// <summary>
    /// İlgili
    /// </summary>
    public  partial class MBtSConcerned : TTObject
    {
        public class MBtSConcernedList : TTObjectCollection<MBtSConcerned> { }
                    
        public class ChildMBtSConcernedCollection : TTObject.TTChildObjectCollection<MBtSConcerned>
        {
            public ChildMBtSConcernedCollection(TTObject parent, Guid relDefID) : base(parent, relDefID) { }
            public ChildMBtSConcernedCollection(TTObject.ITTChildObjectCollection parentCollection, string relSubtypeDefName) : base(parentCollection, relSubtypeDefName) { }
        }
                    
    /// <summary>
    /// Kurum/Şirket
    /// </summary>
        public string Firm
        {
            get { return (string)this["FIRM"]; }
            set { this["FIRM"] = value; }
        }

    /// <summary>
    /// Soyad
    /// </summary>
        public string Surname
        {
            get { return (string)this["SURNAME"]; }
            set { this["SURNAME"] = value; }
        }

    /// <summary>
    /// Ad
    /// </summary>
        public string Name
        {
            get { return (string)this["NAME"]; }
            set { this["NAME"] = value; }
        }

    /// <summary>
    /// Hesap No
    /// </summary>
        public string AccountNumber
        {
            get { return (string)this["ACCOUNTNUMBER"]; }
            set { this["ACCOUNTNUMBER"] = value; }
        }

        virtual protected void CreateOperationCollection()
        {
            _Operation = new MBtSOperation.ChildMBtSOperationCollection(this, new Guid("e42b6b06-58bb-4a4b-b6d7-ceeeed7538ac"));
            ((ITTChildObjectCollection)_Operation).GetChildren();
        }

        protected MBtSOperation.ChildMBtSOperationCollection _Operation = null;
        public MBtSOperation.ChildMBtSOperationCollection Operation
        {
            get
            {
                if (_Operation == null)
                    CreateOperationCollection();
                return _Operation;
            }
        }

        protected MBtSConcerned(TTObjectContext objectContext, string objectDefName, DataRow dataRow) : base(objectContext, objectDefName, dataRow) { }
        protected MBtSConcerned(TTObjectContext objectContext, string objectDefName, DataRow dataRow, bool isImported) : base(objectContext, objectDefName, dataRow, isImported) { }
        protected MBtSConcerned(TTObjectContext objectContext, string objectDefName, Guid objectID) : base(objectContext, objectDefName, objectID) { }
        protected MBtSConcerned(TTObjectContext objectContext, string objectDefName, Guid objectID, bool isImported) : base(objectContext, objectDefName, objectID, isImported) { }
        protected MBtSConcerned(TTObjectContext objectContext, DataRow dataRow) : base(objectContext, "MBTSCONCERNED", dataRow) { }
        protected MBtSConcerned(TTObjectContext objectContext, DataRow dataRow, bool isImported) : base(objectContext, "MBTSCONCERNED", dataRow, isImported) { }
        public MBtSConcerned(TTObjectContext objectContext) : this(objectContext, (DataRow)null) { }

        public MBtSConcerned(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public MBtSConcerned() : base() { }

    }
}