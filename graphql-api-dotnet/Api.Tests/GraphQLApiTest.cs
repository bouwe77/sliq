// using System.Text.RegularExpressions;
// using System.Text;
// using System.Net.Http;
// using System;
// using System.Threading.Tasks;
// using Xunit;
// using Xunit.Sdk;
// using Microsoft.AspNetCore.TestHost;
// using Microsoft.AspNetCore.Hosting;
// using Newtonsoft.Json;

// namespace Api.Tests
// {
//     public class GraphQLApiTest : IDisposable
//     {
//         private readonly TestServer _server;
//         private readonly HttpClient _client;

//         public GraphQLApiTest()
//         {
//             // Arrange
//             _server = new TestServer(new WebHostBuilder().UseStartup<Startup>());
//             _client = _server.CreateClient();
//         }

//         public void Dispose()
//         {
//             _server.Dispose();
//         }

//         [Fact]
//         public async Task GetPresentationById()
//         {
//             // Arrange
//             var query = "{ presentation(id:\\\"1\\\") { name } }";
//             var definition = new { data = new { presentation = new { name = "" } } };

//             // Act
//             var responseText = await ExecuteGraphQLQuery(query);

//             // Assert
//             var anonymous = JsonConvert.DeserializeAnonymousType(responseText, definition);
//             Assert.Equal("Presentation 1", anonymous.data.presentation.name);
//         }

//         [Fact]
//         public async Task GetPresentations()
//         {
//             // Arrange
//             var query = "{ presentations() { name } }";
//             var definition = new { data = new { presentations = new[] { new { name = "" } } } };

//             // Act
//             var responseText = await ExecuteGraphQLQuery(query);

//             // Assert
//             var anonymous = JsonConvert.DeserializeAnonymousType(responseText, definition);
//             Assert.Equal("Presentation 1", anonymous.data.presentations[0].name);
//         }

//         private async Task<string> ExecuteGraphQLQuery(string query)
//         {
//             if (string.IsNullOrWhiteSpace(query))
//             {
//                 throw new Exception("Please provide a query");
//             }

//             // Remove whitespaces from query to prevent 400 Bad Request responses.
//             query = Regex.Replace(query, @"\s+", string.Empty);

//             // Sending a query to a GraphQL API means an HTTP POST with a JSON body containing the query:
//             var requestBody = new StringContent($"{{\"query\": \"{query}\"}}", Encoding.UTF8, "application/json");

//             // Act
//             var response = await _client.PostAsync("/graphql", requestBody);

//             // Assert
//             var responseString = await response.Content.ReadAsStringAsync();

//             if (!response.IsSuccessStatusCode)
//             {
//                 Console.WriteLine(responseString);
//                 Console.WriteLine("STATUS CODE: " + response.StatusCode);
//                 throw new XunitException("GraphQL request should return a 200 OK status code, but it didn't");
//             }

//             return responseString;
//         }
//     }
// }
