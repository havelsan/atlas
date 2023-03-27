
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
    /// Episode Dosyası (Cilt)
    /// </summary>
    public  partial class EpisodeFolder : TTObject
    {
        protected override void PostInsert()
        {
#region PostInsert
            
            SetEpisodeFolderStatus();
#endregion PostInsert
        }

        protected override void PostUpdate()
        {
#region PostUpdate
            
            SetEpisodeFolderStatus();
#endregion PostUpdate
        }

#region Methods
        /// <summary>
        /// EpisodeFolder ın FolderStatus' ünü FolderContent lerin durumuna göre set eder.
        /// </summary>
        protected void SetEpisodeFolderStatus()
        {
            bool isInComplete = false;
            foreach (EpisodeFolderContent episodeFolderContent in FolderContents)
            {
                if (episodeFolderContent.FolderContentStatus == EpisodeFolderContentStatusEnum.InComplete)
                {
                    isInComplete = true;
                    break;
                }
            }
            if (isInComplete == true)
            {
                FolderStatus = false;
            }
            else 
            {
                FolderStatus = true;
            }
        }

        /// PatientFolder a transaction ekler, LastTransaction ve FolderLocation property lerini set eder.
        /// </summary>
        /// <param name="transactionUser"></param>
        /// <param name="transactionType"></param>
        /// <param name="folderLocation"></param>
        public void AddEpisodeFolderTransaction(ResUser transactionUser, FolderTransactionTypeEnum transactionType, ResSection folderLocation)
        {
            EpisodeFolderTransaction episodeFolderTransaction = new EpisodeFolderTransaction(this, transactionUser, transactionType, folderLocation);
            Transactions.Add(episodeFolderTransaction);
            LastEpisodeFolderTransaction = episodeFolderTransaction;
            EpisodeFolderLocation = folderLocation;
        }

        #endregion Methods

    }
}