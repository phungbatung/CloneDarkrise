using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class Utils
{
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
            if (num > 999 || num < -999)
        {
            return num.ToString("0,.#K", CultureInfo.InvariantCulture);
        }
        else
        {
            return num.ToString(CultureInfo.InvariantCulture);
        }
    }
}
