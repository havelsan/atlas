
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
    /// Dosya hareketleri
    /// </summary>
    public  partial class PatientFolderTransaction : TTObject
    {
        public partial class VEM_HASTA_ARSIV_HAREKET_Class : TTReportNqlObject 
        {
        }

#region Methods
        /// <summary>
        /// PatientFolder a eklenecek transaction create edilir.
        /// </summary>
        /// <param name="patientFolder"></param>
        /// <param name="transactionUser"></param>
        /// <param name="transactionType"></param>
        /// <param name="folderLocation"></param>
        public PatientFolderTransaction(PatientFolder patientFolder, ResUser transactionUser, FolderTransactionTypeEnum transactionType, ResSection folderLocation) : this(patientFolder.ObjectContext)
        {
            TransactionDate = Common.RecTime().Date;
            TransactionType = transactionType;
            FolderLocation = folderLocation;
            TransactionUser = transactionUser;
        }
        
#endregion Methods

    }
}