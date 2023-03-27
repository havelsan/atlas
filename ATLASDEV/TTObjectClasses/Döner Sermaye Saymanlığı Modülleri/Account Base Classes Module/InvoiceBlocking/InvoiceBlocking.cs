
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
    /// Fatura Engelleri
    /// </summary>
    public  partial class InvoiceBlocking : TTObject
    {
        public static void saveNewInvoiceBlocking(Guid episodeObjectID, string invoiceBlockingDescription,string moduleName,InvoiceBlockingTypeEnum type = InvoiceBlockingTypeEnum.ManuelBlock,TTObjectContext objectContext = null)
        {
            if(objectContext == null)
                objectContext = new TTObjectContext(false);

            InvoiceBlocking ib = new InvoiceBlocking(objectContext);

            Episode ep = (Episode)objectContext.GetObject(episodeObjectID, typeof(Episode));
            ib.Episode = ep;
            ib.BlockDescription = invoiceBlockingDescription;
            ib.BlockingType = type;
            ib.BlockDate = DateTime.Now;
            ib.BlockUser = Common.CurrentResource;
            ib.ModuleName = moduleName;
            ib.Active = true;

            objectContext.Save();
            objectContext.FullPartialllyLoadedObjects();
        }

        public static InvoiceBlocking passInvoiceBlocking(Guid ibObjectID, string passInvoiceBlockingDescription, TTObjectContext objectContext = null)
        {
            if (objectContext == null)
                objectContext = new TTObjectContext(false);

            InvoiceBlocking ib = (InvoiceBlocking)objectContext.GetObject(ibObjectID, typeof(InvoiceBlocking));

            ib.Active = false;
            ib.UnblockDate = DateTime.Now;
            ib.UnblockUser = Common.CurrentResource;
            ib.UnblockDescription = passInvoiceBlockingDescription;

            objectContext.Save();
            objectContext.FullPartialllyLoadedObjects();
            return ib;
        }
    }
}