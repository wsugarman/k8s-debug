// Copyright © William Sugarman.
// Licensed under the MIT License.

using Microsoft.Extensions.Logging;

namespace Kubernetes.Web.Mystery;

internal static partial class Logging
{
    [LoggerMessage(1, LogLevel.Error, "Cannot find environment variable {VariableName}")]
    public static partial void MissingVariable(this ILogger logger, string variableName);
}
