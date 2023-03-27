
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
    /// Stok Rezervasyonu için kullanılan sınıftır. Rezervasyonla ilgili bilgileri tutar
    /// </summary>
    public  partial class StockReservation : TTObject
    {
#region Methods
        public void CancelReservation()
        {
            CurrentStateDefID = StockReservation.States.Cancelled;
            foreach (StockActionDetailOut stockActionOutDetail in StockActionOutDetails)
            {
                foreach (QRCodeOutDetail qRCodeOutDetail in stockActionOutDetail.QRCodeOutDetails)
                {
                    if (qRCodeOutDetail.QRCodeTransaction.CurrentStateDefID == QRCodeTransaction.States.Reserved)
                        qRCodeOutDetail.QRCodeTransaction.CurrentStateDefID = QRCodeTransaction.States.Usable;
                }
            }
        }
        
        public void CompletedReservation()
        {
            CurrentStateDefID = StockReservation.States.Completed;
        }
        
#endregion Methods

    }
}