using System;
using System.Globalization;
using System.Linq;

public static class StringUtil
{
    public static string ToStringForDb(this DateTime date)
    {
        return date.ToString("yyyyMMdd", new CultureInfo("th-TH"));
    }

    public static string ToThaiString(this DateTime date)
    {
        return date.ToString("d MMM yy", new CultureInfo("th-TH"));
    }

    public static bool IsNullOrEmpty(this string val)
    {
        return string.IsNullOrEmpty(val);
    }
    public static string RemoveCharactor(this string val)
    {
        var chars = new[]
        {
            " บาท","ครั้ง/วัน",",",  ".0000", ".00",".", "/", "!", "@", "#", "$", "%", "^", "&", "*", "'", "\"", ";", "_", "-", "(", ")", ":", "|",
            "[", "]", "์", " ", "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p", "q", "r",
            "s", "t", "u", "v", "w", "x", "y", "z"
        };
        val = val.ToLower();

        return chars.Aggregate(val, (current, c) => current.Replace(c, ""));
    }
    public static string ValueOrDash(this string val)
    {
        return val.IsNullOrEmpty() ? "-" :val;
    }

    public static DateTime ToDateTime(this string val)
    {
        if (val.Substring(0, 4).ToInt32() > 2500)
            return DateTime.ParseExact(val, "yyyyMMdd", new CultureInfo("th-TH"));
        else
            return DateTime.ParseExact(val, "yyyyMMdd", new CultureInfo("en-US"));
    }

    public static string ToDateTimeString(this string val)
    {
        if (val.IsNullOrEmpty())
            return string.Empty;

        if (val.Trim().Length != 8)
            return string.Empty;

        return val.ToDateTime().ToString("d MMMM yyyy", new CultureInfo("th-TH"));
    }

    public static string ToDateTimeStringShort(this string val)
    {
        if (val.IsNullOrEmpty())
            return string.Empty;

        if (val.Trim().Length != 8)
            return string.Empty;

        return val.ToDateTime().ToString("d MMM yy", new CultureInfo("th-TH"));
    }

    public static string ToDateTimeStringFull(this string val)
    {
        if (val.IsNullOrEmpty())
            return string.Empty;

        if (val.Trim().Length != 8)
            return string.Empty;

        var dt = val.ToDateTime();
        var monthThai = dt.ToString("MMMM", new CultureInfo("th-TH"));
        var yearThai = dt.ToString("yyyy", new CultureInfo("th-TH"));

        return string.Format("วันที่ {0} เดือน{1} พ.ศ. {2}", dt.Day, monthThai, yearThai);
    }

    public static int ToInt32(this string val)
    {
        return Convert.ToInt32(val);
    }

    public static int ToInt32OrDefault(this string val)
    {
        try
        {
            return Convert.ToInt32(val.Replace(",","").Trim());
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public static int? ToInt32OrNull(this string val)
    {
        try
        {
            return Convert.ToInt32(val);
        }
        catch (Exception)
        {
            return null;
        }
    }

    public static decimal ToDecimal(this string val)
    {
        return Convert.ToDecimal(val);
    }

    public static decimal ToDecimalOrDefault(this string val)
    {
        try
        {
            return Convert.ToDecimal(val);
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public static long ToInt64(this string val)
    {
        return Convert.ToInt64(val);
    }

    public static long ToInt64OrDefault(this string val)
    {
        try
        {
            return Convert.ToInt64(val);
        }
        catch (Exception)
        {
            return 0;
        }
    }

    public static bool IsNumber(this string val)
    {
        try
        {
            var i = Convert.ToDecimal(val);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    public static string ToStringNoThousandSeparate(this int val)
    {
        return val + "";
    }

    public static string ToStringNoThousandSeparateOrDash(this int? val)
    {
        return val.HasValue ? val + "" :"-";
    }

    public static string ToStringOrDash(this int? val)
    {
        return val.HasValue ? string.Format("{0:#,0}", val) :"-";
    }

    public static string ToStringOrBlank(this int? val)
    {
        return val.HasValue ? string.Format("{0:#,0}", val) :"";
    }

    public static string ToStringNumberOrDash(this decimal? val)
    {
        return val.HasValue ? string.Format("{0:#,0}", val) :"-";
    }

    public static string ToStringCurrencyOrDash(this decimal? val)
    {
        return val.HasValue ? string.Format("{0:#,0.00}", val) :"-";
    }

    public static string ToStringOrDash(this string val)
    {
        return !val.IsNullOrEmpty() ? val :"-";
    }

    public static string ToStringOrDash(this int val)
    {
        return val != 0 ? val.ToString("#,0") :"-";
    }

    public static string ToStringNumber(this int val)
    {
        return val != 0 ? val.ToString("#,0") :"-";
    }

    public static string ToStringNumber(this decimal val)
    {
        return val.ToString("#,0");
    }

    public static string ToStringNumberOrDash(this decimal val)
    {
        return val != 0 ? val.ToString("#,0") :"-";
    }

    public static string ToStringCurrency(this decimal val)
    {
        return val.ToString("#,0.00");
    }

    public static string ToStringCurrencyOrDash(this decimal val)
    {
        return val != 0 ? val.ToString("#,0.00") :"-";
    }

    public static string ToStringShort(this DateTime val)
    {
        return string.Format(General.CurrentCulture, "{0:dd/MM/yy}", val);
    }

    public static string ToStringNormal(this DateTime val)
    {
        return string.Format(General.CurrentCulture, "{0:d MMM yy}", val);
    }

    public static string ToStringLong(this DateTime val)
    {
        return string.Format(General.CurrentCulture, "{0:d MMMM yyyyy}", val);
    }

    public static DateTime ToDateTime(string date, string time)
    {
        const string dateFormat = "d/M/yyyy HH:mm";
        return DateTime.ParseExact(string.Format("{0} {1}", date.Trim(), time.Trim()), dateFormat, General.CurrentCulture);
    }

    public static DateTime? ToDateTimeOrDefault(string date, string time)
    {
        try
        {
            const string dateFormat = "d/M/yyyy HH:mm";
            return DateTime.ParseExact(string.Format("{0} {1}", date.Trim(), time.Trim()), dateFormat, General.CurrentCulture);
        }
        catch (Exception)
        {
            return null;
        }
    }
}