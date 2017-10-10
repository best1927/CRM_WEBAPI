using System;
using System.Globalization;

public class General
{
    public static int CurrentThaiYear
    {
        get { return CurrentCulture.Calendar.GetYear(DateTime.Now); }
    }

    public static string TodayAsString
    {
        get
        {
            return CurrentCulture.Calendar.GetYear(DateTime.Now) + DateTime.Now.Month.ToString("00") +
                   DateTime.Now.Day.ToString("00");
        }
    }

    public static CultureInfo CurrentCulture
    {
        get { return new CultureInfo("th-TH"); }
    }
}