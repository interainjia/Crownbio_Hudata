using System.Collections.Generic;
using System.Configuration;
using System.Linq;

public static class AppConfig
{
    public static string UserViewRight => ConfigurationManager.AppSettings["UserViewRight"] ?? "";
    public static string UserEditRight => ConfigurationManager.AppSettings["UserEditRight"] ?? "";

    // 甚至可以直接提供拆分好的列表
    public static List<string> UserViewRightList => UserViewRight.Split(';').Select(s => s.Trim()).ToList();
    public static List<string> UserEditRightList => UserEditRight.Split(';').Select(s => s.Trim()).ToList();
}