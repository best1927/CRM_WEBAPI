﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for SysDataTablePager
/// </summary>
public class SysDataTablePager
{
    public string sEcho { get; set; }
    public int iTotalRecords { get; set; }
    public int iTotalDisplayRecords { get; set; }
    public List<object> aaData { get; set; }
}