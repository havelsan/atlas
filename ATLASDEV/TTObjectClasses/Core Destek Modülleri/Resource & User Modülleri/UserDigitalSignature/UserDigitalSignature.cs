
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
    /// Kullanıcı e-imza
    /// </summary>
    public  partial class UserDigitalSignature : TTObject
    {
#region Methods
        [Serializable]
        public class Encrypto
        {

            private Guid _userID;
            public Guid UserID
            {
                get { return _userID; }
                set { _userID = value; }
            }

            private string _userName;
            public string UserName
            {
                get { return _userName; }
                set { _userName = value; }
            }

            private DateTime _signingDate;
            public DateTime SigningDate
            {
                get { return _signingDate; }
                set { _signingDate = value; }
            }
            
            private byte[] _signature;
            public byte[] Signature
            {
                get { return _signature; }
                set { _signature = value; }
            }

            private string _text;
            public string Text
            {
                get { return _text; }
                set { _text = value; }
            }

        }
        
#endregion Methods

    }
}