using System.Runtime.InteropServices;

namespace k8s_tools;

public static class OsHelper
{
    public static bool IsWindows() => RuntimeInformation.IsOSPlatform(OSPlatform.Windows);

    public static bool IsMacOS() => RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

    public static bool IsLinux() => RuntimeInformation.IsOSPlatform(OSPlatform.Linux);

    public static string FileSeperator
    {
        get
        {
            if (OperatingSystem.IsWindows()) return "\\";
            if (OperatingSystem.IsMacOS()) return "/";
            if (OperatingSystem.IsLinux()) return "/";
            return "\\";
        }
    }
}
