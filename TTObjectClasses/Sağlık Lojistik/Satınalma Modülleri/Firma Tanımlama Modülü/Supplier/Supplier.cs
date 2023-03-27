
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
    /// <summary>
    /// Tedarikçi tanımlama modülü için ana sınıftır
    /// </summary>
    public  partial class Supplier : TerminologyManagerDef, ISupplier
    {
        public partial class SupplierDefFormNQL_Class : TTReportNqlObject 
        {
        }

        public partial class GetSupplierRecordReportQuery_Class : TTReportNqlObject 
        {
        }

        #region Methods
        #region ITTCoreObject Members

        public TTObjectDef GetObjectDef()
        {
            return ObjectDef;
        }

        public Guid GetObjectID()
        {
            return ObjectID;
        }
        #endregion
        #region ITTCoreDefinitionObject Members
        public DateTime? GetLastUpdate()
        {
            return LastUpdate;
        }

        public bool? GetIsActive()
        {
            return IsActive;
        }
        #endregion
        #region ISupplier Members
        public string GetTaxNo()
        {
            return TaxNo;
        }

        public string GetSupplierNumber()
        {
            return SupplierNumber;
        }
        public void SetSupplierNumber(string value)
        {
            SupplierNumber = value;
        }

        public string GetName()
        {
            return Name;
        }

        public TTSequence GetCode()
        {
            return Code;
        }
        #endregion
        protected override void OnConstruct()
        {
            base.OnConstruct();
            if (((ITTObject)this).IsNew)
                Code.GetNextValue();
        }

        protected override void PostInsert()
        {
            #region PostInsert
            base.PostInsert();

            //this.Code.GetNextValue("firma");

            #endregion PostInsert
        }

#endregion Methods

    }
}