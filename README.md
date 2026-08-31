[![](https://img.shields.io/nuget/v/soenneker.cohere.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cohere.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cohere.openapiclient/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.cohere.openapiclient/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.cohere.openapiclient.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.cohere.openapiclient/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.cohere.openapiclient/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.cohere.openapiclient/actions/workflows/codeql.yml)

# Soenneker.Cohere.OpenApiClient

A Kiota-generated .NET client exposing Cohere's typed chat, embedding, reranking, generation, and model-management APIs.

## Installation

```bash
dotnet add package Soenneker.Cohere.OpenApiClient
```

## Recommended setup

Most applications should use `Soenneker.Cohere.OpenApiClientUtil`, which configures bearer authentication, base URL, reuse, and dependency injection:

```csharp
using Soenneker.Cohere.OpenApiClientUtil.Registrars;

services.AddCohereOpenApiClientUtilAsSingleton();
```

Resolve `ICohereOpenApiClientUtil` and call `Get` to obtain `CohereOpenApiClient`.

## Direct construction

Use this package directly when the application already owns its Kiota authentication and HTTP pipeline:

```csharp
using Microsoft.Kiota.Abstractions.Authentication;
using Microsoft.Kiota.Http.HttpClientLibrary;
using Soenneker.Cohere.OpenApiClient;
using System.Net.Http.Headers;

var httpClient = new HttpClient
{
    BaseAddress = new Uri("https://api.cohere.com")
};

httpClient.DefaultRequestHeaders.Authorization =
    new AuthenticationHeaderValue("Bearer", apiKey);

var adapter = new HttpClientRequestAdapter(
    new AnonymousAuthenticationProvider(),
    httpClient: httpClient)
{
    BaseUrl = httpClient.BaseAddress.ToString().TrimEnd('/')
};

var client = new CohereOpenApiClient(adapter);
```

The root exposes `V1` and `V2` request builders. For example, `client.V2.Chat`, `client.V2.Embed`, and `client.V2.Rerank` accept their corresponding generated request models.

Generated request and response types mirror Cohere's schema. Nullable return values represent endpoints that may return no body, and API failures follow Kiota's generated exception behavior. Pass cancellation tokens to network operations and validate model-specific inputs before sending prompts, documents, or other potentially sensitive content.

## Generated-code boundary

Prefer generated request builders and model properties over manually assembled URLs or JSON. Do not hand-edit generated source files; place retries, application policy, output validation, and data-handling controls around the client.
