
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
    /// Taş Kırma Paket İşlemi
    /// </summary>
    public partial class StoneBreakUpPackageProcedure : SubActionPackageProcedure
    {
        #region Methods
        //public override string GetDVOAyniFarkliKesi()
        //{
        //    return StoneBreakUpRequest?.AyniFarkliKesi?.ayniFarkliKesiKodu;
        //}

        public override string GetDVORaporTakipNo()
        {
            return StoneBreakUpRequest?.MedulaRaporTakipNo;
        }

        #endregion Methods

    }
}