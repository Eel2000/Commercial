using System.Reflection;

namespace Commercial.Application.Extensions;

public static class AssemblyExtension
{
    public static Assembly GetApplicationLibrayAssembly() => Assembly.GetExecutingAssembly();
}