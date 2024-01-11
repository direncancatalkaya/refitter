﻿using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace Refitter.Core;

/// <summary>
/// Provide settings for Refit generator.
/// </summary>
[ExcludeFromCodeCoverage]
public class RefitGeneratorSettings
{
    public const string DefaultOutputFolder = "./Generated";

    /// <summary>
    /// Gets or sets the path to the Open API.
    /// </summary>
    public string OpenApiPath { get; set; } = null!;

    /// <summary>
    /// Gets or sets the namespace for the generated code. (default: GeneratedCode)
    /// </summary>
    public string Namespace { get; set; } = "GeneratedCode";

    /// <summary>
    /// Gets or sets the naming settings.
    /// </summary>
    public NamingSettings Naming { get; set; } = new();

    /// <summary>
    /// Gets or sets a value indicating whether contracts should be generated.
    /// </summary>
    public bool GenerateContracts { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether XML doc comments should be generated.
    /// </summary>
    public bool GenerateXmlDocCodeComments { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether <c>ApiException</c> and <c>IApiResponse</c> should be documented with
    /// the relevant status codes specified in the OpenAPI document.
    /// </summary>
    public bool GenerateStatusCodeComments { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to add auto-generated header.
    /// </summary>
    public bool AddAutoGeneratedHeader { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to add accept headers [Headers("Accept: application/json")].
    /// </summary>
    public bool AddAcceptHeaders { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether to return <c>IApiResponse</c> objects.
    /// </summary>
    public bool ReturnIApiResponse { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether to generate operation headers.
    /// </summary>
    public bool GenerateOperationHeaders { get; set; } = true;

    /// <summary>
    /// Gets or sets the generated type accessibility. (default: Public)
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TypeAccessibility TypeAccessibility { get; set; } = TypeAccessibility.Public;

    /// <summary>
    /// Enable or disable the use of cancellation tokens.
    /// </summary>
    public bool UseCancellationTokens { get; set; }

    /// <summary>
    /// Set to <c>true</c> to explicitly format date query string parameters
    /// in ISO 8601 standard date format using delimiters (for example: 2023-06-15)
    /// </summary>
    public bool UseIsoDateFormat { get; set; }

    /// <summary>
    /// Add additional namespace to generated types
    /// </summary>
    public string[] AdditionalNamespaces { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Set to <c>true</c> to Generate a Refit interface for each endpoint
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public MultipleInterfaces MultipleInterfaces { get; set; }

    /// <summary>
    /// Set to <c>true</c> to Generate a Refit interface for each endpoint
    /// </summary>
    public string[] IncludePathMatches { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Set to <c>true</c> to Generate a Refit interface for each endpoint
    /// </summary>
    public string[] IncludeTags { get; set; } = Array.Empty<string>();

    /// <summary>
    /// Set to <c>true</c> to generate deprecated operations, otherwise <c>false</c>
    /// </summary>
    public bool GenerateDeprecatedOperations { get; set; } = true;

    /// <summary>
    /// Generate operation names using pattern. 
    /// When using <see cref="MultipleInterfaces"/> <see cref="Core.MultipleInterfaces.ByEndpoint"/>, this is name of the Execute() method in the interface.
    /// </summary>
    public string? OperationNameTemplate { get; set; }

    /// <summary>
    /// Set to <c>true</c> to re-order optional parameters to the end of the parameter list
    /// </summary>
    public bool OptionalParameters { get; set; }

    /// <summary>
    /// Gets or sets the relative path to a folder in which the output files are generated. (default: ./Generated)
    /// </summary>
    public string OutputFolder { get; set; } = DefaultOutputFolder;

    /// <summary>
    /// Gets or sets the filename of the generated code.
    /// For the CLI tool, the default is Output.cs
    /// For the Source Generator, this is the name of the generated class and the default is [.refitter defined naming OR .refitter filename].g.cs)
    /// </summary>
    public string? OutputFilename { get; set; }

    /// <summary>
    /// Gets or sets the settings describing how to register generated interface to the .NET Core DI container
    /// </summary>
    public DependencyInjectionSettings? DependencyInjectionSettings { get; set; }

    /// <summary>
    /// Gets or sets the settings describing how to generate types using NSwag
    /// </summary>
    public CodeGeneratorSettings? CodeGeneratorSettings { get; set; }
    
    /// <summary>
    /// Set to <c>true</c> to apply tree-shaking to the OpenApi schema.
    /// This works in conjunction with <see cref="IncludeTags"/> and <see cref="IncludePathMatches"/>.
    /// </summary>
    public bool TrimUnusedSchema { get; set; }
    
    /// <summary>
    /// Array of regular expressions that determine if a schema needs to be kept.
    /// This works in conjunction with <see cref="TrimUnusedSchema"/>.
    /// </summary>
    public string[] KeepSchemaPatterns { get; set; } = Array.Empty<string>();

    /// <summary>
    /// The NSwag IOperationNameGenerator implementation to use
    /// </summary>
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public OperationNameGeneratorTypes OperationNameGenerator { get; set; }

    /// <summary>
    /// Set to <c>false</c> to skip default additional properties. Default is <c>true</c>
    /// </summary>
    public bool GenerateDefaultAdditionalProperties { get; set; } = true;
}