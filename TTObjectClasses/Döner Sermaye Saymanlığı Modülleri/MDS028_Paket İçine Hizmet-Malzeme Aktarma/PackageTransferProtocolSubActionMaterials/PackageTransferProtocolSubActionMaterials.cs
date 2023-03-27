
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
    /// Paket İçine Hizmet/Malzeme Aktarma Malzeme Hareketleri
    /// </summary>
    public  partial class PackageTransferProtocolSubActionMaterials : TTObject
    {
    /// <summary>
    /// İşlem Tarihi
    /// </summary>
        public DateTime? PricingDate
        {
            get
            {
                try
                {
#region PricingDate_GetScript                    
                    if (SubActionMaterial != null)
                    return SubActionMaterial.PricingDate;

                return null;
#endregion PricingDate_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "PricingDate") + " : " + ex.Message, ex);
                }
            }
        }

    /// <summary>
    /// Malzeme Kodu
    /// </summary>
        public string MaterialCode
        {
            get
            {
                try
                {
#region MaterialCode_GetScript                    
                    if(SubActionMaterial != null)
                {
                    if(SubActionMaterial.Material != null)
                        return SubActionMaterial.Material.Code;
                }

                return null;
#endregion MaterialCode_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "MaterialCode") + " : " + ex.Message, ex);
                }
            }
        }

    /// <summary>
    /// Malzeme Adı
    /// </summary>
        public string MaterialName
        {
            get
            {
                try
                {
#region MaterialName_GetScript                    
                    if(SubActionMaterial != null)
                {
                    if(SubActionMaterial.Material != null)
                        return SubActionMaterial.Material.Name;
                }

                return null;
#endregion MaterialName_GetScript
                }
                catch (Exception ex)
                {
                    throw new TTException(TTUtils.CultureService.GetText("M148", "Error getting property '{0}'", "MaterialName") + " : " + ex.Message, ex);
                }
            }
        }

    }
}