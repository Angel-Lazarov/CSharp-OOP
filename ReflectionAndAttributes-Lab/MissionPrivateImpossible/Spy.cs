﻿using System.Reflection;
using System.Text;

namespace Stealer;

public class Spy
{
    public string AnalyzeAccessModifiers(string investigatedClass)
    {

        Type classType = Type.GetType(investigatedClass);

        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public);

        MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.Public);

        MethodInfo[] classNonPublicMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        foreach (var field in classFields)
        {
            sb.AppendLine($"{field.Name} must be private!");
        }

        foreach (var method in classNonPublicMethods.Where(m => m.Name.StartsWith("get")))
        {
            sb.AppendLine($"{method.Name} have to be public!");
        }

        foreach (var method in classPublicMethods.Where(m => m.Name.StartsWith("set")))
        {
            sb.AppendLine($"{method.Name} have to be private!");

        }


        return sb.ToString().Trim();

    }

    public string StealFieldInfo(string investigatedClass, params string[] fieldsToInvestigate)
    {
        Type classType = Type.GetType(investigatedClass);

        //  FieldInfo[] privateFields = classType.GetFields((BindingFlags)60);

        FieldInfo[] classFields = classType.GetFields(BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();

        Object classInstance = Activator.CreateInstance(classType, new object[] { });


        sb.AppendLine($"Class under investigation: {investigatedClass}");

        foreach (var field in classFields.Where(f => fieldsToInvestigate.Contains(f.Name)))
        {
            sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
        }

        return sb.ToString().Trim();
    }

    public string RevealPrivateMethods(string investigatedClass) 
    {
        Type classType = Type.GetType(investigatedClass);

        var classPrivateMethods = classType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);

        StringBuilder sb = new StringBuilder();  
        sb.AppendLine($"All Private Methods of Class: {classType.FullName}");
        sb.AppendLine($"Base Class: {classType.BaseType.Name}");

        foreach (var method in classPrivateMethods)
        {
           sb.AppendLine(method.Name);
        }

        return sb.ToString().Trim();

    }

}
