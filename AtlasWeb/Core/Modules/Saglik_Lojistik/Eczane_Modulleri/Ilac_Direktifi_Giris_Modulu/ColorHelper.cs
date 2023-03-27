using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TTObjectClasses;

namespace Core.Modules.Saglik_Lojistik.Eczane_Modulleri.Ilac_Direktifi_Giris_Modulu
{
    public class ColorHelper
    {
        public static string GetFontColor(ColorEnum? color)
        {
            if (color != null)
            {
                if (ColorEnum.Black == color.Value)
                {
                    return "black";
                }
                else if (ColorEnum.Blue == color.Value)
                {
                    return "blue";

                }
                else if (ColorEnum.Brown == color.Value)
                {
                    return "brown";

                }
                else if (ColorEnum.Green == color.Value)
                {
                    return "green";

                }
                else if (ColorEnum.Hazel == color.Value)
                {
                    return "#eedc82";

                }
                else if (ColorEnum.Red == color.Value)
                {
                    return "red";

                }
                else if (ColorEnum.White == color.Value)
                {
                    // Font Color Beyaz olamaz olarak yazıldı kod. Tanım ekranı düzenlendiğinde bu kısım kod da düzenlenmeli
                    return "Black";

                }
                else
                {
                    return "Black";

                }
            }
            else

                return "black";
        }
    }
}
