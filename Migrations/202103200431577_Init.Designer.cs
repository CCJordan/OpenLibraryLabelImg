﻿// <auto-generated />
namespace OpenLibraryLabelImg.Migrations
{
    using System.CodeDom.Compiler;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Migrations.Infrastructure;
    using System.Resources;
    
    [GeneratedCode("EntityFramework.Migrations", "6.4.4")]
    public sealed partial class Init : IMigrationMetadata
    {
        private readonly ResourceManager Resources = new ResourceManager(typeof(Init));
        
        string IMigrationMetadata.Id
        {
            get { return "202103200431577_Init"; }
        }
        
        string IMigrationMetadata.Source
        {
            get { return null; }
        }
        
        string IMigrationMetadata.Target
        {
            get { return @"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"; }
        }
    }
}
