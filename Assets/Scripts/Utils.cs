using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class Utils
{
    private static string resourcePath = "Utils/";
    public static string ConvertToKMB(int num)
    {
        if (num > 999999999 || num < -999999999)
        {
            return num.ToString("0,,,.#B", CultureInfo.InvariantCulture);
        }
        else
            if (num > 999999 || num < -999999)
        {
            return num.ToString("0,,.#M", CultureInfo.InvariantCulture);
        }
        else
            if (num > 9999 || num < -9999)
        {
            return num.ToString("0,.#K", CultureInfo.InvariantCulture);
        }
        else
        {
            return num.ToString(CultureInfo.InvariantCulture);
        }
    }

    public static CurrencyIcon GetCurrencyIcon()
    {
        string path = resourcePath + "CurrencyIcon";
        return Resources.Load<CurrencyIcon>(path);
    }


}
