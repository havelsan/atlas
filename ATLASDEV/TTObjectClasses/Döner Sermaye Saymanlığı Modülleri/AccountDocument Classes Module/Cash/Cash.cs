
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
    /// Nakit Ödeme Türü
    /// </summary>
    public  partial class Cash : Payment
    {
#region Methods
        override protected void OnConstruct()
        {
            ITTObject ttObject = (ITTObject)this;
            if(ttObject.IsNew)
            {
                if (CurrencyType == null)
                {
                    IList curTypeList  = CurrencyTypeDefinition.GetByQref(ObjectContext,"TL");
                    if (curTypeList.Count != 0)
                    {
                        foreach (CurrencyTypeDefinition curType in curTypeList)
                        {
                            CurrencyType = curType;
                            break ;
                        }
                    }
                }
                
            }
            
        }
        
        // Default olarak nakit ödeme tutarı ve  TL para birimi set ediliyor
        
#endregion Methods

    }
}