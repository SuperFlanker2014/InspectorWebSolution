using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Scaffolding.Internal;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace InspectorWeb.Classes
{
    //public class MyEFDesignTimeServices : IDesignTimeServices
    //{
    //    public void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
    //    {
    //        serviceCollection.AddSingleton<ICandidateNamingService, CustomCandidateNamingService>();
    //    }
    //}

    public class CustomCandidateNamingService : CandidateNamingService
    {
        public override string GetDependentEndCandidateNavigationPropertyName(IForeignKey foreignKey)
        {
            try
            {
                Console.WriteLine(foreignKey.PrincipalToDependent);
                Console.WriteLine(foreignKey.DependentToPrincipal);



                var n = foreignKey.PrincipalToDependent.GetFieldName();
                if (n.EndsWith("Gu"))
                {
                    return n.Substring(0, n.Length - 2);
                }

                //string newName = foreignKey.GetDefaultName().Replace("FK_", "")
                //                           .Replace(foreignKey.DeclaringEntityType.Name + "_", "", StringComparison.OrdinalIgnoreCase);
                //return newName;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Generating GetDependentEndCandidateNavigationPropertyName: " + ex.Message);
            }

            return base.GetDependentEndCandidateNavigationPropertyName(foreignKey);
        }

        public override string GetPrincipalEndCandidateNavigationPropertyName(IForeignKey foreignKey, string dependentEndNavigationPropertyName)
        {
            try
            {
                var n = foreignKey.PrincipalToDependent.GetFieldName();
                if (n.EndsWith("Gu"))
                {
                    return n.Substring(0, n.Length - 2);
                }

                //string newName = foreignKey.GetDefaultName().Replace("FK_", "")
                //                           .Replace(foreignKey.DeclaringEntityType.Name + "_", "", StringComparison.OrdinalIgnoreCase);
                //return newName;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error in Generating GetPrincipalEndCandidateNavigationPropertyName: " + ex.Message);
            }
            return base.GetPrincipalEndCandidateNavigationPropertyName(foreignKey, dependentEndNavigationPropertyName);
        }
    }
}