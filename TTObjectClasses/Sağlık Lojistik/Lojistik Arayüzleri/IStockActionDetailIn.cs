
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
    public partial interface IStockActionDetailIn : IAttributeInterface, IStockActionDetail
    {
        BigCurrency? GetNotDiscountedUnitPrice();
        void SetNotDiscountedUnitPrice(BigCurrency? value);

        int? GetRetrievalYear();
        void SetRetrievalYear(int? value);

        BigCurrency? GetDiscountAmount();
        void SetDiscountAmount(BigCurrency? value);

        BigCurrency? GetDiscountRate();
        void SetDiscountRate(BigCurrency? value);

        BigCurrency? GetUnitPrice();
        void SetUnitPrice(BigCurrency? value);

        DateTime? GetExpirationDate();
        void SetExpirationDate(DateTime? value);

        long? GetVatRate();
        void SetVatRate(long? value);
    }
}