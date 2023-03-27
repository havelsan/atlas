
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
    /// Hasta Dosyası
    /// </summary>
    public  partial class PatientFolder : TTObject
    {
        protected override void PostInsert()
        {
#region PostInsert
            
            SetPatientFolderStatus();
#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            SetPatientFolderStatus();
#endregion PostUpdate
        }

#region Methods
        protected override void OnConstruct()
        {
            base.OnConstruct();
            ITTObject ttObject = (ITTObject)this;
            if(ttObject.IsNew)
            {
                PatientFolderID.GetNextValue();
            }
        }
        
        /// <summary>
        /// PatientFolder a transaction ekler, LastTransaction ve FolderLocation property lerini set eder.
        /// </summary>
        /// <param name="transactionUser"></param>
        /// <param name="transactionType"></param>
        /// <param name="folderLocation"></param>
        public void AddPatientFolderTransaction(ResUser transactionUser,FolderTransactionTypeEnum transactionType,ResSection folderLocation)
        {
            PatientFolderTransaction patientFolderTransaction = new PatientFolderTransaction(this,transactionUser,transactionType,folderLocation);
            Transactions.Add(patientFolderTransaction);
            LastPatientFolderTransaction = patientFolderTransaction;
            FolderLocation = folderLocation;
        }
        
        /// <summary>
        /// PatientFolder ın FolderStatus unu EpisodeFolder larının FolderStatus üne göre set eder.
        /// </summary>
        protected void SetPatientFolderStatus()
        {
            bool isInComplete = false;
            foreach (EpisodeFolder episodeFolder in EpisodeFolders)
            {
                if (episodeFolder.FolderStatus == false)
                {
                    isInComplete = true;
                    break;
                }
            }
            if (isInComplete == true)
            {
                FolderStatus = FolderStatusEnum.Incomplete;
            }
            else
            {
                FolderStatus = FolderStatusEnum.Complete;
            }
        }
        
#endregion Methods

    }
}