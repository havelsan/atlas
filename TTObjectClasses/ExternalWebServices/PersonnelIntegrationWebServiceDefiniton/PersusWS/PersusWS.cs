
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
    /// Personnel Entegrasyonunda Sunulan WebServis Objesi
    /// </summary>
    public  partial class PersusWS : TTObject
    {
        public static partial class WebMethods
        {
                    
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com.persus/")]
        public partial class wsRole
        {

            private string idField;

            private string nameField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string id
            {
                get
                {
                    return idField;
                }
                set
                {
                    idField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string name
            {
                get
                {
                    return nameField;
                }
                set
                {
                    nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com.persus/")]
        public partial class wsIzin
        {

            private System.DateTime baslangicField;

            private bool baslangicFieldSpecified;

            private System.DateTime bitisField;

            private bool bitisFieldSpecified;

            private string izinturuField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public System.DateTime baslangic
            {
                get
                {
                    return baslangicField;
                }
                set
                {
                    baslangicField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool baslangicSpecified
            {
                get
                {
                    return baslangicFieldSpecified;
                }
                set
                {
                    baslangicFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public System.DateTime bitis
            {
                get
                {
                    return bitisField;
                }
                set
                {
                    bitisField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool bitisSpecified
            {
                get
                {
                    return bitisFieldSpecified;
                }
                set
                {
                    bitisFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string izinturu
            {
                get
                {
                    return izinturuField;
                }
                set
                {
                    izinturuField = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com.persus/")]
        public partial class wsIzinResult
        {

            private wsIzin[] detailField;

            private int errorCodeField;

            private bool errorCodeFieldSpecified;

            private string errorMsgField;

            private int statusField;

            private bool statusFieldSpecified;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("detail", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public wsIzin[] detail
            {
                get
                {
                    return detailField;
                }
                set
                {
                    detailField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int errorCode
            {
                get
                {
                    return errorCodeField;
                }
                set
                {
                    errorCodeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool errorCodeSpecified
            {
                get
                {
                    return errorCodeFieldSpecified;
                }
                set
                {
                    errorCodeFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string errorMsg
            {
                get
                {
                    return errorMsgField;
                }
                set
                {
                    errorMsgField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int status
            {
                get
                {
                    return statusField;
                }
                set
                {
                    statusField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool statusSpecified
            {
                get
                {
                    return statusFieldSpecified;
                }
                set
                {
                    statusFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com.persus/")]
        public partial class wsLoginResult
        {

            private System.DateTime deadlineField;

            private bool deadlineFieldSpecified;

            private int errorCodeField;

            private bool errorCodeFieldSpecified;

            private string errorMsgField;

            private string tokenField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public System.DateTime deadline
            {
                get
                {
                    return deadlineField;
                }
                set
                {
                    deadlineField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool deadlineSpecified
            {
                get
                {
                    return deadlineFieldSpecified;
                }
                set
                {
                    deadlineFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int errorCode
            {
                get
                {
                    return errorCodeField;
                }
                set
                {
                    errorCodeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool errorCodeSpecified
            {
                get
                {
                    return errorCodeFieldSpecified;
                }
                set
                {
                    errorCodeFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string errorMsg
            {
                get
                {
                    return errorMsgField;
                }
                set
                {
                    errorMsgField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string token
            {
                get
                {
                    return tokenField;
                }
                set
                {
                    tokenField = value;
                }
            }
        }
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com.persus/")]
        public partial class wsPerson
        {

            private string adiField;

            private string akademikUnvanField;

            private string asaletDurumuField;

            private System.DateTime asaletTarihiField;

            private bool asaletTarihiFieldSpecified;

            private string cinsiyetiField;

            private string gorevUnvanField;

            private string kadroUnvanField;

            private string kurumSicilnoField;

            private string soyadiField;

            private string tckimliknoField;

            private wsTelefon[] telefonField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string adi
            {
                get
                {
                    return adiField;
                }
                set
                {
                    adiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string akademikUnvan
            {
                get
                {
                    return akademikUnvanField;
                }
                set
                {
                    akademikUnvanField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string asaletDurumu
            {
                get
                {
                    return asaletDurumuField;
                }
                set
                {
                    asaletDurumuField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public System.DateTime asaletTarihi
            {
                get
                {
                    return asaletTarihiField;
                }
                set
                {
                    asaletTarihiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool asaletTarihiSpecified
            {
                get
                {
                    return asaletTarihiFieldSpecified;
                }
                set
                {
                    asaletTarihiFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string cinsiyeti
            {
                get
                {
                    return cinsiyetiField;
                }
                set
                {
                    cinsiyetiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string gorevUnvan
            {
                get
                {
                    return gorevUnvanField;
                }
                set
                {
                    gorevUnvanField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kadroUnvan
            {
                get
                {
                    return kadroUnvanField;
                }
                set
                {
                    kadroUnvanField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string kurumSicilno
            {
                get
                {
                    return kurumSicilnoField;
                }
                set
                {
                    kurumSicilnoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string soyadi
            {
                get
                {
                    return soyadiField;
                }
                set
                {
                    soyadiField = value;
                }
            }
            [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
            [System.SerializableAttribute()]
            [System.Diagnostics.DebuggerStepThroughAttribute()]
            [System.ComponentModel.DesignerCategoryAttribute("code")]
            [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com.persus/")]
            public partial class wsTelefon
            {

                private string dahiliField;

                private string iletisimField;

                private string ilkodField;

                private string telefonField;

                private string turField;

                private string ulkekodField;

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
                public string dahili
                {
                    get
                    {
                        return dahiliField;
                    }
                    set
                    {
                        dahiliField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
                public string iletisim
                {
                    get
                    {
                        return iletisimField;
                    }
                    set
                    {
                        iletisimField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
                public string ilkod
                {
                    get
                    {
                        return ilkodField;
                    }
                    set
                    {
                        ilkodField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
                public string telefon
                {
                    get
                    {
                        return telefonField;
                    }
                    set
                    {
                        telefonField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
                public string tur
                {
                    get
                    {
                        return turField;
                    }
                    set
                    {
                        turField = value;
                    }
                }

                /// <remarks/>
                [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
                public string ulkekod
                {
                    get
                    {
                        return ulkekodField;
                    }
                    set
                    {
                        ulkekodField = value;
                    }
                }
            }
            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tckimlikno
            {
                get
                {
                    return tckimliknoField;
                }
                set
                {
                    tckimliknoField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("telefon", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public wsTelefon[] telefon
            {
                get
                {
                    return telefonField;
                }
                set
                {
                    telefonField = value;
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com.persus/")]
        public partial class wsPersonResult
        {

            private wsPerson[] detailField;

            private int errorCodeField;

            private bool errorCodeFieldSpecified;

            private string errorMsgField;

            private int statusField;

            private bool statusFieldSpecified;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("detail", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public wsPerson[] detail
            {
                get
                {
                    return detailField;
                }
                set
                {
                    detailField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int errorCode
            {
                get
                {
                    return errorCodeField;
                }
                set
                {
                    errorCodeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool errorCodeSpecified
            {
                get
                {
                    return errorCodeFieldSpecified;
                }
                set
                {
                    errorCodeFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string errorMsg
            {
                get
                {
                    return errorMsgField;
                }
                set
                {
                    errorMsgField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int status
            {
                get
                {
                    return statusField;
                }
                set
                {
                    statusField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool statusSpecified
            {
                get
                {
                    return statusFieldSpecified;
                }
                set
                {
                    statusFieldSpecified = value;
                }
            }
        }

        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com.persus/")]
        public partial class wsWorkPlanResult
        {

            private wsWorkPlan[] detailField;

            private int errorCodeField;

            private bool errorCodeFieldSpecified;

            private string errorMsgField;

            private int statusField;

            private bool statusFieldSpecified;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("detail", Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = true)]
            public wsWorkPlan[] detail
            {
                get
                {
                    return detailField;
                }
                set
                {
                    detailField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int errorCode
            {
                get
                {
                    return errorCodeField;
                }
                set
                {
                    errorCodeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool errorCodeSpecified
            {
                get
                {
                    return errorCodeFieldSpecified;
                }
                set
                {
                    errorCodeFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string errorMsg
            {
                get
                {
                    return errorMsgField;
                }
                set
                {
                    errorMsgField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public int status
            {
                get
                {
                    return statusField;
                }
                set
                {
                    statusField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool statusSpecified
            {
                get
                {
                    return statusFieldSpecified;
                }
                set
                {
                    statusFieldSpecified = value;
                }
            }
        }

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.6.1590.0")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://xxxxxx.com.persus/")]
        public partial class wsWorkPlan
        {

            private string baslangicSaatField;

            private string birimField;

            private string bitisSaatField;

            private string onaylandiField;

            private System.DateTime tarihField;

            private bool tarihFieldSpecified;

            private string turField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string baslangicSaat
            {
                get
                {
                    return baslangicSaatField;
                }
                set
                {
                    baslangicSaatField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string birim
            {
                get
                {
                    return birimField;
                }
                set
                {
                    birimField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string bitisSaat
            {
                get
                {
                    return bitisSaatField;
                }
                set
                {
                    bitisSaatField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string onaylandi
            {
                get
                {
                    return onaylandiField;
                }
                set
                {
                    onaylandiField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public System.DateTime tarih
            {
                get
                {
                    return tarihField;
                }
                set
                {
                    tarihField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlIgnoreAttribute()]
            public bool tarihSpecified
            {
                get
                {
                    return tarihFieldSpecified;
                }
                set
                {
                    tarihFieldSpecified = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
            public string tur
            {
                get
                {
                    return turField;
                }
                set
                {
                    turField = value;
                }
            }
        }
    }

}